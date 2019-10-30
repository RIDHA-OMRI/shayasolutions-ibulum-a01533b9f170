using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IBulum_v1.Models;
using IBulum_v1.Models.Entities;

namespace IBulum_v1.Controllers
{
    public class InquiriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Inquiries
        public async Task<ActionResult> Index()
        {
            return View(await db.Inquiries.ToListAsync());
        }

        // GET: Inquiries/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inquiry inquiry = await db.Inquiries.FindAsync(id);
            if (inquiry == null)
            {
                return HttpNotFound();
            }
            return View(inquiry);
        }

        // GET: Inquiries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inquiries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,CompanyId,ContactId,Role,InquiryDeadline,StartDate,EndDate,Status")] Inquiry inquiry)
        {
            if (ModelState.IsValid)
            {
                db.Inquiries.Add(inquiry);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(inquiry);
        }

        // GET: Inquiries/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inquiry inquiry = await db.Inquiries.FindAsync(id);
            if (inquiry == null)
            {
                return HttpNotFound();
            }
            return View(inquiry);
        }

        // POST: Inquiries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CompanyId,ContactId,Role,InquiryDeadline,StartDate,EndDate,Status")] Inquiry inquiry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inquiry).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(inquiry);
        }

        // GET: Inquiries/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inquiry inquiry = await db.Inquiries.FindAsync(id);
            if (inquiry == null)
            {
                return HttpNotFound();
            }
            return View(inquiry);
        }

        // POST: Inquiries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Inquiry inquiry = await db.Inquiries.FindAsync(id);
            db.Inquiries.Remove(inquiry);
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
