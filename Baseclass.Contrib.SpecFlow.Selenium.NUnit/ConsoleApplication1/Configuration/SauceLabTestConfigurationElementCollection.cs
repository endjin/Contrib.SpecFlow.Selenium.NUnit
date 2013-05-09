namespace ConsoleApplication1.Configuration
{
    using System.Configuration;

    public class SauceLabTestConfigurationElementCollection : ConfigurationElementCollection
    {
        public SauceLabTestConfigurationElementCollection()
        {
            var myElement = (SauceLabTestConfigurationElement)this.CreateNewElement();
            this.Add(myElement);
        }

        public void Add(SauceLabTestConfigurationElement sauceLabTestConfigurationElement)
        {
            this.BaseAdd(sauceLabTestConfigurationElement);
        }

        protected override void BaseAdd(ConfigurationElement element)
        {
            base.BaseAdd(element, false);
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new SauceLabTestConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((SauceLabTestConfigurationElement)element).ConfigName;
        }

        public SauceLabTestConfigurationElement this[int Index]
        {
            get
            {
                return (SauceLabTestConfigurationElement)this.BaseGet(Index);
            }
            set
            {
                if (this.BaseGet(Index) != null)
                {
                    this.BaseRemoveAt(Index);
                }
                this.BaseAdd(Index, value);
            }
        }

        new public SauceLabTestConfigurationElement this[string Name]
        {
            get
            {
                return (SauceLabTestConfigurationElement)this.BaseGet(Name);
            }
        }

        public int Indexof(SauceLabTestConfigurationElement element)
        {
            return this.BaseIndexOf(element);
        }

        public void Remove(SauceLabTestConfigurationElement sauceLabTestConfigurationElement)
        {
            if (this.BaseIndexOf(sauceLabTestConfigurationElement) >= 0)
                this.BaseRemove(sauceLabTestConfigurationElement.ConfigName);
        }

        public void RemoveAt(int index)
        {
            this.BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            this.BaseRemove(name);
        }

        public void Clear()
        {
            this.BaseClear();
        }
    }
}