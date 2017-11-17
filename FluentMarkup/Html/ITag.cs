using System;

namespace FluentMarkup.Html
{
    public interface ITag
    {
        string TagID { get; set; }
        string Text { get; set; }
        bool IsSelfClosing { get; set; } 
        bool Disabled { get; set; }
    }
}