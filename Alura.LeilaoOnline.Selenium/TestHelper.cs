using System.IO;
using System.Reflection;

namespace Alura.LeilaoOnline.Selenium
{
    static class TestHelper
    {
        public static string PastaDoExecutavel => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static string UrlDoSistema => "http://localhost:51128";
    }
}
