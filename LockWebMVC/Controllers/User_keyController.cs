using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LockWebMVC;

namespace LockWebMVC.Controllers
{
    public class User_keyController : Controller
    {
        private lockEntities db = new lockEntities();

        // GET: User_key
        public ActionResult Index()
        {
            var user_key = db.User_key.Include(u => u.DomainUser).Include(u => u.Ukey);
            return View(user_key.ToList());
        }

        // GET: User_key/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_key user_key = db.User_key.Find(id);
            if (user_key == null)
            {
                return HttpNotFound();
            }
            return View(user_key);
        }
       

        // GET: User_key/Create
        public ActionResult Create()
        {
            var user_key = db.User_key.Include(u => u.DomainUser).Include(u => u.Ukey);
            ViewBag.UserID = new SelectList(db.DomainUsers.Where(x=>x.User_key.Count==0), "ID", "UserName");
            ViewBag.KeyID = new SelectList(db.Ukeys.Where(x=>x.User_key.Count==0), "ID", "CN");
            return View();
        }

        // POST: User_key/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserID,KeyID")] User_key user_key)
        {
            if (ModelState.IsValid)
            {
                db.User_key.Add(user_key);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.DomainUsers, "ID", "UserName", user_key.UserID);
            ViewBag.KeyID = new SelectList(db.Ukeys, "ID", "CN", user_key.KeyID);
            return View(user_key);
        }

        // GET: User_key/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_key user_key = db.User_key.Find(id);
            if (user_key == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.DomainUsers, "ID", "UserName", user_key.UserID);
            ViewBag.KeyID = new SelectList(db.Ukeys, "ID", "CN", user_key.KeyID);
            return View(user_key);
        }

        // POST: User_key/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,KeyID")] User_key user_key)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_key).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.DomainUsers, "ID", "UserName", user_key.UserID);
            ViewBag.KeyID = new SelectList(db.Ukeys, "ID", "CN", user_key.KeyID);
            return View(user_key);
        }

        // GET: User_key/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_key user_key = db.User_key.Find(id);
            if (user_key == null)
            {
                return HttpNotFound();
            }
            return View(user_key);
        }

        // POST: User_key/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            User_key user_key = db.User_key.Find(id);
            db.User_key.Remove(user_key);
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
