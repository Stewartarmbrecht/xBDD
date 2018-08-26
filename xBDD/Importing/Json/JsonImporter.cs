namespace xBDD.Importing.Json
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using xBDD.Model;
    using xBDD;
    /// <summary>
    /// Converts json to a TestRun object.
    /// </summary>
    public class JsonImporter
    {
        /// <summary>
        /// Creates a test run object from a text file.
        /// </summary>
        /// <param name="text">The json to import.</param>
        /// <returns>TestRun object hydrated from the json.</returns>
        public TestRun ImportJson(string text) {
            var bytes = Encoding.UTF8.GetBytes(text);
            TestRun tr = null;
            using ( var stream = new MemoryStream( bytes ) )
            {
                var serializer = new DataContractJsonSerializer(typeof(TestRun));
                tr = (TestRun)serializer.ReadObject(stream);
            }
            return tr;   
        }
    }
}