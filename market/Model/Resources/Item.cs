namespace Algorithm.Model
{
    public class Item
    {
        public string item_id { get; set; }
        public string city { get; set; }
        public int quality { get; set; }
        public int sell_price_min { get; set; }
        public string sell_price_min_date { get; set; }
        public int sell_price_max { get; set; }
        public string sell_price_max_date { get; set; }
        public int buy_price_min { get; set; }
        public string buy_price_min_date { get; set; }
        public int buy_price_max { get; set; }
        public string buy_price_max_date { get; set; }

        public override string ToString()
        {
            return item_id + " " + city + " " + quality + " " + sell_price_min + " " + sell_price_min_date + " " + sell_price_max + " " + sell_price_max_date + " " + buy_price_min + " " + buy_price_min_date + " " + buy_price_max + " " + buy_price_max_date;
        }
    }
}