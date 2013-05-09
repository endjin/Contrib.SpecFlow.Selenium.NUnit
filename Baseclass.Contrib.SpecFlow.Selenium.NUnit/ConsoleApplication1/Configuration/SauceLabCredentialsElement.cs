namespace ConsoleApplication1.Configuration
{
    using System.Configuration;

    public class SauceLabCredentialsElement : ConfigurationElement
    {
        public SauceLabCredentialsElement()
        {
        }

        [ConfigurationProperty("userName", IsRequired = true)]
        public string UserName
        {
            get { return (string)this["userName"]; }
            set { this["userName"] = value; }
        }

        [ConfigurationProperty("accessKey", IsRequired = true)]
        public string AccessKey
        {
            get { return (string)this["accessKey"]; }
            set { this["accessKey"] = value; }
        }

        [ConfigurationProperty("url", IsRequired = true)]
        public string Url
        {
            get { return (string)this["url"]; }
            set { this["url"] = value; }
        }
    }
}