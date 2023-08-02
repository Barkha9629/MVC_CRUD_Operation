using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using MyApp.Models;
using MyApp.Db.DbOperations;

namespace MVCAppWithDb.Controllers
{
    public class HomeController : Controller
    {
        EmployeeRepositary repositary = null;
        public HomeController() 
        {
            repositary= new EmployeeRepositary();
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                int id = repositary.AddEmployee(model);
                if(id > 0)
                {
                    ModelState.Clear();
                    ViewBag.Issuccess = "Data Added";
                }
            }



            return View();
        }

        [HttpGet]
        public ActionResult GetAllEmployee(EmployeeModel model)
        {
            var Get = repositary.GetAllEmployee();

            return View(Get);
        }

        public ActionResult GetEmployee(int Id)
        {
            var Grid = repositary.GetEmployee(Id);

            return View(Grid);
        }

        public ActionResult Edit(int Id)
        {
            var Edit = repositary.GetEmployee(Id);

            return View(Edit);
        }





        [HttpPost]
        public ActionResult Edit(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                 repositary.UpdateEmployee(model.Id, model);

                return RedirectToAction("GetAllEmployee");
            }


            return View();
        }


        //Delete
        public ActionResult Delete(int Id)
        {
            
            
                repositary.DeleteEmployee(Id);

                return RedirectToAction("GetAllEmployee");
            


            
        }
    }
}