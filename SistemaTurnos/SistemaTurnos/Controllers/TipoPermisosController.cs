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
    public class TipoPermisosController : Controller
    {
        private TurnosAduanaEntities db = new TurnosAduanaEntities();

        // GET: TipoPermisos
        public async Task<ActionResult> Index()
        {
            return View(await db.TipoPermiso.ToListAsync());
        }

        // GET: TipoPermisos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPermiso tipoPermiso = await db.TipoPermiso.FindAsync(id);
            if (tipoPermiso == null)
            {
                return HttpNotFound();
            }
            return View(tipoPermiso);
        }

        // GET: TipoPermisos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoPermisos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdTipoPermiso,VDescripcionPermiso")] TipoPermiso tipoPermiso)
        {
            if (ModelState.IsValid)
            {
                db.TipoPermiso.Add(tipoPermiso);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tipoPermiso);
        }

        // GET: TipoPermisos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPermiso tipoPermiso = await db.TipoPermiso.FindAsync(id);
            if (tipoPermiso == null)
            {
                return HttpNotFound();
            }
            return View(tipoPermiso);
        }

        // POST: TipoPermisos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdTipoPermiso,VDescripcionPermiso")] TipoPermiso tipoPermiso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoPermiso).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipoPermiso);
        }

        // GET: TipoPermisos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPermiso tipoPermiso = await db.TipoPermiso.FindAsync(id);
            if (tipoPermiso == null)
            {
                return HttpNotFound();
            }
            return View(tipoPermiso);
        }

        // POST: TipoPermisos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TipoPermiso tipoPermiso = await db.TipoPermiso.FindAsync(id);
            db.TipoPermiso.Remove(tipoPermiso);
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
