using System;
using System.Configuration;
using MyApplication.PluginConfiguration;

namespace MyApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Get setting from appSetting section.
            Console.WriteLine("Connection limit is {0}", ConfigurationManager.AppSettings["limit"]);
            Console.WriteLine("A maximum delay is {0}", ConfigurationManager.AppSettings["delay"]);

            // Get connection string from connectionStrings section.
            Console.WriteLine("A connection string for accounts database is set: {0}.", ConfigurationManager.ConnectionStrings["accounts-master"] != null);

            // Get a custom section as an instantiated object.
            var section = (PluginConfigurationSection)ConfigurationManager.GetSection("pluginConfiguration");

            Console.WriteLine("\nPlugin types:");
            foreach (var pluginType in section.PluginTypes)
            {
                Console.WriteLine("\tPlugin: {0}, {1}", pluginType.Id, pluginType.Name);
            }

            Console.WriteLine("\nNotification plugins:");
            foreach (var notificationPlugin in section.NotificationPlugins)
            {
                Console.WriteLine("\tPlugin: {0}, {1}", notificationPlugin.Id, notificationPlugin.Name);
                if (notificationPlugin.Filter != null)
                {
                    foreach (var filter in notificationPlugin.Filter)
                    {
                        Console.WriteLine("\t\tFilter: {0}", filter);
                    }
                }
            }

            Console.WriteLine("\nPlugins:");
            foreach (var plugin in section.Plugins)
            {
                Console.WriteLine("\tPlugin: {0}, {1}", plugin.Id, plugin.Name);
                foreach (var setting in plugin.Settings)
                {
                    Console.WriteLine("\t\tSetting: {0} = {1}", setting.Name, setting.Value);
                }

                foreach (PluginDependencyElement dependency in plugin.Dependencies)
                {
                    Console.WriteLine("\t\tDependency: {0}", dependency.Id);
                }
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
}
