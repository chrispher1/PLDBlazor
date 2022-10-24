using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Business.DTO
{
    public class UserRoleDTO
    {        
        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }
                
        public string? ModifiedBy { get; set; }
                
        public int UserId { get; set; }
        //public UserDTO? User { get; set; }
        public int RoleId { get; set; }
        //public RoleDTO? Role { get; set; }
    }
}
