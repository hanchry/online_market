using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algorithm.Model;
using Microsoft.EntityFrameworkCore;

namespace Database.Persistance.Readers.Implemented
{
    public class CityReader : ICityReader
    {
        private readonly IDbContextFactory<AlbionMarketContext> _contextFactory;
        
        public CityReader(IDbContextFactory<AlbionMarketContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        
        public async Task<IList<City>> GetSafeCities(bool isSafe)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Cities.Where(x=> x.IsSafe == isSafe).ToListAsync();
            }
        }

        public async Task<IList<City>> GetCities()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Cities.ToListAsync();
            }
        }

        public async Task<City> AddCity(City city)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Cities.Add(city);
                await context.SaveChangesAsync();
                return city;
            }
        }
    }
}