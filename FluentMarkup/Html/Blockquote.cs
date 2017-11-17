using System;
using System.Collections.Generic;

namespace FluentMarkup.Html
{
    public class Blockquote : AbstractElement
    {
        public Blockquote()
        {
            Tag = new Tag("blockquote");
        }

        public Blockquote Citation(string sourceUrl)
        {
            HtmlAttribute attr = new HtmlAttribute()
                {
                    AttributeName = "cite",
                    Values = new List<string>() { sourceUrl  }
                };

            this.Attributes.Add(attr);

            return this;
        }
    }
}