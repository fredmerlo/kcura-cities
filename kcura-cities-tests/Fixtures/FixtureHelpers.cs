using System.Collections.Generic;
using kcura_cities_common.Models;

namespace kcura_cities_tests.Fixtures
{
    public static class FixtureHelpers
    {
        public static City[] RawCities =
        {
            new City
            {
                Name = "a",
                State = "a",
                Population = 8,
                Interstates =
                    new List<string>
                    {
                        "I-10",
                        "I-20"
                    }
            },
            new City
            {
                Name = "b",
                State = "b",
                Population = 10,
                Interstates =
                    new List<string>
                    {
                        "I-10",
                        "I-15",
                        "I-40"
                    }
            },
            new City
            {
                Name = "c",
                State = "c",
                Population = 7,
                Interstates =
                    new List<string>
                    {
                        "I-20",
                        "I-35"
                    }
            },
            new City
            {
                Name = "d",
                State = "d",
                Population = 9,
                Interstates =
                    new List<string>
                    {
                        "I-15",
                        "I-35"
                    }
            },
            new City
            {
                Name = "e",
                State = "e",
                Population = 8,
                Interstates =
                    new List<string>
                    {
                        "I-10",
                        "I-20",
                        "I-40"
                    }
            },
            new City {Name = "f", State = "f", Population = 10, Interstates = new List<string> {"I-15"}}
        };
    }
}
