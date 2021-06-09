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

        [TestCase("fixtures/config.invalid.json")]
        [TestCase("fixtures/non-existing-file.json")]
        public void ConfigDataIsEmptyIfParsingFails(string filePath)
        {
            var config = _parser.ParseConfigFiles(filePath);
            Assert.IsNull(config.database);
        }

        [TestCase("fixtures/config.json", "fixtures/config.local.json", "127.0.0.1")]
        [TestCase("fixtures/config.local.json", "fixtures/config.json", "mysql")]
        public void ConfigFilesAreMergedInOrder(string configFilePath1, string configFilePath2, string data)
        {
            var config = _parser.ParseConfigFiles(configFilePath1, configFilePath2);
            string host = config.database.host;
            Assert.AreEqual(host, data);
        }
    }
}