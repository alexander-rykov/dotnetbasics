namespace MyApplication.PluginConfiguration
{
    public class PluginCollection : ConfigurationElementCollection<PluginElement>
    {
        protected override string ElementName
        {
            get
            {
                return "plugin";
            }
        }
    }
}
