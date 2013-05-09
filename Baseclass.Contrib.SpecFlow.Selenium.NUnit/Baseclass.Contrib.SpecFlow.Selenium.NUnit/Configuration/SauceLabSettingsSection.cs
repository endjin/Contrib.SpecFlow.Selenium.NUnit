namespace Baseclass.Contrib.SpecFlow.Selenium.NUnit.Configuration
{
    using System.Configuration;

    public class SauceLabSettingsSection : ConfigurationSection
    {
        public SauceLabSettingsSection()
        {
        }

        [ConfigurationProperty("sauceLabConfigs", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(SauceLabTestConfigurationElementCollection), 
            AddItemName = "add",
            ClearItemsName = "clear",
            RemoveItemName = "remove")]
        public SauceLabTestConfigurationElementCollection ConfigurationElementCollection
        {
            get { return (SauceLabTestConfigurationElementCollection) base["sauceLabConfigs"]; }
        }

        [ConfigurationProperty("sauceLabCredentials")]
        public SauceLabCredentialsElement Credentials
        {
            get { return (SauceLabCredentialsElement) base["sauceLabCredentials"]; }
        }
    }
}