using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Parser
{
    public static class PathRegex
    {
        public static Regex Property = new Regex(@"\S+$");
        public static Regex ArrayElement = new Regex(@"(\S+)\[(\d+)\]$");
    }
}
