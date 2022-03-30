using Microsoft.EntityFrameworkCore;
using PLD.Blazor.DataAccess.Model;

namespace PLD.Blazor.DataAccess
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {           
        }
        public DbSet<Carrier> Carrier { get; set; }


    }
}