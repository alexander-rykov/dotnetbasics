using System.Configuration;

namespace MyApplication.PluginConfiguration
{
    public class PluginConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("pluginTypes", IsRequired = true, IsDefaultCollection = false)]
        public PluginTypeCollection PluginTypes
        {
            get
            {
                return (PluginTypeCollection)this["pluginTypes"];
            }
        }

        [ConfigurationProperty("notificationPlugins", IsDefaultCollection = false)]
        public NotificationPluginCollection NotificationPlugins
        {
            get
            {
                return (NotificationPluginCollection)this["notificationPlugins"];
            }
        }

        [ConfigurationProperty("plugins", IsDefaultCollection = false)]
        public PluginCollection Plugins
        {
            get
            {
                return (PluginCollection)this["plugins"];
            }
        }

        [ConfigurationProperty("xmlns", IsRequired = false)]
        public string XmlNamespace
        {
            get
            {
                return (string)this["xmlns"];
            }
        }

        [ConfigurationProperty("xmlns:xsi", IsRequired = false)]
        public string Xsi
        {
            get
            {
                return (string)this["xmlns:xsi"];
            }
        }

        [ConfigurationProperty("xsi:noNamespaceSchemaLocation", IsRequired = false)]
        public string NamespaceSchemaLocation
        {
            get
            {
                return (string)this["xsi:noNamespaceSchemaLocation"];
            }
        }
    }
}
