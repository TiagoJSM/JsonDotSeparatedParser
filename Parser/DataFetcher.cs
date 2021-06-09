using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parser
{
    public class DataFetcher
    {
        public static TData Fetch<TData>(JObject data, IEnumerable<string> pathParts)
        {
            JToken result = data;
            foreach(var pathPart in pathParts)
            {
                result = result[pathPart];
                if(result == null)
                {
                    return default(TData);
                }
            }
            return result.Value<TData>();
        }
    }
}
