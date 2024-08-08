using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TravelTripProject.Models.Classes;

namespace TravelTripProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context c= new Context();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login() 
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult Login(Admin ad) 
        {
            var info=c.Admins.FirstOrDefault(x=>x.Username==ad.Username&&x.Password==ad.Password);
            if(info!=null)
            {
                FormsAuthentication.SetAuthCookie(info.Username,false);
                Session["Username"]=info.Username.ToString();
                return RedirectToAction("Index","Admin");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
    }
}