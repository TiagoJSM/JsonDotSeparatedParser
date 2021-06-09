using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Parser
{
    public class SeparatedPathParser
    {
        private char _separator;
        public SeparatedPathParser(char separator)
        {
            _separator = separator;
        }

        public IEnumerable<string> GetPathParts(string path)
        {
            return path.Split(_separator);
        }
    }
}
