using System.IO;
using System.Linq;
using System.Reflection;
using kcura_cities_common.Processor;
using kcura_cities_tests.Fixtures;
using Xunit;

namespace kcura_cities_tests
{
    public class OutputWriterTests : IClassFixture<CityManagerFixture>
    {
        private CityManagerFixture fixtureCity;

        public OutputWriterTests(CityManagerFixture fixtureCity)
        {
            this.fixtureCity = fixtureCity;
        }

        [Fact]
        public void OutputWriterUsesCurrentPathForOutput()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Substring(6);
            var file = "test.txt";

            var wirter = new OutputWriter("test.txt", null);
            wirter.ProcessOutput();
            
            Assert.True(File.Exists(path + "\\" + file));
        }

        [Fact]
        public void OutputWriterProcessOutputUsesOutputFormatter()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Substring(6);
            var file = "test.txt";
            var expected = "10";

            var wirter = new OutputWriter("test.txt", fixtureCity.CityManager);
            wirter.ProcessOutput();

            var actual = File.ReadLines(path + "\\" + file);

            Assert.Equal(expected, actual.First());
        }
    }
}
