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
using SATDummy.Models;

namespace SATDummy.Controllers
{
    public class MataKuliahsController : ApiController
    {
        private SATDummyContext db = new SATDummyContext();

        // GET: api/MataKuliahs
        public IQueryable<MataKuliah> GetMataKuliahs()
        {
            return db.MataKuliahs;
        }

        // GET: api/MataKuliahs/5
        [ResponseType(typeof(MataKuliah))]
        public async Task<IHttpActionResult> GetMataKuliah(Guid id)
        {
            MataKuliah mataKuliah = await db.MataKuliahs.FindAsync(id);
            if (mataKuliah == null)
            {
                return NotFound();
            }

            return Ok(mataKuliah);
        }

        // PUT: api/MataKuliahs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMataKuliah(Guid id, MataKuliah mataKuliah)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mataKuliah.Id)
            {
                return BadRequest();
            }

            db.Entry(mataKuliah).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MataKuliahExists(id))
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

        // POST: api/MataKuliahs
        [ResponseType(typeof(MataKuliah))]
        public async Task<IHttpActionResult> PostMataKuliah(MataKuliah mataKuliah)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MataKuliahs.Add(mataKuliah);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MataKuliahExists(mataKuliah.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mataKuliah.Id }, mataKuliah);
        }

        // DELETE: api/MataKuliahs/5
        [ResponseType(typeof(MataKuliah))]
        public async Task<IHttpActionResult> DeleteMataKuliah(Guid id)
        {
            MataKuliah mataKuliah = await db.MataKuliahs.FindAsync(id);
            if (mataKuliah == null)
            {
                return NotFound();
            }

            db.MataKuliahs.Remove(mataKuliah);
            await db.SaveChangesAsync();

            return Ok(mataKuliah);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MataKuliahExists(Guid id)
        {
            return db.MataKuliahs.Count(e => e.Id == id) > 0;
        }
    }
}