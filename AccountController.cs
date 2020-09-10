using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppRegisLogin.DBModel;
using WebAppRegisLogin.Models;

namespace WebAppRegisLogin.Controllers
{
    public class AccountController : Controller
    {
        UserDBEntities objUserDBEntities = new UserDBEntities();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            UserModel objUserModel = new UserModel();
            return View(objUserModel);
        }
        [HttpPost]
        public ActionResult Register(UserModel objUserModel)
        {
            if (ModelState.IsValid)
            {
                User objUser = new DBModel.User();
                objUser.CreatedOn = DateTime.Now;
                objUser.Email = objUserModel.Email;
                objUser.FirstName = objUserModel.FirstName;
                objUser.LastName = objUserModel.LastName;
                objUser.Password = objUserModel.Password;

                objUserDBEntities.Users.Add(objUser);
                objUserDBEntities.SaveChanges();
                objUserModel = new UserModel();
                objUserModel.SuccessMessage = "User is Successfully Added";
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        public ActionResult Login()
        {
            LoginModel objloginModel = new LoginModel();
            return View(objloginModel);
        }
        [HttpPost]
        public ActionResult Login(LoginModel objloginModel)
        {
            if (ModelState.IsValid)
            {
               if( objUserDBEntities.Users.Where(m => m.Email == objloginModel.Email && m.Password == objloginModel.Password).FirstOrDefault() == null)
                {
                    ModelState.AddModelError("Error", "Invalid Email and Password");
                    return View();
                }
                else
                {
                    Session["Email"] = objloginModel.Email;
                    return RedirectToAction("List", "Account");
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }
        public ActionResult List()
        {
            var res = objUserDBEntities.Users.ToList();
            return View(res);
        }
    }
}