using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PLD.Blazor.Business.DTO;
using PLD.Blazor.Business.IRepositories;
using PLD.Blazor.Common;
using PLD.Blazor.DataAccess.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PLD.Blazor.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // code for Authorization using Policy
    [Authorize(Policy = ConstantClass.MaintenanceRolePolicy)]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly APISettings _aPISettings;
        private readonly IConfiguration _configuration;
        public UserController(IUnitOfWork unitOfWork, IMapper mapper, IOptions<APISettings> option,
            IConfiguration configuration)
            
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _aPISettings = option.Value;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDTO userForRegisterDTO)
        {   
            try
            {               

                if (await _unitOfWork.User.UserExists(userForRegisterDTO.UserName.ToLower()))
                {
                    return BadRequest(
                            new ErrorModelDTO()
                            {
                                StatusCode = StatusCodes.Status400BadRequest,
                                ErrorMessage = "UserName already exists."
                            }
                        );
                }

                var user = await _unitOfWork.User.Register(userForRegisterDTO);
                return Ok(new UserResponseDTO
                {
                    Token = await GenerateToken(user),
                    User  = _mapper.Map<User,UserDTO>(user)
                });

            }
            catch (Exception ex)
            {
                return BadRequest(
                            new ErrorModelDTO()
                            {
                                StatusCode = StatusCodes.Status400BadRequest,
                                ErrorMessage = ex.InnerException.Message.Substring(0, ex.InnerException.Message.Length - 1)
                            }
                        );
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserDTO user)
        {
            try
            {   
                
                if (await _unitOfWork.User.UserExists(user.UserName.ToLower()))
                {
                    return BadRequest(
                            new ErrorModelDTO()
                            {
                                StatusCode = StatusCodes.Status400BadRequest,
                                ErrorMessage = "UserName already exists."
                            }
                        );
                }
                var userForRegisterDTO = _mapper.Map<UserDTO, UserForRegisterDTO>(user);
                var userObject = await _unitOfWork.User.Register(userForRegisterDTO);
                return Ok();                
            }
            catch (Exception ex)
            {
                return BadRequest(
                            new ErrorModelDTO()
                            {
                                StatusCode = StatusCodes.Status400BadRequest,
                                ErrorMessage = ex.InnerException.Message.Substring(0, ex.InnerException.Message.Length - 1)
                            }
                        );
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(UserDTO user)
        {
            try
            {
                var userObject = _mapper.Map<UserDTO, User>(user);
                var record = await _unitOfWork.User.Get(obj => obj.Id == user.Id);
                if (record != null)
                {
                    _unitOfWork.User.Update(userObject);
                    await _unitOfWork.Save();
                    return Ok();
                }
                else
                {
                    return BadRequest(
                            new ErrorModelDTO()
                            {
                                StatusCode = StatusCodes.Status400BadRequest,
                                ErrorMessage = ConstantClass.NoRecordFound
                            }
                           );
                }
            }
            catch (Exception ex)
            {
                return BadRequest(
                            new ErrorModelDTO()
                            {
                                StatusCode = StatusCodes.Status400BadRequest,
                                ErrorMessage = ex.InnerException.Message.Substring(0, ex.InnerException.Message.Length - 1)
                            }
                       );
            }
        }

        [AllowAnonymous]
        [HttpGet("login")]
        public async Task<IActionResult> Login([FromQuery] UserForLoginDTO userForLoginDTO)
        {
            try
            {
                // retrieve the section on appSettings.json file
                IConfigurationSection sectionAPISettings2 = _configuration.GetSection("APISettings2");
                
                // retrieve the value of a property of a section
                string d = sectionAPISettings2.GetValue<string>("ValidAudience23");
                
                // binding the configuration values to an instance of an object
                APISettings objectAPISettings = new APISettings();
                _configuration.GetSection("APISettings").Bind(objectAPISettings);


                APISettings APISettings2 = _configuration.GetSection("APISettings2").Get<APISettings>();

                //sectionLogging.bi

                var user = await _unitOfWork.User.LogIn(userForLoginDTO.UserName.ToLower(), userForLoginDTO.Password);

                if (user == null)
                {
                    return BadRequest(
                            new ErrorModelDTO()
                            {
                                StatusCode = StatusCodes.Status404NotFound,
                                ErrorMessage = ConstantClass.NoRecordFound
                            }
                        );
                }

                return Ok(new UserResponseDTO
                {
                    Token = await GenerateToken(user),
                    User = _mapper.Map<User, UserDTO>(user)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(
                            new ErrorModelDTO()
                            {
                                StatusCode = StatusCodes.Status400BadRequest,
                                ErrorMessage = ex.InnerException.Message.Substring(0, ex.InnerException.Message.Length - 1)
                            }
                        );
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(await _unitOfWork.User.GetAll(includeProperties: "UserRoles"));
            return Ok(list);
        }

        [Route("{id:int}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var record = _mapper.Map<User, UserDTO>(await _unitOfWork.User.Get(obj => obj.Id == id, includeProperties: "UserRoles"));

                if (record == null)
                {
                    return NotFound();
                }
                return Ok(record);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [Route("GetByUserName/{userName}")]
        [HttpGet]
        public async Task<IActionResult> Get(string userName)
        {
            try
            {
                var record = _mapper.Map<User, UserDTO>(await _unitOfWork.User.Get(obj => obj.UserName == userName, includeProperties: "UserRoles"));

                if (record != null)
                {
                    return Ok(record);
                }

                return NotFound(
                        new ErrorModelDTO()
                        {
                            StatusCode = StatusCodes.Status404NotFound,
                            ErrorMessage = ConstantClass.NoRecordFound
                        }
                       );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetByUserNameAndNotID/{userName}/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(string userName, int id)
        {
            try
            {
                var record = _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(await _unitOfWork.User.GetAll(obj => obj.Id != id && obj.UserName == userName, includeProperties: "UserRoles"));
                return Ok(record);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private async Task<string> GenerateToken(User user)
        {
            var claims = new List<Claim>
            {   
                new Claim( ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("WorkPlace", "Seven Seven Global")
            };

            List<Role> roles = new List<Role>();

            foreach(var userRole in user.UserRoles)
            {
                var role = await _unitOfWork.Role.Get(r => r.Id == userRole.RoleId);

                if (role !=null)
                roles.Add(role);
            }


            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_aPISettings.SecretKey));
            
            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(claims),
            //    SigningCredentials = credential,
            //    Expires = DateTime.Now.AddDays(1),
            //    Audience = _aPISettings.ValidAudience,
            //    Issuer  = _aPISettings.ValidIssuer
            //};

            //var tokenHandler = new JwtSecurityTokenHandler();

            //var token = tokenHandler.CreateToken(tokenDescriptor);

            //return tokenHandler.WriteToken(token);

            var tokenOptions = new JwtSecurityToken(
                    issuer: _aPISettings.ValidIssuer,
                    audience: _aPISettings.ValidAudience,
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: credential
                   
                    );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return token;
        }
    }
}
