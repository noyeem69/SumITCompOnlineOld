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
using SumITCompOnline.Entities;
using SumITCompOnline.WebApi.DataContexts;

namespace SumITCompOnline.WebApi.Controllers
{
    /// <summary>
    ///     Controller for Products resources.
    ///     ProductsController uses WebAPI v2.0 features.
    ///     Author: Risath
    /// </summary>

    public class ProductsController : ApiController
    {
        private readonly IProductContext _db;

        public ProductsController()
        {
            _db = new ProductContext();
        }

        public ProductsController(IProductContext db)
        {
            _db = db;
        }

        public IEnumerable<Product> Get()
        {

            return _db.Products;
        }

        [ResponseType(typeof(Product))]
        public IHttpActionResult Get(long id)
        {
            Product product = _db.Products.SingleOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(long id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            _db.MarkAsModified(product);

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Products.Add(product);
            _db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }


        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(long id)
        {
            Product product = _db.Products.SingleOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            _db.Products.Remove(product);
            _db.SaveChanges();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(long id)
        {
            return _db.Products.Count(e => e.Id == id) > 0;
        }
    }
}