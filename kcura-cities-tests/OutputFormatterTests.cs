using kcura_cities_tests.Fixtures;
using Xunit;

namespace kcura_cities_tests
{
    public class OutputFormatterTests:IClassFixture<CityManagerFixture>
    {
        private CityManagerFixture fixture;

        public OutputFormatterTests(CityManagerFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void OutputFormatterProducesCorrectFormatForCitiesByPopulation()
        {
            var expected = "10\r\nb, b\nInterstates: I-10, I-15, I-40\r\n10\r\nf, f\nInterstates: I-15\r\n9\r\nd, d\nInterstates: I-15, I-35\r\n8\r\na, a\nInterstates: I-10, I-20\r\n8\r\ne, e\nInterstates: I-10, I-20, I-40\r\n7\r\nc, c\nInterstates: I-20, I-35\r\n";
            var actual = fixture.CityManager.GetCitiesByPopulationFormatted();

            Assert.Equal(expected, actual);
        }
    }
}
