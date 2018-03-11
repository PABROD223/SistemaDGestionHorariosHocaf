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
    public class VersionesController : Controller
    {
        private HocafModel db = new HocafModel();

        // GET: Versiones
        public ActionResult Index()
        {
            return View(db.Versiones.ToList());
        }

        // GET: Versiones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Versiones versiones = db.Versiones.Find(id);
            if (versiones == null)
            {
                return HttpNotFound();
            }
            return View(versiones);
        }

        // GET: Versiones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Versiones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idVersion,nombre,estado,fechaInicio,fechaFin")] Versiones versiones)
        {
            if (ModelState.IsValid)
            {
                db.Versiones.Add(versiones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(versiones);
        }

        // GET: Versiones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Versiones versiones = db.Versiones.Find(id);
            if (versiones == null)
            {
                return HttpNotFound();
            }
            return View(versiones);
        }

        // POST: Versiones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idVersion,nombre,estado,fechaInicio,fechaFin")] Versiones versiones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(versiones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(versiones);
        }

        // GET: Versiones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Versiones versiones = db.Versiones.Find(id);
            if (versiones == null)
            {
                return HttpNotFound();
            }
            return View(versiones);
        }

        // POST: Versiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Versiones versiones = db.Versiones.Find(id);
            db.Versiones.Remove(versiones);
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
