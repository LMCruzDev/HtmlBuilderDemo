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
                var table = new HtmlTag("table");

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

            html = html.Append(body);

            return html.ToHtmlString();
        }
    }
}