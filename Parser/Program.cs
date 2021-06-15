using System;

namespace Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new JsonConfigParser();
            var path = "database.host";
            var configFiles = new[] { "fixtures/config.json", "fixtures/config.local.json" };

            var config = parser.ParseConfigFiles(configFiles);
            var data = JsonDotSeparatedPath.Select<string>(config, path);

            Console.WriteLine("Config files loaded:");
            foreach (var configFile in configFiles)
            {
                Console.WriteLine(configFile);
            }

            Console.WriteLine();
            Console.WriteLine($"Dot Separated Path: {path}");
            Console.WriteLine($"Result: {data}");
        }
    }
}
