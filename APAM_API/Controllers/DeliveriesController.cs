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
using APAM_API.Models.Selling_System;

namespace APAM_API.Controllers
{
    public class DeliveriesController : ApiController
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

        // GET: api/Deliveries
        public IQueryable<Delivery> GetDeliveries()
        {
            return db.Deliveries;
        }

        // GET: api/Deliveries/5
        [ResponseType(typeof(Delivery))]
        public async Task<IHttpActionResult> GetDelivery(string id)
        {
            Delivery delivery = await db.Deliveries.FindAsync(id);
            if (delivery == null)
            {
                return NotFound();
            }

            return Ok(delivery);
        }

        // PUT: api/Deliveries/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDelivery(string id, Delivery delivery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != delivery.Id)
            {
                return BadRequest();
            }

            db.Entry(delivery).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryExists(id))
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

        // POST: api/Deliveries
        [ResponseType(typeof(Delivery))]
        public async Task<IHttpActionResult> PostDelivery(Delivery delivery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Deliveries.Add(delivery);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DeliveryExists(delivery.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = delivery.Id }, delivery);
        }

        // DELETE: api/Deliveries/5
        [ResponseType(typeof(Delivery))]
        public async Task<IHttpActionResult> DeleteDelivery(string id)
        {
            Delivery delivery = await db.Deliveries.FindAsync(id);
            if (delivery == null)
            {
                return NotFound();
            }

            db.Deliveries.Remove(delivery);
            await db.SaveChangesAsync();

            return Ok(delivery);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeliveryExists(string id)
        {
            return db.Deliveries.Count(e => e.Id == id) > 0;
        }
    }
}