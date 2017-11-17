using System.Collections.Generic;

namespace FluentMarkup.Html
{
    public class HtmlAttribute : IHtmlAttribute
    {
        public string AttributeName { get; set; }
        public List<string> Values { get; set; } 
    }
}