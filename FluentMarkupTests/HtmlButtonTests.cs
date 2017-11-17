using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using FluentMarkup.Html;

namespace FluentMarkupTests  
{
    public class HtmlButtonTests
    {
        [Fact]
        public void ShouldCreateButton()
        {
            string result = new Button().Render();

            Assert.Equal("<button></button>", result);
        }

        [Fact]
        public void ShouldCreateButtonWithButtonType()
        {
            string result = new Button().Type(HtmlButtonType.Button).Render();

            Assert.Equal("<button type=\"button\"></button>", result);
        }

        [Fact]
        public void ShouldCreateButtonWithSubmitType()
        {
            string result = new Button().Type(HtmlButtonType.Submit).Render();

            Assert.Equal("<button type=\"submit\"></button>", result);
        }
    }
}