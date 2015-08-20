using System.IO;
using System.Linq;
using System.Reflection;
using kcura_cities_common.Models;
using kcura_cities_common.Processor;
using Xunit;

namespace kcura_cities_tests
{
    public class InputParserTests
    {
        [Fact]
        public void InputParserCreatesCityFromStringContent()
        {
            var content = "6|Oklahoma City|Oklahoma|I-35;I-44;I-40";
            var parser = new InputParser("");
            var expected = new City
            {
                Name = "Oklahoma City",
                State = "Oklahoma",
                Population = 6,
                Interstates = new[] {"I-35", "I-44", "I-40"}.ToList()
            };

            var actual = parser.ParseItemForCity(content);

            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.State, actual.State);
            Assert.Equal(expected.Population, actual.Population);
            Assert.Equal(expected.Interstates, actual.Interstates);
        }

        [Fact]
        public void InputParseCanProcessInputFile()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Substring(6);
            var file = "sample_cities.txt";
            var parser = new InputParser(path + "\\" + file);
            var expected = new City
            {
                Name = "Oklahoma City",
                State = "Oklahoma",
                Population = 6,
                Interstates = new[] { "I-35", "I-44", "I-40" }.ToList()
            };


            var actual = parser.Parse();

            Assert.Equal(expected.Name, actual[0].Name);
            Assert.Equal(expected.State, actual[0].State);
            Assert.Equal(expected.Population, actual[0].Population);
            Assert.Equal(expected.Interstates, actual[0].Interstates);
        }
    }
}
