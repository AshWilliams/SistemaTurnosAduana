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
    public class ContratosController : Controller
    {
        private TurnosAduanaEntities db = new TurnosAduanaEntities();

        // GET: Contratoes
        public async Task<ActionResult> Index()
        {
            var contrato = db.Contrato.Include(c => c.TipoContrato).Include(c => c.Usuario);
            return View(await contrato.ToListAsync());
        }

        // GET: Contratoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = await db.Contrato.FindAsync(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // GET: Contratoes/Create
        public ActionResult Create()
        {
            ViewBag.IdTipoContrato = new SelectList(db.TipoContrato, "IdTipoContrato", "IdTipoContrato");
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "VEmail");
            return View();
        }

        // POST: Contratoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdContrato,DFechaInicio,DFechaFin,IdTipoContrato,IdUsuario")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                db.Contrato.Add(contrato);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdTipoContrato = new SelectList(db.TipoContrato, "IdTipoContrato", "IdTipoContrato", contrato.IdTipoContrato);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "VEmail", contrato.IdUsuario);
            return View(contrato);
        }

        // GET: Contratoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = await db.Contrato.FindAsync(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipoContrato = new SelectList(db.TipoContrato, "IdTipoContrato", "IdTipoContrato", contrato.IdTipoContrato);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "VEmail", contrato.IdUsuario);
            return View(contrato);
        }

        // POST: Contratoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdContrato,DFechaInicio,DFechaFin,IdTipoContrato,IdUsuario")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contrato).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdTipoContrato = new SelectList(db.TipoContrato, "IdTipoContrato", "IdTipoContrato", contrato.IdTipoContrato);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "VEmail", contrato.IdUsuario);
            return View(contrato);
        }

        // GET: Contratoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = await db.Contrato.FindAsync(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // POST: Contratoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Contrato contrato = await db.Contrato.FindAsync(id);
            db.Contrato.Remove(contrato);
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
