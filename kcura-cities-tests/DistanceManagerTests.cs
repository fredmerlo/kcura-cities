using System.Collections.Generic;
using System.Linq;
using kcura_cities_common.Models;
using kcura_cities_tests.Fixtures;
using Xunit;

namespace kcura_cities_tests
{
    public class DistanceManagerTests : IClassFixture<DistanceManagerFixture>
    {
        private DistanceManagerFixture fixture;

        public DistanceManagerTests(DistanceManagerFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void DistanceManagerContainsDictionaryOfCity()
        {
            Assert.IsType<Dictionary<string, City>>(fixture.DistanceManager.Cities);
        }

        [Fact]
        public void DistanceManagerContainsDictionaryOfInterstate()
        {
            Assert.IsType<Dictionary<string, Interstate>>(fixture.DistanceManager.Interstates);
        }

        [Fact]
        public void DistanceManagerInitBuildsInterstateDictonaryFromCityInterstateList()
        {
            var expected = new Dictionary<string, Interstate>
            {
                {"I-10", new Interstate {Name = "I-10"}},
                {"I-15", new Interstate {Name = "I-15"}},
                {"I-20", new Interstate {Name = "I-20"}},
                {"I-35", new Interstate {Name = "I-35"}},
                {"I-40", new Interstate {Name = "I-40"}}
            };

            fixture.DistanceManager.Init();
            var actual = fixture.DistanceManager.Interstates;

            Assert.NotNull(actual);
            foreach (var interstate in expected.Values)
            {
                Assert.Equal(expected[interstate.Name].Name, actual[interstate.Name].Name);
            }
        }

        [Fact]
        public void DistanceManagerGetDistanceFromCityReturnsListCityDistance()
        {
            Assert.IsType<List<CityDistance>>(fixture.DistanceManager.GetDistanceFromCity2(string.Empty, new List<CityInterstate>()));
        }

        [Fact]
        public void DistanceManagerGetDistanceFromCityReturnsListCityDistanceFromAGivenCity()
        {
            var data = new[]
            {
                new CityInterstate {City = "a", Interstate = "I-10"},
                new CityInterstate {City = "a", Interstate = "I-20"},
                new CityInterstate {City = "b", Interstate = "I-10"},
                new CityInterstate {City = "b", Interstate = "I-15"},
                new CityInterstate {City = "b", Interstate = "I-40"},
                new CityInterstate {City = "c", Interstate = "I-20"},
                new CityInterstate {City = "c", Interstate = "I-35"},
                new CityInterstate {City = "d", Interstate = "I-15"},
                new CityInterstate {City = "d", Interstate = "I-35"},
                new CityInterstate {City = "e", Interstate = "I-10"},
                new CityInterstate {City = "e", Interstate = "I-20"},
                new CityInterstate {City = "e", Interstate = "I-40"},
                new CityInterstate {City = "f", Interstate = "I-15"}
            }.ToList();

            var expected =
                new[]
                {
                    new CityDistance {Name = "d", Distance = 0}, new CityDistance {Name = "b", Distance = 1},
                    new CityDistance {Name = "c", Distance = 1}, new CityDistance {Name = "f", Distance = 1},
                    new CityDistance {Name = "a", Distance = 2}, new CityDistance {Name = "e", Distance = 2}
                }.ToList();

            var actual = fixture.DistanceManager.GetDistanceFromCity2("d", data);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i].Name, actual[i].Name);
                Assert.Equal(expected[i].Distance, actual[i].Distance);
            }
        }
    }
}
