using System.Collections.Generic;
using System.Linq;
using kcura_cities_common.Manager;
using kcura_cities_common.Models;

namespace kcura_cities_tests.Fixtures
{
    public class DistanceManagerFixture
    {
        public DistanceManagerFixture()
        {
            var rawCities = new []
            {
                    new City
                    {
                        Name = "a",
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
                        Interstates =
                            new List<string>
                            {
                                "I-10",
                                "I-20",
                                "I-40"
                            }
                    },
                    new City {Name = "f", Interstates = new List<string> {"I-15"}}
            }.ToList();

            DistanceManager = new DistanceManager{Cities = rawCities};
        }

        public DistanceManager DistanceManager { get; set; }
    }
}