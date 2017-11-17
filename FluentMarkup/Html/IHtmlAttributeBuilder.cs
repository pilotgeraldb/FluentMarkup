using System.Collections.Generic;

namespace FluentMarkup.Html
{
    public interface IHtmlAttributeBuilder
    {
        string Build(IEnumerable<IHtmlAttribute> attributes);
    }
}