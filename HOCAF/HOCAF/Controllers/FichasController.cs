using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HOCAF.Models;

namespace HOCAF.Controllers
{
    public class FichasController : Controller
    {
        private HocafModel db = new HocafModel();

        // GET: Fichas
        public ActionResult Index()
        {
            var ficha = db.Ficha.Include(f => f.EstadoFicha).Include(f => f.Jornada).Include(f => f.Jornada1);
            return View(ficha.ToList());
        }

        // GET: Fichas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ficha ficha = db.Ficha.Find(id);
            if (ficha == null)
            {
                return HttpNotFound();
            }
            return View(ficha);
        }

        // GET: Fichas/Create
        public ActionResult Create()
        {
            ViewBag.idEstadoFicha = new SelectList(db.EstadoFicha, "idEstado", "nombre");
            ViewBag.idJornada = new SelectList(db.Jornada, "idJornada", "nombre");
            ViewBag.idPrograma = new SelectList(db.ProgramaDeFormacion, "idPrograma", "nombre");
            return View();
        }

        // POST: Fichas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ficha ficha)
        {
            if (ModelState.IsValid)
            {
                db.Ficha.Add(ficha);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPrograma = new SelectList(db.ProgramaDeFormacion, "idPrograma", "nombre",ficha.idPrograma);
            ViewBag.idEstadoFicha = new SelectList(db.EstadoFicha, "idEstado", "nombre", ficha.idEstadoFicha);
            ViewBag.idJornada = new SelectList(db.Jornada, "idJornada", "nombre", ficha.idJornada);
            return View(ficha);
        }

        // GET: Fichas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ficha ficha = db.Ficha.Find(id);
            if (ficha == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEstadoFicha = new SelectList(db.EstadoFicha, "idEstado", "nombre", ficha.idEstadoFicha);
            ViewBag.idJornada = new SelectList(db.Jornada, "idJornada", "nombre", ficha.idJornada);
            ViewBag.idJornada = new SelectList(db.Jornada, "idJornada", "nombre", ficha.idJornada);
            return View(ficha);
        }

        // POST: Fichas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idFicha,idJornada,idEstadoFicha,fechaInicio,fechaFin,idPrograma")] Ficha ficha)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ficha).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEstadoFicha = new SelectList(db.EstadoFicha, "idEstado", "nombre", ficha.idEstadoFicha);
            ViewBag.idJornada = new SelectList(db.Jornada, "idJornada", "nombre", ficha.idJornada);
            ViewBag.idJornada = new SelectList(db.Jornada, "idJornada", "nombre", ficha.idJornada);
            return View(ficha);
        }

        // GET: Fichas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ficha ficha = db.Ficha.Find(id);
            if (ficha == null)
            {
                return HttpNotFound();
            }
            return View(ficha);
        }

        // POST: Fichas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ficha ficha = db.Ficha.Find(id);
            db.Ficha.Remove(ficha);
            db.SaveChanges();
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
