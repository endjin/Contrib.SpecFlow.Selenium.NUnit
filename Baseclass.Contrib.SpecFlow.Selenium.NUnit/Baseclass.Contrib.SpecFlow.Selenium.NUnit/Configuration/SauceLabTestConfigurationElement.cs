namespace Baseclass.Contrib.SpecFlow.Selenium.NUnit.Configuration
{
    using System.Configuration;

    public class SauceLabTestConfigurationElement : ConfigurationElement
    {
        public SauceLabTestConfigurationElement()
        {
        }

        [ConfigurationProperty("configName", IsRequired = true)]
        public string ConfigName
        {
            get { return (string)this["configName"]; }
            set { this["configName"] = value; }
        }

        [ConfigurationProperty("browser", IsRequired = true)]
        public string Browser
        {
            get { return (string)this["browser"]; }
            set { this["browser"] = value; }
        }

        [ConfigurationProperty("version", IsRequired = true)]
        public string Version
        {
            get { return (string)this["version"]; }
            set { this["version"] = value; }
        }

        [ConfigurationProperty("platform", IsRequired = true)]
        public string Platform
        {
            get { return (string)this["platform"]; }
            set { this["platform"] = value; }
        }
    }
}