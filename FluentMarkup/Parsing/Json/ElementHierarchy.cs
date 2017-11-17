using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using FluentMarkup.Html;

namespace FluentMarkup.Parsing.Json
{
    internal class ElementHierarchy
    {
        private List<IElement> AllElements { get; set; }
        private IElement Root { get; set; }
        private SortedList<string, string> ElementParentMap { get; set; }
        private SortedList<string, string> ParentElementMap { get; set; }

        public ElementHierarchy()
        {
            Initialize();
        }

        public IElement Add(IElement e, string parentID)
        {
            AllElements.Add(e);

            ElementParentMap.Add(e.ElementID, parentID);

            if(Root == null && string.IsNullOrWhiteSpace(parentID))
            {
                Root = e;
            }

            return e;
        }

        public IElement Collapse()
        {
            IEnumerable<IElement> children = AllElements.Where(x => x.ElementID != Root.ElementID);

            for(int i = 0; i < children.Count(); i++)
            {
                IElement el = children.ToList()[i];

                if(ElementParentMap.ContainsKey(el.ElementID))
                {
                    string parentID = ElementParentMap[el.ElementID];

                    IElement parentElement = AllElements.Where(x => x.ID() == parentID)
                        .FirstOrDefault();

                    if(parentElement != null)
                    {
                        parentElement.AddChild(el);
                    }
                }
            }

            return Root;
        }

        private void Initialize()
        {
            ElementParentMap = new SortedList<string, string>();
            ParentElementMap = new SortedList<string, string>();
            AllElements = new List<IElement>();
        }

        public void Reset()
        {
            Initialize();
        }
    }
}