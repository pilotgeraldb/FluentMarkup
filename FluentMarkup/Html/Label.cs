using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace FluentMarkup.Html
{
    public class Label : AbstractElement
    {
        public Label()
        {
            Tag = new Tag("label");
        }

        public Label For(string id)
        {
            if(!string.IsNullOrWhiteSpace(id))
            {
                Attributes.Add(new HtmlAttribute()
                {
                    AttributeName = "for",
                    Values = new List<string>() { id }
                });
            }

            return this;
        }

        public Label For(IElement element)
        {
            if(element == null || element.Attributes == null)
            {
                return this;
            }

            IHtmlAttribute attr = element.Attributes
                .Where(x => x.AttributeName.ToLower().Trim().Equals("id"))
                .FirstOrDefault();

            if(attr != null)
            {
                return For(attr.Values.FirstOrDefault());
            }

            return this;
        }
    }
}   