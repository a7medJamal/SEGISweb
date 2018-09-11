using ModelsData;
using SEGISweb.Common;
using SEGISweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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

            if (ModelState.IsValid)
            {
                var dataAcesslayer = new AccountModel();
                var result = dataAcesslayer.Login(model.Username, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var user = dataAcesslayer.GetById(model.Username);
                    var usersession = new UserLogin();
                    usersession.UserName = user.UserName;
                    usersession.UserID = user.ID;
                    Session.Add(CommonConstants.User_Session, usersession);
                    return RedirectToAction("Home", "Admin", "Index");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", " اسم المستخدم غير صحيح");

                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "هذا المستخدم غير مسموح له بالدخول");

                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "كلمه المرور خطأ");

                }

                else
                {
                    ModelState.AddModelError("", "كلمه السر او اسم المستخدم غير صحيح");

                }
            }
            return View("Index");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "LogIn");
        }
    }
}