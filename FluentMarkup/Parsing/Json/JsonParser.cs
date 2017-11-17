using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using FluentMarkup.Html;
using Newtonsoft.Json;

namespace FluentMarkup.Parsing.Json
{
    public class JsonParser : IParser
    {
        private ITypeResolver<IElement> ElementTypeResolver { get; set; }

        public JsonParser()
        {
            ElementTypeResolver = new ElementTypeResolver();
        }

        public IParser WithNamespace(string ns)
        {
            ElementTypeResolver.WithNamespace(ns);

            return this;
        }

        public IElement Parse(string input)
        {
            IElement result = null;

            result = FromContainer(JsonConvert.DeserializeObject<ElementContainer>(input));

            return result;
        }

        private IElement FromContainer(ElementContainer container)
        {
            ElementHierarchy hierarchy = new ElementHierarchy();
            
            container.Elements.ForEach((ed) =>
            {
                IElement e = null;
                
                if (ed.HasTag)
                {
                    e = new BaseElement();
                    (e as BaseElement).Tag = new Tag(ed.Tag);
                }
                else if(ed.HasType)
                {
                    e = ElementTypeResolver.Resolve(ed.Type).Instance();
                }

                AddAttributes(e, ed);
                hierarchy.Add(e, ed.ParentID);
            });

            IElement result = hierarchy.Collapse();

            return result;
        }

        private void AddAttributes(IElement element, ElementDescription description)
        {
            if(element == null || description == null || description.Attributes == null)
            {
                return;
            }

            description.Attributes.ForEach((ea) =>
            {
                element.Attributes.Add(new HtmlAttribute()
                {
                    AttributeName = ea.AttributeName,
                    Values = ea.Values
                });
            });
        }
    }
}   