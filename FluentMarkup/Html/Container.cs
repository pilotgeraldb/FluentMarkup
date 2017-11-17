using System;
using System.Collections.Generic;

namespace FluentMarkup.Html
{
    public class Container : AbstractElement
    {
        public Container()
        {
            Tag = new Tag("div");
        }
    }
}