using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace AppConfig
{
    public static class ConfigReader
    {
        private static FileSystemWatcher fileSystemWatcher = null;
        private static XElement configXmlElement = null;
        private static string folder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        static ConfigReader()
        {
            fileSystemWatcher = new FileSystemWatcher(folder);
            fileSystemWatcher.Changed += FileSystemWatcher_Changed;
            fileSystemWatcher.EnableRaisingEvents = true;
        }

        private static XElement GetConfigXmlElement()
        {
            if (configXmlElement == null)
            {
                configXmlElement = LoadConfig();
            }

            return configXmlElement;
        }

        public static string GetApiUrl(string name, string action)
        {
            var config = GetConfigXmlElement();
            var apiConfig = config.Elements("Api").Where(element => element.Attribute("name").Value == name);
            var urlConfig = apiConfig != null && apiConfig.Count() > 0 ? apiConfig.Elements("Url").Where(element => element.Attribute("action").Value == action) : null;
            return urlConfig != null && urlConfig.Count() > 0 ? urlConfig.FirstOrDefault().Value : null;
        }

        private static void FileSystemWatcher_Changed(object sender, FileSystemEventArgs args)
        {
            configXmlElement = LoadConfig();
        }

        private static XElement LoadConfig()
        {
            return XElement.Load("AppConfig.xml");
        }
    }
}
