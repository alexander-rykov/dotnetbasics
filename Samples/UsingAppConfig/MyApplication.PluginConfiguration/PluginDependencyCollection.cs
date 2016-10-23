using System;
using System.Configuration;

namespace MyApplication.PluginConfiguration
{
    public class PluginDependencyCollection : ConfigurationElementCollection
    {
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }

        protected override string ElementName
        {
            get
            {
                return "dependency";
            }
        }

        protected override bool IsElementName(string elementName)
        {
            return elementName.Equals("dependency", StringComparison.InvariantCultureIgnoreCase);
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new PluginDependencyElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as PluginDependencyElement).Id;
        }
    }
}
