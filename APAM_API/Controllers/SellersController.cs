using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using APAM_API.Data;
using APAM_API.Models.Identity_Users;

namespace APAM_API.Controllers
{
    public class SellersController : ApiController
    {
        private APAM_APIContext db = new APAM_APIContext();

        [HttpOptions]
        [ResponseType(typeof(void))]
        public IHttpActionResult Options()
        {
            HttpContext.Current.Response.AppendHeader("Allow", "GET, POST, PATCH, PUT, DELETE, OPTIONS");
            HttpContext.Current.Response.AppendHeader("Content-type", "application/json;charset=UTF-8");
            return Ok();
        }

        // GET: api/Sellers
        public IQueryable<Seller> GetIdentityUsers()
        {
            return db.Sellers;
        }

        // GET: api/Sellers/5
        [ResponseType(typeof(Seller))]
        public async Task<IHttpActionResult> GetSeller(string id)
        {
            Seller seller = await db.Sellers.FindAsync(id);
            if (seller == null)
            {
                return NotFound();
            }

            return Ok(seller);
        }

        // PUT: api/Sellers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSeller(string id, Seller seller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != seller.Id)
            {
                return BadRequest();
            }

            db.Entry(seller).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellerExists(id))
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

        // POST: api/Sellers
        [ResponseType(typeof(Seller))]
        public async Task<IHttpActionResult> PostSeller(Seller seller)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sellers.Add(seller);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SellerExists(seller.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = seller.Id }, seller);
        }

        // DELETE: api/Sellers/5
        [ResponseType(typeof(Seller))]
        public async Task<IHttpActionResult> DeleteSeller(string id)
        {
            Seller seller = await db.Sellers.FindAsync(id);
            if (seller == null)
            {
                return NotFound();
            }

            db.Sellers.Remove(seller);
            await db.SaveChangesAsync();

            return Ok(seller);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SellerExists(string id)
        {
            return db.Sellers.Count(e => e.Id == id) > 0;
        }
    }
}