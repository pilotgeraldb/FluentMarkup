using System.Text;

namespace FluentMarkup.Html
{
    public class TagBuilder : ITagBuilder
    {
        private IHtmlAttributeBuilder AttributeBuilder { get; set; }
            
        public TagBuilder()
        {
            AttributeBuilder = new HtmlAttributeBuilder();
        }

        private string Attributes(IElement element)
        {
            StringBuilder sb = new StringBuilder();
            
            if(element.Tag == null || element.Tag.Disabled)
            {
                return sb.ToString();
            }

            sb.Append(AttributeBuilder.Build(element.Attributes));

            return sb.ToString();
        }

        public string CloseTag(IElement element)
        {
            StringBuilder sb = new StringBuilder();

            if(element.Tag == null || element.Tag.Disabled)
            {
                return sb.ToString();
            }

            if(!element.Tag.IsSelfClosing)
            {
                sb.Append("</");
                sb.Append(element.Tag.Text);
                sb.Append(">");
            }
            else
            {
                sb.Append("/>");
            }

            return sb.ToString();
        }

        public string OpenTag(IElement element)
        {
            StringBuilder sb = new StringBuilder();

            if(element.Tag == null || element.Tag.Disabled)
            {
                return sb.ToString();
            }

            sb.Append("<");
            sb.Append(element.Tag.Text);

            string attributes = this.Attributes(element);

            if(!string.IsNullOrWhiteSpace(attributes))
            {
                sb.Append(" " + attributes);
            }

            if(!element.Tag.IsSelfClosing)
            {
                sb.Append(">");
            }

            return sb.ToString();
        }
    }
}