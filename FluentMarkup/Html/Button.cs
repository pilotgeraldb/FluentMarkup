using System;
using System.Collections.Generic;

namespace FluentMarkup.Html
{
    public class Button : AbstractElement
    {
        public Button()
        {
            Tag = new Tag("button");
        }

        public Button Type(HtmlButtonType type)
        {
            string typestring = type.ToString().ToLower();

            if(type == HtmlButtonType.None)
            {
                return this;
            }

            Attributes.Add(new HtmlAttribute()
            {
                AttributeName = "type",
                Values = new List<string>() { typestring  }
            });

            return this;
        }
    }
}