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
    public class EstadoFichasController : Controller
    {
        private HocafModel db = new HocafModel();

        // GET: EstadoFichas
        public ActionResult Index()
        {
            return View(db.EstadoFicha.ToList());
        }

        // GET: EstadoFichas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoFicha estadoFicha = db.EstadoFicha.Find(id);
            if (estadoFicha == null)
            {
                return HttpNotFound();
            }
            return View(estadoFicha);
        }

        // GET: EstadoFichas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoFichas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEstado,nombre")] EstadoFicha estadoFicha)
        {
            if (ModelState.IsValid)
            {
                db.EstadoFicha.Add(estadoFicha);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadoFicha);
        }

        // GET: EstadoFichas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoFicha estadoFicha = db.EstadoFicha.Find(id);
            if (estadoFicha == null)
            {
                return HttpNotFound();
            }
            return View(estadoFicha);
        }

        // POST: EstadoFichas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEstado,nombre")] EstadoFicha estadoFicha)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadoFicha).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadoFicha);
        }

        // GET: EstadoFichas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoFicha estadoFicha = db.EstadoFicha.Find(id);
            if (estadoFicha == null)
            {
                return HttpNotFound();
            }
            return View(estadoFicha);
        }

        // POST: EstadoFichas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstadoFicha estadoFicha = db.EstadoFicha.Find(id);
            db.EstadoFicha.Remove(estadoFicha);
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
