using System.Collections.Generic;
using System.Linq;
using System.Text;
using kcura_cities_common.Models;
using kcura_cities_common.Processor;

namespace kcura_cities_common.Manager
{
    public class CityManager : IStringOutputFormatter
    {
        public List<City> Cities { get; set; }

        public IOrderedEnumerable<City> GetCitiesByPopulation()
        {
            return Cities.OrderBy(n => n.State).ThenBy(t => t.Name).OrderByDescending(p => p.Population);
        }

        public StringBuilder GetCitiesByPopulationFormatted()
        {
            var output = new StringBuilder();
            var format = "{0}\r\n{1}\nInterstates: {2}\r\n";

            foreach (var city in GetCitiesByPopulation())
            {
                var interstates = string.Join(", ", city.InterstateRef.Select(s => s.Name));
                output.AppendFormat(format, city.Population, city.FullName, interstates);
            }

            return output;
        }

        public StringBuilder GetOutput()
        {
            return GetCitiesByPopulationFormatted();
        }
    }
}