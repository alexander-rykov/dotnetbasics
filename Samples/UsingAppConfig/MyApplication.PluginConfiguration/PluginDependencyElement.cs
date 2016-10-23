using System;
using System.Configuration;

namespace MyApplication.PluginConfiguration
{
    public class PluginDependencyElement : ConfigurationElement
    {
        [ConfigurationProperty("id", IsRequired = true, IsKey = true)]
        public Guid Id
        {
            get
            {
                return (Guid)this["id"];
            }
        }
    }
}
