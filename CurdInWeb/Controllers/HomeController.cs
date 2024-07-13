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
            List<Students> obj = dbContext.GeStudents();
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
                if (ModelState.IsValid == true)
                {
                    StudentDbContext context = new StudentDbContext();
                    bool check = context.AddStudent(student);
                    if (check == true)
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
        //update data
        public ActionResult Edit(int id)
        {
            StudentDbContext context=new StudentDbContext();
            var row = context.GeStudents().Find(model => model.Id == id);
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(int id,Students students)
        {
            if (ModelState.IsValid == true)
            {
                StudentDbContext context = new StudentDbContext();
                bool check = context.UpdateStudent(students);
                if (check == true)
                {
                    TempData["UpdateStudent"] = "data update successful";
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

    }
}