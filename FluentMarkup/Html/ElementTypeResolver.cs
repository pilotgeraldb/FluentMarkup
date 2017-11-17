using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FluentMarkup.Html
{
    internal class ElementTypeResolver : ITypeResolver<IElement>
    {
        private IList<string> Namespaces { get; set; }

        private Type Type { get; set; }

        public ElementTypeResolver()
        {
            Namespaces = new List<string>()
            {
                "FluentMarkup.Html"
            };
        }

        public ITypeResolver<IElement> WithNamespace(string ns)
        {
            Namespaces.Add(ns);

            return this;
        }

        public IElement Instance()
        {
            if(Type == null)
            {
                return null;
            }

            return (IElement)Activator.CreateInstance(Type);
        }

        public ITypeResolver<IElement> Resolve(string type)
        {
            Type = null;

            if(string.IsNullOrWhiteSpace(type))
            {
                return this;
            }

            Type = FindType(type);

            if(Type == null && !type.Contains("."))
            {
                foreach(string ns in Namespaces)
                {
                    if(!type.ToLower().Trim().StartsWith(ns.ToLower().Trim()))
                    {
                        Type = FindType(ns + "." + type);
                    }
                }
            }            

            return this;
        }

        private Type FindType(string type)
        {
            try
            {
                var t = typeof(IElement);

                var types = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(s => s.GetTypes())
                    .Where(p => t.IsAssignableFrom(p))
                    .Where(p => p.Name.ToLower().Trim() == type.ToLower().Trim() || p.FullName.ToLower().Trim() == type.ToLower().Trim());
                

                var more_types = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(p => t.IsAssignableFrom(p))
                    .Where(p => p.Name.ToLower().Trim() == type.ToLower().Trim() || p.FullName.ToLower().Trim() == type.ToLower().Trim());

                types = types.Concat(more_types);

                return types.First();
            }
            catch
            {
                Console.WriteLine($"in ElementTypeResolver, could not resolve element for {type}");
            }

            return null;
        }
    }
}   