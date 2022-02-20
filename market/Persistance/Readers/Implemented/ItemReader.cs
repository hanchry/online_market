using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algorithm.Model;
using Microsoft.EntityFrameworkCore;

namespace Database.Persistance.Readers.Implemented
{
    public class ItemReader:IItemIdReader
    {
        private readonly IDbContextFactory<AlbionMarketContext> _contextFactory;
        
        public ItemReader(IDbContextFactory<AlbionMarketContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        
        public async Task<IList<ItemId>> GetIdsOfTier(int tier)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Ids.Where(x => x.Tier == tier).ToListAsync();
            }
        }

        public async Task<IList<ItemId>> GetIds()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await context.Ids.ToListAsync();
            }
        }

        public async Task<ItemId> AddId(ItemId itemId)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Ids.Add(itemId);
                await context.SaveChangesAsync();
                //return await context.Ids.FirstAsync(x => x.Id.Equals(itemId.Id));
                return itemId;
            }
        }
    }
}