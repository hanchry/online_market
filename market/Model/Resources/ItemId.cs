using System.ComponentModel.DataAnnotations;

namespace Algorithm.Model
{
    public class ItemId
    {
        [Key]
        public string Id { get; set; }
        public int Tier { get; set; }

        public override string ToString()
        {
            return Id + " " + Tier;
        }
    }
}