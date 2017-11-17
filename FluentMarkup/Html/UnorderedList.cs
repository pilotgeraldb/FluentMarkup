using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace FluentMarkup.Html
{
    public class UnorderedList : AbstractElement
    {
        public UnorderedList()
        {
            Tag = new Tag("ul");
        }

        public UnorderedList(IEnumerable<ListItem> listItems)
        {
            Tag = new Tag("ul");
            WithListItems(listItems);
        }

        public UnorderedList WithListItems(IEnumerable<ListItem> listItems)
        {
            Children.AddRange(listItems);

            return this;
        }
    }
}