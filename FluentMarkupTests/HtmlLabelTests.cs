using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using FluentMarkup.Html;

namespace FluentMarkupTests  
{
    public class HtmlLabelTests
    {
        [Fact]
        public void ShouldCreateLabel()
        {
            IElement label = new Label();

            string result = label.Render();

            Assert.Equal("<label></label>", result);
        }

        [Fact]
        public void ShouldCreateLabelWithFor()
        {
            IElement label = new Label().For("someElementID");

            string result = label.Render();

            Assert.Equal("<label for=\"someElementID\"></label>", result);
        }

        [Fact]
        public void ShouldCreateLabelWithForUsingAnIElement()
        {
            IElement input = new Input().ID("someElementID");
            IElement label = new Label().For(input);

            string result = label.Render();

            Assert.Equal("<label for=\"someElementID\"></label>", result);
        }
    }
}