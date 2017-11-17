using System.Collections.Generic;

namespace FluentMarkup.Parsing.Json
{
    internal class ElementAttribute
    {
        public string AttributeName { get; set; }
        public List<string> Values { get; set; }
    }
}   