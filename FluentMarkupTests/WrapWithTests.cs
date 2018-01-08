using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using FluentMarkup.Html;

namespace FluentMarkupTests
{
    public class WrapWithTests
    {
        [Fact]
        public void ShouldWrapElement()
        {
            IElement e = new Input().WrapWith(new Label().Text("test"));

            string result = e.Render();

            Assert.Equal("<label>test<input/></label>", result);
        }

        [Fact]
        public void ShouldWrapElementAndPersistAttributes()
        {
            IElement e = new Input().WrapWith(new Label().Text("test").Attr("test", "test"));

            string result = e.Render();

            Assert.Equal("<label test=\"test\">test<input/></label>", result);
        }

        [Fact]
        public void ShouldWrapElementAndPersistClasses()
        {
            IElement e = new Input().WrapWith(new Label().Text("test").Class("test"));

            string result = e.Render();

            Assert.Equal("<label class=\"test\">test<input/></label>", result);
        }

        [Fact]
        public void ShouldWrapIconWithAnchor()
        {
            IElement e = new Icon().WrapWith(new Anchor().Href("test").Text("test").Class("test"));

            string result = e.Render();

            Assert.Equal("<a href=\"test\" class=\"test\">test<i></i></a>", result);
        }

        [Fact]
        public void ShouldAddWrappedElementToContainer()
        {
            IElement e = new Icon().WrapWith(new Anchor().Href("test").Text("test").Class("test"));

            IElement div = new Container();
            div.AddChild(e);

            string result = div.Render();

            Assert.Equal("<div><a href=\"test\" class=\"test\">test<i></i></a></div>", result);
        }
    }
}