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
        //public ActionResult Create(FormCollection formCollection)
        public ActionResult Create(string name, string gender, string city, DateTime dateOfBirth)
        {
            Employee employee = new Employee();
            employee.Name = name;
            employee.Gender = gender;
            employee.City = city;
            employee.DateOfBirth = dateOfBirth;
            //Employee employee = new Employee();
            //employee.Name = formCollection["Name"];
            //employee.Gender = formCollection["Gender"];
            //employee.City = formCollection["City"];
            //employee.DateOfBirth = Convert.ToDateTime(formCollection["DateOfBirth"]);

            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();

            employeeBusinessLayer.AddEmployee(employee);

            return RedirectToAction("Index");
            //just to write in the webpage, it's not storing in the database. code above stores it in database
            //foreach(string key in formCollection.AllKeys)
            //{
            //    Response.Write("Key = " + key + "     ");
            //    Response.Write(formCollection[key]);
            //    Response.Write("<br/>");
            //}
            //return View();
        }
    }
    
}