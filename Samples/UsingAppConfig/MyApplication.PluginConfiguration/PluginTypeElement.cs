using System;
using System.Configuration;

namespace MyApplication.PluginConfiguration
{
    public class PluginTypeElement : ConfigurationElement
    {
        [ConfigurationProperty("id", IsRequired = true, IsKey = true)]
        public Guid Id
        {
            get
            {
                return (Guid)this["id"];
            }
        }

        [ConfigurationProperty("name", IsRequired = true)]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\")]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
        }

        [ConfigurationProperty("loaderClass", IsRequired = true)]
        public LoaderClassElement LoaderClass
        {
            get
            {
                return (LoaderClassElement)this["loaderClass"];
            }
        }
    }
}
