using System.Collections.Generic;
using kcura_cities_common.Manager;
using kcura_cities_common.Models;

namespace kcura_cities_tests.Fixtures
{
    public class DistanceManagerFixture
    {
        public DistanceManagerFixture()
        {
            var rawCities = new Dictionary<string, City>
            {
                {
                    "a",
                    new City
                    {
                        Name = "a",
                        Interstates =
                            new List<Interstate>
                            {
                                new Interstate {Name = "I-10"},
                                new Interstate {Name = "I-20"}
                            }
                    }
                },
                {
                    "b",
                    new City
                    {
                        Name = "b",
                        Interstates =
                            new List<Interstate>
                            {
                                new Interstate {Name = "I-10"},
                                new Interstate {Name = "I-15"},
                                new Interstate {Name = "I-40"}
                            }
                    }
                },
                {
                    "c", new City
                    {
                        Name = "c",
                        Interstates =
                            new List<Interstate>
                            {
                                new Interstate {Name = "I-20"},
                                new Interstate {Name = "I-35"}
                            }
                    }
                },
                {
                    "d", new City
                    {
                        Name = "d",
                        Interstates =
                            new List<Interstate>
                            {
                                new Interstate {Name = "I-15"},
                                new Interstate {Name = "I-35"}
                            }
                    }
                },
                {
                    "e", new City
                    {
                        Name = "e",
                        Interstates =
                            new List<Interstate>
                            {
                                new Interstate {Name = "I-10"},
                                new Interstate {Name = "I-20"},
                                new Interstate {Name = "I-40"}
                            }
                    }
                },
                {"f", new City {Name = "f", Interstates = new List<Interstate> {new Interstate {Name = "I-15"}}}}
            };

            DistanceManager = new DistanceManager{Cities = rawCities, Interstates = new Dictionary<string, Interstate>()};
        }

        public DistanceManager DistanceManager { get; set; }
    }
}