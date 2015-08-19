using System.Collections.Generic;
using kcura_cities_common.Manager;
using kcura_cities_common.Models;
using Xunit;

namespace kcura_cities_tests
{
    public class DistanceManagerTests
    {
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


    }
}
