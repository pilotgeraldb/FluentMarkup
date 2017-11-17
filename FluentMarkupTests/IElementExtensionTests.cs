using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using FluentMarkup.Html;

namespace FluentMarkupTests
{
    public class IElementExtensionTests
    {
        public HtmlDocument Document()
        {
            var document = new HtmlDocument();

            var form = new Form()
                .Action("")
                .Method("post");
                
            var div1 = new Container()
                .Class("row")
                .Text("this is some text in div.. dont get mad bruh");
                
            var div2 = new Container()
                .Class("col");

            var input1 = new Input()
                .Type(HtmlInputType.Text)
                .DontSelfClose()
                .Placeholder("Input 1")
                .ID("input_1")
                .WithLabel("Input One")
                    .Data("abcdefg", "123456");

            div2.AddChild(input1);
            div1.AddChild(div2);
            form.AddChild(div1);

            document.AddChild(form);

            return document;
        }

        [Fact]
        public void ShouldRender()
        {
            string result = Document().Render();

            string expected = "<html><form action=\"\" method=\"post\"><div class=\"row\">this is some text in div.. dont get mad bruh<div class=\"col\"><label for=\"input_1\" data-abcdefg=\"123456\">Input One<input type=\"text\" placeholder=\"Input 1\" id=\"input_1\"></input></label></div></div></form></html>";

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ShouldDetectChildren()
        {
            bool result = Document().HasChildren();

            Assert.True(result);
        }

        [Fact]
        public void ShouldReturnData()
        {
            IElement element = new BaseElement();
            element.Data("test", "this is a test");

            string result = element.Data("test");

            Assert.Equal("this is a test", result);
        }

        [Fact]
        public void ShouldReturnAttribute()
        {
            IElement element = new BaseElement();
            element.Attr("test", "test_value");

            IHtmlAttribute result = element.Attr("test");

            Assert.Equal("test", result.AttributeName);
            Assert.Equal("test_value", result.Values[0]);
        }

        [Fact]
        public void ShouldReturnAttributeWithMultipleValues()
        {
            IElement element = new BaseElement();
            element.Attr("test", "test_value test_value2");

            IHtmlAttribute result = element.Attr("test");

            Assert.Equal("test", result.AttributeName);
            Assert.Equal("test_value test_value2", result.Values[0]);
        }

        [Fact]
        public void ShouldAddTextElement()
        {
            IElement element = new BaseElement();
            element.Text("this is a test");

            Assert.IsType<Text>(element.Children[0]);
        }

        [Fact]
        public void ShouldGetSingleTextForElement()
        {
            IElement element = new BaseElement();
            element.Text("this is a test");

            Assert.Equal("this is a test", element.Text());
        }

        [Fact]
        public void ShouldGetMultipleTextForElement()
        {
            IElement element = new BaseElement();
            element.Text("this is a test");
            element.AddChild(new Input());
            element.Text("this is another test");
            Assert.Equal("this is a test this is another test", element.Text());
        }

        [Fact]
        public void ShouldSetElementID()
        {
            IElement element = new BaseElement();

            element.ID("test");

            IHtmlAttribute idAttr = element.Attributes
                .Where(x => x.AttributeName.Equals("id"))
                .FirstOrDefault();

            Assert.Equal("test", idAttr.Values[0]);
        }

        [Fact]
        public void ShouldGetElementID()
        {
            IElement element = new BaseElement();

            var attr = new HtmlAttribute()
            {
                AttributeName = "id",
                Values = new List<string>() { "test"  }
            };

            element.Attributes.Add(attr);

            string result = element.ID();

            Assert.Equal("test", result);
        }

        [Fact]
        public void ShouldSetElementName()
        {
            IElement element = new BaseElement();

            element.Name("test");

            IHtmlAttribute attr = element.Attributes
                .Where(x => x.AttributeName.Equals("name"))
                .FirstOrDefault();

            Assert.Equal("test", attr.Values[0]);
        }

        [Fact]
        public void ShouldSetReadonly()
        {
            IElement element = new BaseElement();

            element.Readonly();

            IHtmlAttribute attr = element.Attributes
                .Where(x => x.AttributeName.Equals("readonly"))
                .FirstOrDefault();

            Assert.Equal("readonly", attr.Values[0]);
        }

        [Fact]
        public void ShouldSetDisabled()
        {
            IElement element = new BaseElement();

            element.Disabled();

            IHtmlAttribute attr = element.Attributes
                .Where(x => x.AttributeName.Equals("disabled"))
                .FirstOrDefault();

            Assert.Equal("disabled", attr.Values[0]);
        }

        [Fact]
        public void ShouldGetElementName()
        {
            IElement element = new BaseElement();

            var attr = new HtmlAttribute()
            {
                AttributeName = "name",
                Values = new List<string>() { "test"  }
            };

            element.Attributes.Add(attr);

            string result = element.Name();

            Assert.Equal("test", result);
        }

        [Fact]
        public void ShouldCloneElement()
        {
            IElement element = new BaseElement();
            element.ID("testID");

            IElement clone = element.Clone();

            string elementid = clone.ID();
            string elementuniqueid = clone.ElementID;

            Assert.Equal("testID", elementid);
            Assert.NotEqual(element.ElementID, elementuniqueid);
        }

        [Fact]
        public void ShouldCloneElementWithChildren()
        {
            IElement element = new BaseElement()
            .ID("testID")
            .AddChild(new BaseElement());

            IElement clone = element.Clone();

            string elementid = clone.ID();
            string elementuniqueid = clone.ElementID;

            Assert.Equal("testID", elementid);
            Assert.Single(clone.Children);
            Assert.NotEqual(element.ElementID, elementuniqueid);
        }

        [Fact]
        public void ShouldCloneElementWithAttributes()
        {
            IElement element = new BaseElement()
            .ID("testID")
            .Attr("test", "test");

            IElement clone = element.Clone();

            string elementid = clone.ID();
            string elementuniqueid = clone.ElementID;

            Assert.Equal("testID", elementid);
            Assert.Equal(2, clone.Attributes.Count());
            Assert.NotEqual(element.ElementID, elementuniqueid);
        }

        [Fact]
        public void ShouldWrapElement()
        {
            IElement e = new Input().WrapWith(new Label().Text("test"));

            string result = e.Render();

            Assert.Equal("<label>test<input/></label>", result);
        }
    }
}