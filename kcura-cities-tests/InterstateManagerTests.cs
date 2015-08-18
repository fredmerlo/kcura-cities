using System.Collections.Generic;
using kcura_cities_common.Manager;
using kcura_cities_common.Models;
using Xunit;

namespace kcura_cities_tests
{
    public class InterstateManagerFixture
    {
        public List<Interstate> InterstateGroupA { get; set; }

        public InterstateManagerFixture()
        {
            InterstateManager = new InterstateManager{Interstates = new List<Interstate>()};
        }

        public InterstateManager InterstateManager { get; set; }
    }

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
    }
}
