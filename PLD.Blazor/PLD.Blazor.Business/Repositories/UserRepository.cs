using PLD.Blazor.Business.DTO;
using PLD.Blazor.Business.IRepositories;
using PLD.Blazor.DataAccess;
using PLD.Blazor.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace PLD.Blazor.Business.Repositories
{
    public sealed class UserRepository : GenericRepository<User>, IUserRepository<User, UserForRegisterDTO>
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public UserRepository(ApplicationDBContext applicationDBContext) : base(applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }

        public async Task<User> Register(UserForRegisterDTO entity)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            User user = new User();

            CreatePasswordHash(entity.Password, out passwordHash, out passwordSalt);
            user.UserName = entity.UserName;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.BirthDate = entity.BirthDate;
            user.FirstName = entity.FirstName;
            user.LastName = entity.LastName;
            user.CreatedBy = entity.CreatedBy;
            user.CreatedDate = entity.CreatedDate;

            var userRoleList = new List<UserRole>();
            foreach(var userRoleDTO in entity.UserRoles)
            {
                var userRole = new UserRole();
                userRole.CreatedDate = userRoleDTO.CreatedDate;
                userRole.CreatedBy = userRoleDTO.CreatedBy;
                //userRole.UserId = userRoleDTO.UserId;
                userRole.RoleId = userRoleDTO.RoleId;
                userRoleList.Add(userRole);
            }

            user.UserRoles = userRoleList;
            await _applicationDBContext.User.AddAsync(user);
            await _applicationDBContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> LogIn(string userName, string password)
        {
            var user = await _applicationDBContext.User.Include(role => role.UserRoles).Where(u => u.UserName == userName).FirstOrDefaultAsync();

            if (user == null)
                return null;

            if (!PasswordMatch(password, user.PasswordHash, user.PasswordSalt))
                return null;

            user.ModifiedBy = user.CreatedBy;
            user.ModifiedDate = DateTime.Now;
            user.LastLoginDate = DateTime.Now;
            await _applicationDBContext.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool PasswordMatch(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                    if (computedHash[i] != passwordHash[i])
                        return false;
            }
            return true;
        }
        public async Task<bool> UserExists(string userName)
        {            
            if (await _applicationDBContext.User.AnyAsync(u => u.UserName == userName))
                return true;

            return false;
        }

        public void Update(User entity)
        {
            var record = _applicationDBContext.User.Where(obj => obj.Id == entity.Id).Include(prop => prop.UserRoles).Single();
            record.UserName = entity.UserName;
            record.PasswordHash = entity.PasswordHash;
            record.PasswordSalt = entity.PasswordSalt;
            record.FirstName = entity.FirstName;
            record.LastName = entity.LastName;
            record.BirthDate = entity.BirthDate;
            record.ModifiedBy = entity.ModifiedBy;
            record.ModifiedDate = entity.ModifiedDate;

            // Clear the userRoles
            record.UserRoles.Clear();

            var userRoleList = new List<UserRole>();
            foreach (var userRoleDTO in entity.UserRoles)
            {
                // Add the new userRoles
                var userRole = new UserRole();
                userRole.CreatedDate = userRoleDTO.CreatedDate;
                userRole.CreatedBy = userRoleDTO.CreatedBy;
                //userRole.UserId = userRoleDTO.UserId;
                userRole.RoleId = userRoleDTO.RoleId;
                userRoleList.Add(userRole);
            }
            record.UserRoles = userRoleList;
        }
    }
}
