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

        [TestCase(new string[] { "fixtures/config.json" }, "environment", "production")]
        [TestCase(new string[] { "fixtures/config.json" }, "database.host", "mysql")]
        [TestCase(new string[] { "fixtures/config.json" }, "cache.redis.host", "redis")]
        [TestCase(new string[] { "fixtures/config.json" }, "cache.redis.none", null)]
        [TestCase(new string[] { "fixtures/config.json" }, "not.a.path", null)]
        [TestCase(new string[] { "fixtures/config.json" }, "environment.not.a.path", null)]
        [TestCase(new string[] { "fixtures/config.json", "config.local.json" }, "environment.not.a.path", null)]
        public void CanSelectDataFromPath(string[] filePaths, string jsonPath, string expectedData)
        {
            dynamic config = _parser.ParseConfigFiles(filePaths);
            var data = JsonDotSeparatedPath.Select<string>(config, jsonPath);
            Assert.AreEqual(expectedData, data);
        }
    }
}
