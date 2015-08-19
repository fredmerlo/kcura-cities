using System.Collections.Generic;

namespace kcura_cities_common.Models
{
    public class City
    {
        public int Population { get; set; }
        public string Name { get; set; }
        public List<string> Interstates { get; set; }
    }
}