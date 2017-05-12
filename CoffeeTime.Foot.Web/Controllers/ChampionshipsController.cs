using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CoffeeTime.Foot.Core.Model;

namespace CoffeeTime.Foot.Web.Controllers
{
    public class ChampionshipsController : Controller
    {
        private CoffeeTime_FootEntities db = new CoffeeTime_FootEntities();

        // GET: Championships
        public ActionResult Index()
        {
            var championships = db.Championships.Include(c => c.Pays);
            return View(championships.ToList());
        }

        // GET: Championships/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Championship championship = db.Championships.Find(id);
            if (championship == null)
            {
                return HttpNotFound();
            }
            return View(championship);
        }

        // GET: Championships/Create
        public ActionResult Create()
        {
            ViewBag.PaysId = new SelectList(db.Pays, "Id", "Label");
            return View();
        }

        // POST: Championships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Label,TeamNumber,WinPts,DefeatPts,TiePts,PaysId")] Championship championship)
        {
            if (ModelState.IsValid)
            {
                db.Championships.Add(championship);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PaysId = new SelectList(db.Pays, "Id", "Label", championship.PaysId);
            return View(championship);
        }

        // GET: Championships/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Championship championship = db.Championships.Find(id);
            if (championship == null)
            {
                return HttpNotFound();
            }
            ViewBag.PaysId = new SelectList(db.Pays, "Id", "Label", championship.PaysId);
            return View(championship);
        }

        // POST: Championships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Label,TeamNumber,WinPts,DefeatPts,TiePts,PaysId")] Championship championship)
        {
            if (ModelState.IsValid)
            {
                db.Entry(championship).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PaysId = new SelectList(db.Pays, "Id", "Label", championship.PaysId);
            return View(championship);
        }

        // GET: Championships/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Championship championship = db.Championships.Find(id);
            if (championship == null)
            {
                return HttpNotFound();
            }
            return View(championship);
        }

        // POST: Championships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Championship championship = db.Championships.Find(id);
            db.Championships.Remove(championship);
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
