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
    public class TrimestresController : Controller
    {
        private HocafModel db = new HocafModel();

        // GET: Trimestres
        public ActionResult Index()
        {
            return View(db.Trimestre.ToList());
        }

        // GET: Trimestres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trimestre trimestre = db.Trimestre.Find(id);
            if (trimestre == null)
            {
                return HttpNotFound();
            }
            return View(trimestre);
        }

        // GET: Trimestres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trimestres/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTrimestre,nombre")] Trimestre trimestre)
        {
            if (ModelState.IsValid)
            {
                db.Trimestre.Add(trimestre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trimestre);
        }

        // GET: Trimestres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trimestre trimestre = db.Trimestre.Find(id);
            if (trimestre == null)
            {
                return HttpNotFound();
            }
            return View(trimestre);
        }

        // POST: Trimestres/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTrimestre,nombre")] Trimestre trimestre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trimestre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trimestre);
        }

        // GET: Trimestres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trimestre trimestre = db.Trimestre.Find(id);
            if (trimestre == null)
            {
                return HttpNotFound();
            }
            return View(trimestre);
        }

        // POST: Trimestres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trimestre trimestre = db.Trimestre.Find(id);
            db.Trimestre.Remove(trimestre);
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
