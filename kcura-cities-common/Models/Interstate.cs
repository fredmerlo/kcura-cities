namespace kcura_cities_common.Models
{
    public class Interstate
    {
        public string Name { get; set; }

        public int Code
        {
            get
            {
                int result;
                var parts = Name.Split('-');

                if (parts.Length != 2)
                    return -1;

                return int.TryParse(parts[1], out result) ? result : -1;
            }
        }
    }
}