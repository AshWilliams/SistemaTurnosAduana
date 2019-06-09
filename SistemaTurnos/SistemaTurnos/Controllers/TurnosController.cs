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
    public class TurnosController : Controller
    {
        private TurnosAduanaEntities db = new TurnosAduanaEntities();

        // GET: Turnos
        public async Task<ActionResult> Index()
        {
            return View(await db.Turnos.ToListAsync());
        }

        // GET: Turnos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turnos turnos = await db.Turnos.FindAsync(id);
            if (turnos == null)
            {
                return HttpNotFound();
            }
            return View(turnos);
        }

        // GET: Turnos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Turnos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdTurno,VNombreTurno")] Turnos turnos)
        {
            if (ModelState.IsValid)
            {
                db.Turnos.Add(turnos);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(turnos);
        }

        // GET: Turnos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turnos turnos = await db.Turnos.FindAsync(id);
            if (turnos == null)
            {
                return HttpNotFound();
            }
            return View(turnos);
        }

        // POST: Turnos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdTurno,VNombreTurno")] Turnos turnos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(turnos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(turnos);
        }

        // GET: Turnos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turnos turnos = await db.Turnos.FindAsync(id);
            if (turnos == null)
            {
                return HttpNotFound();
            }
            return View(turnos);
        }

        // POST: Turnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Turnos turnos = await db.Turnos.FindAsync(id);
            db.Turnos.Remove(turnos);
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
