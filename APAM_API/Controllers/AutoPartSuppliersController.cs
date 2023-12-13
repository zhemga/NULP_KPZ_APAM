using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using APAM_API.Data;
using APAM_API.Models.Identity_Users;

namespace APAM_API.Controllers
{
    public class AutoPartSuppliersController : ApiController
    {
        private APAM_APIContext db = new APAM_APIContext();

        // GET: api/AutoPartSuppliers
        public IQueryable<AutoPartSupplier> GetIdentityUsers()
        {
            return db.AutoPartSuppliers;
        }

        // GET: api/AutoPartSuppliers/5
        [ResponseType(typeof(AutoPartSupplier))]
        public async Task<IHttpActionResult> GetAutoPartSupplier(string id)
        {
            AutoPartSupplier autoPartSupplier = await db.AutoPartSuppliers.FindAsync(id);
            if (autoPartSupplier == null)
            {
                return NotFound();
            }

            return Ok(autoPartSupplier);
        }

        // PUT: api/AutoPartSuppliers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAutoPartSupplier(string id, AutoPartSupplier autoPartSupplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != autoPartSupplier.Id)
            {
                return BadRequest();
            }

            db.Entry(autoPartSupplier).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutoPartSupplierExists(id))
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

        // POST: api/AutoPartSuppliers
        [ResponseType(typeof(AutoPartSupplier))]
        public async Task<IHttpActionResult> PostAutoPartSupplier(AutoPartSupplier autoPartSupplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AutoPartSuppliers.Add(autoPartSupplier);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AutoPartSupplierExists(autoPartSupplier.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = autoPartSupplier.Id }, autoPartSupplier);
        }

        // DELETE: api/AutoPartSuppliers/5
        [ResponseType(typeof(AutoPartSupplier))]
        public async Task<IHttpActionResult> DeleteAutoPartSupplier(string id)
        {
            AutoPartSupplier autoPartSupplier = await db.AutoPartSuppliers.FindAsync(id);
            if (autoPartSupplier == null)
            {
                return NotFound();
            }

            db.AutoPartSuppliers.Remove(autoPartSupplier);
            await db.SaveChangesAsync();

            return Ok(autoPartSupplier);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AutoPartSupplierExists(string id)
        {
            return db.AutoPartSuppliers.Count(e => e.Id == id) > 0;
        }
    }
}