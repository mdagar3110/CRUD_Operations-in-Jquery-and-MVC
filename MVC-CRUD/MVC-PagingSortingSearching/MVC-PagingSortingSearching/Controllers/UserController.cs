using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_PagingSortingSearching.DAL;
using MVC_PagingSortingSearching.Models;

namespace MVC_PagingSortingSearching.Controllers
{
    public class UserController : Controller
    {
        private DataContext db = new DataContext();
        const int pageSize = 3;

        // GET: /User/
        public ActionResult Search(int page = 1, string sort = "UserId", string sortDir = "ASC", string search="")
        {
            UserModel user = new UserModel();
            var data = user.GetUsers(page, pageSize, sort.ToUpper(), sortDir.ToUpper(),search.ToUpper());
            return View(data);
        }

        // GET: /User/
        public ActionResult Index(int page=1, string sort="UserId", string sortDir="ASC")
        {
            UserModel user = new UserModel();
            var data = user.GetUsers(page, pageSize, sort.ToUpper(), sortDir.ToUpper());
            return View(data);
        }

        // GET: /User/Details/5
        // This function can handle Nullable ID Also
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: /User/Create
        public ActionResult Create()
        {
            return View();
        }

      

        // GET: /User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

    
        // GET: /User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: /User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.User.Find(id);
            db.User.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
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
