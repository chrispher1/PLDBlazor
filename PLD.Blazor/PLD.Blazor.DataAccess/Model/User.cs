using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.DataAccess.Model
{
    [Table("DMT_USER")]
    public class User
    {
        [Key]
        [Column("User_Id")]
        public int Id { get; set; }

        [Column("User_Name")]
        public string UserName { get; set; }
        
        [Column("Password_Hash")]
        public byte[] PasswordHash { get; set; }

        [Column("Password_Salt")]
        public byte[] PasswordSalt { get; set; }

        [Column("First_Name")]
        public string FirstName { get; set; }
        
        [Column("Last_Name")]
        public string LastName { get; set; }

        [Column("Birth_Date")]
        [Required]
        public DateTime BirthDate { get; set; }

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

        [Column("Last_Login_Dt")]
        public DateTime? LastLoginDate { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
