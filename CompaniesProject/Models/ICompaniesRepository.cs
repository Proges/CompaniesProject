using System;
namespace CompaniesProject.Models
{
    interface ICompaniesRepository
    {
        void AddComment(int userId, int companyId, string text);
        void AddCompany(CompaniesTable newCompany);
        void EditCompany(int id, CompaniesTable editCompany);
        CompaniesTable EditCompanyForm(int id);
        System.Collections.Generic.List<CompaniesTable> ShowAllCompanies();
        Company ShowCompany(int id);
        string UserLoggin(string email, string password);
    }
}
