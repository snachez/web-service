using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Xcolor.Models;

namespace Xcolor.Controllers
{
    public class CantonsController : Controller
    {
        private xcolorEntities db = new xcolorEntities();

        // GET: Cantons
        public ActionResult Index()
        {
            var canton = db.Canton.Include(c => c.Provincia);
            return View(canton.ToList());
        }

        // GET: Cantons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Canton canton = db.Canton.Find(id);
            if (canton == null)
            {
                return HttpNotFound();
            }
            return View(canton);
        }

        // GET: Cantons/Create
        public ActionResult Create()
        {
            ViewBag.idProvincia = new SelectList(db.Provincia, "ID", "provincia1");
            return View();
        }

        // POST: Cantons/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,idProvincia,canton1")] Canton canton)
        {
            if (ModelState.IsValid)
            {
                db.Canton.Add(canton);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idProvincia = new SelectList(db.Provincia, "ID", "provincia1", canton.idProvincia);
            return View(canton);
        }

        // GET: Cantons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Canton canton = db.Canton.Find(id);
            if (canton == null)
            {
                return HttpNotFound();
            }
            ViewBag.idProvincia = new SelectList(db.Provincia, "ID", "provincia1", canton.idProvincia);
            return View(canton);
        }

        // POST: Cantons/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,idProvincia,canton1")] Canton canton)
        {
            if (ModelState.IsValid)
            {
                db.Entry(canton).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idProvincia = new SelectList(db.Provincia, "ID", "provincia1", canton.idProvincia);
            return View(canton);
        }

        // GET: Cantons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Canton canton = db.Canton.Find(id);
            if (canton == null)
            {
                return HttpNotFound();
            }
            return View(canton);
        }

        // POST: Cantons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Canton canton = db.Canton.Find(id);
            db.Canton.Remove(canton);
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
