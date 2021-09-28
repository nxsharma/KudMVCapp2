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
        [ActionName("Create")]
        public  ActionResult Create_Get()
        {
            return View();
        }

        [HttpGet]        
        public ActionResult Edit(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            Employee employee =  employeeBusinessLayer.Employees.Single(emp => emp.ID == id);
            return View(employee);
            
        }

        [HttpPost]
        [ActionName("Edit")]
        //public ActionResult Edit_post(int id)
        //include list
        //public ActionResult Edit_post([Bind(Include ="Id, Gender, City, DateOfBirth"]Employee employee)

        //Exclude list
        // public ActionResult Edit_post([Bind(Exclude = "Name"] Employee employee)
        public ActionResult Edit_post(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            Employee employee = employeeBusinessLayer.Employees.Single(x => x.ID == id);
            // BINDING method using Exclude employee.Name = employeeBusinessLayer.Employees.Single(x => x.ID == employee.ID).Name;
            //Include list
            // UpdateModel(employee, new string[] { "ID", "Gender", "City", "DateOfBirth" });

            //exclude list
            //UpdateModel(employee, null, null, new string[] { "Name" });

            UpdateModel<IEmployee>(employee);
            if (ModelState.IsValid)
            {
                
                employeeBusinessLayer.SaveEmployeeDetails(employee);

                return RedirectToAction("Index");


            }
            return View(employee);

        }

        [HttpPost]
        [ActionName("Create")]
        //public ActionResult Create(FormCollection formCollection)
        //public ActionResult Create(string name, string gender, string city, DateTime dateOfBirth)
        //public ActionResult Create(Employee employee)
        public ActionResult Create_Post(Employee employee)
        {
            //Employee employee = new Employee();
            //TryUpdateModel(employee);
            
            //Employee employee = new Employee();
            //employee.Name = name;
            //employee.Gender = gender;
            //employee.City = city;
            //employee.DateOfBirth = dateOfBirth;

            //Employee employee = new Employee();
            //employee.Name = formCollection["Name"];
            //employee.Gender = formCollection["Gender"];
            //employee.City = formCollection["City"];
            //employee.DateOfBirth = Convert.ToDateTime(formCollection["DateOfBirth"]);
            if (ModelState.IsValid)
            {
                    //Employee employee = new Employee();
                    //UpdateModel(employee);
                EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();

                employeeBusinessLayer.AddEmployee(employee);

                return RedirectToAction("Index");
            }

            return View();
            //just to write in the webpage, it's not storing in the database. code above stores it in database
            //foreach(string key in formCollection.AllKeys)
            //{
            //    Response.Write("Key = " + key + "     ");
            //    Response.Write(formCollection[key]);
            //    Response.Write("<br/>");
            //}
            //return View();
        }

        public ActionResult Delete(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            employeeBusinessLayer.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
    
}