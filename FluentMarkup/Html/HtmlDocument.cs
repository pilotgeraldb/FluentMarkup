using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace FluentMarkup.Html
{
    public class HtmlDocument : AbstractElement
    {
        public HtmlDocument()
        {
            Tag = new Tag("html");
        }
    }
}