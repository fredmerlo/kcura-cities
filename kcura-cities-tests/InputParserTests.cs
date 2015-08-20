using kcura_cities_common.Models;
using kcura_cities_common.Processor;
using Xunit;

namespace kcura_cities_tests
{
    public class InputParserTests
    {
        [Fact]
        public void InputParserCreatesCityFromPipeContent()
        {
            var content = "6|Oklahoma City|Oklahoma|I-35;I-44;I-40";
            var parser = new InputParser();
            var expected = new City { Name = "Oklahoma City", State = "Oklahoma", Population = 6 };

            var actual = parser.ParseItemForCity(content);

            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.State, actual.State);
            Assert.Equal(expected.Population, actual.Population);
        }
    }
}
