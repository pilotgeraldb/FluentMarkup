using System;

namespace FluentMarkup.Html
{
    public class Tag : ITag
    {
        public Tag(string text)
        {
            TagID = Guid.NewGuid().ToString();
            Text = text.ToLower().Trim();
        }

        public string TagID { get; set; }
        public string Text { get; set; }
        public bool Disabled { get; set; }
        public bool IsSelfClosing { get; set; }
    }
}