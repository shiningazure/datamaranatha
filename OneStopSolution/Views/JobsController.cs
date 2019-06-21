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
    public class JobsController : Controller
    {
        private OneStopContext db = new OneStopContext();

        // GET: Jobs
        public async Task<ActionResult> Index()
        {
            var jobs = db.Jobs.Include(j => j.Categories).Include(j => j.Poster);
            return View(await jobs.ToListAsync());
        }

        // GET: Jobs/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = await db.Jobs.FindAsync(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: Jobs/Create
        public ActionResult Create()
        {
            ViewBag.CategoriesId = new SelectList(db.JobCategories, "Id", "CategoriesName");
            ViewBag.PosterId = new SelectList(db.Users, "Id", "NRP");
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Address,Description,Position,PosterId,CategoriesId,Location,Skill_Requirements,Company,Icon_Company")] Job job)
        {
            if (ModelState.IsValid)
            {
                job.Id = Guid.NewGuid();
                db.Jobs.Add(job);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriesId = new SelectList(db.JobCategories, "Id", "CategoriesName", job.CategoriesId);
            ViewBag.PosterId = new SelectList(db.Users, "Id", "NRP", job.PosterId);
            return View(job);
        }

        // GET: Jobs/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = await db.Jobs.FindAsync(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriesId = new SelectList(db.JobCategories, "Id", "CategoriesName", job.CategoriesId);
            ViewBag.PosterId = new SelectList(db.Users, "Id", "NRP", job.PosterId);
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Address,Description,Position,PosterId,CategoriesId,Location,Skill_Requirements,Company,Icon_Company")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriesId = new SelectList(db.JobCategories, "Id", "CategoriesName", job.CategoriesId);
            ViewBag.PosterId = new SelectList(db.Users, "Id", "NRP", job.PosterId);
            return View(job);
        }

        // GET: Jobs/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = await db.Jobs.FindAsync(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Job job = await db.Jobs.FindAsync(id);
            db.Jobs.Remove(job);
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
