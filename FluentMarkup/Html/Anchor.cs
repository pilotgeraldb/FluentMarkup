using System;
using System.Collections.Generic;

namespace FluentMarkup.Html
{
    public class Anchor : AbstractElement
    {
        public Anchor()
        {
            Tag = new Tag("a");
        }

        public Anchor Href(string url)
        {
            Attributes.Add(new HtmlAttribute()
            {
                AttributeName = "href",
                Values = new List<string>() { url  }
            });

            return this;
        }
    }
}