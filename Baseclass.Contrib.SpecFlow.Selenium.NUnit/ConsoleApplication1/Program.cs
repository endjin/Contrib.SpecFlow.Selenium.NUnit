using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    using System.Configuration;
    using ConsoleApplication1.Configuration;

    class Program
    {
        static void Main(string[] args)
        {
            var sauceLabSettings = (SauceLabSettingsSection)ConfigurationManager.GetSection("sauceLabSettings");
        }
    }
}
