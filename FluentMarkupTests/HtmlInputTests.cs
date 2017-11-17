using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using FluentMarkup.Html;

namespace FluentMarkupTests  
{
    public class HtmlInputTests
    {
        [Fact]
        public void ShouldCreateInput()
        {
            IElement el = new Input();

            string result = el.Render();

            Assert.Equal("<input/>", result);
        }

        [Fact]
        public void ShouldCreateInputWithID()
        {
            IElement el = new Input().ID("testInput");

            string result = el.Render();

            Assert.Equal("<input id=\"testInput\"/>", result);
        }

        [Fact]
        public void ShouldCreateInputWithIDAndName()
        {
            IElement el = new Input().ID("testInput").Name("test_input");

            string result = el.Render();

            Assert.Equal("<input id=\"testInput\" name=\"test_input\"/>", result);
        }

        [Fact]
        public void ShouldCreateCheckbox()
        {
            IElement el = new Input().Type(HtmlInputType.Checkbox);

            string result = el.Render();

            Assert.Equal("<input type=\"checkbox\"/>", result);
        }

        [Fact]
        public void ShouldCreateRadio()
        {
            IElement el = new Input().Type(HtmlInputType.Radio);

            string result = el.Render();

            Assert.Equal("<input type=\"radio\"/>", result);
        }

        [Fact]
        public void ShouldCreateInputWithLabel()
        {
            IElement e = new Input().WithLabel("test");

            string result = e.Render();

            Assert.Equal("<label>test<input/></label>", result);
        }
    }
}