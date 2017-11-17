using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using FluentMarkup.Html;

namespace FluentMarkupTests  
{
    public class HtmlBlockQuoteTests
    {
        [Fact]
        public void ShouldCreateBlockquote()
        {
            string result = new Blockquote().Render();

            Assert.Equal("<blockquote></blockquote>", result);
        }
    }
}