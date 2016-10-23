using System.Configuration;

namespace MyApplication.PluginConfiguration
{
    public class LoaderClassElement : ConfigurationElement
    {
        [ConfigurationProperty("assembly")]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\")]
        public string Assembly
        {
            get
            {
                return (string)this["assembly"];
            }
        }

        [ConfigurationProperty("class", IsRequired = true)]
        [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\")]
        public string Class
        {
            get
            {
                return (string)this["class"];
            }
        }
    }
}
