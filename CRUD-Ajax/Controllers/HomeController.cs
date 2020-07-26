using CRUD_Ajax.Contexts;
using CRUD_Ajax.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace CRUD_Ajax.Controllers
{
    public class HomeController : Controller
    {
        private EmployeeContext db = new EmployeeContext();
        public ActionResult Index()
        {
            
            return View(db.Employees.ToList());
        }
        [HttpPost]
        public JsonResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();

                return Json(200);
            }
            return Json(400);
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            Employee employee = db.Employees.Find(id);
            if (employee != null)
            {
                db.Employees.Remove(employee);
                db.SaveChanges();
                return Json(200);
            }
            return Json(400);
        }
        public  JsonResult GetEmployeeId()
        {
            int id = db.Employees.ToList().Last().Id;

            return Json(id, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Edit(Employee employee)
        {


            if (ModelState.IsValid)
            {
                Employee e = db.Employees.Find(employee.Id);
                if (e!=null)
                {
                    db.ChangeTracker.Entries().Where(x => x.Entity != null).ToList().ForEach(x => x.State = EntityState.Detached);
                    db.Entry(employee).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(200);
                }
                
            }
            return Json(400);
        }
        [HttpPost]
        public JsonResult DeleteSelected(int[] ids )
        {
            if (ids.Length > 0)
            {
                for (int i = 0; i < ids.Length; i++)
                {
                    Employee employee = db.Employees.Find(ids[i]);
                        if (employee != null)
                    {
                        db.Employees.Remove(employee);
                        db.SaveChanges();
                    }
                }
                return Json(200);
            }
            return Json(400);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();   
            }

            base.Dispose(disposing);    
        }
    }
}