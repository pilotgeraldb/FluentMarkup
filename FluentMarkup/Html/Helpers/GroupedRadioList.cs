using System;
using System.Collections.Generic;
using System.Linq;
using FluentMarkup.Html;

namespace FluentMarkup.Html.Helpers
{
    public class GroupedRadioList : ICompoundElement
    {
        public IEnumerable<IElement> Elements { get; set; }

        public GroupedRadioList(string groupName, IEnumerable<string> labels)
        {
            var container = new Container()
                .Classes("grouped-radio-list");

            foreach(string l in labels)
            {
                IElement element = new Input()
                    .Type(HtmlInputType.Radio)
                    .Name(groupName)
                    .WithLabel(l);

                container.AddChild(element);
            }

            Elements = new List<IElement>() { container };
        }
    }
}