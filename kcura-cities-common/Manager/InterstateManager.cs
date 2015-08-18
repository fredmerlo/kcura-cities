using System.Collections.Generic;
using System.Linq;
using kcura_cities_common.Models;

namespace kcura_cities_common.Manager
{
    public class InterstateManager
    {
        public List<Interstate> Interstates { get; set; }

        public IEnumerable<InterstateCount> GetInterstateCount()
        {

            return Interstates.OrderBy(o => o.Code).GroupBy(i => i.Name).Select(g => new InterstateCount{Name = g.Key, Count = g.Count()});
        }
    }
}