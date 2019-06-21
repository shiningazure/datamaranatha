using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SATDummy.Models;

namespace SATDummy.Views
{
    public class MataKuliahsController : Controller
    {
        private SATDummyContext db = new SATDummyContext();

        // GET: MataKuliahs
        public async Task<ActionResult> Index()
        {
            return View(await db.MataKuliahs.ToListAsync());
        }

        // GET: MataKuliahs/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MataKuliah mataKuliah = await db.MataKuliahs.FindAsync(id);
            if (mataKuliah == null)
            {
                return HttpNotFound();
            }
            return View(mataKuliah);
        }

        // GET: MataKuliahs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MataKuliahs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,KodeMataKuliah,NamaMataKuliah,SKS")] MataKuliah mataKuliah)
        {
            if (ModelState.IsValid)
            {
                mataKuliah.Id = Guid.NewGuid();
                db.MataKuliahs.Add(mataKuliah);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mataKuliah);
        }

        // GET: MataKuliahs/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MataKuliah mataKuliah = await db.MataKuliahs.FindAsync(id);
            if (mataKuliah == null)
            {
                return HttpNotFound();
            }
            return View(mataKuliah);
        }

        // POST: MataKuliahs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,KodeMataKuliah,NamaMataKuliah,SKS")] MataKuliah mataKuliah)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mataKuliah).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mataKuliah);
        }

        // GET: MataKuliahs/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MataKuliah mataKuliah = await db.MataKuliahs.FindAsync(id);
            if (mataKuliah == null)
            {
                return HttpNotFound();
            }
            return View(mataKuliah);
        }

        // POST: MataKuliahs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            MataKuliah mataKuliah = await db.MataKuliahs.FindAsync(id);
            db.MataKuliahs.Remove(mataKuliah);
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
