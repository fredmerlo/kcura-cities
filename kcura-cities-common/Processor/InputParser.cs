using System.Collections.Generic;
using System.IO;
using System.Linq;
using kcura_cities_common.Models;

namespace kcura_cities_common.Processor
{
    public class InputParser
    {
        private string file;

        public InputParser(string file)
        {
            this.file = file;
        }

        public City ParseItemForCity(string item)
        {
            var parts = item.Split('|');
            var population = 0;
            int.TryParse(parts[0], out population);

            return new City
            {
                Name = parts[1],
                State = parts[2],
                Population = population,
                Interstates = parts[3].Split(';').ToList()
            };
        }

        public List<City> Parse()
        {
            var cities = new List<City>();

            if (!string.IsNullOrEmpty(file))
            {
                cities.AddRange(File.ReadLines(file).Select(ParseItemForCity));
            }

            return cities;
        }
    }
}