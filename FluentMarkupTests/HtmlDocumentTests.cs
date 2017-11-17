using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using FluentMarkup.Html;

namespace FluentMarkupTests
{
    public class HtmlDocumentTests
    {
        [Fact]
        public void ShouldCreateHtmlDocument()
        {
            string result = new HtmlDocument().Render();

            Assert.Equal("<html></html>", result);
        }
    }
}