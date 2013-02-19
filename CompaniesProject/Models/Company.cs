using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompaniesProject.Models
{
    public class Company
    {
        public CompaniesTable companiesList { get; set; }
        public List<Comment> commentList { get; set; }

        public Company()
        {
            companiesList = new CompaniesTable();
            commentList = new List<Comment>();
        }
    }
}