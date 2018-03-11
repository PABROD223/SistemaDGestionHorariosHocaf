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
    public class TipoFormacionsController : Controller
    {
        private HocafModel db = new HocafModel();

        // GET: TipoFormacions
        public ActionResult Index()
        {
            return View(db.TipoFormacion.ToList());
        }

        // GET: TipoFormacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoFormacion tipoFormacion = db.TipoFormacion.Find(id);
            if (tipoFormacion == null)
            {
                return HttpNotFound();
            }
            return View(tipoFormacion);
        }

        // GET: TipoFormacions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoFormacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoFormacion,nombre,estado")] TipoFormacion tipoFormacion)
        {
            if (ModelState.IsValid)
            {
                db.TipoFormacion.Add(tipoFormacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoFormacion);
        }

        // GET: TipoFormacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoFormacion tipoFormacion = db.TipoFormacion.Find(id);
            if (tipoFormacion == null)
            {
                return HttpNotFound();
            }
            return View(tipoFormacion);
        }

        // POST: TipoFormacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoFormacion,nombre,estado")] TipoFormacion tipoFormacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoFormacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoFormacion);
        }

        // GET: TipoFormacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoFormacion tipoFormacion = db.TipoFormacion.Find(id);
            if (tipoFormacion == null)
            {
                return HttpNotFound();
            }
            return View(tipoFormacion);
        }

        // POST: TipoFormacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoFormacion tipoFormacion = db.TipoFormacion.Find(id);
            db.TipoFormacion.Remove(tipoFormacion);
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
