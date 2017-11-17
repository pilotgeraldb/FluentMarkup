using System;

namespace FluentMarkup.Html
{
    public interface ITagBuilder
    {
        string OpenTag(IElement element);
        string CloseTag(IElement element);
    }
}