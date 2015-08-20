using System.Text;

namespace kcura_cities_common.Processor
{
    public interface IStringOutputFormatter
    {
        StringBuilder GetOutput();
    }
}