using System.Linq;
using kcura_cities_common.Manager;

namespace kcura_cities_tests.Fixtures
{
    public class CityManagerFixture
    {
        public CityManagerFixture()
        {
            CityManager = new CityManager {Cities = FixtureHelpers.RawCities.ToList()};
        }

        public CityManager CityManager { get; set; }
    }
}