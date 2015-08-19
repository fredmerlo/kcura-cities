using System.Collections.Generic;
using kcura_cities_common.Models;

namespace kcura_cities_common.Manager
{
    public class DistanceManager
    {
        public Dictionary<string, City> Cities { get; set; }
        public Dictionary<string, Interstate> Interstates { get; set; }
    }
}