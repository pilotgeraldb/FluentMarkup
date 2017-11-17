using System;
using System.Collections.Generic;

namespace FluentMarkup.Html
{
    public class Form : AbstractElement
    {
        public Form()
        {
            Tag = new Tag("form");
        }

        public Form Action(string action)
        {
            Attributes.Add(new HtmlAttribute()
            {
                AttributeName = "action",
                Values = new List<string>() { action }
            });

            return this;
        }

        public Form NoAutoComplete()
        {
            Attributes.Add(new HtmlAttribute()
            {
                AttributeName = "autocomplete",
                Values = new List<string>() { "off" }
            });

            return this;
        }

        public Form AutoComplete()
        {
            Attributes.Add(new HtmlAttribute()
            {
                AttributeName = "autocomplete",
                Values = new List<string>() { "on" }
            });

            return this;
        }

        public Form Target(HtmlTarget htmlTargetType)
        {
            Attributes.Add(new HtmlAttribute()
            {
                AttributeName = "target",
                Values = new List<string>() { "_" + htmlTargetType.ToString().ToLower() }
            });

            return this;
        }

        public Form NoValidate()
        {
            Attributes.Add(new HtmlAttribute()
            {
                AttributeName = "novalidate",
                Values = new List<string>() { "novalidate" }
            });

            return this;
        }

        public Form Method(string method)
        {
            Attributes.Add(new HtmlAttribute()
            {
                AttributeName = "method",
                Values = new List<string>() { method }
            });
            
            return this;
        }
    }
}