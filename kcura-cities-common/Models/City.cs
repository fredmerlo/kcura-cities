using System.Collections.Generic;
using System.Linq;

namespace kcura_cities_common.Models
{
    public class City
    {
        public int Population { get; set; }
        public string Name { get; set; }
        public List<string> Interstates { get; set; }
        public List<Interstate> InterstateRef { get { return Interstates.Select(s => new Interstate {Name = s}).OrderBy(o => o.Code).ToList(); } } 
        public string State { get; set; }
        public string FullName { get { return Name + ", " + State; } }
    }
}