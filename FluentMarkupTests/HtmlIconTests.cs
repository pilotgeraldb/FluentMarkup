using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using FluentMarkup.Html;

namespace FluentMarkupTests  
{
    public class HtmlIconTests
    {
        [Fact]
        public void ShouldCreateIcon()
        {
            IElement el = new Icon();

            string result = el.Render();

            Assert.Equal("<i></i>", result);
        }
    }
}