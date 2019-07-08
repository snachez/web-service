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
    public class PermisosxPerfilesController : ApiController
    {
        private xcolorEntities db = new xcolorEntities();

        // GET: api/PermisosxPerfiles
        public IQueryable<PermisosxPerfil> GetPermisosxPerfil()
        {
            return db.PermisosxPerfil;
        }

        // GET: api/PermisosxPerfiles/5
        [ResponseType(typeof(PermisosxPerfil))]
        public IHttpActionResult GetPermisosxPerfil(int id)
        {
            PermisosxPerfil permisosxPerfil = db.PermisosxPerfil.Find(id);
            if (permisosxPerfil == null)
            {
                return NotFound();
            }

            return Ok(permisosxPerfil);
        }

        // PUT: api/PermisosxPerfiles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPermisosxPerfil(int id, PermisosxPerfil permisosxPerfil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != permisosxPerfil.ID)
            {
                return BadRequest();
            }

            db.Entry(permisosxPerfil).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PermisosxPerfilExists(id))
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

        // POST: api/PermisosxPerfiles
        [ResponseType(typeof(PermisosxPerfil))]
        public IHttpActionResult PostPermisosxPerfil(PermisosxPerfil permisosxPerfil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PermisosxPerfil.Add(permisosxPerfil);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = permisosxPerfil.ID }, permisosxPerfil);
        }

        // DELETE: api/PermisosxPerfiles/5
        [ResponseType(typeof(PermisosxPerfil))]
        public IHttpActionResult DeletePermisosxPerfil(int id)
        {
            PermisosxPerfil permisosxPerfil = db.PermisosxPerfil.Find(id);
            if (permisosxPerfil == null)
            {
                return NotFound();
            }

            db.PermisosxPerfil.Remove(permisosxPerfil);
            db.SaveChanges();

            return Ok(permisosxPerfil);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PermisosxPerfilExists(int id)
        {
            return db.PermisosxPerfil.Count(e => e.ID == id) > 0;
        }
    }
}