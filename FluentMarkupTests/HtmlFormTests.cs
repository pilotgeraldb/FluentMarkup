using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using FluentMarkup.Html;

namespace FluentMarkupTests
{
    public class HtmlFormTests
    {
        [Fact]
        public void ShouldCreateForm()
        {
            string result = new Form().Render();

            Assert.Equal("<form></form>", result);
        }

        [Fact]
        public void ShouldCreateFormWithAction()
        {
            string result = new Form()
                .Action("www.google.com")
                .Render();

            Assert.Equal("<form action=\"www.google.com\"></form>", result);
        }

        [Fact]
        public void ShouldCreateFormWithMethod()
        {
            string result = new Form()
                .Method("post")
                .Render();

            Assert.Equal("<form method=\"post\"></form>", result);
        }

        [Fact]
        public void ShouldCreateFormWithActionAndMethod()
        {
            string result = new Form()
                .Action("www.google.com")
                .Method("post")
                .Render();

            Assert.Equal("<form action=\"www.google.com\" method=\"post\"></form>", result);
        }

        [Fact]
        public void ShouldCreateFormWithActionAndMethodAndNestedContainer()
        {
            string result = new Form()
                .Action("www.google.com")
                .Method("post")
                .AddChild(new Container())
                .Render();

            Assert.Equal("<form action=\"www.google.com\" method=\"post\"><div></div></form>", result);
        }

        [Fact]
        public void ShouldCreateFormWithoutAutocompleteEnabled()
        {
            Form f = new Form()
                .NoAutoComplete();

            IHtmlAttribute attr = f.Attributes
                .Where(x => x.AttributeName.Equals("autocomplete"))
                .FirstOrDefault();

            Assert.Equal("off", attr.Values[0]);
        }

        [Fact]
        public void ShouldCreateFormThatDoesntValidate()
        {
            Form f = new Form()
                .NoValidate();

            IHtmlAttribute attr = f.Attributes
                .Where(x => x.AttributeName.Equals("novalidate"))
                .FirstOrDefault();

            Assert.Equal("novalidate", attr.Values[0]);
        }
    }
}