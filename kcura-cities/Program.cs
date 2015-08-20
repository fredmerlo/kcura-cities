using System;
using System.IO;
using System.Reflection;
using kcura_cities_common.Manager;
using kcura_cities_common.Processor;

namespace kcura_cities
{
    public class Program
    {
        static void Main(string[] args)
        {
            if(args.Length < 2 || args.Length > 2 )
            {
                Console.WriteLine("Usage: kcura-cities.exe c:\\directory\\sample_cities.txt chicago");
                return;
            }

            Console.WriteLine("Processing Input file: " + args[0] + " for city: " + args[1]);
            
            var parser = new InputParser(args[0]);
            var cities = parser.Parse();
            
            if (cities.Count == 0)
            {
                Console.WriteLine("Input file invalid");
                return;
            }

            new OutputWriter("Cities_By_Population.txt", new CityManager {Cities = cities})
                .ProcessOutput();

            new OutputWriter("Interstates_By_City.txt", new InterstateManager{ Cities = cities })
                .ProcessOutput();

            new OutputWriter("Degrees_From_Chicago.txt", new DistanceManager {City = args[1], Cities = cities})
                .ProcessOutput();

            Console.WriteLine("Processing Complete Output located at: " + Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Substring(6));
        }
    }
}
