using System.Collections.Generic;
using System.Linq;
using kcura_cities_common.Models;

namespace kcura_cities_common.Manager
{
    public class DistanceManager
    {
        public List<City> Cities { get; set; }


        public List<CityInterstate> GetCityInterstateList()
        {
            var list = new List<CityInterstate>();
            foreach (var city in Cities)
            {
                list.AddRange(city.Interstates.Select(s => new CityInterstate{City = city.Name, Interstate = s}));
            }
            return list;
        }

        public List<CityDistance> GetDistanceFromCity(string city)
        {
            var list = GetCityInterstateList();
            var distances = BuildList(city, list, 0);
            var uniq = new Dictionary<string, CityDistance>();

            foreach (var distance in distances.OrderBy( o => o.Distance))
            {
                if (!uniq.ContainsKey(distance.Name))
                {
                    uniq.Add(distance.Name, distance);
                }
            }

            return uniq.ToList().Select(s => s.Value).OrderBy(o => o.Name).OrderBy(o => o.Distance).ToList();
        }

        private List<CityDistance> BuildList(string city, List<CityInterstate> list, int distance)
        {
            var newList = list.Where(w => !w.City.Equals(city)).ToList();
            var interstates = list.Where(w => w.City.Equals(city)).Select(s => s.Interstate);
            var cities = newList.Where(w => interstates.Contains(w.Interstate)).Select(s => s.City).Distinct();
            var r = new List<CityDistance>();

            r.Add(new CityDistance{Distance = distance, Name = city});

            foreach (var city1 in cities)
            {
                r.AddRange(BuildList(city1, newList, distance + 1));
            }

            return r;
        }
    }
}