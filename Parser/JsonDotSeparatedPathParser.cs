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
                if (PathRegex.ArrayElement.IsMatch(segment))
                {
                    var match = PathRegex.ArrayElement.Match(segment);
                    yield return (d) => PropertySegment(d, match.Groups[1].Value);
                    yield return (d) => ArraySegment(d, int.Parse(match.Groups[2].Value));
                }
                else if (PathRegex.Property.IsMatch(segment))
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
        private static JToken PropertySegment(JToken data, object property)
        {
            return data[property];
        }

        /// <summary>
        /// Gets JToken from data based on an index
        /// </summary>
        /// <param name="data">The token to obtain the property from</param>
        /// <param name="index">The index of the array</param>
        /// <returns></returns>
        private static JToken ArraySegment(JToken data, int index)
        {
            // check if index is valid
            return
                data.Children().Count() > index && index >= 0
                ? data[index]
                : null;
        }
    }
}
