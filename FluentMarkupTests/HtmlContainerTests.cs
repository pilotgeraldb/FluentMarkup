using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using FluentMarkup.Html;

namespace FluentMarkupTests  
{
    public class HtmlContainerTests
    {
        [Fact]
        public void ShouldCreateContainer()
        {
            string result = new Container().Render();

            Assert.Equal("<div></div>", result);
        }

        [Fact]
        public void ShouldCreateContainerWithAClass()
        {
            string result = new Container()
                .Class("class-1")
                .Render();

            Assert.Equal("<div class=\"class-1\"></div>", result);
        }
        
        [Fact]
        public void ShouldCreateContainerWithMultipleClasses()
        {
            string result = new Container()
                .Class("class-1")
                .Class("class-2")
                .Class("class-3")
                .Render();

            Assert.Equal("<div class=\"class-1 class-2 class-3\"></div>", result);
        }

        [Fact]
        public void ShouldCreateContainerWithMultipleClasses2()
        {
            string result = new Container()
                .Classes("class-1 class-2 class-3")
                .Render();

            Assert.Equal("<div class=\"class-1 class-2 class-3\"></div>", result);
        }

        [Fact]
        public void ShouldCreateContainerWithMultipleClassesAndID()
        {
            string result = new Container()
                .Class("class-1")
                .Class("class-2")
                .Class("class-3")
                .ID("testdiv")
                .Render();

            Assert.Equal("<div class=\"class-1 class-2 class-3\" id=\"testdiv\"></div>", result);
        }
    }
}