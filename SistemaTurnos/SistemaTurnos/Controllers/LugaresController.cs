using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaTurnos.Models;

namespace SistemaTurnos.Controllers
{
    public class LugaresController : Controller
    {
        private TurnosAduanaEntities db = new TurnosAduanaEntities();

        // GET: Lugares
        public async Task<ActionResult> Index()
        {
            return View(await db.Lugar.ToListAsync());
        }

        // GET: Lugares/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lugar lugar = await db.Lugar.FindAsync(id);
            if (lugar == null)
            {
                return HttpNotFound();
            }
            return View(lugar);
        }

        // GET: Lugares/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lugares/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdLugar,VDescripcionLugar")] Lugar lugar)
        {
            if (ModelState.IsValid)
            {
                db.Lugar.Add(lugar);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(lugar);
        }

        // GET: Lugares/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lugar lugar = await db.Lugar.FindAsync(id);
            if (lugar == null)
            {
                return HttpNotFound();
            }
            return View(lugar);
        }

        // POST: Lugares/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdLugar,VDescripcionLugar")] Lugar lugar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lugar).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(lugar);
        }

        // GET: Lugares/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lugar lugar = await db.Lugar.FindAsync(id);
            if (lugar == null)
            {
                return HttpNotFound();
            }
            return View(lugar);
        }

        // POST: Lugares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Lugar lugar = await db.Lugar.FindAsync(id);
            db.Lugar.Remove(lugar);
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
