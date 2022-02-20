using System.ComponentModel.DataAnnotations;

namespace Algorithm.Model
{
    public class City
    {
        [Key]
        public string Name { get; set; }
        public bool IsSafe { get; set; }
        public string Island { get; set; }
    }
}