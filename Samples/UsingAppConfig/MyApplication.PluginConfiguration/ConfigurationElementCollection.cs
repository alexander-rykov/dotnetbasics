using System.Collections.Generic;
using System.Configuration;

namespace MyApplication.PluginConfiguration
{
    public class ConfigurationElementCollection<T> : ConfigurationElementCollection, IEnumerable<T> where T : ConfigurationElement, new()
    {
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }

        public T this[int index]
        {
            get
            {
                return (T)BaseGet(index);
            }
        }

        public new IEnumerator<T> GetEnumerator()
        {
            foreach (T item in (ConfigurationElementCollection)this)
            {
                yield return item;
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new T();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            foreach (var property in element.GetType().GetProperties())
            {
                var obj = property.GetCustomAttributes(typeof(ConfigurationPropertyAttribute), true);

                if (obj.Length == 0)
                {
                    continue;
                }

                var configurationProperty = (ConfigurationPropertyAttribute)obj[0];

                if (configurationProperty.IsKey)
                {
                    return property.GetValue(element);
                }
            }

            return null;
        }
    }
}
