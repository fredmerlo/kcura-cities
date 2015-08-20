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
            Assert.IsType<List<City>>(fixture.DistanceManager.Cities);
        }

        [Fact]
        public void DistanceManagerInitBuildsCityInterstateListFromCityList()
        {
            var expected = new[]
            {
                new CityInterstate {City = "a, a", Interstate = "I-10"},
                new CityInterstate {City = "a, a", Interstate = "I-20"},
                new CityInterstate {City = "b, b", Interstate = "I-10"},
                new CityInterstate {City = "b, b", Interstate = "I-15"},
                new CityInterstate {City = "b, b", Interstate = "I-40"},
                new CityInterstate {City = "c, c", Interstate = "I-20"},
                new CityInterstate {City = "c, c", Interstate = "I-35"},
                new CityInterstate {City = "d, d", Interstate = "I-15"},
                new CityInterstate {City = "d, d", Interstate = "I-35"},
                new CityInterstate {City = "e, e", Interstate = "I-10"},
                new CityInterstate {City = "e, e", Interstate = "I-20"},
                new CityInterstate {City = "e, e", Interstate = "I-40"},
                new CityInterstate {City = "f, f", Interstate = "I-15"}
            }.ToList();

            var actual = fixture.DistanceManager.GetCityInterstateList();

            Assert.NotNull(actual);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i].City, actual[i].City);
                Assert.Equal(expected[i].Interstate, actual[i].Interstate);
            }
        }

        [Fact]
        public void DistanceManagerGetDistanceFromCityReturnsListCityDistanceForD()
        {
            var expected =
                new[]
                {
                    new CityDistance {Name = "a, a", Distance = 2}, new CityDistance {Name = "e, e", Distance = 2},
                    new CityDistance {Name = "b, b", Distance = 1}, new CityDistance {Name = "c, c", Distance = 1},
                    new CityDistance {Name = "f, f", Distance = 1},new CityDistance {Name = "d, d", Distance = 0}
                }.ToList();

            var actual = fixture.DistanceManager.GetDistanceFromCity("d");

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i].Name, actual[i].Name);
                Assert.Equal(expected[i].Distance, actual[i].Distance);
            }
        }

        [Fact]
        public void DistanceManagerGetDistanceFromCityReturnsListCityDistanceForF()
        {
            var expected =
                new[]
                {
                    new CityDistance {Name = "a, a", Distance = 2}, new CityDistance {Name = "c, c", Distance = 2},
                    new CityDistance {Name = "e, e", Distance = 2}, new CityDistance {Name = "b, b", Distance = 1},
                    new CityDistance {Name = "d, d", Distance = 1},new CityDistance {Name = "f, f", Distance = 0}
                }.ToList();

            var actual = fixture.DistanceManager.GetDistanceFromCity("f");

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i].Name, actual[i].Name);
                Assert.Equal(expected[i].Distance, actual[i].Distance);
            }
        }
    }
}
