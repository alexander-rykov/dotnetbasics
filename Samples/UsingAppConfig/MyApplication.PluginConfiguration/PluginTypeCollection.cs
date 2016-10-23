namespace MyApplication.PluginConfiguration
{
    public class PluginTypeCollection : ConfigurationElementCollection<PluginTypeElement>
    {
        protected override string ElementName
        {
            get
            {
                return "pluginType";
            }
        }
    }
}
