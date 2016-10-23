using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace MyApplication.PluginConfiguration
{
    public class PluginSettingsElement : ConfigurationElement, IEnumerable<NameValueConfigurationElement>
    {
        [ConfigurationProperty("", IsDefaultCollection = true)]
        public NameValueConfigurationCollection Values
        {
            get
            {
                return (NameValueConfigurationCollection)this[string.Empty];
            }
        }

        public IEnumerator<NameValueConfigurationElement> GetEnumerator()
        {
            foreach (NameValueConfigurationElement item in this.Values)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Values.GetEnumerator();
        }
    }
}
