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

        // GET: Posts
        public ActionResult Index()
        {
            return View(db.Posts.ToList());
        }


        // GET: Posts/Create
        public ActionResult Create()
        {
            return View();
        }




        //Get: Users followed
        [Authorize]
        public ActionResult Followed()
        {
            User user = db.Users.Find(User.Identity.GetUserId());
            return View(user.UsersFollowed.Select(u => new UsersFollowedVM() { FullName = u.FirstName + " " + u.LastName, UserName = u.UserName, Id = u.Id }));
        }

        //Get: Choose who to follow
        [Authorize]
        public ActionResult FindUsers()
        {
            var userid = User.Identity.GetUserId();

            //grab all the users except for me. Already Following defaults to false here.
            var model = db.Users.Where(x => x.Id != userid).Select(u => new UsersFollowedVM()
            {
                FullName = u.FirstName + " " + u.LastName,
                UserName = u.UserName,
                Id = u.Id
            }).ToList();

            //grab JUST the ids of all the people I'm following
            var userids = db.Users.Find(userid).UsersFollowed.ToList().Select(x => x.Id);

            //go back through the model and if the model's id is in my list of ids I'm following them mark them as 'Already Following'
            foreach (var m in model)
            {
                if (userids.Contains(m.Id))
                    m.AlreadyFollowing = true;
            }

            return View(model);
        }








        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostId,Title,Message,ImageUrl")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }







        //Post: Choose who to follow
        [HttpPost]
        public ActionResult FollowUser(string Id)
        {
            User user = db.Users.Find(User.Identity.GetUserId());

            var followedUser = user.UsersFollowed.Where(i => i.Id == Id).FirstOrDefault();
            if (followedUser == null)
            {
                UsersFollwedVM whoTheyWantToFollow = db.Users.Find(Id);
                user.UsersFollowed.Add(whoTheyWantToFollow);
                db.SaveChanges();
            }
            return Content("OK");
        }

        [HttpPost]
        public ActionResult UnFollowUser(string Id)
        {
            User user = db.Users.Find(User.Identity.GetUserId());
            var unfollowedUser = user.UsersFollowed.Where(i => i.Id == Id).FirstOrDefault();
            user.UsersFollowed.Remove(unfollowedUser);
            db.SaveChanges();
            return Content("OK");
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
