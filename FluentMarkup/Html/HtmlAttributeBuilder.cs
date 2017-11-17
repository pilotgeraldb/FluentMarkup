using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace FluentMarkup.Html
{
    public class HtmlAttributeBuilder : IHtmlAttributeBuilder
    {
        public string Build(IEnumerable<IHtmlAttribute> attributes)
        {
            if(attributes == null || !attributes.Any())
            {
                return "";
            }

            StringBuilder sb = new StringBuilder();

            List<string> attributeStrings = new List<string>();

            attributes = Consolidate(attributes);

            foreach(IHtmlAttribute a in attributes)
            {
                sb.Clear();

                sb.Append(a.AttributeName);
                sb.Append("=\"");
                sb.Append(string.Join(" ", a.Values.Select(x => x.Replace("\"", "").Trim())));
                sb.Append("\"");

                attributeStrings.Add(sb.ToString());
            }

            return string.Join(" ", attributeStrings);
        }

        private IEnumerable<IHtmlAttribute> Consolidate(IEnumerable<IHtmlAttribute> attributes)
        {
            //attributes = attributes.Distinct(x => x.AttributeName);

            return attributes;
        }
    }
}