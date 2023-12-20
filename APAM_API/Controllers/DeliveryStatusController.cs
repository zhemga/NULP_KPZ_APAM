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
    public class DeliveryStatusController : ApiController
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

        // GET: api/DeliveryStatus
        public IQueryable<DeliveryStatus> GetDeliveryStatus()
        {
            return db.DeliveryStatuses;
        }

        // GET: api/DeliveryStatus/5
        [ResponseType(typeof(DeliveryStatus))]
        public async Task<IHttpActionResult> GetDeliveryStatus(string id)
        {
            DeliveryStatus deliveryStatus = await db.DeliveryStatuses.FindAsync(id);
            if (deliveryStatus == null)
            {
                return NotFound();
            }

            return Ok(deliveryStatus);
        }

        // PUT: api/DeliveryStatus/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDeliveryStatus(string id, DeliveryStatus deliveryStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deliveryStatus.Id)
            {
                return BadRequest();
            }

            db.Entry(deliveryStatus).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryStatusExists(id))
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

        // POST: api/DeliveryStatus
        [ResponseType(typeof(DeliveryStatus))]
        public async Task<IHttpActionResult> PostDeliveryStatus(DeliveryStatus deliveryStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DeliveryStatuses.Add(deliveryStatus);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DeliveryStatusExists(deliveryStatus.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = deliveryStatus.Id }, deliveryStatus);
        }

        // DELETE: api/DeliveryStatus/5
        [ResponseType(typeof(DeliveryStatus))]
        public async Task<IHttpActionResult> DeleteDeliveryStatus(string id)
        {
            DeliveryStatus deliveryStatus = await db.DeliveryStatuses.FindAsync(id);
            if (deliveryStatus == null)
            {
                return NotFound();
            }

            db.DeliveryStatuses.Remove(deliveryStatus);
            await db.SaveChangesAsync();

            return Ok(deliveryStatus);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeliveryStatusExists(string id)
        {
            return db.DeliveryStatuses.Count(e => e.Id == id) > 0;
        }
    }
}