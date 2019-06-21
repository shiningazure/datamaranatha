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
using AdmissionDummy.Models;

namespace AdmissionDummy.Controllers
{
    public class StaffsController : ApiController
    {
        private AdmissionDummyContext db = new AdmissionDummyContext();

        // GET: api/Staffs
        public IQueryable<Staff> GetStaffs()
        {
            return db.Staffs;
        }

        // GET: api/Staffs/5
        [ResponseType(typeof(Staff))]
        public async Task<IHttpActionResult> GetStaff(Guid id)
        {
            Staff staff = await db.Staffs.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }

            return Ok(staff);
        }

        // PUT: api/Staffs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStaff(Guid id, Staff staff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != staff.Id)
            {
                return BadRequest();
            }

            db.Entry(staff).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffExists(id))
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

        // POST: api/Staffs
        [ResponseType(typeof(Staff))]
        public async Task<IHttpActionResult> PostStaff(Staff staff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Staffs.Add(staff);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StaffExists(staff.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = staff.Id }, staff);
        }

        // DELETE: api/Staffs/5
        [ResponseType(typeof(Staff))]
        public async Task<IHttpActionResult> DeleteStaff(Guid id)
        {
            Staff staff = await db.Staffs.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }

            db.Staffs.Remove(staff);
            await db.SaveChangesAsync();

            return Ok(staff);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StaffExists(Guid id)
        {
            return db.Staffs.Count(e => e.Id == id) > 0;
        }
    }
}