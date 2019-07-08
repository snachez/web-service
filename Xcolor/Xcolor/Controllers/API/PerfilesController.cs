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
    public class PerfilesController : ApiController
    {
        private xcolorEntities db = new xcolorEntities();

        // GET: api/Perfiles
        public IQueryable<Perfil> GetPerfil()
        {
            return db.Perfil;
        }

        // GET: api/Perfiles/5
        [ResponseType(typeof(Perfil))]
        public IHttpActionResult GetPerfil(int id)
        {
            Perfil perfil = db.Perfil.Find(id);
            if (perfil == null)
            {
                return NotFound();
            }

            return Ok(perfil);
        }

        // PUT: api/Perfiles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPerfil(int id, Perfil perfil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != perfil.ID)
            {
                return BadRequest();
            }

            db.Entry(perfil).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerfilExists(id))
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

        // POST: api/Perfiles
        [ResponseType(typeof(Perfil))]
        public IHttpActionResult PostPerfil(Perfil perfil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Perfil.Add(perfil);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = perfil.ID }, perfil);
        }

        // DELETE: api/Perfiles/5
        [ResponseType(typeof(Perfil))]
        public IHttpActionResult DeletePerfil(int id)
        {
            Perfil perfil = db.Perfil.Find(id);
            if (perfil == null)
            {
                return NotFound();
            }

            db.Perfil.Remove(perfil);
            db.SaveChanges();

            return Ok(perfil);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PerfilExists(int id)
        {
            return db.Perfil.Count(e => e.ID == id) > 0;
        }
    }
}