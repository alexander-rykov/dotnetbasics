namespace MyApplication.PluginConfiguration
{
    public sealed class NotificationPluginCollection : ConfigurationElementCollection<NotificationPluginElement>
    {
        protected override string ElementName
        {
            get
            {
                return "notificationPlugin";
            }
        }
    }
}
