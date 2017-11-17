using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using FluentMarkup.Html;

namespace FluentMarkupTests  
{
    public class HtmlSelectTests
    {
        [Fact]
        public void ShouldCreateSelectListWithOptions()
        {
            IElement select = new Select();
            IElement item1 = new Option().Text("this is Option 1");
            IElement item2 = new Option().Text("this is Option 2");
            IElement item3 = new Option().Text("this is Option 3");

            select.AddChild(item1);
            select.AddChild(item2);
            select.AddChild(item3);

            string result = select.Render();

            Assert.Equal("<select><option>this is Option 1</option><option>this is Option 2</option><option>this is Option 3</option></select>", result);
        }

        [Fact]
        public void ShouldCreateSelectListWithOptionsThatHaveClasses()
        {
            IElement select = new Select();
            IElement item1 = new Option().Classes("list-item item class-1").Text("this is Option 1");
            IElement item2 = new Option().Text("this is Option 2");
            IElement item3 = new Option()
                .Class("list-item")
                .Class("item")
                .Class("class-1")
                .Text("this is Option 3");

            select.AddChild(item1);
            select.AddChild(item2);
            select.AddChild(item3);

            string result = select.Render();

            Assert.Equal("<select><option class=\"list-item item class-1\">this is Option 1</option><option>this is Option 2</option><option class=\"list-item item class-1\">this is Option 3</option></select>", result);
        }
    }
}