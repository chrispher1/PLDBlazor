using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Business.DTO
{
    public class UserResponseDTO
    {
        public string Token { get; set; }
        public UserDTO User { get; set; }
    }
}
