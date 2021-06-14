using System.Collections.Generic;

namespace HtmlBuilderDemo.Models
{
    public class Section
    {
        public string Text { get; set; }
        public List<Question> Questions { get; set; }
    }
}