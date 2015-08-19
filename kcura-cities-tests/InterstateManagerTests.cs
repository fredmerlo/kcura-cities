using System.Collections.Generic;
using System.Linq;
using kcura_cities_common.Models;
using kcura_cities_tests.Fixtures;
using Xunit;

namespace kcura_cities_tests
{
    public class InterstateManagerTests : IClassFixture<InterstateManagerFixture>
    {
        private InterstateManagerFixture fixture;

        public InterstateManagerTests(InterstateManagerFixture fixture)
        {
            this.fixture = fixture;
        }
        [Fact]
        public void InterstateManagerContainsListOfInterstate()
        {
            Assert.IsType<List<Interstate>>(fixture.InterstateManager.Interstates);
        }

        [Fact]
        public void InterstateManagerReturnsInterstateCountByNameAscendingAndIgnoresInvalidEntries()
        {
            var expected = new[] {"I-5","I-10","I-44","I-60","I-85"}.ToList();

            var actual = fixture.InterstateManager.GetInterstateCount().Select(s => s.Name).ToList();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InterstateManagerReturnsCountOfEachInterstate()
        {
            var expected = new[]
            {
                new InterstateCount{Name = "I-5", Count = 2}, 
                new InterstateCount{Name = "I-10", Count = 1}, 
                new InterstateCount{Name = "I-44", Count = 2}, 
                new InterstateCount{Name = "I-60", Count = 1}, 
                new InterstateCount{Name = "I-85", Count = 2}, 
            }.ToList();

            var actual = fixture.InterstateManager.GetInterstateCount().ToList();

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i].Count, actual[i].Count);
                Assert.Equal(expected[i].Name, actual[i].Name);
            }
        }
    }
}
