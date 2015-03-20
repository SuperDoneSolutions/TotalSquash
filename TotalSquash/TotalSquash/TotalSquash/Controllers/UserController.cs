using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TotalSquash.Models;

namespace TotalSquash.Controllers
{
    public class UserController : Controller
    {
        private PrimarySquashDBContext db = new PrimarySquashDBContext();

        // GET: /User/
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.AccountType).Include(u => u.Country).Include(u => u.Province).Include(u => u.Skill);
            return View(users.ToList());
        }

        // GET: /User/Details/5
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

        // GET: /User/Create
        public ActionResult Create()
        {
            ViewBag.accountId = new SelectList(db.AccountTypes, "accountId", "description");
            ViewBag.countryId = new SelectList(db.Countries, "countryId", "countryName");
            ViewBag.provinceId = new SelectList(db.Provinces, "provinceId", "provinceName");
            ViewBag.skillId = new SelectList(db.Skills, "skillId", "description");
            return View();
        }

        // POST: /User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,username,skillId,password,photo,wins,losses,ties,firstName,lastName,streetAddress,city,provinceId,countryId,phoneNumber,emailAddress,gender,birthDate,accountId,locked")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.accountId = new SelectList(db.AccountTypes, "accountId", "description", user.accountId);
            ViewBag.countryId = new SelectList(db.Countries, "countryId", "countryName", user.countryId);
            ViewBag.provinceId = new SelectList(db.Provinces, "provinceId", "provinceName", user.provinceId);
            ViewBag.skillId = new SelectList(db.Skills, "skillId", "description", user.skillId);
            return View(user);
        }

        // GET: /User/Edit/5
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
            ViewBag.accountId = new SelectList(db.AccountTypes, "accountId", "description", user.accountId);
            ViewBag.countryId = new SelectList(db.Countries, "countryId", "countryName", user.countryId);
            ViewBag.provinceId = new SelectList(db.Provinces, "provinceId", "provinceName", user.provinceId);
            ViewBag.skillId = new SelectList(db.Skills, "skillId", "description", user.skillId);
            return View(user);
        }

        // POST: /User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,username,skillId,password,photo,wins,losses,ties,firstName,lastName,streetAddress,city,provinceId,countryId,phoneNumber,emailAddress,gender,birthDate,accountId,locked")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.accountId = new SelectList(db.AccountTypes, "accountId", "description", user.accountId);
            ViewBag.countryId = new SelectList(db.Countries, "countryId", "countryName", user.countryId);
            ViewBag.provinceId = new SelectList(db.Provinces, "provinceId", "provinceName", user.provinceId);
            ViewBag.skillId = new SelectList(db.Skills, "skillId", "description", user.skillId);
            return View(user);
        }

        // GET: /User/Delete/5
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

        // POST: /User/Delete/5
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
