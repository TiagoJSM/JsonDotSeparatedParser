using System;

namespace Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new JsonConfigParser();

            var config = parser.ParseConfigFiles("fixtures/userroles.json", "fixtures/userroles.local.json");
            var data = JsonDotSeparatedPath.Select<string>(config, "userRoles[1]");

            Console.WriteLine("Hello World!");
        }
    }
}
