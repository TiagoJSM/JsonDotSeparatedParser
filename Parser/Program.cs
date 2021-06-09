using System;

namespace Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new JsonConfigParser();
            var pathParser = new SeparatedPathParser('.');

            var config = parser.ParseConfigFiles("fixtures/config.json", "fixtures/config.local.json");
            var data = DataFetcher.Fetch<string>(config, pathParser.GetPathParts("database.host"));

            Console.WriteLine("Hello World!");
        }
    }
}
