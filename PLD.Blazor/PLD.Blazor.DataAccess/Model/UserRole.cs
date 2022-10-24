using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.DataAccess.Model
{
    [Table("DMT_USER_ROLE")]
    public class UserRole
    {       
        [Required]
        [Column("Crt_Dt")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [Column("Crt_By")]
        [MaxLength(100)]
        public string CreatedBy { get; set; }

        [Column("Mod_Dt")]
        public DateTime? ModifiedDate { get; set; }

        [Column("Mod_By")]
        [MaxLength(100)]
        public string? ModifiedBy { get; set; }

        [Column("User_Id")]
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Column("Role_Id")]
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
