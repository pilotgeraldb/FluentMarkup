using System.Collections.Generic;

namespace FluentMarkup.Html
{
    public interface IElement
    {
        string ElementID { get; }
        ITag Tag { get; } 
        List<IElement> Children { get; }
        List<IHtmlAttribute> Attributes { get; set; }
        string Render();

    }
}