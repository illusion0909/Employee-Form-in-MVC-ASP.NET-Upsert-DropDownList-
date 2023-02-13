using DotNet_Project8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;//used for Include



namespace DotNet_Project8.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Employee
        public ActionResult Index()
        {
            var vdata = ViewData["vdata"]; ///example of viewdata!!   viewdata not access from controller to controller 
           
            var tdata = TempData["tdata"]; ///example of temp data from home controller



            var employeeList = _context.Employees.Include(e => e.Department).Include(e => e.Designation).ToList();
            return View(employeeList);
        }
        public ActionResult Upsert(int? id) //? id can be null..... int means ZERO or something but can not be null ! in case of create --id-- is null ....so we allow null value!
        {
            //ViewData["depList"] = _context.Departments.ToList();
            //ViewData["dsgList"] = _context.Designations.ToList();
            ViewBag.depList = _context.Departments.ToList();
            ViewBag.dsgList = _context.Designations.ToList();

            Employee employee=new Employee();

            if (id == null)
            {   //create
                return View(employee);
            }
            else
            {
                //Edit
                employee = _context.Employees.Include(d => d.Department).Include(d => d.Designation).FirstOrDefault(e => e.Id == id);
                if (employee == null)
                    return HttpNotFound();
                return View(employee);
            }

        }
        [HttpPost]
        public ActionResult Upsert(Employee employee) 
        {
            if (employee == null)
                return HttpNotFound();

            if(!ModelState.IsValid)
            {
                ViewBag.depList = _context.Departments.ToList();
                ViewBag.dsgList = _context.Designations.ToList();
                //ViewData["depList"] = _context.Departments.ToList();
                //ViewData["dsgList"] = _context.Designations.ToList();
                return View(employee);

            }
           
            if(employee.Id==0)//create
                _context.Employees.Add(employee);

            else//edit
            {
                var employeeInDb = _context.Employees.Find(employee.Id);//find
                
                //update
                
                employeeInDb.Name= employee.Name;
                employeeInDb.Address=employee.Address;
                employeeInDb.Salary=employee.Salary;
                employeeInDb.DepartmentId=employee.DepartmentId;
                employeeInDb.DesignationId=employee.DesignationId;
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Details(int id)
        {
            var employeeInDb = _context.Employees.Include(e => e.Department).Include(e => e.Designation).FirstOrDefault(e => e.Id == id);
            if (employeeInDb == null) return HttpNotFound();
            return View(employeeInDb);
        }
        public ActionResult Delete(int id)
        {
            var employeeInDb = _context.Employees.Find(id);
            if (employeeInDb == null) return HttpNotFound();
            _context.Employees.Remove(employeeInDb);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}