using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Register;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        private LoginDLL bll = new LoginDLL();

     
        [HttpGet]
        public IActionResult Register()
        {
            return View(new LoginDLL());
        }

    

        public IActionResult Register(LoginDLL obj)
        {
            if (ModelState.IsValid)
            {
                obj.Add();
                
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }


        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {

            return View(new LoginDLL());

        }

        [HttpPost]
        public IActionResult Login(LoginDLL obj)
        {
          
                if (obj.Log() == true && ModelState.IsValid)
                {
                    return RedirectToAction("List", "Student");
                }
                else
                {
                    return View(obj);
                }
            
           



        }


        [HttpPost]
        public IActionResult Edit(LoginDLL obj)
        {

            if(ModelState.IsValid)
            {
                obj.Edit();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
          

          

        }

        public IActionResult Edit()
        {
            return View(new LoginDLL());
        }

      
    }
}
