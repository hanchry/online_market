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
        
        public AlbionData(IItemIdReader itemReader)
        {
            _reader = itemReader;
            ids = _reader.GetIds().Result;
            _controller = new ItemsController();
            
        }
        
        public IList<Item> items { get; set; }

        public void BiggestDifference()
        {
            while (true)
            {
                for (int a = 0; a < ids.Count; a++)
                {
                    IList<Item> data = _controller.GetAllPricesOfItemAsync(ids[a].Id, 0).Result;
                    foreach (var i in data)
                    {
                        items.Add(i);
                    }
                    Thread.Sleep(2000);
                }
            }
        }
    }
}