﻿using System.Collections.Generic;
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
            var crossReferencList = GetCityInterstateList();

            var distanceClosestToFurthest = 
                GetDistanceList(city, crossReferencList, 0)
                .OrderBy(o => o.Distance);

            var unique = FilterDuplicatesCities(distanceClosestToFurthest);

            return GetSortedDistanceList(unique);
        }

        private static List<CityDistance> GetDistanceList(string currentCity, List<CityInterstate> crossReferencList, int distance)
        {
            var crossReferenceMinusCurrentCity = 
                crossReferencList.Where(w => !w.City.Equals(currentCity))
                                 .ToList();

            var currentCityInterstates = 
                crossReferencList.Where(w => w.City.Equals(currentCity))
                                 .Select(s => s.Interstate);

            var neighborCities = 
                crossReferenceMinusCurrentCity
                .Where(w => currentCityInterstates.Contains(w.Interstate))
                .Select(s => s.City).Distinct();

            var result = new List<CityDistance> {new CityDistance {Distance = distance, Name = currentCity}};

            foreach (var neighbor in neighborCities)
            {
                result.AddRange(GetDistanceList(neighbor, crossReferenceMinusCurrentCity, distance + 1));
            }

            return result;
        }

        private static IEnumerable<CityDistance> FilterDuplicatesCities(IOrderedEnumerable<CityDistance> distanceClosestToFurthest)
        {
            var unique = new Dictionary<string, CityDistance>();

            foreach (var distance in distanceClosestToFurthest)
            {
                if (!unique.ContainsKey(distance.Name))
                {
                    unique.Add(distance.Name, distance);
                }
            }

            return unique.ToList().Select(s => s.Value);
        }

        private static List<CityDistance> GetSortedDistanceList(IEnumerable<CityDistance> uniqe)
        {
            return uniqe.OrderBy(o => o.Name)
                        .OrderByDescending(o => o.Distance)
                        .ToList();
        }
    }
}