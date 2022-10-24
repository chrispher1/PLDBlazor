using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Business.DTO
{
    public class RoleDTO
    {   
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }
                
        public string CreatedBy { get; set; }
                
        public DateTime? ModifiedDate { get; set; }
                
        public string? ModifiedBy { get; set; }

        public bool IsSelected { get; set; }
        public ICollection<UserRoleDTO>? UserRoles { get; set; }
    }
}
