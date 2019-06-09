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
    public class CambioTurnosController : Controller
    {
        private TurnosAduanaEntities db = new TurnosAduanaEntities();

        // GET: CambioTurnos
        public async Task<ActionResult> Index()
        {
            var cambioTurno = db.CambioTurno.Include(c => c.Estado).Include(c => c.TurnoUsuario).Include(c => c.Usuario).Include(c => c.Usuario1);
            return View(await cambioTurno.ToListAsync());
        }

        // GET: CambioTurnos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CambioTurno cambioTurno = await db.CambioTurno.FindAsync(id);
            if (cambioTurno == null)
            {
                return HttpNotFound();
            }
            return View(cambioTurno);
        }

        // GET: CambioTurnos/Create
        public ActionResult Create()
        {
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "VDescripcionEstado");
            ViewBag.IdTurnoUsuario = new SelectList(db.TurnoUsuario, "IdTurnoUsuario", "IdTurnoUsuario");
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "VEmail");
            ViewBag.IdUsuarioold = new SelectList(db.Usuario, "IdUsuario", "VEmail");
            return View();
        }

        // POST: CambioTurnos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdCambioTurno,IdUsuario,IdUsuarioold,IdEstado,VObservaciones,IdTurnoUsuario")] CambioTurno cambioTurno)
        {
            if (ModelState.IsValid)
            {
                db.CambioTurno.Add(cambioTurno);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "VDescripcionEstado", cambioTurno.IdEstado);
            ViewBag.IdTurnoUsuario = new SelectList(db.TurnoUsuario, "IdTurnoUsuario", "IdTurnoUsuario", cambioTurno.IdTurnoUsuario);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "VEmail", cambioTurno.IdUsuario);
            ViewBag.IdUsuarioold = new SelectList(db.Usuario, "IdUsuario", "VEmail", cambioTurno.IdUsuarioold);
            return View(cambioTurno);
        }

        // GET: CambioTurnos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CambioTurno cambioTurno = await db.CambioTurno.FindAsync(id);
            if (cambioTurno == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "VDescripcionEstado", cambioTurno.IdEstado);
            ViewBag.IdTurnoUsuario = new SelectList(db.TurnoUsuario, "IdTurnoUsuario", "IdTurnoUsuario", cambioTurno.IdTurnoUsuario);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "VEmail", cambioTurno.IdUsuario);
            ViewBag.IdUsuarioold = new SelectList(db.Usuario, "IdUsuario", "VEmail", cambioTurno.IdUsuarioold);
            return View(cambioTurno);
        }

        // POST: CambioTurnos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdCambioTurno,IdUsuario,IdUsuarioold,IdEstado,VObservaciones,IdTurnoUsuario")] CambioTurno cambioTurno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cambioTurno).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdEstado = new SelectList(db.Estado, "IdEstado", "VDescripcionEstado", cambioTurno.IdEstado);
            ViewBag.IdTurnoUsuario = new SelectList(db.TurnoUsuario, "IdTurnoUsuario", "IdTurnoUsuario", cambioTurno.IdTurnoUsuario);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "VEmail", cambioTurno.IdUsuario);
            ViewBag.IdUsuarioold = new SelectList(db.Usuario, "IdUsuario", "VEmail", cambioTurno.IdUsuarioold);
            return View(cambioTurno);
        }

        // GET: CambioTurnos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CambioTurno cambioTurno = await db.CambioTurno.FindAsync(id);
            if (cambioTurno == null)
            {
                return HttpNotFound();
            }
            return View(cambioTurno);
        }

        // POST: CambioTurnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CambioTurno cambioTurno = await db.CambioTurno.FindAsync(id);
            db.CambioTurno.Remove(cambioTurno);
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
