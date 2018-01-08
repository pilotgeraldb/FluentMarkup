using System;
using System.Collections.Generic;

namespace FluentMarkup.Html
{
    public class Icon : AbstractElement
    {
        public Icon()
        {
            Tag = new Tag("i");
        }
    }
}