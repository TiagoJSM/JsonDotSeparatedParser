using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Parser
{
    public delegate JToken PathSegment(JToken data);

    /// <summary>
    /// Utility class to parse dot separated paths
    /// </summary>
    public static class JsonDotSeparatedPathParser
    {
        private const char Separator = '.';

        /// <summary>
        /// Returns a collection of path segment getters
        /// </summary>
        /// <param name="path">Dot separated path</param>
        /// <returns></returns>
        public static IEnumerable<PathSegment> GetPathSegments(string path)
        {
            var segments = path.Split(Separator);

            foreach (var segment in segments)
            {
                if (PathRegex.Property.IsMatch(segment))
                {
                    yield return (d) => PropertySegment(d, segment);
                }
            }
        }

        /// <summary>
        /// Gets JToken from data based on property parameter
        /// </summary>
        /// <param name="data">The token to obtain the property from</param>
        /// <param name="property">The property name</param>
        /// <returns></returns>
        private static JToken PropertySegment(JToken data, string property)
        {
            return data.Children<JProperty>().FirstOrDefault(c => c.Name == property)?.Value;
        }
    }
}
