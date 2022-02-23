using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Algorithm.Data;
using Algorithm.Model;
using Database.Persistance.Readers;

namespace market.Model
{
    public class AlbionData
    {
        private IList<ItemId> ids;

        private readonly IItemIdReader _reader;
        private ItemsController _controller;
        private IList<Item> items;

        public AlbionData(IItemIdReader itemReader)
        {
            _reader = itemReader;
            ids = _reader.GetIdsOfTier(4).Result;
            _controller = new ItemsController();
            items = new List<Item>();
        }

        public IList<Item> GetItems()
        {
            return items;
        }

        public void BiggestDifference()
        {
            while (true)
            {
                foreach (ItemId t in ids)
                {
                    IList<Item> data = _controller.GetAllPricesOfItemAsync(t.Id, 0).Result;
                    foreach (Item i in data)
                    {
                        items.Add(i);
                    }

                    Thread.Sleep(1000);
                }
            }
        }
    }
}