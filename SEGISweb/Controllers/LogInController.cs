using ModelsData;
using SEGISweb.Code;
using SEGISweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SEGISweb.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            var result = new AccountModel().Login(model.Username, model.Password);
            if(result && ModelState.IsValid)
            {
                SessionHelper.setSession(new UserSession() { UserName = model.Username });
                RedirectToAction("Admin","Index","Home");
            }
            else
            {
                ModelState.AddModelError("خطأ","لم يتم تسجيل الدخول");
            }
            return View(model);
        }
    }
}