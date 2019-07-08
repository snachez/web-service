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
    public class TelefonosClientesController : ApiController
    {
        private xcolorEntities db = new xcolorEntities();

        // GET: api/TelefonosClientes
        public IQueryable<TelefonoCliente> GetTelefonoCliente()
        {
            return db.TelefonoCliente;
        }

        // GET: api/TelefonosClientes/5
        [ResponseType(typeof(TelefonoCliente))]
        public IHttpActionResult GetTelefonoCliente(int id)
        {
            TelefonoCliente telefonoCliente = db.TelefonoCliente.Find(id);
            if (telefonoCliente == null)
            {
                return NotFound();
            }

            return Ok(telefonoCliente);
        }

        // PUT: api/TelefonosClientes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTelefonoCliente(int id, TelefonoCliente telefonoCliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != telefonoCliente.ID)
            {
                return BadRequest();
            }

            db.Entry(telefonoCliente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelefonoClienteExists(id))
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

        // POST: api/TelefonosClientes
        [ResponseType(typeof(TelefonoCliente))]
        public IHttpActionResult PostTelefonoCliente(TelefonoCliente telefonoCliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TelefonoCliente.Add(telefonoCliente);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = telefonoCliente.ID }, telefonoCliente);
        }

        // DELETE: api/TelefonosClientes/5
        [ResponseType(typeof(TelefonoCliente))]
        public IHttpActionResult DeleteTelefonoCliente(int id)
        {
            TelefonoCliente telefonoCliente = db.TelefonoCliente.Find(id);
            if (telefonoCliente == null)
            {
                return NotFound();
            }

            db.TelefonoCliente.Remove(telefonoCliente);
            db.SaveChanges();

            return Ok(telefonoCliente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TelefonoClienteExists(int id)
        {
            return db.TelefonoCliente.Count(e => e.ID == id) > 0;
        }
    }
}