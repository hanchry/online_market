

using Algorithm.Model;
using Microsoft.EntityFrameworkCore;

namespace Database.Persistance
{
    public class AlbionMarketContext:DbContext
    {
        public AlbionMarketContext(DbContextOptions<AlbionMarketContext> options) : base(options)
        {
            
        }
        
       public DbSet<City> Cities { get; set; }
       public DbSet<ItemId> Ids { get; set; }
    }
}