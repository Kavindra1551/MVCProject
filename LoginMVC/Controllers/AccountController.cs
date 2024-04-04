using LoginMVC.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LoginMVC.Controllers
{
    public class AccountController : Controller
    {
        public static bool isLoggedIn = false;
        public static bool isAdmin = false;
        public static bool isUser = false;
        UserdataEntities db = new UserdataEntities();
        // GET: Account
        public ActionResult Index()
        {
            if (isLoggedIn == false || isAdmin == false)
                return HttpNotFound();
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserRegister ur)
        {
            if(ModelState.IsValid) 
            {
                if(db.UserRegisters.Any(x => x.Email == ur.Email)) 
                {
                    ViewBag.Message = "Email already registered";
                    
                }
                else
                {
                    db.UserRegisters.Add(ur);
                    db.SaveChanges();
                    Response.Write("<script>alert('Registration Successful')</script>");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(MyLogin l)
        {
            var query = db.UserRegisters.SingleOrDefault(m => m.Email == l.Email && m.Password == l.Password);
            var query1 = db.AdminRegisters.SingleOrDefault(m => m.AdminEmail == l.Email && m.AdminPassword == l.Password);

            if (query == null && query1 != null )
            {
                isLoggedIn = true;
                isAdmin = true;
                Response.Redirect("~/Groceries/Index");

            }
            else if(query1 == null && query != null)
            {
                isLoggedIn = true;
                isUser = true;
                Response.Redirect("~/Groceries/UserView");
            }
            else
            {
                Response.Write("<script>alert('Invalid  Credentials')</script>");
            }
            return View();
        }
        public ActionResult Logout()
        {
            isLoggedIn = false;
            isUser = false;
            isAdmin = false;

            return RedirectToAction("Index", "Home");
        }
        public ActionResult Password()
        {
            ViewBag.Message = "OTP IS SEND TO THE REGISTERED EMAIL OR PHONE NUMBER";
            return View();
        }

    }
  
}