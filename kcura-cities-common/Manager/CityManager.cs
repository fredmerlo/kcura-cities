﻿using System.Collections.Generic;
using System.Linq;
using kcura_cities_common.Models;

namespace kcura_cities_common.Manager
{
    public class CityManager
    {
        public List<City> Cities { get; set; }

        public IOrderedEnumerable<City> GetCitiesByPopulation()
        {
            return Cities.OrderBy(n => n.State).ThenBy(t => t.Name).OrderByDescending(p => p.Population);
        }

        public string GetCitiesByPopulationFormatted()
        {
            var output = string.Empty;
            var format = "{0}\r\n{1}\nInterstates: {2}\r\n";

            foreach (var city in GetCitiesByPopulation())
            {
                var interstates = string.Join(", ", city.Interstates);
                output += string.Format(format, city.Population, city.FullName, interstates);
            }

            return output;
        }
    }
}