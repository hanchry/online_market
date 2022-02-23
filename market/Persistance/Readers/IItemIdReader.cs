using System.Collections.Generic;
using System.Threading.Tasks;
using Algorithm.Model;

namespace Database.Persistance.Readers
{
    public interface IItemIdReader
    {
        Task<IList<ItemId>> GetIdsOfTier(int tier);
        Task<IList<ItemId>> GetIds();
        Task<ItemId> AddId(ItemId itemId);
    }
}