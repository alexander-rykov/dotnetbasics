using System;
using System.Configuration;

namespace MyApplication.PluginConfiguration
{
    public class PluginElement : ConfigurationElement
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

        [ConfigurationProperty("pluginSettings")]
        public PluginSettingsElement Settings
        {
            get
            {
                return (PluginSettingsElement)this["pluginSettings"];
            }
        }

        [ConfigurationProperty("dependencies")]
        public PluginDependencyCollection Dependencies
        {
            get
            {
                return (PluginDependencyCollection)this["dependencies"];
            }
        }
    }
}
