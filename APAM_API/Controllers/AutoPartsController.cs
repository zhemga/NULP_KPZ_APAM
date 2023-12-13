using APAM_API.Data;
using APAM_API.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;


namespace APAM_API.Controllers
{
    public class AutoPartsController : ApiController
    {
        private APAM_APIContext db = new APAM_APIContext();

        // GET: api/AutoParts
        public List<AutoPart> GetAutoParts()
        {
            return db.AutoParts.ToList();
        }

        // GET: api/AutoParts/5
        [ResponseType(typeof(AutoPart))]
        public async Task<IHttpActionResult> GetAutoPart(string id)
        {
            AutoPart autoPart = await db.AutoParts.FindAsync(id);
            if (autoPart == null)
            {
                return NotFound();
            }

            return Ok(autoPart);
        }

        // PUT: api/AutoParts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAutoPart(string id, AutoPart autoPart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != autoPart.Id)
            {
                return BadRequest();
            }

            db.Entry(autoPart).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutoPartExists(id))
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

        // POST: api/AutoParts
        [ResponseType(typeof(AutoPart))]
        public async Task<IHttpActionResult> PostAutoPart(AutoPart autoPart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AutoParts.Add(autoPart);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AutoPartExists(autoPart.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = autoPart.Id }, autoPart);
        }

        // DELETE: api/AutoParts/5
        [ResponseType(typeof(AutoPart))]
        public async Task<IHttpActionResult> DeleteAutoPart(string id)
        {
            AutoPart autoPart = await db.AutoParts.FindAsync(id);
            if (autoPart == null)
            {
                return NotFound();
            }

            db.AutoParts.Remove(autoPart);
            await db.SaveChangesAsync();

            return Ok(autoPart);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AutoPartExists(string id)
        {
            return db.AutoParts.Count(e => e.Id == id) > 0;
        }
    }
}