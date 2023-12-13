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
using APAM_API.Models;

namespace APAM_API.Controllers
{
    public class AutoPartCategoriesController : ApiController
    {
        private APAM_APIContext db = new APAM_APIContext();

        // GET: api/AutoPartCategories
        public IQueryable<AutoPartCategory> GetAutoPartCategories()
        {
            return db.AutoPartCategories;
        }

        // GET: api/AutoPartCategories/5
        [ResponseType(typeof(AutoPartCategory))]
        public async Task<IHttpActionResult> GetAutoPartCategory(string id)
        {
            AutoPartCategory autoPartCategory = await db.AutoPartCategories.FindAsync(id);
            if (autoPartCategory == null)
            {
                return NotFound();
            }

            return Ok(autoPartCategory);
        }

        // PUT: api/AutoPartCategories/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAutoPartCategory(string id, AutoPartCategory autoPartCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != autoPartCategory.Id)
            {
                return BadRequest();
            }

            db.Entry(autoPartCategory).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutoPartCategoryExists(id))
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

        // POST: api/AutoPartCategories
        [ResponseType(typeof(AutoPartCategory))]
        public async Task<IHttpActionResult> PostAutoPartCategory(AutoPartCategory autoPartCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AutoPartCategories.Add(autoPartCategory);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AutoPartCategoryExists(autoPartCategory.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = autoPartCategory.Id }, autoPartCategory);
        }

        // DELETE: api/AutoPartCategories/5
        [ResponseType(typeof(AutoPartCategory))]
        public async Task<IHttpActionResult> DeleteAutoPartCategory(string id)
        {
            AutoPartCategory autoPartCategory = await db.AutoPartCategories.FindAsync(id);
            if (autoPartCategory == null)
            {
                return NotFound();
            }

            db.AutoPartCategories.Remove(autoPartCategory);
            await db.SaveChangesAsync();

            return Ok(autoPartCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AutoPartCategoryExists(string id)
        {
            return db.AutoPartCategories.Count(e => e.Id == id) > 0;
        }
    }
}