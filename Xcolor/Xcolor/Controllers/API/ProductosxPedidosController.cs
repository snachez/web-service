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
    public class ProductosxPedidosController : ApiController
    {
        private xcolorEntities db = new xcolorEntities();

        // GET: api/ProductosxPedidos
        public IQueryable<ProductosxPedido> GetProductosxPedido()
        {
            return db.ProductosxPedido;
        }

        // GET: api/ProductosxPedidos/5
        [ResponseType(typeof(ProductosxPedido))]
        public IHttpActionResult GetProductosxPedido(int id)
        {
            ProductosxPedido productosxPedido = db.ProductosxPedido.Find(id);
            if (productosxPedido == null)
            {
                return NotFound();
            }

            return Ok(productosxPedido);
        }

        // PUT: api/ProductosxPedidos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProductosxPedido(int id, ProductosxPedido productosxPedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productosxPedido.ID)
            {
                return BadRequest();
            }

            db.Entry(productosxPedido).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductosxPedidoExists(id))
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

        // POST: api/ProductosxPedidos
        [ResponseType(typeof(ProductosxPedido))]
        public IHttpActionResult PostProductosxPedido(ProductosxPedido productosxPedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductosxPedido.Add(productosxPedido);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = productosxPedido.ID }, productosxPedido);
        }

        // DELETE: api/ProductosxPedidos/5
        [ResponseType(typeof(ProductosxPedido))]
        public IHttpActionResult DeleteProductosxPedido(int id)
        {
            ProductosxPedido productosxPedido = db.ProductosxPedido.Find(id);
            if (productosxPedido == null)
            {
                return NotFound();
            }

            db.ProductosxPedido.Remove(productosxPedido);
            db.SaveChanges();

            return Ok(productosxPedido);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductosxPedidoExists(int id)
        {
            return db.ProductosxPedido.Count(e => e.ID == id) > 0;
        }
    }
}