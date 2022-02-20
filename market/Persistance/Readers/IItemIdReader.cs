using System.Collections.Generic;
using System.Threading.Tasks;
using Algorithm.Model;

namespace Database.Persistance.Readers
{
    public interface IItemIdReader
    {
        public Task<IList<ItemId>> GetIdsOfTier(int tier);
        public Task<IList<ItemId>> GetIds();
        public Task<ItemId> AddId(ItemId itemId);
    }
}