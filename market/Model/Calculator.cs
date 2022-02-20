using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Algorithm.Data;
using Algorithm.Model;
using Database.Persistance.Readers;
using Database.Persistance.Readers.Implemented;

namespace market.Model
{
    public class Calculator
    {
        private IList<Result> _results;
        private IList<ItemId> ids;

        private readonly IItemIdReader _reader;
        private ItemsController _controller;

        public Calculator(IItemIdReader itemReader)
        {
            _reader = itemReader;
            _results = new List<Result>();
            ids = _reader.GetIdsOfTier(4).Result;
            _controller = new ItemsController();
            Thread newThread = new Thread(new ThreadStart(BiggestDifference));
            newThread.Start();
        }

        public Result getBuingItem()
        {
            return _results.FirstOrDefault(x => x.Tier == 4);
        }

        private void BiggestDifference()
        {
            _results.Add(new Result
            {
                Buy = new Item
                {
                    buy_price_min = 2
                },
                Sell = new Item
                {
                    sell_price_min = 1
                },
                Tier = 4
            });
            
            while (true)
            {
                for (int a = 0; a < ids.Count; a++)
                {
                    IList<Item> items = _controller.GetAllPricesOfItemAsync(ids[a].Id, 0).Result;
                    foreach (var x in items)
                    {
                        foreach (var y in items)
                        {
                            if (x.buy_price_min != 0 && y.sell_price_min != 0 &&
                                x.item_id.Equals(y.item_id))
                            {
                                int calculation = x.buy_price_min - y.sell_price_min;
                                if (_results.First(re => re.Tier == ids[a].Tier).Difference() < calculation &&
                                    x != y)
                                {
                                    Console.WriteLine("if2 " + x.buy_price_min);
                                    _results.Remove(_results.First(re => re.Tier == ids[a].Tier));
                                    Console.WriteLine(_results.Count);
                                    Result result = new Result
                                    {
                                        Buy = x,
                                        Sell = y,
                                        Tier = ids[a].Tier
                                    };
                                    _results.Add(result);
                                    Console.WriteLine(result.Buy.buy_price_min);
                                    Console.WriteLine(result.Sell.sell_price_min);
                                    Console.WriteLine();
                                    Console.WriteLine(_results[0].Buy.buy_price_min);
                                    Console.WriteLine(_results[0].Sell.sell_price_min);
                                }
                            }
                        }
                    }

                    Console.WriteLine(a);
                    Thread.Sleep(5000);
                }
            }
        }
        
        
    }
}