using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KudMVCapp2.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            List<Employee> employees = employeeBusinessLayer.Employees.ToList();
            return View(employees);
        }

        [HttpGet]
        public  ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            foreach(string key in formCollection.AllKeys)
            {
                Response.Write("Key = " + key + "     ");
                Response.Write(formCollection[key]);
                Response.Write("<br/>");
            }
            return View();
        }
    }
    
}