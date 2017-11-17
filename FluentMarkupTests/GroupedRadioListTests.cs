using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using FluentMarkup.Html;
using FluentMarkup.Html.Helpers;

namespace FluentMarkupTests  
{
    public class HtmlGroupedRadioListTests
    {
        [Fact]
        public void ShouldConvertToElement()
        {
            ICompoundElement el = new GroupedRadioList("testGroup", new List<string>() 
            {  
                "radio 1",
                "radio 2"
            });

            IElement result = el.ToElement();

            Assert.IsType<BaseElement>(result);
        }

        [Fact]
        public void ShouldHaveLabels()
        {
            ICompoundElement el = new GroupedRadioList("testGroup", new List<string>() 
            {  
                "radio 1",
                "radio 2"
            });

            IElement result = el.ToElement();

            Assert.NotEmpty(result.Children);
            Assert.Equal(2, result.Children[0].Children.Count());
            Assert.IsType<Label>(result.Children[0].Children[0]);
            Assert.IsType<Label>(result.Children[0].Children[1]);
        }

        [Fact]
        public void ShouldHaveInputs()
        {
            ICompoundElement el = new GroupedRadioList("testGroup", new List<string>() 
            {  
                "radio 1",
                "radio 2"
            });

            IElement result = el.ToElement();

            Assert.IsType<Input>(result.Children[0].Children[0].Children[1]);
            Assert.IsType<Input>(result.Children[0].Children[1].Children[1]);
        }

        [Fact]
        public void ShouldRenderGroupedRadioList()
        {
            ICompoundElement el = new GroupedRadioList("testGroup", new List<string>() 
            {  
                "radio 1",
                "radio 2"
            });

            IElement result = el.ToElement();
            
            string rendering = result.Render();

            Assert.Equal("<div class=\"grouped-radio-list\"><label>radio 1<input type=\"radio\" name=\"testGroup\"/></label><label>radio 2<input type=\"radio\" name=\"testGroup\"/></label></div>", rendering);
        }
    }
}