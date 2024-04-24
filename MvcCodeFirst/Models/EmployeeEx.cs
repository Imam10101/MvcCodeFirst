using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcCodeFirst.Models
{
    public class EmployeeEx
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public int YearofEx { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeID {  get; set; }
        public Employee Employee { get; set; }

    }
}