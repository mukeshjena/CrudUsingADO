using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrudAppUsingADO.Models;

namespace CrudAppUsingADO.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            EmployeeDBContext db = new EmployeeDBContext();

            List<Employee> obj = db.GetEmployees();
            return View(obj);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    EmployeeDBContext context = new EmployeeDBContext();
                    bool check = context.AddEmployees(emp);
                    if (check == true)
                    {
                        TempData["InsertMessage"] = "success";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            EmployeeDBContext ctx = new EmployeeDBContext();
            var row = ctx.GetEmployees().Find(model => model.id == id);
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(int id, Employee emp)
        {
            if (ModelState.IsValid == true)
            {
                EmployeeDBContext context = new EmployeeDBContext();
                bool check = context.UpdateEmployees(emp);
                if (check == true)
                {
                    TempData["UpdateMessage"] = "success";
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            EmployeeDBContext ctx = new EmployeeDBContext();
            var row = ctx.GetEmployees().Find(model => model.id == id);
            return View(row);
        }

        public ActionResult Delete(int id)
        {
            EmployeeDBContext ctx = new EmployeeDBContext();
            var row = ctx.GetEmployees().Find(model => model.id == id);
            return View(row);
        }
        [HttpPost]
        public ActionResult Delete(int id, Employee emp)
        {
            EmployeeDBContext context = new EmployeeDBContext();
            bool check = context.DeleteEmployees(id);
            if (check == true)
            {
                TempData["DeleteMessage"] = "deleted";
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}