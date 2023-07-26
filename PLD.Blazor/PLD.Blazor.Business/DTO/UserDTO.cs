using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Business.DTO
{
    public class UserDTO
    {   
        public UserDTO()
        {
            UserRoles = new List<UserRoleDTO>();
            UserName = String.Empty;
            FirstName = String.Empty;
            LastName = String.Empty;
            CreatedBy = String.Empty;
        }
        public int Id { get; set; }


        // don't make PasswordHash and PasswordSalt required
        public byte[]? PasswordHash { get; set; }

        public byte[]? PasswordSalt { get; set; }
                        
        public DateTime? ModifiedDate { get; set; }
        
        public string? ModifiedBy { get; set; }
        
        public DateTime? LastLoginDate { get; set; }

        [Required]
        public string UserName { get; set; }        

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime? BirthDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }
        public ICollection<UserRoleDTO>? UserRoles { get; set; }
    }
}
