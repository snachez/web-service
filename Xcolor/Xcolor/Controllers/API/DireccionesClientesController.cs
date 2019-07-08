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
    public class DireccionesClientesController : ApiController
    {
        private xcolorEntities db = new xcolorEntities();

        // GET: api/DireccionesClientes
        public IQueryable<DireccionCliente> GetDireccionCliente()
        {
            return db.DireccionCliente;
        }

        // GET: api/DireccionesClientes/5
        [ResponseType(typeof(DireccionCliente))]
        public IHttpActionResult GetDireccionCliente(int id)
        {
            DireccionCliente direccionCliente = db.DireccionCliente.Find(id);
            if (direccionCliente == null)
            {
                return NotFound();
            }

            return Ok(direccionCliente);
        }

        // PUT: api/DireccionesClientes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDireccionCliente(int id, DireccionCliente direccionCliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != direccionCliente.ID)
            {
                return BadRequest();
            }

            db.Entry(direccionCliente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DireccionClienteExists(id))
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

        // POST: api/DireccionesClientes
        [ResponseType(typeof(DireccionCliente))]
        public IHttpActionResult PostDireccionCliente(DireccionCliente direccionCliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DireccionCliente.Add(direccionCliente);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = direccionCliente.ID }, direccionCliente);
        }

        // DELETE: api/DireccionesClientes/5
        [ResponseType(typeof(DireccionCliente))]
        public IHttpActionResult DeleteDireccionCliente(int id)
        {
            DireccionCliente direccionCliente = db.DireccionCliente.Find(id);
            if (direccionCliente == null)
            {
                return NotFound();
            }

            db.DireccionCliente.Remove(direccionCliente);
            db.SaveChanges();

            return Ok(direccionCliente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DireccionClienteExists(int id)
        {
            return db.DireccionCliente.Count(e => e.ID == id) > 0;
        }
    }
}