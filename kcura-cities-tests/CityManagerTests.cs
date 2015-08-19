using System.Collections.Generic;
using System.Linq;
using kcura_cities_common.Models;
using kcura_cities_tests.Fixtures;
using Xunit;

namespace kcura_cities_tests
{
    public class CityManagerTests : IClassFixture<CityManagerFixture>
    {
        private CityManagerFixture fixture;

        public CityManagerTests(CityManagerFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void CityManagerContainsListOfCity()
        {
            Assert.IsType<List<City>>(fixture.CityManager.Cities);
        }

        [Fact]
        public void CityManagerReturnsListOfCitiesByPopulationDescending()
        {
            var expected = new[] {10, 10, 9, 8, 8, 7 }.ToList();
            var actual = fixture.CityManager.GetCitiesByPopulation().Select(s => s.Population).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CityManagerReturnsListOfCitiesByPopulationDescendingAndCityNameAscending()
        {
            var expected = new[]
            {
                new City {Population = 10, Name = "b"},
                new City {Population = 10, Name = "f"},
                new City {Population = 9, Name = "d"},
                new City {Population = 8, Name = "a"},
                new City {Population = 8, Name = "e"},
                new City {Population = 7, Name = "c"}
            }.ToList();

            var actual = fixture.CityManager.GetCitiesByPopulation().ToList();

            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(expected[i].Population, actual[i].Population);
                Assert.Equal(expected[i].Name, actual[i].Name);
            }
        }
    }
}
