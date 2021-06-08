﻿using System;

namespace Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new JsonConfigParser();
            var config = parser.ParseConfigFiles("fixtures/config.json", "fixtures/config.local.json");

            Console.WriteLine("Hello World!");
        }
    }
}
