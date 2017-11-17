using System;
using System.Text;
using System.Collections;
using FluentMarkup.Html;

namespace FluentMarkup.Parsing
{
    public interface IParser
    {
        IElement Parse(string input);
    }
}   