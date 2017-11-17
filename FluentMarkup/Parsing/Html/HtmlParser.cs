using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using FluentMarkup.Html;
using System.Text.RegularExpressions;

namespace FluentMarkup.Parsing.Html
{
    public class HtmlParser : IParser
    {
        private const string Pattern = "<\\/?\\w+((\\s+(\\w|-)+(\\s*=\\s*(?:\".*?\"|'.*?'|[\\^'\">\\s]+))?)+\\s*|\\s*)\\/?>";
        private const string AttributePattern = "(\\w|-)*=\\s*(?:\".*?\"|'.*?'|[\\^'\">\\s]+)";
        private ITypeResolver<IElement> ElementTypeResolver { get; set; }

        public HtmlParser()
        {
            ElementTypeResolver = new ElementTypeResolver();
        }

        public IElement Parse(string input)
        {
            Console.WriteLine("parsing html...");

            Regex matcher = new Regex(Pattern, RegexOptions.Multiline | RegexOptions.IgnoreCase);

            MatchCollection mc = matcher.Matches(input);

            if(mc.Count() <= 0)
            {
                Console.WriteLine("no tags found");
            }
            else
            {
                Console.WriteLine(mc.Count() + " tags found");
            }

            Console.WriteLine("parsing parent element");

            IElement parent = Parent(mc);

            if(parent != null)
            {
                Console.WriteLine(parent.Render());
            }
            else
            {
                Console.WriteLine("could not parse parent");
            }

            foreach(Match m in mc)
            {
                
            }

            Console.WriteLine("done parsing");

            return null;
        }

        private IElement Parent(MatchCollection mc)
        {
            Match startTagMatch = mc[0];

            string startTagName = startTagMatch.Value
                .Replace("<", "")
                .Replace(">", "")
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0];

            if(startTagName.ToLower().Trim().Equals("html"))
            {
                startTagName = "HtmlDocument";
            }

            IElement element = ElementTypeResolver.Resolve(startTagName).Instance();

            if(element != null)
            {
                element.Attributes.AddRange(Attributes(startTagMatch.Value));
            }

            return element;
        }

        private IElement Element(MatchCollection mc)
        {
            IElement element = null;

            for(int i = 0; i < mc.Count(); i++)
            {
                Match startTagMatch = mc[i];

                string startTagName = startTagMatch.Value
                    .Replace("<", "")
                    .Replace(">", "")
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0];

                bool isSelfClosing = startTagMatch.Value.EndsWith("/>");

                if(startTagName.ToLower().Trim().Equals("html"))
                {
                    startTagName = "HtmlDocument";
                }

                //find end tag

                ElementTypeResolver.Resolve(startTagName).Instance();

                if(element != null)
                {
                    element.Attributes.AddRange(Attributes(startTagMatch.Value));
                }
            }

            

            return element;
        }

        private IEnumerable<IHtmlAttribute> Attributes(string html)
        {
            html = html.Trim();

            List<IHtmlAttribute> attributes = new List<IHtmlAttribute>();

            Regex r = new Regex(AttributePattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);

            MatchCollection mc = r.Matches(html);

            foreach(Match m in mc)
            {
                List<string> parts = m.Value.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                string attributeName = parts[0];
                string attributeValues = parts[1];

                attributes.Add(new HtmlAttribute()
                {
                    AttributeName = attributeName,
                    Values = attributeValues.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList()
                });
            }

            return attributes;
        }
    }
}