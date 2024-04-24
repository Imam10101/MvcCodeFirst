using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcCodeFirst.Models
{
    public class Employee
    {
        public Employee()
        {
            EmployeeEx = new List<EmployeeEx>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picpath { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [NotMapped]
        public HttpPostedFileBase Picture { get; set; }
        public int TotalEx { get; set; }
        public bool IsAvaiable { get; set; }
        public List<EmployeeEx> EmployeeEx { get; set; }
    }
}