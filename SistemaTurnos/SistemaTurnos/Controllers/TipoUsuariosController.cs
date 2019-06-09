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
    public class TipoUsuariosController : Controller
    {
        private TurnosAduanaEntities db = new TurnosAduanaEntities();

        // GET: TipoUsuarios
        public async Task<ActionResult> Index()
        {
            var tipoUsuario = db.TipoUsuario.Include(t => t.Rol);
            return View(await tipoUsuario.ToListAsync());
        }

        // GET: TipoUsuarios/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoUsuario tipoUsuario = await db.TipoUsuario.FindAsync(id);
            if (tipoUsuario == null)
            {
                return HttpNotFound();
            }
            return View(tipoUsuario);
        }

        // GET: TipoUsuarios/Create
        public ActionResult Create()
        {
            ViewBag.IdRol = new SelectList(db.Rol, "IdRol", "VNombreRol");
            return View();
        }

        // POST: TipoUsuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdTipoUsuario,TipoUsuario1,Permisos,IdRol")] TipoUsuario tipoUsuario)
        {
            if (ModelState.IsValid)
            {
                db.TipoUsuario.Add(tipoUsuario);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdRol = new SelectList(db.Rol, "IdRol", "VNombreRol", tipoUsuario.IdRol);
            return View(tipoUsuario);
        }

        // GET: TipoUsuarios/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoUsuario tipoUsuario = await db.TipoUsuario.FindAsync(id);
            if (tipoUsuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdRol = new SelectList(db.Rol, "IdRol", "VNombreRol", tipoUsuario.IdRol);
            return View(tipoUsuario);
        }

        // POST: TipoUsuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdTipoUsuario,TipoUsuario1,Permisos,IdRol")] TipoUsuario tipoUsuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoUsuario).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdRol = new SelectList(db.Rol, "IdRol", "VNombreRol", tipoUsuario.IdRol);
            return View(tipoUsuario);
        }

        // GET: TipoUsuarios/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoUsuario tipoUsuario = await db.TipoUsuario.FindAsync(id);
            if (tipoUsuario == null)
            {
                return HttpNotFound();
            }
            return View(tipoUsuario);
        }

        // POST: TipoUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TipoUsuario tipoUsuario = await db.TipoUsuario.FindAsync(id);
            db.TipoUsuario.Remove(tipoUsuario);
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
