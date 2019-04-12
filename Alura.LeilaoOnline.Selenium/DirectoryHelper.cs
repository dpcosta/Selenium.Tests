using System.IO;
using System.Reflection;

namespace Alura.LeilaoOnline.Selenium
{
    static class DirectoryHelper
    {
        public static string PastaDoExecutavel => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }
}
