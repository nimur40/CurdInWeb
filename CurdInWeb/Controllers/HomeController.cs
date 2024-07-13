using CurdInWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;    

namespace CurdInWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            StudentDbContext dbContext = new StudentDbContext();
            List<Students> obj=dbContext.GeStudents();
            return View(obj);
        }
        public ActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Create(Students student)
        { 
            try
            {
                if(ModelState.IsValid==true)
                {
                    StudentDbContext context = new StudentDbContext();
                    bool check = context.AddStudent(student);
                    if(check==true)
                    {
                        TempData["InsertMessage"] = "data insert successfel";
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
    }
}