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
    public class JornadaTipoFormacionsController : Controller
    {
        private HocafModel db = new HocafModel();

        // GET: JornadaTipoFormacions
        public ActionResult Index()
        {
            var jornadaTipoFormacion = db.JornadaTipoFormacion.Include(j => j.Jornada).Include(j => j.TipoFormacion);
            return View(jornadaTipoFormacion.ToList());
        }

        // GET: JornadaTipoFormacions/Details/5
        public ActionResult Details(int? idjornada,int?  idtipoFormacion)
        {
            if (idjornada == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (idtipoFormacion == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JornadaTipoFormacion jornadaTipoFormacion = db.JornadaTipoFormacion.Find(idjornada, idtipoFormacion);
            if (jornadaTipoFormacion == null)
            {
                return HttpNotFound();
            }
            return View(jornadaTipoFormacion);
        }

        // GET: JornadaTipoFormacions/Create
        public ActionResult Create()
        {
            ViewBag.idJornada = new SelectList(db.Jornada, "idJornada", "nombre");
            ViewBag.idTipoFormacion = new SelectList(db.TipoFormacion, "idTipoFormacion", "nombre");
            return View();
        }

        // POST: JornadaTipoFormacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idJornada,idTipoFormacion,estado")] JornadaTipoFormacion jornadaTipoFormacion)
        {
            if (ModelState.IsValid)
            {
                db.JornadaTipoFormacion.Add(jornadaTipoFormacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idJornada = new SelectList(db.Jornada, "idJornada", "nombre", jornadaTipoFormacion.idJornada);
            ViewBag.idTipoFormacion = new SelectList(db.TipoFormacion, "idTipoFormacion", "nombre", jornadaTipoFormacion.idTipoFormacion);
            return View(jornadaTipoFormacion);
        }

        // GET: JornadaTipoFormacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JornadaTipoFormacion jornadaTipoFormacion = db.JornadaTipoFormacion.Find(id);
            if (jornadaTipoFormacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idJornada = new SelectList(db.Jornada, "idJornada", "nombre", jornadaTipoFormacion.idJornada);
            ViewBag.idTipoFormacion = new SelectList(db.TipoFormacion, "idTipoFormacion", "nombre", jornadaTipoFormacion.idTipoFormacion);
            return View(jornadaTipoFormacion);
        }

        // POST: JornadaTipoFormacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idJornada,idTipoFormacion,estado")] JornadaTipoFormacion jornadaTipoFormacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jornadaTipoFormacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idJornada = new SelectList(db.Jornada, "idJornada", "nombre", jornadaTipoFormacion.idJornada);
            ViewBag.idTipoFormacion = new SelectList(db.TipoFormacion, "idTipoFormacion", "nombre", jornadaTipoFormacion.idTipoFormacion);
            return View(jornadaTipoFormacion);
        }

        // GET: JornadaTipoFormacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JornadaTipoFormacion jornadaTipoFormacion = db.JornadaTipoFormacion.Find(id);
            if (jornadaTipoFormacion == null)
            {
                return HttpNotFound();
            }
            return View(jornadaTipoFormacion);
        }

        // POST: JornadaTipoFormacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JornadaTipoFormacion jornadaTipoFormacion = db.JornadaTipoFormacion.Find(id);
            db.JornadaTipoFormacion.Remove(jornadaTipoFormacion);
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
