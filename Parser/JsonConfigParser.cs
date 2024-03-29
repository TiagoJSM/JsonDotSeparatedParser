﻿using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace Parser
{
    public class JsonConfigParser
    {
        /// <summary>
        /// Parses json config files, when providing more than 1 parameter the files are merged.
        /// </summary>
        /// <param name="filePaths">The path for the json files.</param>
        /// <returns></returns>
        public JObject ParseConfigFiles(params string[] filePaths)
        {
            var resultConfig = new JObject();
            foreach (var filePath in filePaths)
            {
                var configFile = ReadJsonFile(filePath);
                if (configFile != null)
                {
                    resultConfig.Merge(configFile, new JsonMergeSettings { MergeArrayHandling = MergeArrayHandling.Replace });
                }
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

            // Newtonsoft Json doesn't provide a method to check if a parse is possible, so for now we have to use a try-catch to avoid exceptions bubbling up
            // ToDo: Replace try-catch if Newtonsoft Json provides a "validation" method
            try
            {
                return JObject.Parse(jsonText);
            }
            catch(Exception)
            {
                return null;
            }
        }
    }
}
