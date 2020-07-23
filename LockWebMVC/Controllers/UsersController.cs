using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LockWebMVC;
using PagedList;

namespace LockWebMVC.Controllers
{
    public class UsersController : Controller
    {
        private lockEntities db = new lockEntities();

        // GET: Users
        public ActionResult Index(int? PageSize, int? page,int? DID,string SearchString)
        {
            //保存状态
            ViewBag.DID = DID;
            ViewBag.SearchString = SearchString;
            ViewBag.PageSize = PageSize;
            ViewBag.DepartmentList = db.Departments.ToList();
            ViewBag.TotalCount = db.Users.Count();
            //
            var users = db.Users.Include(u => u.Department1).Include(u => u.AuthType1);
            if(DID!=null)
            {
                users = db.Users.Include(u => u.Department1).Include(u => u.AuthType1).Where(u => u.DepartmentID == DID);
            }

            if(SearchString!=null)
            {
                users = users.Where(u => u.Name.Contains(SearchString)
                  || u.SpecificDepartment.Contains(SearchString)                
                  || u.IpAddress.Contains(SearchString)
                  || u.Address.Contains(SearchString)
                  ||u.CN.Contains(SearchString)
                  ||u.DomainUserName.Contains(SearchString)

                );
            }

            users = users.OrderBy(x => x.Approved).ThenByDescending(x => x.ID);

            //分页
            int pageSize = PageSize ?? 10;
            int pageNumber = (page ?? 1);
            return View(users.ToPagedList(pageNumber, pageSize));
           
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "DepartmentName");
            ViewBag.AuthTypeID = new SelectList(db.AuthTypes, "ID", "AuthName");
            return View();
        }

        // POST: Users/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,DepartmentID,SpecificDepartment,Address,Number,DomainUserName,IpAddress,MacAddress,CN,Password,ShowC,CanShare,UseDeskTop,Approved,AuthTypeID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "DepartmentName", user.DepartmentID);
            ViewBag.AuthTypeID = new SelectList(db.AuthTypes, "ID", "AuthName", user.AuthTypeID);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "DepartmentName", user.DepartmentID);
            ViewBag.AuthTypeID = new SelectList(db.AuthTypes, "ID", "AuthName", user.AuthTypeID);
            return View(user);
        }

        // POST: Users/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,DepartmentID,SpecificDepartment,Address,Number,DomainUserName,IpAddress,MacAddress,CN,Password,ShowC,CanShare,UseDeskTop,Usb,Approved,AuthTypeID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "DepartmentName", user.DepartmentID);
            ViewBag.AuthTypeID = new SelectList(db.AuthTypes, "ID", "AuthName", user.AuthTypeID);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
