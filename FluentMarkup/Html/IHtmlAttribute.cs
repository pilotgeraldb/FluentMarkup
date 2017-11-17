using System.Collections.Generic;

namespace FluentMarkup.Html
{
    public interface IHtmlAttribute
    {
        string AttributeName { get; set; }
        List<string> Values { get; set; } 
    }
}