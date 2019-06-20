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
using OneStopSolution.Models;

namespace OneStopSolution.Controllers
{
    public class DonationsController : ApiController
    {
        private OneStopContext db = new OneStopContext();

        // GET: api/Donations
        public IQueryable<Donation> GetDonations()
        {
            return db.Donations;
        }

        // GET: api/Donations/5
        [ResponseType(typeof(Donation))]
        public async Task<IHttpActionResult> GetDonation(Guid id)
        {
            Donation donation = await db.Donations.FindAsync(id);
            if (donation == null)
            {
                return NotFound();
            }

            return Ok(donation);
        }

        // PUT: api/Donations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDonation(Guid id, Donation donation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != donation.Id)
            {
                return BadRequest();
            }

            db.Entry(donation).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonationExists(id))
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

        // POST: api/Donations
        [ResponseType(typeof(Donation))]
        public async Task<IHttpActionResult> PostDonation(Donation donation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Donations.Add(donation);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DonationExists(donation.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = donation.Id }, donation);
        }

        // DELETE: api/Donations/5
        [ResponseType(typeof(Donation))]
        public async Task<IHttpActionResult> DeleteDonation(Guid id)
        {
            Donation donation = await db.Donations.FindAsync(id);
            if (donation == null)
            {
                return NotFound();
            }

            db.Donations.Remove(donation);
            await db.SaveChangesAsync();

            return Ok(donation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DonationExists(Guid id)
        {
            return db.Donations.Count(e => e.Id == id) > 0;
        }
    }
}