using System.Collections.Generic;
using kcura_cities_common.Manager;
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
            var distanceManager = new DistanceManager{Cities = new Dictionary<string, City>()};

            Assert.IsType<Dictionary<string, City>>(distanceManager.Cities);
        }

        [Fact]
        public void DistanceManagerContainsDictionaryOfInterstate()
        {
            var distanceManager = new DistanceManager {Interstates = new Dictionary<string, Interstate>()};

            Assert.IsType<Dictionary<string, Interstate>>(distanceManager.Interstates);
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
    }
}
