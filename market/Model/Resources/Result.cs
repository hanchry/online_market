using System.Collections.Generic;

namespace Algorithm.Model
{
    public class Result
    {
        public Item Buy { get; set; }
        public Item Sell { get; set; }
        
        //public int Tier { get; set; }

        public Result()
        {
            Buy = new Item();
            Sell = new Item();
        }

        public int Difference() {
            return Sell.buy_price_max - Buy.sell_price_min;
        }
        public override string ToString()
        {
            return Buy.item_id + " " + Buy.city + " " + Buy.sell_price_min + "          " + Sell.item_id + " " + Sell.city + " " + Sell.buy_price_max + "          " + Difference();
        }
    }
}