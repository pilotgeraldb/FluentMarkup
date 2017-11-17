using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace FluentMarkup.Html
{
    public class Select : AbstractElement
    {
        public Select()
        {
            Tag = new Tag("select");
        }

        public Select(IEnumerable<Option> options)
        {
            Tag = new Tag("select");
            WithOptions(options);
        }

        public Select WithOption(string display, string value)
        {
            IElement option = new Option().Attr("value", value).Text(display);

            Children.Add(option);

            return this;            
        }

        public Select WithOption(Option option)
        {
            Children.Add(option);

            return this;            
        }

        public Select WithOptions(IEnumerable<Option> options)
        {
            Children.AddRange(options);
            return this;            
        }
    }
}