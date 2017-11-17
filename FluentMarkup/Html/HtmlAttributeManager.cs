using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace FluentMarkup.Html
{
    public interface IHtmlAttributeManager
    {
        void Add(string name, string value);
        void Remove(string name);
    }

    public interface IHtmlAttributeMerger
    {
        void AddOrMerge(IHtmlAttribute attribute);
        void AddOrOverwrite(IHtmlAttribute attribute);
    }

    public class HtmlAttributeManager : IHtmlAttributeManager, IHtmlAttributeMerger
    {
        private IElement Element { get; set; }

        public HtmlAttributeManager(IElement element)
        {
            Element = element;
        }

        public void Add(string name, string value)
        {
            IHtmlAttribute existingAttribute = Element.Attr(name);

            if(existingAttribute != null)
            {
                existingAttribute.Values.Add(value);
            }
            else
            {
                Element.Attributes.Add(new HtmlAttribute()
                {
                    AttributeName = name,
                    Values = new List<string>() { value }
                });
            }
        }

        public IEnumerable<string> Values(string name)
        {
            IEnumerable<string> values = Element.Attributes
            .Where(x => x.AttributeName.Equals(name))
            .SelectMany(x => x.Values);

            return values;
        }

        public string Value(string name)
        {
            string result = null;

            // IEnumerable<string> values = Element.Attributes
            // .Where(x => x.AttributeName.Equals(name))
            // .FirstOrDefault()?.Values;

            IEnumerable<string> values = Values(name);

            if(values != null && values.Any())
            {
                result = values.ToList()[0];
            }

            return result;
        }

        public void AddOrOverwrite(IHtmlAttribute attribute)
        {
            IHtmlAttribute existingAttr = Element.Attr(attribute.AttributeName);

            if(existingAttr == null)
            {
                Element.Attributes.Add(attribute);
                return;
            }
            else
            {
                existingAttr.Values = attribute.Values;
            }
        }

        public void AddOrMerge(IHtmlAttribute attribute)
        {
            IHtmlAttribute existingAttr = Element.Attr(attribute.AttributeName);

            if(existingAttr == null)
            {
                Element.Attributes.Add(attribute);
                return;
            }
            else
            {
                existingAttr.Values = existingAttr.Values
                    .Concat(attribute.Values)
                    .Distinct()
                    .ToList();
            }
        }

        public void Remove(string name)
        {
            IHtmlAttribute existingAttr = Element.Attr(name);

            if(existingAttr != null)
            {
                Element.Attributes.Remove(existingAttr);
            }
        }
    }
}