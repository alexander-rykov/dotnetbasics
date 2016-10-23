using System;
using System.ComponentModel;
using System.Configuration;

namespace MyApplication.PluginConfiguration
{
    public class NotificationPluginElement : ConfigurationElement
    {
        [ConfigurationProperty("id", IsRequired = true, IsKey = true)]
        public Guid Id
        {
            get
            {
                return (Guid)this["id"];
            }
        }

        [ConfigurationProperty("type", IsRequired = true)]
        public Guid Type
        {
            get
            {
                return (Guid)this["type"];
            }
        }

        [ConfigurationProperty("name")]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
        }

        [ConfigurationProperty("filter")]
        [TypeConverter(typeof(CommaDelimitedStringCollectionConverter))]
        public CommaDelimitedStringCollection Filter
        {
            get
            {
                return (CommaDelimitedStringCollection)this["filter"];
            }
        }
    }
}
