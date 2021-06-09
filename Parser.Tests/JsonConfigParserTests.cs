using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Parser.Tests
{
    public class JsonConfigParserTests
    {
        private JsonConfigParser _parser;

        [SetUp]
        public void Setup()
        {
            _parser = new JsonConfigParser();
        }

        [TestCase("fixtures/config.json", "mysql")]
        [TestCase("fixtures/config.local.json", "127.0.0.1")]
        public void CanParseHostFromSingleConfigFile(string filePath, string data)
        {
            var config = _parser.ParseConfigFiles(filePath);
            string host = config.database.host;
            Assert.AreEqual(host, data);
        }

        [TestCase("config.invalid.json")]
        public void ReturnsNullOnInvalidJsonFile(string filePath)
        {
            var config = _parser.ParseConfigFiles(filePath);
            Assert.IsNull(config);
        }
    }
}