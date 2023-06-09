using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLD.Blazor.Common
{
    public class PaginationHeader
    {        
        public int TotalItems { get; set; }        
        public PaginationHeader(int totalItems)
        {            
            this.TotalItems = totalItems;
        }
    }
}
