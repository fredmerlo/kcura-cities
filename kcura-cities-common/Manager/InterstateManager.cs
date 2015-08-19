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

            return Interstates.Where(w => w.Code > 0)
                              .OrderBy(o => o.Code)
                              .GroupBy(g => g.Name)
                              .Select(s => new InterstateCount{Name = s.Key, Count = s.Count()});
        }
    }
}