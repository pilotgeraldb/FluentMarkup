using System.Collections.Generic;

namespace FluentMarkup.Parsing.Json
{
    internal class ElementDescription
    {
        public ElementDescription()
        {
            Type = "FluentMarkup.Html.BaseElement";
        }

        public string Type  { get; set; }
        public string Tag { get; set; }
        public bool SelfClosing { get; set; }
        public List<ElementAttribute> Attributes{ get; set ;}
        public string ParentID { get; set; }

        public bool HasType
        {
            get
            {
                return !string.IsNullOrWhiteSpace(Type);
            }
        }

        public bool HasTag
        {
            get
            {
                return !string.IsNullOrWhiteSpace(Tag);
            }
        }
    }
}   