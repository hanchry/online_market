using System.Collections.Generic;

namespace Algorithm.Model
{
    public class Result
    {
        public Item Buy { get; set; }
        public Item Sell { get; set; }

        public int Difference() {
            return Sell.buy_price_max - Buy.sell_price_min;
        }
        public int Tier { get; set; }

        public override string ToString()
        {
            return Buy.item_id + " " + Buy.city + " " + Buy.sell_price_min + " " + Sell.item_id + " " + Sell.city + " " + Sell.buy_price_max;
        }
    }
}