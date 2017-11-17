using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using FluentMarkup.Parsing.Json;
using FluentMarkup.Html;
using FluentMarkupTests.Helpers;
using System.IO;

namespace FluentMarkupTests  
{
    public class JsonParserTests
    {
        [Fact]
        public void ShouldParseElementsFromJson()
        {
            string input = FileHelper.GetFile(@"Data/test0.json");

            IElement element = new JsonParser().Parse(input);

            Assert.IsType<Form>(element);
            Assert.Single(element.Attributes);
        }

        [Fact]
        public void ShouldParseElementsWithChildrenFromJson()
        {
            string input = FileHelper.GetFile(@"Data/test1.json");

            IElement element = new JsonParser().Parse(input);

            Assert.Single(element.Children);
            Assert.Single(element.Attributes);
            Assert.IsType<Form>(element);
            Assert.Equal("test_element", element.ID());
            Assert.Equal("test_element2", element.Children[0].ID());
        }

        [Fact]
        public void ShouldParseElementsWithMultipleNestedChildrenFromJson()
        {
            string input = FileHelper.GetFile(@"Data/test2.json");

            IElement element = new JsonParser().Parse(input);

            Assert.Equal("test_element1", element.ID());
            Assert.Equal("test_element2", element.Children[0].ID());
        }

        [Fact]
        public void ShouldParseThisJsonFile()
        {
            string input = FileHelper.GetFile(@"Data/test4.json");

            IElement element = new JsonParser().Parse(input);

            Assert.IsType<HtmlDocument>(element);
            Assert.Equal("test_element1", element.Children[0].ID());
        }

        [Fact]
        public void ShouldParseElementsFromJsonWithoutFullyQualifiedType()
        {
            string input = FileHelper.GetFile(@"Data/test3.json");

            IElement element = new JsonParser().Parse(input);

            Assert.IsType<Form>(element);
            Assert.Equal("test_element", element.ID());
        }

        [Fact]
        public void ShouldParseElementsWithCustomTags()
        {
            string input = FileHelper.GetFile(@"Data/test5.json");

            IElement element = new JsonParser().Parse(input);

            Assert.Equal("<custom id=\"test_element\"></custom>", element.Render());
        }
    }
}