using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parser
{
    public class JsonDotSeparatedPath
    {
        public static TData Select<TData>(JObject data, string path)
        {
            var parts = JsonDotSeparatedPathParser.GetPathSegments(path);

            JToken result = data;
            foreach(var part in parts)
            {
                result = part(result);
                if(result == null)
                {
                    return default(TData);
                }
            }
            return result.Value<TData>();
        }
    }
}
