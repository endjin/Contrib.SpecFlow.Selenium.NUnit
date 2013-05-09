using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baseclass.Contrib.SpecFlow.Selenium.NUnit
{
    using System.Configuration;
    using OpenQA.Selenium;

    /// <summary>
    /// Extension to <see cref="OpenQA.Selenium.Remote.RemoteWebDriver"/> allowing the instantiation with two strings
    /// Simplifies the xml configuration of an IOC Container
    /// Uses reflection to retrieve the <see cref="DesiredCapabilities"/> static method to create the DesiredCapabilities for a specific browser.
    /// </summary>
    public class RemoteWebDriver : OpenQA.Selenium.Remote.RemoteWebDriver
    {
        /// <summary>
        /// Creates a new instance of <see cref="RemoteWebDriver"/>
        /// Retrieves the <see cref="DesiredCapabilities"/> by calling the static method on <see cref="DesiredCapabilities"/>
        /// with the same name as <paramref name="browser"/>
        /// Example: Calls DesiredCapabilites.InternetExplorer() if <paramref name="browser"/> is specified as InternetExplorer
        /// </summary>
        /// <param name="url">
        /// Url pointing to the Selenium web server
        /// </param>
        /// <param name="browser">
        /// Name of the browser to use for testing
        /// </param>
        public RemoteWebDriver(string url, string browser)
            : base(new Uri(url), GetCapabilities(browser))
        {
        }

        public RemoteWebDriver(string url, string browser, string version, string platform, string testName = "", bool sauceLabs = false)
            : base(new Uri(url), GetCapabilities(browser, version, platform, testName, sauceLabs))
        {
        }

        private static ICapabilities GetCapabilities(string browserName, string version, string platform, string testName = "", bool sauceLabs = false)
        {
            DesiredCapabilities capabilities;

            switch (browserName)
            {
                case "InternetExplorer":
                    capabilities = DesiredCapabilities.InternetExplorer();
                    break;
                case "Chrome":
                    capabilities = DesiredCapabilities.Chrome();
                    break;
                case "Firefox":
                    capabilities = DesiredCapabilities.Firefox();
                    break;
                default:
                    throw new InvalidOperationException(string.Format("{0} is not a valid browser type", browserName));
            }

            capabilities.SetCapability(CapabilityType.Version, version);
            capabilities.SetCapability(CapabilityType.Platform, platform);


            if (sauceLabs)
            {
                var userName = ConfigurationManager.AppSettings["sauceLabsUserName"];
                var accessKey = ConfigurationManager.AppSettings["sauceLabsAccessKey"];
                capabilities.SetCapability("username", userName);
                capabilities.SetCapability("accessKey", accessKey);
                capabilities.SetCapability("name", testName); 
            }

            return capabilities;
        }


        /// <summary>
        /// Uses reflection to create an instance of <see cref="DesiredCapabilities"/>
        /// </summary>
        /// <param name="browserName">
        /// Name of the browser to use for testing
        /// </param>
        /// <returns>
        /// Instance of DesiredCapabilities describing the browser
        /// </returns>
        private static DesiredCapabilities GetCapabilities(string browserName)
        {
            var capabilityCreationMethod = typeof(DesiredCapabilities)
                .GetMethod(browserName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);


            if (capabilityCreationMethod == null)
            {
                throw new NotSupportedException("Can't find DesiredCapabilities with name " + browserName);
            }

            var capabilities = capabilityCreationMethod.Invoke(null, null) as DesiredCapabilities;

            if (capabilities == null)
            {
                throw new NotSupportedException("Can't find DesiredCapabilities with name " + browserName);
            }

            return capabilities;
        }
    }
}
