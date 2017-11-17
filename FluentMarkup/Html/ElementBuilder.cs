using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace FluentMarkup.Html
{
    public class ElementBuilder : IElementBuilder
    {
        private ITagBuilder TagBuilder { get; set; }

        public ElementBuilder()
        {
            TagBuilder = new TagBuilder();
        }

        public string Build(IElement element)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(TagBuilder.OpenTag(element));
            
            foreach(IElement e in element.Children)
            {
                sb.Append(e.Render());
            }

            sb.Append(TagBuilder.CloseTag(element));

            return sb.ToString();
        }
    }
}