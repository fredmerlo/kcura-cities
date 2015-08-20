using kcura_cities_common.Models;

namespace kcura_cities_common.Processor
{
    public class InputParser
    {
        public City ParseItemForCity(string item)
        {
            var parts = item.Split('|');
            var population = 0;
            int.TryParse(parts[0], out population);

            return new City {Name = parts[1], State = parts[2], Population = population};
        }
    }
}