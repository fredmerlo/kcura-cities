using System.Collections.Generic;
using System.Linq;
using System.Text;
using kcura_cities_common.Models;
using kcura_cities_common.Processor;

namespace kcura_cities_common.Manager
{
    public class InterstateManager : IStringOutputFormatter
    {
        public List<Interstate> Interstates { get; set; }

        public IEnumerable<InterstateCount> GetInterstateCount()
        {

            return Interstates.Where(w => w.Code > 0)
                              .OrderBy(o => o.Code)
                              .GroupBy(g => g.Name)
                              .Select(s => new InterstateCount{Name = s.Key, Count = s.Count()});
        }

        public StringBuilder GetInterstatesByCity()
        {
            var output = new StringBuilder();
            var format = "{0} {1}\n";

            foreach (var interstates in GetInterstateCount())
            {
                output.AppendFormat(format, interstates.Name, interstates.Count);
            }
            return output;
        }

        public StringBuilder GetOutput()
        {
            return GetInterstatesByCity();
        }
    }
}