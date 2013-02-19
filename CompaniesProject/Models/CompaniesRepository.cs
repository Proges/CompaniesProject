using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace CompaniesProject.Models
{
    public class CompaniesRepository : CompaniesProject.Models.ICompaniesRepository
    {
        CompaniesClassesDataContext connection;

        public int UserId { get; private set; }

        public CompaniesRepository()
        {
            connection = new CompaniesClassesDataContext();
        }


        public List<CompaniesTable> ShowAllCompanies()
        {
            var companies = (from comp in connection.CompaniesTables select comp).ToList();
            return companies;
        }


        public Company ShowCompany(int id)
        {
            Company company = new Company();

            var comments = (from comment in connection.CommentsTables
                            where comment.CompanyId == id
                            select new
                            {
                                employeeName = (from users in connection.UsersTables where users.Id == comment.UserId select users.Name).First(),
                                date = comment.Date,
                                text = comment.Comment
                            }).ToList();

            company.companiesList = (from companies in connection.CompaniesTables
                                     where companies.Id == id
                                     select companies).First();

            foreach (var comment in comments)
            {                
                company.commentList.Add(new Comment(comment.date, comment.employeeName, comment.text));
            }                                                    

            return company;
        }        


        public void AddCompany(CompaniesTable newCompany)
        {
            connection.CompaniesTables.InsertOnSubmit(newCompany);
            connection.SubmitChanges();
        }


        public CompaniesTable EditCompanyForm(int id)
        {
            var company = (from comp in connection.CompaniesTables
                           where comp.Id == id
                           select comp).First();

            return company;
        }


        public void EditCompany(int id, CompaniesTable editCompany)
        {
            var company = (from comp in connection.CompaniesTables
                           where comp.Id == id
                           select comp).First();

            company.Name = editCompany.Name;
            company.Address = editCompany.Address;
            company.Phone = editCompany.Phone;
            company.EmployeesNumber = editCompany.EmployeesNumber;

            connection.SubmitChanges();
            
        }


        public string UserLoggin(string email, string password)
        {
            var currUser = (from user in connection.UsersTables
                        where user.Email == email &&
                        user.Password == password
                        select new
                        {
                            Id = user.Id,
                            name = user.Name
                        }).First();

            UserId = currUser.Id;

            return currUser.name;            
        }



        public void AddComment(int userId, int companyId, string text)
        {
            CommentsTable comment = new CommentsTable();
            comment.UserId = userId;
            comment.Date = DateTime.Now;
            comment.CompanyId = companyId;
            comment.Comment = text;
            connection.CommentsTables.InsertOnSubmit(comment);
            connection.SubmitChanges();
        }
    }
}