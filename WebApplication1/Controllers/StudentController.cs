using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using Interpro_Business_Logic;
namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        private StudentDLL  bll = new StudentDLL();



        public IActionResult List()
        {
            List<StudentDLL> list = bll.GetAll();

            return View(list);
        }

        public IActionResult Add()
        {
            return View(new StudentDLL());
        }

        [HttpPost]
        public IActionResult Add(StudentDLL obj)
        {
            if (ModelState.IsValid)
            {
                obj.Add();
                return RedirectToAction("List");
            }
            else
            {
                return View(obj);
            }
        }

        public IActionResult Edit(int id)
        {
            StudentDLL obj = bll.Get(id);
            if (obj.id == 0) return RedirectToAction("List");
            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(StudentDLL obj)
        {
            if (ModelState.IsValid)
            {
                obj.Edit();
                return RedirectToAction("List");
            }
            else
            {
                return View(obj);
            }
        }

        [HttpPost]
        public IActionResult Delete(StudentDLL obj)
        {
            obj.Delete();
            return RedirectToAction("List");
        }

        public IActionResult Index(string search, StudentDLL obj)
        {

            return View();
         
        }


    }
}
