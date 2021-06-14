using System;
using System.IO;
using HtmlAgilityPack;
using HtmlBuilderDemo.Interfaces;
using HtmlBuilderDemo.Models;

namespace HtmlBuilderDemo.Services
{
    public class HtmlAgilityPackBuilder : IHtmlBuilder
    {
        public string Build(Form form)
        {
            var htmlTemplate = File.ReadAllText(@".\Template\Template.html");

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlTemplate);

            foreach (var section in form.Sections)
            {
                var table = HtmlNode.CreateNode("<table class=\"table\" />");

                var trHead = HtmlNode.CreateNode("<tr />");

                trHead.ChildNodes.Add(HtmlNode.CreateNode($"<th>{section.Text}</th>"));
                
                var trSubHead = HtmlNode.CreateNode("<tr />");

                trSubHead.ChildNodes.Add(HtmlNode.CreateNode("<th>Question</th>"));
                trSubHead.ChildNodes.Add(HtmlNode.CreateNode("<th>Answer</th>"));
                
                table.ChildNodes.Add(trHead);
                table.ChildNodes.Add(trSubHead);

                foreach (var question in section.Questions)
                {
                    var tr = HtmlNode.CreateNode("<tr />");
                    
                    tr.ChildNodes.Add(HtmlNode.CreateNode($"<td>{question.Text}</td>"));
                    tr.ChildNodes.Add(HtmlNode.CreateNode($"<td>{question.Widget.Value}</td>"));
                    
                    table.ChildNodes.Add(tr);
                }
                
                htmlDoc.DocumentNode.SelectSingleNode("//body").ChildNodes.Add(table);
            }

            using var writer = new StringWriter();
            htmlDoc.Save(writer);
            return writer.ToString();
        }
    }
}
