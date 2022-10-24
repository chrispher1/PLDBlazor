using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Business.DTO
{
    public class UserForRegisterDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]       
        public string Password { get; set; }
        
        [Compare("Password",ErrorMessage ="Entered password does not match with the confirmed password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public DateTime CreatedDate { get; set; }
               
        public string CreatedBy { get; set; }
        public ICollection<UserRoleDTO>? UserRoles { get; set; }

    }
}
