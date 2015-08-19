using System.Collections.Generic;
using System.Linq;
using kcura_cities_common.Models;

namespace kcura_cities_common.Manager
{
    public class DistanceManager
    {
        public Dictionary<string, City> Cities { get; set; }
        public Dictionary<string, Interstate> Interstates { get; set; }

        public void Init()
        {
            Interstates = new Dictionary<string, Interstate>();

            var interstates =
                Cities.SelectMany(cityItem => cityItem.Value.Interstates)
                      .Where(interstate => !Interstates.ContainsKey(interstate.Name));

            foreach (var interstate in interstates)
            {
                Interstates.Add(interstate.Name, interstate);
            }
        }

        public List<CityDistance> GetDistanceFromCity(string city)
        {
            return new List<CityDistance>();
        }
    }
}