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
    public class TipoTelefonosController : ApiController
    {
        private xcolorEntities db = new xcolorEntities();

        // GET: api/TipoTelefonos
        public IQueryable<TipoTelefono> GetTipoTelefono()
        {
            return db.TipoTelefono;
        }

        // GET: api/TipoTelefonos/5
        [ResponseType(typeof(TipoTelefono))]
        public IHttpActionResult GetTipoTelefono(int id)
        {
            TipoTelefono tipoTelefono = db.TipoTelefono.Find(id);
            if (tipoTelefono == null)
            {
                return NotFound();
            }

            return Ok(tipoTelefono);
        }

        // PUT: api/TipoTelefonos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoTelefono(int id, TipoTelefono tipoTelefono)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoTelefono.ID)
            {
                return BadRequest();
            }

            db.Entry(tipoTelefono).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoTelefonoExists(id))
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

        // POST: api/TipoTelefonos
        [ResponseType(typeof(TipoTelefono))]
        public IHttpActionResult PostTipoTelefono(TipoTelefono tipoTelefono)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoTelefono.Add(tipoTelefono);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoTelefono.ID }, tipoTelefono);
        }

        // DELETE: api/TipoTelefonos/5
        [ResponseType(typeof(TipoTelefono))]
        public IHttpActionResult DeleteTipoTelefono(int id)
        {
            TipoTelefono tipoTelefono = db.TipoTelefono.Find(id);
            if (tipoTelefono == null)
            {
                return NotFound();
            }

            db.TipoTelefono.Remove(tipoTelefono);
            db.SaveChanges();

            return Ok(tipoTelefono);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoTelefonoExists(int id)
        {
            return db.TipoTelefono.Count(e => e.ID == id) > 0;
        }
    }
}