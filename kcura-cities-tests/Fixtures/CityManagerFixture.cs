using System.Linq;
using kcura_cities_common.Manager;
using kcura_cities_common.Models;

namespace kcura_cities_tests.Fixtures
{
    public class CityManagerFixture
    {
        public CityManagerFixture()
        {
            var rawCities = new[]
            {
                new City {Population = 8, Name = "z"}, new City {Population = 7, Name = "b"},
                new City {Population = 10, Name = "x"}, new City {Population = 9, Name = "a"},
                new City {Population = 8, Name = "y"}
            };

            CityManager = new CityManager {Cities = rawCities.ToList()};
        }

        public CityManager CityManager { get; set; }
    }
}