using System.IO;
using System.Reflection;
using kcura_cities_common.Processor;
using Xunit;

namespace kcura_cities_tests
{
    public class OutputWriterTests
    {
        [Fact]
        public void OutputWriterUsesCurrentPathForOutput()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Substring(6);
            var file = "test.txt";

            var wirter = new OutputWriter("test.txt");
            wirter.ProcessOutput();
            
            Assert.True(File.Exists(path + "\\" + file));
        }
    }
}
