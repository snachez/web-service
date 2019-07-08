using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Xcolor.Models;

namespace Xcolor.Controllers.API
{
    public class TiposDireccionesController : ApiController
    {
        private xcolorEntities db = new xcolorEntities();

        // GET: api/TiposDirecciones
        public IQueryable<TipoDireccion> GetTipoDireccion()
        {
            return db.TipoDireccion;
        }

        // GET: api/TiposDirecciones/5
        [ResponseType(typeof(TipoDireccion))]
        public IHttpActionResult GetTipoDireccion(int id)
        {
            TipoDireccion tipoDireccion = db.TipoDireccion.Find(id);
            if (tipoDireccion == null)
            {
                return NotFound();
            }

            return Ok(tipoDireccion);
        }

        // PUT: api/TiposDirecciones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoDireccion(int id, TipoDireccion tipoDireccion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoDireccion.ID)
            {
                return BadRequest();
            }

            db.Entry(tipoDireccion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoDireccionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TiposDirecciones
        [ResponseType(typeof(TipoDireccion))]
        public IHttpActionResult PostTipoDireccion(TipoDireccion tipoDireccion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoDireccion.Add(tipoDireccion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoDireccion.ID }, tipoDireccion);
        }

        // DELETE: api/TiposDirecciones/5
        [ResponseType(typeof(TipoDireccion))]
        public IHttpActionResult DeleteTipoDireccion(int id)
        {
            TipoDireccion tipoDireccion = db.TipoDireccion.Find(id);
            if (tipoDireccion == null)
            {
                return NotFound();
            }

            db.TipoDireccion.Remove(tipoDireccion);
            db.SaveChanges();

            return Ok(tipoDireccion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoDireccionExists(int id)
        {
            return db.TipoDireccion.Count(e => e.ID == id) > 0;
        }
    }
}