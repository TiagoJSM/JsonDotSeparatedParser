using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parser.Tests
{
    public class JsonDotSeparatedPathTests
    {
        private JsonConfigParser _parser;

        [SetUp]
        public void Setup()
        {
            _parser = new JsonConfigParser();
        }

        [TestCase("fixtures/config.json", "database.host", "mysql")]
        public void CanSelectDataFromPath(string filePath, string jsonPath, string expectedData)
        {
            dynamic config = _parser.ParseConfigFiles(filePath);
            var data = JsonDotSeparatedPath.Select<string>(config, jsonPath);
            Assert.AreEqual(expectedData, data);
        }
    }
}
