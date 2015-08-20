using System.Linq;
using kcura_cities_common.Manager;

namespace kcura_cities_tests.Fixtures
{
    public class DistanceManagerFixture
    {
        public DistanceManagerFixture()
        {
            DistanceManager = new DistanceManager("d"){Cities = FixtureHelpers.RawCities.ToList()};
        }

        public DistanceManager DistanceManager { get; set; }
    }
}