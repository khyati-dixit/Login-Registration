using Login_RegisterApplication.DBModel;
using Login_RegisterApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login_RegisterApplication.Controllers
{
    public class AccountController : Controller
    {
        newDBEntities objEntity = new newDBEntities();

        // GET: Account
        public ActionResult Index()
        {
            var res = objEntity.Users.ToList();
            return View(res);
            
        }
        public ActionResult Registration()
        {
            UserModel objUserModel = new UserModel();
            return View(objUserModel);
        }
        [HttpPost]
        public ActionResult Registration(UserModel objUserModel)
        {
            if (ModelState.IsValid)
            {
                if (!objEntity.Users.Any(m => m.Email == objUserModel.Email))
                {
                    User objUser = new DBModel.User();
                    // objUser.CreatedOn = DateTime.Now;
                    objUser.FirstName = objUserModel.FirstName;
                    objUser.LastName = objUserModel.LastName;
                    objUser.Email = objUserModel.Email;
                    objUser.Password = objUserModel.Password;
                    objUser.Age = objUserModel.Age;
                    objUser.Phone = objUserModel.Phone;
                    objUser.City = objUserModel.City;

                    objEntity.Users.Add(objUser);
                    objEntity.SaveChanges();
                    objUserModel = new UserModel();
                    objUserModel.SuccessMessage = "DONE ";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Error", "Email is Already exists!");
                    return View();
                }
            }
            return View();
        }

        public ActionResult Login()
        {
            LoginModel objLoginModel = new LoginModel();
            return View(objLoginModel);
        }
        [HttpPost]
        public ActionResult Login(LoginModel objLoginModel)
        {
            if (ModelState.IsValid)
            {
                if (objEntity.Users.Where(m => m.Email == objLoginModel.Email && m.Password == objLoginModel.Password).FirstOrDefault() == null)
                {
                    ModelState.AddModelError("Error", "Invalid Email and password");
                    return View();
                }
                else
                {
                    Session["Email"] = objLoginModel.Email;
                    return RedirectToAction("Index", "Account");
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Account");

        }


    }
}