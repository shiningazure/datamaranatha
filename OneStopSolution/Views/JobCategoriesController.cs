using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OneStopSolution.Models;

namespace OneStopSolution.Views
{
    public class JobCategoriesController : Controller
    {
        private OneStopContext db = new OneStopContext();

        // GET: JobCategories
        public async Task<ActionResult> Index()
        {
            return View(await db.JobCategories.ToListAsync());
        }

        // GET: JobCategories/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobCategories jobCategories = await db.JobCategories.FindAsync(id);
            if (jobCategories == null)
            {
                return HttpNotFound();
            }
            return View(jobCategories);
        }

        // GET: JobCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,CategoriesName")] JobCategories jobCategories)
        {
            if (ModelState.IsValid)
            {
                jobCategories.Id = Guid.NewGuid();
                db.JobCategories.Add(jobCategories);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(jobCategories);
        }

        // GET: JobCategories/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobCategories jobCategories = await db.JobCategories.FindAsync(id);
            if (jobCategories == null)
            {
                return HttpNotFound();
            }
            return View(jobCategories);
        }

        // POST: JobCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CategoriesName")] JobCategories jobCategories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobCategories).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(jobCategories);
        }

        // GET: JobCategories/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobCategories jobCategories = await db.JobCategories.FindAsync(id);
            if (jobCategories == null)
            {
                return HttpNotFound();
            }
            return View(jobCategories);
        }

        // POST: JobCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            JobCategories jobCategories = await db.JobCategories.FindAsync(id);
            db.JobCategories.Remove(jobCategories);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
