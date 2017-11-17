using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace FluentMarkup.Html
{
    public class Text : AbstractElement
    {
        public Text()
        {
            Tag = new Tag("");
            Tag.Disabled = true;
        }

        public Text(string value)
        {
            Tag = new Tag("");
            Tag.Disabled = true;
            Value = value;
        }

        public override string Render()
        {
            return Value;
        }

        public string Value { get; set; }
    }
}