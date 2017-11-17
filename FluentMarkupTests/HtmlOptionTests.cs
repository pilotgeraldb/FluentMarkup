using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using FluentMarkup.Html;

namespace FluentMarkupTests  
{
    public class HtmlOptionTests
    {
        [Fact]
        public void ShouldCreateOption()
        {
            IElement el = new Option();

            string result = el.Render();

            Assert.Equal("<option></option>", result);
        }
    }
}