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
    public class TipoContratosController : Controller
    {
        private TurnosAduanaEntities db = new TurnosAduanaEntities();

        // GET: TipoContratos
        public async Task<ActionResult> Index()
        {
            var tipoContrato = db.TipoContrato.Include(t => t.CalidadJuridica);
            return View(await tipoContrato.ToListAsync());
        }

        // GET: TipoContratos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoContrato tipoContrato = await db.TipoContrato.FindAsync(id);
            if (tipoContrato == null)
            {
                return HttpNotFound();
            }
            return View(tipoContrato);
        }

        // GET: TipoContratos/Create
        public ActionResult Create()
        {
            ViewBag.IdCalidadJuridica = new SelectList(db.CalidadJuridica, "IdCalidadJuridica", "VTipoCalidadJuridica");
            return View();
        }

        // POST: TipoContratos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdTipoContrato,IdCalidadJuridica,IDuracion")] TipoContrato tipoContrato)
        {
            if (ModelState.IsValid)
            {
                db.TipoContrato.Add(tipoContrato);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdCalidadJuridica = new SelectList(db.CalidadJuridica, "IdCalidadJuridica", "VTipoCalidadJuridica", tipoContrato.IdCalidadJuridica);
            return View(tipoContrato);
        }

        // GET: TipoContratos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoContrato tipoContrato = await db.TipoContrato.FindAsync(id);
            if (tipoContrato == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCalidadJuridica = new SelectList(db.CalidadJuridica, "IdCalidadJuridica", "VTipoCalidadJuridica", tipoContrato.IdCalidadJuridica);
            return View(tipoContrato);
        }

        // POST: TipoContratos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdTipoContrato,IdCalidadJuridica,IDuracion")] TipoContrato tipoContrato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoContrato).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdCalidadJuridica = new SelectList(db.CalidadJuridica, "IdCalidadJuridica", "VTipoCalidadJuridica", tipoContrato.IdCalidadJuridica);
            return View(tipoContrato);
        }

        // GET: TipoContratos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoContrato tipoContrato = await db.TipoContrato.FindAsync(id);
            if (tipoContrato == null)
            {
                return HttpNotFound();
            }
            return View(tipoContrato);
        }

        // POST: TipoContratos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TipoContrato tipoContrato = await db.TipoContrato.FindAsync(id);
            db.TipoContrato.Remove(tipoContrato);
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
