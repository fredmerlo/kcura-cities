using System.IO;
using System.Reflection;

namespace kcura_cities_common.Processor
{
    public class OutputWriter
    {
        private string fileName;

        public OutputWriter(string fileName)
        {
            this.fileName = fileName;
        }

        public void ProcessOutput()
        {
            var file = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Substring(6) + "\\" + fileName;

            File.Create(file);
        }
    }
}