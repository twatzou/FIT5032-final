using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5032_final.Models;

namespace FIT5032_final.Controllers
{
    public class HeritagesController : Controller
    {
        private HeritageModelContainer db = new HeritageModelContainer();

        // GET: Heritages
        public ActionResult Index()
        {
            var heritageSet = db.HeritageSet.Include(h => h.Route);
            return View(heritageSet.ToList());
        }

        // GET: Heritages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heritage heritage = db.HeritageSet.Find(id);
            if (heritage == null)
            {
                return HttpNotFound();
            }
            return View(heritage);
        }

        // GET: Heritages/Create
        public ActionResult Create()
        {
            if (!User.IsInRole("admin"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            ViewBag.RouteId = new SelectList(db.RouteSet, "Id", "Price");
            return View();
        }

        // POST: Heritages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Picture,UpdatedDate,RouteId")] Heritage heritage)
        {
            if (ModelState.IsValid)
            {
                db.HeritageSet.Add(heritage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RouteId = new SelectList(db.RouteSet, "Id", "Price", heritage.RouteId);
            return View(heritage);
        }

        // GET: Heritages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (!User.IsInRole("admin"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            Heritage heritage = db.HeritageSet.Find(id);
            if (heritage == null)
            {
                return HttpNotFound();
            }
            ViewBag.RouteId = new SelectList(db.RouteSet, "Id", "Price", heritage.RouteId);
            return View(heritage);
        }

        // POST: Heritages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Picture,UpdatedDate,RouteId")] Heritage heritage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(heritage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RouteId = new SelectList(db.RouteSet, "Id", "Price", heritage.RouteId);
            return View(heritage);
        }

        // GET: Heritages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (!User.IsInRole("admin"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            Heritage heritage = db.HeritageSet.Find(id);
            if (heritage == null)
            {
                return HttpNotFound();
            }
            return View(heritage);
        }

        // POST: Heritages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Heritage heritage = db.HeritageSet.Find(id);
            db.HeritageSet.Remove(heritage);
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
