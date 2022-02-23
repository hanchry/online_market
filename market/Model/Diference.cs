using System.Collections.Generic;
using System.Linq;
using Algorithm.Model;

namespace market.Model
{
    public class Diference
    {
        private IList<Item> Items;

        public Diference(AlbionData data)
        {
            Items = new List<Item>();
            Items = data.items;
        }

        private void removeOtherThan(int tier)
        {
            foreach (var i in Items)
            {
                if (!i.item_id.Contains($"T{tier}_"))
                {
                    Items.Remove(i);
                }
            }
        }
        public IList<Result> HighestDiferenceOf(int tier)
        {
            IList<Result> result = new List<Result>();
            
            removeOtherThan(tier);
            
            
            
            
            return result;
        }
    }
}