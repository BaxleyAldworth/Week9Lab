using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Week9Lab.Models;

namespace Week9Lab.Controllers
{
    [Authorize]
    public class PostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpPost]
        public ActionResult Follow(string userId)
        {
            var currentUserID = User.Identity.GetUserId();
            var currentUser = db.Users.Find(currentUserID);

            var personToFollow = db.Users.Find(userId);

            currentUser.WhoIFollow.Add(personToFollow);

            db.SaveChanges();
         
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult Create(string message)
        {
            var currentUserId = User.Identity.GetUserId();

            var post = new Post()
            {
                Created = DateTime.Now,
                User = db.Users.Find(currentUserId),
                Message = message
            };

            db.Posts.Add(post);
            db.SaveChanges();
            return RedirectToAction("Start", "Twitter");
        }







        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
