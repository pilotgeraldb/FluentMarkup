using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using FluentMarkup.Html;

namespace FluentMarkupTests  
{
    public class HtmlUnorderedListTests
    {
        [Fact]
        public void ShouldCreateUnorderedListWithItems()
        {
            IElement ul = new UnorderedList();
            IElement item1 = new ListItem().Text("this is list item 1");
            IElement item2 = new ListItem().Text("this is list item 2");
            IElement item3 = new ListItem().Text("this is list item 3");

            ul.AddChild(item1);
            ul.AddChild(item2);
            ul.AddChild(item3);

            string result = ul.Render();

            Assert.Equal("<ul><li>this is list item 1</li><li>this is list item 2</li><li>this is list item 3</li></ul>", result);
        }
    }
}