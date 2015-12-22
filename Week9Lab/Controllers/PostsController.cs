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

        public ActionResult Index()
        {

            var model = db.Posts.Select(x => new PostIndexVM()
            {
                Message = x.Message,
                PostId = x.Id,
                Author = x.User.UserName,
                PostedOn = x.Created
            }).ToList();

            return View(model);

        }

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
        public ActionResult UnFollow(string userId)
        {
            var currentUserID = User.Identity.GetUserId();
            var currentUser = db.Users.Find(currentUserID);

            var personToFollow = db.Users.Find(userId);

            currentUser.WhoIFollow.Remove(personToFollow);

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
            return RedirectToAction("Index");
            //return RedirectToAction("Start", "Twitter");
        }
        //[HttpGet]
        //List<Post> GetTimeLine()
        //{
        //    var followerIds = db.Users.Where(f => f.FollowedById == MyUserId).Select(f => f.Userid);
        //    var allIds = followerIds.Add(MyUserId);
        //    return db.Posts.Where(x => allIds.Contains(x.PostedById)).OrderByDesc(x => x.CreatedBy);
        //}



        [HttpGet]
        public ActionResult Create()
        {
            return View();
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
