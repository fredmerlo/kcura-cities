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

                return int.TryParse(Name.Split('-')[1], out result) ? result : -1;
            }
        }
    }
}