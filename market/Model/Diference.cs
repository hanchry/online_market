using System;
using System.Collections.Generic;
using System.Linq;
using Algorithm.Model;
using Database.Persistance.Readers;

namespace market.Model
{
    public class Diference
    {
        private IList<Item> items;
        private AlbionData _data;
        private readonly ICityReader _cityReader;

        public Diference(AlbionData data, ICityReader cityReader)
        {
            items = new List<Item>();
            _data = data;
            _cityReader = cityReader;
        }

        private void removeOtherThan(int tier)
        {
            for (int i = 0 ; i < items.Count; i++)
            {
                if (!items[i].item_id.Contains($"T{tier}_"))
                {
                    items.Remove(items[i]);
                }
            }
            
        }
        

        public Result HighestDiferenceOf(int tier, bool isSafe)
        {
            Result result = new Result();
            int difference = 0;
            items = _data.GetItems();

            removeOtherThan(tier);

            for (int i = 0; i < items.Count - 1; i++)
            {
                for (int j = i + 1; j < items.Count; j++)
                {
                    if (difference < items[i].buy_price_max - items[j].sell_price_min &&
                        items[i].item_id.Equals(items[j].item_id) && items[j].sell_price_min > 1 &&
                        items[i].buy_price_max > 1)
                    {
                        difference = items[i].buy_price_max - items[j].sell_price_min;
                        result.Buy = items[j];
                        result.Sell = items[i];
                    }
                }
            }
            
            Console.WriteLine(result + "          " + items.Count);
            return result;
        }
    }
}