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
    public class DireccionClientesController : Controller
    {
        private xcolorEntities db = new xcolorEntities();

        // GET: DireccionClientes
        public ActionResult Index()
        {
            var direccionCliente = db.DireccionCliente.Include(d => d.Canton).Include(d => d.Cliente).Include(d => d.Distrito).Include(d => d.Provincia).Include(d => d.TipoDireccion);
            return View(direccionCliente.ToList());
        }

        // GET: DireccionClientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DireccionCliente direccionCliente = db.DireccionCliente.Find(id);
            if (direccionCliente == null)
            {
                return HttpNotFound();
            }
            return View(direccionCliente);
        }

        // GET: DireccionClientes/Create
        public ActionResult Create()
        {
            ViewBag.idCanton = new SelectList(db.Canton, "ID", "canton1");
            ViewBag.idCliente = new SelectList(db.Cliente, "ID", "nombre");
            ViewBag.idDistrito = new SelectList(db.Distrito, "ID", "Distrito1");
            ViewBag.idProvincia = new SelectList(db.Provincia, "ID", "provincia1");
            ViewBag.idTipoDireccion = new SelectList(db.TipoDireccion, "ID", "tipoDireccion1");
            return View();
        }

        // POST: DireccionClientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,idCliente,direccion,idProvincia,idCanton,idDistrito,idTipoDireccion")] DireccionCliente direccionCliente)
        {
            if (ModelState.IsValid)
            {
                db.DireccionCliente.Add(direccionCliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCanton = new SelectList(db.Canton, "ID", "canton1", direccionCliente.idCanton);
            ViewBag.idCliente = new SelectList(db.Cliente, "ID", "nombre", direccionCliente.idCliente);
            ViewBag.idDistrito = new SelectList(db.Distrito, "ID", "Distrito1", direccionCliente.idDistrito);
            ViewBag.idProvincia = new SelectList(db.Provincia, "ID", "provincia1", direccionCliente.idProvincia);
            ViewBag.idTipoDireccion = new SelectList(db.TipoDireccion, "ID", "tipoDireccion1", direccionCliente.idTipoDireccion);
            return View(direccionCliente);
        }

        // GET: DireccionClientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DireccionCliente direccionCliente = db.DireccionCliente.Find(id);
            if (direccionCliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCanton = new SelectList(db.Canton, "ID", "canton1", direccionCliente.idCanton);
            ViewBag.idCliente = new SelectList(db.Cliente, "ID", "nombre", direccionCliente.idCliente);
            ViewBag.idDistrito = new SelectList(db.Distrito, "ID", "Distrito1", direccionCliente.idDistrito);
            ViewBag.idProvincia = new SelectList(db.Provincia, "ID", "provincia1", direccionCliente.idProvincia);
            ViewBag.idTipoDireccion = new SelectList(db.TipoDireccion, "ID", "tipoDireccion1", direccionCliente.idTipoDireccion);
            return View(direccionCliente);
        }

        // POST: DireccionClientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,idCliente,direccion,idProvincia,idCanton,idDistrito,idTipoDireccion")] DireccionCliente direccionCliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(direccionCliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCanton = new SelectList(db.Canton, "ID", "canton1", direccionCliente.idCanton);
            ViewBag.idCliente = new SelectList(db.Cliente, "ID", "nombre", direccionCliente.idCliente);
            ViewBag.idDistrito = new SelectList(db.Distrito, "ID", "Distrito1", direccionCliente.idDistrito);
            ViewBag.idProvincia = new SelectList(db.Provincia, "ID", "provincia1", direccionCliente.idProvincia);
            ViewBag.idTipoDireccion = new SelectList(db.TipoDireccion, "ID", "tipoDireccion1", direccionCliente.idTipoDireccion);
            return View(direccionCliente);
        }

        // GET: DireccionClientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DireccionCliente direccionCliente = db.DireccionCliente.Find(id);
            if (direccionCliente == null)
            {
                return HttpNotFound();
            }
            return View(direccionCliente);
        }

        // POST: DireccionClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DireccionCliente direccionCliente = db.DireccionCliente.Find(id);
            db.DireccionCliente.Remove(direccionCliente);
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
