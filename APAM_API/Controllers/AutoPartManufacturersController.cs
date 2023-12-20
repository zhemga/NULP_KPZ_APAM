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
using APAM_API.Models;

namespace APAM_API.Controllers
{
    public class AutoPartManufacturersController : ApiController
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

        // GET: api/AutoPartManufacturers
        public IQueryable<AutoPartManufacturer> GetAutoPartManufacturers()
        {
            return db.AutoPartManufacturers;
        }

        // GET: api/AutoPartManufacturers/5
        [ResponseType(typeof(AutoPartManufacturer))]
        public async Task<IHttpActionResult> GetAutoPartManufacturer(string id)
        {
            AutoPartManufacturer autoPartManufacturer = await db.AutoPartManufacturers.FindAsync(id);
            if (autoPartManufacturer == null)
            {
                return NotFound();
            }

            return Ok(autoPartManufacturer);
        }

        // PUT: api/AutoPartManufacturers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAutoPartManufacturer(string id, AutoPartManufacturer autoPartManufacturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != autoPartManufacturer.Id)
            {
                return BadRequest();
            }

            db.Entry(autoPartManufacturer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutoPartManufacturerExists(id))
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

        // POST: api/AutoPartManufacturers
        [ResponseType(typeof(AutoPartManufacturer))]
        public async Task<IHttpActionResult> PostAutoPartManufacturer(AutoPartManufacturer autoPartManufacturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AutoPartManufacturers.Add(autoPartManufacturer);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AutoPartManufacturerExists(autoPartManufacturer.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = autoPartManufacturer.Id }, autoPartManufacturer);
        }

        // DELETE: api/AutoPartManufacturers/5
        [ResponseType(typeof(AutoPartManufacturer))]
        public async Task<IHttpActionResult> DeleteAutoPartManufacturer(string id)
        {
            AutoPartManufacturer autoPartManufacturer = await db.AutoPartManufacturers.FindAsync(id);
            if (autoPartManufacturer == null)
            {
                return NotFound();
            }

            db.AutoPartManufacturers.Remove(autoPartManufacturer);
            await db.SaveChangesAsync();

            return Ok(autoPartManufacturer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AutoPartManufacturerExists(string id)
        {
            return db.AutoPartManufacturers.Count(e => e.Id == id) > 0;
        }
    }
}