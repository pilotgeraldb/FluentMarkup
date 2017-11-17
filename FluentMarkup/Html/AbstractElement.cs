using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Reflection;

namespace FluentMarkup.Html
{
    public abstract class AbstractElement : IElement
    {
        public AbstractElement()
        {
            ElementID = Guid.NewGuid().ToString();
            Children = new List<IElement>();
            Attributes = new List<IHtmlAttribute>();
            ElementBuilder = new ElementBuilder();
        }

        public string ElementID { get; private set; }
        public ITag Tag { get; set; } 
        public List<IElement> Children { get; set; }
        public List<IHtmlAttribute> Attributes { get; set; }
        private IElementBuilder ElementBuilder { get; set; }

        public virtual string Render()
        {
            return ElementBuilder.Build(this);
        }
    }
}