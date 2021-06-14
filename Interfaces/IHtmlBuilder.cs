using System.Collections.Generic;
using HtmlBuilderDemo.Models;

namespace HtmlBuilderDemo.Interfaces
{
    public interface IHtmlBuilder
    {
        string Build(Form form);
    }
}