﻿using kcura_cities_tests.Fixtures;
using Xunit;

namespace kcura_cities_tests
{
    public class OutputFormatterTests:IClassFixture<CityManagerFixture>, IClassFixture<InterstateManagerFixture>
    {
        private CityManagerFixture fixtureCity;
        private InterstateManagerFixture fixtureInterstate;

        public OutputFormatterTests(CityManagerFixture fixtureCity, InterstateManagerFixture fixtureInterstate)
        {
            this.fixtureCity = fixtureCity;
            this.fixtureInterstate = fixtureInterstate;
        }

        [Fact]
        public void OutputFormatterProducesCorrectFormatForCitiesByPopulation()
        {
            var expected = "10\r\nb, b\nInterstates: I-10, I-15, I-40\r\n10\r\nf, f\nInterstates: I-15\r\n9\r\nd, d\nInterstates: I-15, I-35\r\n8\r\na, a\nInterstates: I-10, I-20\r\n8\r\ne, e\nInterstates: I-10, I-20, I-40\r\n7\r\nc, c\nInterstates: I-20, I-35\r\n";
            var actual = fixtureCity.CityManager.GetCitiesByPopulationFormatted();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OutputFormatterProducesCorrectFormatForInterstatesByCity()
        {
            var expected = "I-5 2\nI-10 1\nI-44 2\nI-60 1\nI-85 2\n";
            var actual = fixtureInterstate.InterstateManager.GetInterstatesByCity();

            Assert.Equal(expected, actual);
        }
    }
}
