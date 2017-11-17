using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace FluentMarkup.Html
{
    public static class IElementExtensions
    {
        public static T AddChild<T>(this T element, IElement child) where T : IElement
        {
            element.Children.Add(child);

            return element;
        }

        public static T AddChildren<T>(this T element, IEnumerable<IElement> children) where T : IElement
        {
            element.Children.AddRange(children);

            return element;
        }

        public static T AddChildren<T>(this T element, params IElement[] children) where T : IElement
        {
            element.Children.AddRange(children);

            return element;
        }

        public static T Clone<T>(this T element) where T : IElement
        {
            IElement e2 = (IElement)Activator.CreateInstance(element.GetType());

            foreach(var propA in element.GetType().GetProperties())
            {
                foreach(var propB in e2.GetType().GetProperties())
                {
                    if(propB.Name != propA.Name )
                    { 
                        continue;
                    }

                    if(propB.CanWrite)
                    {
                        propB.SetValue(e2, propA.GetValue(element, null));
                    }
                }
            };

            return (T)e2;
        }

        public static T WrapWith<T>(this IElement element, T wrapper) where T : IElement
        {
            element = (T)wrapper.Clone()
                .AddChild(element.Clone());

            return (T)element;
        }

        public static T Class<T>(this T element, string className) where T : IElement
        {
            new HtmlAttributeManager(element)
                .AddOrMerge(new HtmlAttribute()
                {
                    AttributeName = "class",
                    Values = new List<string>() { className.Trim() }
                });

            return element;
        }

        public static T Classes<T>(this T element, params string[] classes) where T : IElement
        {
            var existingClassAttribute = element.Attr("class");

            if(existingClassAttribute != null)
            {
                foreach(string className in classes)
                {
                    existingClassAttribute.Values.Add(className.Trim());
                }
            }
            else
            {
                element.Attributes.Add(new HtmlAttribute()
                {
                    AttributeName = "class",
                    Values = classes.ToList()
                });
            }

            return element;
        }

        public static T Disabled<T>(this T element) where T : IElement
        {
            new HtmlAttributeManager(element)
                .AddOrOverwrite(new HtmlAttribute()
                {
                    AttributeName = "disabled",
                    Values = new List<string>() { "disabled"  }
                });

            return element;
        }

        public static T Readonly<T>(this T element) where T : IElement
        {
            new HtmlAttributeManager(element)
                .AddOrOverwrite(new HtmlAttribute()
                {
                    AttributeName = "readonly",
                    Values = new List<string>() { "readonly"  }
                });

            return element;
        }

        public static T Classes<T>(this T element, string className) where T : IElement
        {
            var existingClassAttribute = element.Attr("class");

            IEnumerable<string> classesToAdd = className.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            classesToAdd.ToList().ForEach((x) => { x = x.Trim(); });

            if(existingClassAttribute != null)
            {
                existingClassAttribute.Values.AddRange(classesToAdd);
            }
            else
            {
                element.Attributes.Add(new HtmlAttribute()
                {
                    AttributeName = "class",
                    Values = classesToAdd.ToList()
                });
            }

            return element;
        }

        public static T Name<T>(this T element, string name) where T : IElement
        {
            new HtmlAttributeManager(element)
                .AddOrOverwrite(new HtmlAttribute()
                {
                    AttributeName = "name",
                    Values = new List<string>() { name }
                });

            return element; 
        }

        public static string Name<T>(this T element) where T : IElement
        {
            return new HtmlAttributeManager(element)
                .Value("name");            
        }

        public static T ID<T>(this T element, string id) where T : IElement
        {
            new HtmlAttributeManager(element)
                .AddOrOverwrite(new HtmlAttribute()
                {
                    AttributeName = "id",
                    Values = new List<string>() { id }
                });

            return element;            
        }

        public static string ID<T>(this T element) where T : IElement
        {
            return new HtmlAttributeManager(element)
                .Value("id");   
        }

        public static T Text<T>(this T element, string text) where T : IElement
        {
            element.Children.Add(new Text() { Value = text });

            return element;
        }

        public static string Text<T>(this T element) where T : IElement
        {
            List<string> text = new List<string>();

            element.Children
                .Where(x => (x is Text) == true)
                .ToList()
                .ForEach((x) => { text.Add(x.Render()); });

            return string.Join(" ", text);
        }

        public static string Val<T>(this T element) where T : IElement
        {
            IHtmlAttribute attr = element.Attributes
                .Where(x => x.AttributeName.ToLower().Trim().Equals("value"))
                .FirstOrDefault();

            if(attr != null)
            {
                return attr.Values[0]; 
            }  

            return null;
        }

        public static T Attr<T>(this T element, string name, string value) where T : IElement
        {
            new HtmlAttributeManager(element)
                .Add(name, value);

            return element;
        }

        public static IHtmlAttribute Attr<T>(this T element, string name) where T : IElement
        {
            var existingClassAttribute = element.Attributes
                .Where(x => x.AttributeName.ToLower().Trim() == name.ToLower().Trim())
                .FirstOrDefault();

            return existingClassAttribute;
        }

        public static T Data<T>(this T element, string name, string value) where T : IElement
        {
            new HtmlAttributeManager(element)
                .AddOrOverwrite(new HtmlAttribute()
                {
                    AttributeName = "data-" + name.ToLower().Trim(), 
                    Values = new List<string>() { value }
                });

            return element;
        }

        public static string Data<T>(this T element, string name) where T : IElement
        {
            string result = new HtmlAttributeManager(element)
                .Value("data-" + name.ToLower().Trim());
 
            return result;
        }

        public static bool HasChildren<T>(this T element) where T : IElement
        {
            return (element != null && element.Children != null && element.Children.Any());
        }
    }
}