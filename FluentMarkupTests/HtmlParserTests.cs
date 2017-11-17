using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using FluentMarkup.Parsing.Html;
using FluentMarkup.Html;
using System.IO;
using FluentMarkupTests.Helpers;

namespace FluentMarkupTests  
{
    public class HtmlParserTests
    {
        [Fact]
        public void ShouldParseHtml()
        {
            string input = FileHelper.GetFile(@"test0.html");

            IElement element = new HtmlParser().Parse(input);

        }
    }
}