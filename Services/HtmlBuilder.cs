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

            var div = new HtmlTag("div").Id("root");

            var img = new HtmlTag("img")
                .Style("display", "block")
                .Style("margin-left", "auto")
                .Style("margin-right", "auto")
                .Src("https://dcp-core-static-content.s3.eu-west-2.amazonaws.com/cera-family-logo-new.png")
                .Attribute("alt", "Cera")
                .Attribute("width", "200")
                .Attribute("height", "100");

            div = div.Append(img);

            var h2 = new HtmlTag("h2")
                .Style("text-align", "center")
                .Append("Care Plan and Risk Assessment");

            div = div.Append(h2);

            foreach (var section in form.Sections)
            {
                var divSection = new HtmlTag("div")
                    .Class("dcpforms-MuiPaper-root dcpforms-MuiTableContainer-root dcpforms-MuiPaper-elevation1 dcpforms-MuiPaper-rounded")
                    .Style("margin", "30px 0px");

                var table = new HtmlTag("table")
                    .Class("dcpforms-MuiTable-root")
                    .Attribute("aria-label", "table");

                table = table
                    .Append(
                    new HtmlTag("th")
                    .Class("dcpforms-MuiTableHead-root")
                    .Attribute("role", "rowgroup")
                    .Append(
                           new HtmlTag("tr")
                           .Class("dcpforms-MuiTableRow-root dcpforms-MuiTableRow-head")
                           .Append(
                               new HtmlTag("th")
                               .Class("dcpforms-MuiTableCell-root dcpforms-MuiTableCell-head dcpforms-MuiTableCell-alignCenter")
                               .Attribute("scope", "col")
                               .Attribute("colspan", "6")
                               .Attribute("style", "background-color: rgba(0, 0, 0, 0.04); color: rgb(0, 0, 0); font-size: 16px; font-weight: 600;")
                               .Append(section.Text))));

                foreach (var question in section.Questions)
                {
                    table = table.Append(
                        new HtmlTag("tbody")
                        .Class("dcpforms-MuiTableBody-root")
                        .Append(
                            new HtmlTag("tr")
                            .Class("dcpforms-MuiTableRow-root")
                            .Append(
                                new HtmlTag("td")
                                .Class("dcpforms-MuiTableCell-root dcpforms-MuiTableCell-body")
                                .Attribute("style", "background-color: rgba(0, 0, 0, 0.04); color: rgb(0, 0, 0); font-size: 16px; font-weight: 600;")
                                .Append(question.Text))
                            .Append(
                                new HtmlTag("td")
                                .Class("dcpforms-MuiTableCell-root dcpforms-MuiTableCell-body")
                                .Attribute("colspan", "5")
                                .Append(question.Widget.Value))));
                }

                table = table
                    .Append(new HtmlTag("th")
                    .Class("dcpforms-MuiTableHead-root")
                    .Attribute("role", "rowgroup")
                    .Append(
                        new HtmlTag("tr")
                        .Class("dcpforms-MuiTableRow-root dcpforms-MuiTableRow-head")
                        .Append(
                            new HtmlTag("th")
                            .Class("dcpforms-MuiTableCell-root dcpforms-MuiTableCell-head")
                            .Attribute("scope", "col")
                            .Attribute("style", "background-color: rgba(0, 0, 0, 0.04); color: rgb(0, 0, 0); font-size: 16px; font-weight: 600;")
                            .Append("Type of equipment"))
                        .Append(
                            new HtmlTag("th")
                            .Class("dcpforms-MuiTableCell-root dcpforms-MuiTableCell-head")
                            .Attribute("scope", "col")
                            .Attribute("style", "background-color: rgba(0, 0, 0, 0.04); color: rgb(0, 0, 0); font-size: 16px; font-weight: 600;")
                            .Append("Manufacturer"))
                        .Append(
                            new HtmlTag("th")
                            .Class("dcpforms-MuiTableCell-root dcpforms-MuiTableCell-head")
                            .Attribute("scope", "col")
                            .Attribute("style", "background-color: rgba(0, 0, 0, 0.04); color: rgb(0, 0, 0); font-size: 16px; font-weight: 600;")
                            .Append("Who has responsibility"))
                        .Append(
                            new HtmlTag("th")
                            .Class("dcpforms-MuiTableCell-root dcpforms-MuiTableCell-head")
                            .Attribute("scope", "col")
                            .Attribute("style", "background-color: rgba(0, 0, 0, 0.04); color: rgb(0, 0, 0); font-size: 16px; font-weight: 600;")
                            .Append("Last service date"))
                        .Append(
                            new HtmlTag("th")
                            .Class("dcpforms-MuiTableCell-root dcpforms-MuiTableCell-head")
                            .Attribute("scope", "col")
                            .Attribute("style", "background-color: rgba(0, 0, 0, 0.04); color: rgb(0, 0, 0); font-size: 16px; font-weight: 600;")
                            .Append("Next service date"))))
                    .Append(new HtmlTag("tbody")
                    .Class("dcpforms-MuiTableBody-root")
                    .Append(
                            new HtmlTag("td")
                            .Class("dcpforms-MuiTableCell-root dcpforms-MuiTableCell-body")
                            .Append("**Answer to: Type of equipment**"))
                        .Append(
                            new HtmlTag("td")
                            .Class("dcpforms-MuiTableCell-root dcpforms-MuiTableCell-body")
                            .Append("**Answer to: Manufacturer**"))
                        .Append(
                            new HtmlTag("td")
                            .Class("dcpforms-MuiTableCell-root dcpforms-MuiTableCell-body")
                            .Append("**Answer to: Who has responsibility**"))
                        .Append(
                            new HtmlTag("td")
                            .Class("dcpforms-MuiTableCell-root dcpforms-MuiTableCell-body")
                            .Append("**Answer to: Last service date**"))
                        .Append(
                            new HtmlTag("td")
                            .Class("dcpforms-MuiTableCell-root dcpforms-MuiTableCell-body")
                            .Append("**Answer to: Next service date**")));

                table = table
                    .Append(new HtmlTag("tr")
                    .Class("dcpforms-MuiTableRow-root")
                    .Append(
                        new HtmlTag("td")
                        .Class("dcpforms-MuiTableCell-root")
                        .Attribute("rowspan", "6")
                        .Attribute("style", "color: rgb(0, 0, 0); font-size: 16px; font-weight: 600;")
                        .Append("**Risk type**"))
                    .Append(
                        new HtmlTag("tbody")
                        .Class("dcpforms-MuiTableBody-root")
                        .Append(
                            new HtmlTag("tr")
                            .Class("dcpforms-MuiTableRow-root")
                            .Append(
                                new HtmlTag("td")
                                .Class("dcpforms-MuiTableCell-root dcpforms-MuiTableCell-body")
                                .Attribute("style", "background-color: rgba(0, 0, 0, 0.04); color: rgb(0, 0, 0); font-size: 16px; font-weight: 600;")
                                .Append("Risk for Professional Carer"))
                            .Append(
                                new HtmlTag("td")
                                .Class("dcpforms-MuiTableCell-root dcpforms-MuiTableCell-body")
                                .Attribute("colspan", "5")
                                .Append("Risk for Professional Carer"))))
                    .Append(
                        new HtmlTag("tbody")
                        .Class("dcpforms-MuiTableBody-root")
                        .Append(
                            new HtmlTag("tr")
                            .Class("dcpforms-MuiTableRow-root")
                            .Append(
                                new HtmlTag("td")
                                .Class("dcpforms-MuiTableCell-root dcpforms-MuiTableCell-body")
                                .Attribute("style", "background-color: rgba(0, 0, 0, 0.04); color: rgb(0, 0, 0); font-size: 16px; font-weight: 600;")
                                .Append("Risk for Client"))
                            .Append(
                                new HtmlTag("td")
                                .Class("dcpforms-MuiTableCell-root dcpforms-MuiTableCell-body")
                                .Attribute("colspan", "5")
                                .Append("**Answer**"))))
                    .Append(
                        new HtmlTag("tbody")
                        .Class("dcpforms-MuiTableBody-root")
                        .Append(
                            new HtmlTag("tr")
                            .Class("dcpforms-MuiTableRow-root")
                            .Append(
                                new HtmlTag("td")
                                .Class("dcpforms-MuiTableCell-root dcpforms-MuiTableCell-body")
                                .Attribute("style", "background-color: rgba(0, 0, 0, 0.04); color: rgb(0, 0, 0); font-size: 16px; font-weight: 600;")
                                .Append("Initial risk level"))
                            .Append(
                                new HtmlTag("td")
                                .Class("dcpforms-MuiTableCell-root dcpforms-MuiTableCell-body")
                                .Attribute("colspan", "5")
                                .Append("**Answer**"))))
                    .Append(
                        new HtmlTag("tbody")
                        .Class("dcpforms-MuiTableBody-root")
                        .Append(
                            new HtmlTag("tr")
                            .Class("dcpforms-MuiTableRow-root")
                            .Append(
                                new HtmlTag("td")
                                .Class("dcpforms-MuiTableCell-root dcpforms-MuiTableCell-body")
                                .Attribute("style", "background-color: rgba(0, 0, 0, 0.04); color: rgb(0, 0, 0); font-size: 16px; font-weight: 600;")
                                .Append("Control measures to reduce risk"))
                            .Append(
                                new HtmlTag("td")
                                .Class("dcpforms-MuiTableCell-root dcpforms-MuiTableCell-body")
                                .Attribute("colspan", "5")
                                .Append("**Answer**"))))
                    .Append(
                        new HtmlTag("tbody")
                        .Class("dcpforms-MuiTableBody-root")
                        .Append(
                            new HtmlTag("tr")
                            .Class("dcpforms-MuiTableRow-root")
                            .Append(
                                new HtmlTag("td")
                                .Class("dcpforms-MuiTableCell-root dcpforms-MuiTableCell-body")
                                .Attribute("style", "background-color: rgba(0, 0, 0, 0.04); color: rgb(0, 0, 0); font-size: 16px; font-weight: 600;")
                                .Append("Residual risk level"))
                            .Append(
                                new HtmlTag("td")
                                .Class("dcpforms-MuiTableCell-root dcpforms-MuiTableCell-body")
                                .Attribute("colspan", "5")
                                .Append("**Answer**")))));


                table = table
                    .Append(new HtmlTag("th")
                    .Class("dcpforms-MuiTableHead-root")
                    .Attribute("role", "rowgroup")
                    .Append(
                        new HtmlTag("tr")
                        .Class("dcpforms-MuiTableRow-root dcpforms-MuiTableRow-head")
                        .Append(
                            new HtmlTag("th")
                            .Class("dcpforms-MuiTableCell-root dcpforms-MuiTableCell-head")
                            .Attribute("scope", "col")
                            .Attribute("style", "background-color: rgba(0, 0, 0, 0.04); color: rgb(0, 0, 0); font-size: 16px; font-weight: 600;"))
                        .Append(
                            new HtmlTag("th")
                            .Class("dcpforms-MuiTableCell-root dcpforms-MuiTableCell-head")
                            .Attribute("scope", "col")
                            .Attribute("style", "background-color: rgba(0, 0, 0, 0.04); color: rgb(0, 0, 0); font-size: 16px; font-weight: 600;")
                            .Append("Risk type details"))
                        .Append(
                            new HtmlTag("th")
                            .Class("dcpforms-MuiTableCell-root dcpforms-MuiTableCell-head")
                            .Attribute("scope", "col")
                            .Attribute("style", "background-color: rgba(0, 0, 0, 0.04); color: rgb(0, 0, 0); font-size: 16px; font-weight: 600;")
                            .Append("Initial risk level"))
                        .Append(
                            new HtmlTag("th")
                            .Class("dcpforms-MuiTableCell-root dcpforms-MuiTableCell-head")
                            .Attribute("scope", "col")
                            .Attribute("style", "background-color: rgba(0, 0, 0, 0.04); color: rgb(0, 0, 0); font-size: 16px; font-weight: 600;")
                            .Append("Control measures to reduce risk"))
                        .Append(
                            new HtmlTag("th")
                            .Class("dcpforms-MuiTableCell-root dcpforms-MuiTableCell-head")
                            .Attribute("scope", "col")
                            .Attribute("style", "background-color: rgba(0, 0, 0, 0.04); color: rgb(0, 0, 0); font-size: 16px; font-weight: 600;")
                            .Append("Residual risk level"))))
                    .Append(new HtmlTag("tbody")
                    .Class("dcpforms-MuiTableBody-root")
                    .Append(
                        new HtmlTag("tr")
                        .Class("dcpforms-MuiTableRow-root")
                        .Append(
                            new HtmlTag("td")
                            .Class("dcpforms-MuiTableCell-root dcpforms-MuiTableCell-body")
                            .Attribute("style", "background-color: rgba(0, 0, 0, 0.04); color: rgb(0, 0, 0); font-size: 16px; font-weight: 600;")
                            .Append("**Risk Title**"))
                        .Append(
                            new HtmlTag("td")
                            .Class("dcpforms-MuiTableCell-root dcpforms-MuiTableCell-body")
                            .Append("**Answer to: Risk type details**"))
                        .Append(
                            new HtmlTag("td")
                            .Class("dcpforms-MuiTableCell-root dcpforms-MuiTableCell-body")
                            .Append("**Answer to: Initial risk level**"))
                        .Append(
                            new HtmlTag("td")
                            .Class("dcpforms-MuiTableCell-root dcpforms-MuiTableCell-body")
                            .Append("**Answer to: Control measures to reduce risk**"))
                        .Append(
                            new HtmlTag("td")
                            .Class("dcpforms-MuiTableCell-root dcpforms-MuiTableCell-body")
                            .Append("**Answer to: Residual risk level**"))));

                divSection = divSection.Append(table);

                div = div.Append(divSection);
            }

            body = body.Append(div);

            var css = GetCss();

            html = html
                .Append(new HtmlTag("head").Append(new HtmlTag("style").Append(css)))
                .Append(body);

            return html.ToHtmlString().Replace("\"","'");
        }

        private string GetCss()
        {
            return System.IO.File.ReadAllText(@".\Template\style.css");
        }
    }
}