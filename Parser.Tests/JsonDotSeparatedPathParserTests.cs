using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser.Tests
{
    public class JsonDotSeparatedPathParserTests
    {
        [TestCase("environment", 1)]
        [TestCase("cache.redis.host", 3)]
        [TestCase("userRoles[1]", 2)]
        public void CanParseHostFromSingleConfigFile(string path, int numberOfSegments)
        {
            var segments = JsonDotSeparatedPathParser.GetPathSegments(path);
            Assert.AreEqual(segments.Count(), numberOfSegments);
        }
    }
}
