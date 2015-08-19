using System.Linq;
using kcura_cities_common.Manager;
using kcura_cities_common.Models;

namespace kcura_cities_tests.Fixtures
{
    public class InterstateManagerFixture
    {
        public InterstateManagerFixture()
        {
            var rawInterstates = new[]
            {
                new Interstate {Name = "I-5"}, new Interstate {Name = "I-85"}, new Interstate {Name = "I-10"},
                new Interstate {Name = "I-5"}, new Interstate {Name = "I-60"}, new Interstate {Name = "I-44"},
                new Interstate {Name = "I-44"}, new Interstate {Name = "I-85"}, new Interstate {Name = "I-nvalid"}, new Interstate {Name = "Invalid"}
            };
            InterstateManager = new InterstateManager{Interstates = rawInterstates.ToList()};
        }

        public InterstateManager InterstateManager { get; set; }
    }
}