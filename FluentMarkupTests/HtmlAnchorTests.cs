using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using FluentMarkup.Html;

namespace FluentMarkupTests  
{
    public class HtmlAnchorTests
    {
        [Fact]
        public void ShouldCreateAnchor()
        {
            IElement el = new Anchor();

            string result = el.Render();

            Assert.Equal("<a></a>", result);
        }

        [Fact]
        public void ShouldCreateAnchorWithInnerText()
        {
            IElement el = new Anchor().Text("inner text");

            string result = el.Render();

            Assert.Equal("<a>inner text</a>", result);
        }

        [Fact]
        public void ShouldCreateAnchorWithHref()
        {
            IElement el = new Anchor().Href("www.google.com");

            string result = el.Render();

            Assert.Equal("<a href=\"www.google.com\"></a>", result);
        }
    }
}