namespace xBDD.Importing.Configuration
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using xBDD.Model;
    using xBDD;

    internal static class ConfigurationImporter
    {
        internal static xBDDConfiguration ImportConfiguration(string filePath) {
			var configJson = System.IO.File.ReadAllText(filePath);
            var bytes = Encoding.UTF8.GetBytes(configJson);
            xBDDConfiguration config = null;
            using ( var stream = new MemoryStream( bytes ) )
            {
                var serializer = new DataContractJsonSerializer(typeof(xBDDConfiguration));
                config = (xBDDConfiguration)serializer.ReadObject(stream);
			}
			return config;
        }
    }
}