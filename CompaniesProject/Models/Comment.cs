using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompaniesProject.Models
{
    public class Comment
    {
        public DateTime Date { get; set;}
        public string Name { get; set; }
        public string Text { get; set; }

        public Comment(DateTime date, string name, string text)
        { Date = date; Name = name; Text = text; }
    }
}