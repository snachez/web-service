using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Xcolor.Models;

namespace Xcolor.Controllers.API
{
    public class ProvinciasController : ApiController
    {
        private xcolorEntities db = new xcolorEntities();

        // GET: api/Provincias
        public IEnumerable<Provincia> GetProvincia()
        {
            var data = db.ProvinciaSelectAll();
            return data.ToList();
        }

        // GET: api/Provincias/5
        [ResponseType(typeof(Provincia))]
        public IHttpActionResult GetProvincia(int id)
        {
            var provincia = db.ProvinciaSelect(id);
            if (provincia == null)
            {
                return NotFound();
            }

            return Ok(provincia);
        }

        // PUT: api/Provincias/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult PutProvincia(int ID, Provincia provincia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (ID != provincia.ID)
            {
                return BadRequest();
            }

            var prov = db.ProvinciaUpdate(ID,provincia.provincia);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvinciaExists(ID))
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

        // POST: api/Provincias
        [ResponseType(typeof(Provincia))]
        [HttpPost]
        public IHttpActionResult PostProvincia(Provincia rovincia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var provid = db.ProvinciaInsert(rovincia.provincia);

            return CreatedAtRoute("DefaultApi", new { id = rovincia.ID }, rovincia);
        }

        // DELETE: api/Provincias/5
        [ResponseType(typeof(Provincia))]
        [HttpDelete]
        public IHttpActionResult DeleteProvincia(int id)
        {
            Provincia provincia = db.Provincia.Find(id);
            if (provincia == null)
            {
                return NotFound();
            }

            var prov = db.ProvinciaDelete(id);

            return Ok(provincia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProvinciaExists(int id)
        {
            return db.Provincia.Count(e => e.ID == id) > 0;
        }
    }
}