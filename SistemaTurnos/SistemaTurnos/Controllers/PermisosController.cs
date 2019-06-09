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
    public class PermisosController : Controller
    {
        private TurnosAduanaEntities db = new TurnosAduanaEntities();

        // GET: Permisos
        public async Task<ActionResult> Index()
        {
            var permisos = db.Permisos.Include(p => p.TipoPermiso).Include(p => p.Usuario);
            return View(await permisos.ToListAsync());
        }

        // GET: Permisos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permisos permisos = await db.Permisos.FindAsync(id);
            if (permisos == null)
            {
                return HttpNotFound();
            }
            return View(permisos);
        }

        // GET: Permisos/Create
        public ActionResult Create()
        {
            ViewBag.IdTipoPermiso = new SelectList(db.TipoPermiso, "IdTipoPermiso", "VDescripcionPermiso");
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "VEmail");
            return View();
        }

        // POST: Permisos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdPermisos,DFechaInicio,ICantDias,ICantHoras,DFechaFin,IdTipoPermiso,IdUsuario")] Permisos permisos)
        {
            if (ModelState.IsValid)
            {
                db.Permisos.Add(permisos);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdTipoPermiso = new SelectList(db.TipoPermiso, "IdTipoPermiso", "VDescripcionPermiso", permisos.IdTipoPermiso);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "VEmail", permisos.IdUsuario);
            return View(permisos);
        }

        // GET: Permisos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permisos permisos = await db.Permisos.FindAsync(id);
            if (permisos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipoPermiso = new SelectList(db.TipoPermiso, "IdTipoPermiso", "VDescripcionPermiso", permisos.IdTipoPermiso);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "VEmail", permisos.IdUsuario);
            return View(permisos);
        }

        // POST: Permisos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdPermisos,DFechaInicio,ICantDias,ICantHoras,DFechaFin,IdTipoPermiso,IdUsuario")] Permisos permisos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(permisos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdTipoPermiso = new SelectList(db.TipoPermiso, "IdTipoPermiso", "VDescripcionPermiso", permisos.IdTipoPermiso);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "VEmail", permisos.IdUsuario);
            return View(permisos);
        }

        // GET: Permisos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permisos permisos = await db.Permisos.FindAsync(id);
            if (permisos == null)
            {
                return HttpNotFound();
            }
            return View(permisos);
        }

        // POST: Permisos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Permisos permisos = await db.Permisos.FindAsync(id);
            db.Permisos.Remove(permisos);
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
