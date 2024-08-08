using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models;
using TravelTripProject.Models.Classes;

namespace TravelTripProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c= new Context();
        [Authorize]
        public ActionResult Index()
        {
            var values=c.Blogs.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult NewBlog() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult DeleteBlog(int id)
        {
            var bl=c.Blogs.Find(id);
            c.Blogs.Remove(bl);
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult FindBlog(int id)
        {
            var fb=c.Blogs.Find(id);
            return View("FindBlog",fb);
        }

        public ActionResult UpdateBlog(Blog b) 
        {
            var blg = c.Blogs.Find(b.Id);
            blg.Description=b.Description;
            blg.Title=b.Title;
            blg.BlogImage=b.BlogImage;
            blg.Date=b.Date;
            c.SaveChanges();
            return RedirectToAction("Index"); 
        }

        public ActionResult CommentList()
        { 
            var comm=c.Comments.ToList();
            return View(comm); 
        }

        public ActionResult DeleteComment(int id)
        {
            var bl = c.Comments.Find(id);
            c.Comments.Remove(bl);
            c.SaveChanges();
            return RedirectToAction("CommentList");

        }

        public ActionResult FindComment(int id)
        {
            var fc = c.Comments.Find(id);
            return View("FindComment", fc);
        }

        public ActionResult UpdateComment(Comment y)
        {
            var yrm = c.Comments.Find(y.Id);
            yrm.Username = y.Username;
            yrm.Mail = y.Mail;
            yrm.CommentDetails = y.CommentDetails;
            c.SaveChanges();
            return RedirectToAction("CommentList");
        }
    }
}