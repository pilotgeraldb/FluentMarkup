using System;
using System.Collections.Generic;

namespace FluentMarkup.Html
{
    public class Input : AbstractElement
    {
        private IElement Label { get; set; }

        public Input()
        {
            Tag = new Tag("input");

            Tag.IsSelfClosing = true;
        }

        public Input Type(HtmlInputType type)
        {
            string typestring = type.ToString().ToLower();

            if(type == HtmlInputType.None)
            {
                return this;
            }

            if(type == HtmlInputType.DateTime_Local)
            {
                typestring = "datetime-local";
            }

            Attributes.Add(new HtmlAttribute()
            {
                AttributeName = "type",
                Values = new List<string>() { typestring  }
            });

            return this;
        }

        public Input Placeholder(string placeholderText)
        {
            Attributes.Add(new HtmlAttribute()
            {
                AttributeName = "placeholder",
                Values = new List<string>() { placeholderText  }
            });
            
            return this;
        }

        public Input DontSelfClose()
        {
            Tag.IsSelfClosing = false;
            
            return this;
        }

        public Label WithLabel(string text)
        {
            return this.WrapWith(new Label().For(this).Text(text));
        }
    }
}