using System.Collections.Generic;

namespace FluentMarkup.Html
{
    public interface ICompoundElement
    {
        IEnumerable<IElement> Elements { get; }
    }
}