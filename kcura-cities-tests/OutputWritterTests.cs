using System.IO;
using System.Linq;
using System.Reflection;
using kcura_cities_common.Processor;
using kcura_cities_tests.Fixtures;
using Xunit;

namespace kcura_cities_tests
{
    public class OutputWriterTests : IClassFixture<CityManagerFixture>, IClassFixture<InterstateManagerFixture>, IClassFixture<DistanceManagerFixture>
    {
        private CityManagerFixture fixtureCity;
        private InterstateManagerFixture fixtureInterstate;
        private DistanceManagerFixture fixtureDistance;


        public OutputWriterTests(CityManagerFixture fixtureCity, InterstateManagerFixture fixtureInterstate, DistanceManagerFixture fixtureDistance)
        {
            this.fixtureCity = fixtureCity;
            this.fixtureInterstate = fixtureInterstate;
            this.fixtureDistance = fixtureDistance;
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
        public void OutputWriterProcessOutputForCityManager()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Substring(6);
            var file = "test.txt";
            var expected = "10";

            var wirter = new OutputWriter("test.txt", fixtureCity.CityManager);
            wirter.ProcessOutput();

            var actual = File.ReadLines(path + "\\" + file);

            Assert.Equal(expected, actual.First());
        }

        [Fact]
        public void OutputWriterProcessOutputForInterstateManager()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Substring(6);
            var file = "test.txt";
            var expected = "I-5 2";

            var wirter = new OutputWriter("test.txt", fixtureInterstate.InterstateManager);
            wirter.ProcessOutput();

            var actual = File.ReadLines(path + "\\" + file);

            Assert.Equal(expected, actual.First());
        }

        [Fact]
        public void OutputWriterProcessOutputForDistanceManager()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Substring(6);
            var file = "test.txt";
            var expected = "2 a, a";

            var wirter = new OutputWriter("test.txt", fixtureDistance.DistanceManager);
            wirter.ProcessOutput();

            var actual = File.ReadLines(path + "\\" + file);

            Assert.Equal(expected, actual.First());
        }
    }
}
