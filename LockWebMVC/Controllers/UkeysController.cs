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
    public class UkeysController : Controller
    {
        private lockEntities db = new lockEntities();

        // GET: Ukeys
        public ActionResult Index()
        {
            return View(db.Ukeys.ToList());
        }

        // GET: Ukeys/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ukey ukey = db.Ukeys.Find(id);
            if (ukey == null)
            {
                return HttpNotFound();
            }
            return View(ukey);
        }

        // GET: Ukeys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ukeys/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CN")] Ukey ukey)
        {
            if (ModelState.IsValid)
            {
                db.Ukeys.Add(ukey);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ukey);
        }

        // GET: Ukeys/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ukey ukey = db.Ukeys.Find(id);
            if (ukey == null)
            {
                return HttpNotFound();
            }
            return View(ukey);
        }

        // POST: Ukeys/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CN")] Ukey ukey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ukey).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ukey);
        }

        // GET: Ukeys/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ukey ukey = db.Ukeys.Find(id);
            if (ukey == null)
            {
                return HttpNotFound();
            }
            return View(ukey);
        }

        // POST: Ukeys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Ukey ukey = db.Ukeys.Find(id);
            db.Ukeys.Remove(ukey);
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
