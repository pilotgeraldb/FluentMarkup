using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace FluentMarkup.Html
{
    public class Paragraph : AbstractElement
    {
        public Paragraph()
        {
            Tag = new Tag("p");
        }
    }
}