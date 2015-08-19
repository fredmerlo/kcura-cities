using System.Collections.Generic;
using kcura_cities_common.Manager;
using kcura_cities_common.Models;
using Xunit;

namespace kcura_cities_tests
{
    public class DistanceManagerTests
    {
        [Fact]
        public void DistanceManagerContainsDictionaryOfCity()
        {
            var distanceManager = new DistanceManager{Cities = new Dictionary<string, City>()};

            Assert.IsType<Dictionary<string, City>>(distanceManager.Cities);
        }

        [Fact]
        public void DistanceManagerContainsDictionaryOfInterstate()
        {
            var distanceManager = new DistanceManager {Interstates = new Dictionary<string, Interstate>()};

            Assert.IsType<Dictionary<string, Interstate>>(distanceManager.Interstates);
        }

        [Fact]
        public void DistanceManagerInitBuildsInterstateDictonaryFromCityInterstateList()
        {
            var distanceManager = new DistanceManager
            {
                Cities = new Dictionary<string, City>
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
                }
            };

            var expected = new Dictionary<string, Interstate>
            {
                {"I-10", new Interstate {Name = "I-10"}},
                {"I-15", new Interstate {Name = "I-15"}},
                {"I-20", new Interstate {Name = "I-20"}},
                {"I-35", new Interstate {Name = "I-35"}},
                {"I-40", new Interstate {Name = "I-40"}}
            };

            distanceManager.Init();
            var actual = distanceManager.Interstates;

            Assert.NotNull(actual);
            foreach (var interstate in expected.Values)
            {
                Assert.Equal(expected[interstate.Name].Name, actual[interstate.Name].Name);
            }
        }
    }
}
