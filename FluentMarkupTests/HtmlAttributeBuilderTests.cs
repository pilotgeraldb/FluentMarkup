using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using FluentMarkup.Html;

namespace FluentMarkupTests  
{
    public class HtmlAttributeBuilderTests
    {
        [Fact]
        public void ShouldCreateSingleAttributeWithSingleValue()
        {
            List<IHtmlAttribute> attributes = new List<IHtmlAttribute>();

            attributes.Add(new HtmlAttribute()
            {
                AttributeName="test",
                Values = new List<string>() { "test_value" }
            });

            string result = new HtmlAttributeBuilder().Build(attributes);

            Assert.Equal("test=\"test_value\"", result);
        }

        [Fact]
        public void ShouldCreateSingleAttributeWithMultipleValues()
        {
            List<IHtmlAttribute> attributes = new List<IHtmlAttribute>();

            attributes.Add(new HtmlAttribute()
            {
                AttributeName="test",
                Values = new List<string>() { "test_value", "test_value2" }
            });

            string result = new HtmlAttributeBuilder().Build(attributes);

            Assert.Equal("test=\"test_value test_value2\"", result);
        }

        [Fact]
        public void ShouldCreateMultipleDifferentAttributesWithSingleValue()
        {
            List<IHtmlAttribute> attributes = new List<IHtmlAttribute>();

            attributes.Add(new HtmlAttribute()
            {
                AttributeName="test",
                Values = new List<string>() { "test_value" }
            });

            attributes.Add(new HtmlAttribute()
            {
                AttributeName="test2",
                Values = new List<string>() { "test_value2" }
            });

            string result = new HtmlAttributeBuilder().Build(attributes);

            Assert.Equal("test=\"test_value\" test2=\"test_value2\"", result);
        }

        [Fact]
        public void ShouldCreateMultipleDifferentAttributesWithMultipleValues()
        {
            List<IHtmlAttribute> attributes = new List<IHtmlAttribute>();

            attributes.Add(new HtmlAttribute()
            {
                AttributeName="test",
                Values = new List<string>() { "test_value", "test_value1" }
            });

            attributes.Add(new HtmlAttribute()
            {
                AttributeName="test2",
                Values = new List<string>() { "test_value2", "test_value3" }
            });

            string result = new HtmlAttributeBuilder().Build(attributes);

            Assert.Equal("test=\"test_value test_value1\" test2=\"test_value2 test_value3\"", result);
        }
    }
}