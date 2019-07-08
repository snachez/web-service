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
    public class DistritosController : ApiController
    {
        private xcolorEntities db = new xcolorEntities();

        // GET: api/Distritos
        public IQueryable<Distrito> GetDistrito()
        {
            return db.Distrito;
        }

        // GET: api/Distritos/5
        [ResponseType(typeof(Distrito))]
        public IHttpActionResult GetDistrito(int id)
        {
            Distrito distrito = db.Distrito.Find(id);
            if (distrito == null)
            {
                return NotFound();
            }

            return Ok(distrito);
        }

        // PUT: api/Distritos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDistrito(int id, Distrito distrito)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != distrito.ID)
            {
                return BadRequest();
            }

            db.Entry(distrito).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistritoExists(id))
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

        // POST: api/Distritos
        [ResponseType(typeof(Distrito))]
        public IHttpActionResult PostDistrito(Distrito distrito)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Distrito.Add(distrito);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = distrito.ID }, distrito);
        }

        // DELETE: api/Distritos/5
        [ResponseType(typeof(Distrito))]
        public IHttpActionResult DeleteDistrito(int id)
        {
            Distrito distrito = db.Distrito.Find(id);
            if (distrito == null)
            {
                return NotFound();
            }

            db.Distrito.Remove(distrito);
            db.SaveChanges();

            return Ok(distrito);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DistritoExists(int id)
        {
            return db.Distrito.Count(e => e.ID == id) > 0;
        }
    }
}