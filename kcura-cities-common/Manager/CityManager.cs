using System.Collections.Generic;
using System.Linq;
using kcura_cities_common.Models;

namespace kcura_cities_common.Manager
{
    public class CityManager
    {
        public List<City> Cities { get; set; }

        public IOrderedEnumerable<City> GetCitiesByPopulationDescending()
        {
            return Cities.OrderBy(n => n.Name).OrderByDescending(p => p.Population);
        }
    }
}