using System.IO;
using System.Reflection;

namespace kcura_cities_common.Processor
{
    public class OutputWriter
    {
        private string fileName;
        private IStringOutputFormatter formatter;

        public OutputWriter(string fileName, IStringOutputFormatter formatter)
        {
            this.fileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Substring(6) + "\\" + fileName;
            this.formatter = formatter;
        }

        public void ProcessOutput()
        {
            if (!string.IsNullOrEmpty(fileName) && null != formatter)
            {
                File.WriteAllText(fileName, formatter.GetOutput().ToString());
            }
        }
    }
}