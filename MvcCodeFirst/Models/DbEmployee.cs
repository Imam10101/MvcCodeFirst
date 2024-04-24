using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcCodeFirst.Models
{
    public class DbEmployee: DbContext
    {
        public DbSet<Employee> Employees { get; set;}
        public DbSet<EmployeeEx> EmployeesEx { get; set;}
    }
}