using HtmlBuilderDemo.Interfaces;
using HtmlBuilderDemo.Models;
using HtmlBuilders;

namespace HtmlBuilderDemo.Services
{
    public class HtmlBuilder : IHtmlBuilder
    {
        public string Build(Form form)
        {
            var html = new HtmlTag("html");
            var body = new HtmlTag("body");

            foreach (var section in form.Sections)
            {
                var table = new HtmlTag("table").Class("table");

                table = table.Append(new HtmlTag("tr")
                    .Append(new HtmlTag("th").Append("Question"))
                    .Append(new HtmlTag("th").Append("Answer"))
                    );

                foreach (var question in section.Questions)
                {
                    table = table.Append(new HtmlTag("tr")
                        .Append(new HtmlTag("td").Append(question.Text))
                        .Append(new HtmlTag("td").Append(question.Widget.Value))
                        );
                }

                body = body.Append(table);
            }

            var css = "body {background-color: lightblue;} h1 {color: white;text-align: center;} p {font-family: verdana;font-size: 20px;}";

            html = html
                .Append(new HtmlTag("head").Append(new HtmlTag("style").Append(css)))
                .Append(body);

            return html.ToHtmlString();
        }
    }
}