using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace Parser
{
    public class JsonConfigParser
    {
        public dynamic ParseConfigFiles(params string[] filePaths)
        {
            var resultConfig = new JObject();
            foreach (var filePath in filePaths)
            {
                var configFile = ReadJsonFile(filePath);
                if (configFile == null)
                {
                    return null;
                }
                resultConfig.Merge(configFile);
            }
            return resultConfig;
        }

        private JObject ReadJsonFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return null;
            }
            var jsonText = File.ReadAllText(filePath);
            return JObject.Parse(jsonText);
        }
    }
}
