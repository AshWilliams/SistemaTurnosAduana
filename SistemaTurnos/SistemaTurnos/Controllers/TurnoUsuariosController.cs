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
    public class TurnoUsuariosController : Controller
    {
        private TurnosAduanaEntities db = new TurnosAduanaEntities();

        // GET: TurnoUsuarios
        public async Task<ActionResult> Index()
        {
            var turnoUsuario = db.TurnoUsuario.Include(t => t.Lugar).Include(t => t.Turnos).Include(t => t.Usuario);
            return View(await turnoUsuario.ToListAsync());
        }

        // GET: TurnoUsuarios/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TurnoUsuario turnoUsuario = await db.TurnoUsuario.FindAsync(id);
            if (turnoUsuario == null)
            {
                return HttpNotFound();
            }
            return View(turnoUsuario);
        }

        // GET: TurnoUsuarios/Create
        public ActionResult Create()
        {
            ViewBag.IdLugar = new SelectList(db.Lugar, "IdLugar", "VDescripcionLugar");
            ViewBag.IdTurno = new SelectList(db.Turnos, "IdTurno", "VNombreTurno");
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "VEmail");
            return View();
        }

        // POST: TurnoUsuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdTurnoUsuario,DFechaincio,DFechaTermino,IdLugar,IdTurno,IdUsuario")] TurnoUsuario turnoUsuario)
        {
            if (ModelState.IsValid)
            {
                db.TurnoUsuario.Add(turnoUsuario);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdLugar = new SelectList(db.Lugar, "IdLugar", "VDescripcionLugar", turnoUsuario.IdLugar);
            ViewBag.IdTurno = new SelectList(db.Turnos, "IdTurno", "VNombreTurno", turnoUsuario.IdTurno);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "VEmail", turnoUsuario.IdUsuario);
            return View(turnoUsuario);
        }

        // GET: TurnoUsuarios/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TurnoUsuario turnoUsuario = await db.TurnoUsuario.FindAsync(id);
            if (turnoUsuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdLugar = new SelectList(db.Lugar, "IdLugar", "VDescripcionLugar", turnoUsuario.IdLugar);
            ViewBag.IdTurno = new SelectList(db.Turnos, "IdTurno", "VNombreTurno", turnoUsuario.IdTurno);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "VEmail", turnoUsuario.IdUsuario);
            return View(turnoUsuario);
        }

        // POST: TurnoUsuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdTurnoUsuario,DFechaincio,DFechaTermino,IdLugar,IdTurno,IdUsuario")] TurnoUsuario turnoUsuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(turnoUsuario).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdLugar = new SelectList(db.Lugar, "IdLugar", "VDescripcionLugar", turnoUsuario.IdLugar);
            ViewBag.IdTurno = new SelectList(db.Turnos, "IdTurno", "VNombreTurno", turnoUsuario.IdTurno);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "VEmail", turnoUsuario.IdUsuario);
            return View(turnoUsuario);
        }

        // GET: TurnoUsuarios/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TurnoUsuario turnoUsuario = await db.TurnoUsuario.FindAsync(id);
            if (turnoUsuario == null)
            {
                return HttpNotFound();
            }
            return View(turnoUsuario);
        }

        // POST: TurnoUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TurnoUsuario turnoUsuario = await db.TurnoUsuario.FindAsync(id);
            db.TurnoUsuario.Remove(turnoUsuario);
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
