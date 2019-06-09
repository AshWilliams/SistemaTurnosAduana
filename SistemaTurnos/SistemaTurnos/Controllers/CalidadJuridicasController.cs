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
    public class CalidadJuridicasController : Controller
    {
        private TurnosAduanaEntities db = new TurnosAduanaEntities();

        // GET: CalidadJuridicas
        public async Task<ActionResult> Index()
        {
            return View(await db.CalidadJuridica.ToListAsync());
        }

        // GET: CalidadJuridicas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalidadJuridica calidadJuridica = await db.CalidadJuridica.FindAsync(id);
            if (calidadJuridica == null)
            {
                return HttpNotFound();
            }
            return View(calidadJuridica);
        }

        // GET: CalidadJuridicas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CalidadJuridicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdCalidadJuridica,VTipoCalidadJuridica")] CalidadJuridica calidadJuridica)
        {
            if (ModelState.IsValid)
            {
                db.CalidadJuridica.Add(calidadJuridica);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(calidadJuridica);
        }

        // GET: CalidadJuridicas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalidadJuridica calidadJuridica = await db.CalidadJuridica.FindAsync(id);
            if (calidadJuridica == null)
            {
                return HttpNotFound();
            }
            return View(calidadJuridica);
        }

        // POST: CalidadJuridicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdCalidadJuridica,VTipoCalidadJuridica")] CalidadJuridica calidadJuridica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calidadJuridica).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(calidadJuridica);
        }

        // GET: CalidadJuridicas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalidadJuridica calidadJuridica = await db.CalidadJuridica.FindAsync(id);
            if (calidadJuridica == null)
            {
                return HttpNotFound();
            }
            return View(calidadJuridica);
        }

        // POST: CalidadJuridicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CalidadJuridica calidadJuridica = await db.CalidadJuridica.FindAsync(id);
            db.CalidadJuridica.Remove(calidadJuridica);
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
