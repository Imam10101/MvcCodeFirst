using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcCodeFirst.Models;

namespace MvcCodeFirst.Controllers
{
    public class EmployeeController : Controller
    {
        private DbEmployee db = new DbEmployee();

        public ActionResult Index()
        {
            var employee = db.Employees.ToList();
            return View(employee);
        }

       

        public ActionResult Create()
        {
            Employee employee = new Employee();
            employee.EmployeeEx.Add(new EmployeeEx()
            {
                CompanyName = "",
                YearofEx = 0
            });
            return View(employee);
        }
        [HttpPost]
        public ActionResult Create(Employee employee, string btn)
        {
            if (btn == "Add")
            {
                employee.EmployeeEx.Add(new EmployeeEx());
            }
            if (btn == "Create")
            {
                if (employee.Picture != null)
                {
                    string Extention = Path.GetExtension(employee.Picture.FileName);
                    if (Extention == ".jpg" || Extention == ".jpeg" || Extention == ".png")
                    {
                        string root = Server.MapPath("~/");
                        string filetosave = Path.Combine(root, "Picture/", employee.Picture.FileName);
                        employee.Picpath = "~/Picture/" + employee.Picture.FileName;
                        employee.Picture.SaveAs(filetosave);
                        employee.TotalEx = employee.EmployeeEx.Sum(p => p.YearofEx);
                        db.Employees.Add(employee);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please Provide a valid image");
                        return RedirectToAction("Index");
                    }
                }


            }
            return View(employee);
        }

        public ActionResult Edit(int id)
        {
            Employee employee = db.Employees.Find(id);

            return View(employee);
        }
        [HttpPost]
        public ActionResult Edit(Employee employee, string btn)
        {
            if (btn == "Add")
            {
                employee.EmployeeEx.Add(new EmployeeEx());
            }
            if (btn == "Update")
            {
                if (employee.Picture != null)
                {
                    string Extention = Path.GetExtension(employee.Picture.FileName);
                    if (Extention == ".jpg" || Extention == ".jpeg" || Extention == ".png")
                    {
                        string root = Server.MapPath("~/");
                        string filetosave = Path.Combine(root, "Picture/", employee.Picture.FileName);

                        employee.Picpath = "~/Picture/" + employee.Picture.FileName;
                        employee.Picture.SaveAs(filetosave);
                        employee.TotalEx = employee.EmployeeEx.Sum(p => p.YearofEx);
                        db.Employees.AddOrUpdate(employee);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please Provide a valid image");
                        return RedirectToAction("Index");
                    }
                }


            }
            return View(employee);
        }
        public ActionResult Details(int id)
        {
           
                Employee employee = db.Employees.Find(id);
             
            
                    return View(employee);
                

           
        }

        public ActionResult Delete(int id)
        {
            db.Employees.Remove(db.Employees.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
