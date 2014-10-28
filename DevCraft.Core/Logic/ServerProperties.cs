using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;

namespace DevCraft.Core.Logic
{
    public class ServerProperties : NameValueCollection
    {
        private const string PROPERTIES_FILE = "server.properties";
        private readonly string _serverFolder;

        public ServerProperties(string serverFolder)
        {
            if (string.IsNullOrWhiteSpace(serverFolder)) throw new ArgumentException(Resources.ErrorPropertiesFolder, "serverFolder");
            
            _serverFolder = serverFolder;

            Initialize();
        }

        private void Initialize()
        {
            string fullPath = Path.Combine(_serverFolder, PROPERTIES_FILE);

            if (!File.Exists(fullPath)) return;

            try
            {
                IEnumerable<string> lines = File.ReadAllLines(fullPath).Where(ln => 
                    !string.IsNullOrWhiteSpace(ln) 
                    && !ln.StartsWith("#")
                    && ln.Contains("="));

                foreach (string line in lines)
                {
                    string[] pair = line.Split('=');

                    string key = pair[0];
                    string value = pair[1];

                    if (!string.IsNullOrEmpty(key))
                    {
                        Add(key, value);
                    }
                }
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                // log something
            }
        }
    }
}