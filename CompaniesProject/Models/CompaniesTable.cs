using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CompaniesProject.Models
{
    [MetadataType(typeof(CompanyMetadata))]
    public partial class CompaniesTable
    {       
        public class CompanyMetadata
        {            
            [Required(ErrorMessage = "Введите название компании")]
            [StringLength(50)]
            public string Name { get; set; }

            [Required(ErrorMessage = "Введите адресс компании")]
            [StringLength(50)]
            public string Address { get; set; }

            [Required(ErrorMessage = "Введите телефон компании")]
            [RegularExpression("(\\+380){1}\\d{9}",
                ErrorMessage="Введите телефон в формате +380ххххххххх")]
            public string Phone { get; set; }

            [Required(ErrorMessage = "Введите количество сотрудников компании")]
            public int EmployeesNumber { get; set; }
        }

    }
}