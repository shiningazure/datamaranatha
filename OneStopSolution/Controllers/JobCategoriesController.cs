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
    public class JobCategoriesController : ApiController
    {
        private OneStopContext db = new OneStopContext();

        // GET: api/JobCategories
        public IQueryable<JobCategories> GetJobCategories()
        {
            return db.JobCategories;
        }

        // GET: api/JobCategories/5
        [ResponseType(typeof(JobCategories))]
        public async Task<IHttpActionResult> GetJobCategories(Guid id)
        {
            JobCategories jobCategories = await db.JobCategories.FindAsync(id);
            if (jobCategories == null)
            {
                return NotFound();
            }

            return Ok(jobCategories);
        }

        // PUT: api/JobCategories/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutJobCategories(Guid id, JobCategories jobCategories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jobCategories.Id)
            {
                return BadRequest();
            }

            db.Entry(jobCategories).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobCategoriesExists(id))
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

        // POST: api/JobCategories
        [ResponseType(typeof(JobCategories))]
        public async Task<IHttpActionResult> PostJobCategories(JobCategories jobCategories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.JobCategories.Add(jobCategories);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (JobCategoriesExists(jobCategories.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = jobCategories.Id }, jobCategories);
        }

        // DELETE: api/JobCategories/5
        [ResponseType(typeof(JobCategories))]
        public async Task<IHttpActionResult> DeleteJobCategories(Guid id)
        {
            JobCategories jobCategories = await db.JobCategories.FindAsync(id);
            if (jobCategories == null)
            {
                return NotFound();
            }

            db.JobCategories.Remove(jobCategories);
            await db.SaveChangesAsync();

            return Ok(jobCategories);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JobCategoriesExists(Guid id)
        {
            return db.JobCategories.Count(e => e.Id == id) > 0;
        }
    }
}