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
    public class DomainUsersController : Controller
    {
        private lockEntities db = new lockEntities();

        // GET: DomainUsers
        public ActionResult Index()
        {
            var domainUsers = db.DomainUsers.Include(d => d.Department);
            return View(domainUsers.ToList());
        }

        // GET: DomainUsers/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DomainUser domainUser = db.DomainUsers.Find(id);
            if (domainUser == null)
            {
                return HttpNotFound();
            }
            return View(domainUser);
        }

        // GET: DomainUsers/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Department1");
            return View();
        }

        // POST: DomainUsers/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserName,DepartmentID,NoKey,ShowC,CanShare,UseDeskTop")] DomainUser domainUser)
        {
            if (ModelState.IsValid)
            {
                db.DomainUsers.Add(domainUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Department1", domainUser.DepartmentID);
            return View(domainUser);
        }

        // GET: DomainUsers/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DomainUser domainUser = db.DomainUsers.Find(id);
            if (domainUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Department1", domainUser.DepartmentID);
            return View(domainUser);
        }

        // POST: DomainUsers/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserName,DepartmentID,NoKey,ShowC,CanShare,UseDeskTop")] DomainUser domainUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(domainUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Department1", domainUser.DepartmentID);
            return View(domainUser);
        }

        // GET: DomainUsers/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DomainUser domainUser = db.DomainUsers.Find(id);
            if (domainUser == null)
            {
                return HttpNotFound();
            }
            return View(domainUser);
        }

        // POST: DomainUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            DomainUser domainUser = db.DomainUsers.Find(id);
            db.DomainUsers.Remove(domainUser);
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
