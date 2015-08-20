using kcura_cities_tests.Fixtures;
using Xunit;

namespace kcura_cities_tests
{
    public class OutputFormatterTests:IClassFixture<CityManagerFixture>, IClassFixture<InterstateManagerFixture>, IClassFixture<DistanceManagerFixture>
    {
        private CityManagerFixture fixtureCity;
        private InterstateManagerFixture fixtureInterstate;
        private DistanceManagerFixture fixtureDistance;

        public OutputFormatterTests(CityManagerFixture fixtureCity, InterstateManagerFixture fixtureInterstate, DistanceManagerFixture fixtureDistance)
        {
            this.fixtureCity = fixtureCity;
            this.fixtureInterstate = fixtureInterstate;
            this.fixtureDistance = fixtureDistance;
        }

        [Fact]
        public void OutputFormatterProducesCorrectFormatForCitiesByPopulation()
        {
            var expected = "10\n\nb, b\nInterstates: I-10, I-15, I-40\n\n10\n\nf, f\nInterstates: I-15\n\n9\n\nd, d\nInterstates: I-15, I-35\n\n8\n\na, a\nInterstates: I-10, I-20\n\n8\n\ne, e\nInterstates: I-10, I-20, I-40\n\n7\n\nc, c\nInterstates: I-20, I-35\n\n";
            var actual = fixtureCity.CityManager.GetCitiesByPopulationFormatted().ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OutputFormatterProducesCorrectFormatForInterstatesByCity()
        {
            var expected = "I-5 2\nI-10 1\nI-44 2\nI-60 1\nI-85 2\n";
            var actual = fixtureInterstate.InterstateManager.GetInterstatesByCity().ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OutputFormatterProducesCorrectFormatForDegreesFromCity()
        {
            var expected = "2 a, a\n2 e, e\n1 b, b\n1 c, c\n1 f, f\n0 d, d\n";
            var actual = fixtureDistance.DistanceManager.GetDegreesFromCity().ToString();

            Assert.Equal(expected, actual);
        }
    }
}
