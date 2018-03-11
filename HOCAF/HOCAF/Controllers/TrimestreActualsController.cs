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
    public class TrimestreActualsController : Controller
    {
        private HocafModel db = new HocafModel();

        // GET: TrimestreActuals
        public ActionResult Index()
        {
            return View(db.TrimestreActual.ToList());
        }

        // GET: TrimestreActuals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrimestreActual trimestreActual = db.TrimestreActual.Find(id);
            if (trimestreActual == null)
            {
                return HttpNotFound();
            }
            return View(trimestreActual);
        }

        // GET: TrimestreActuals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrimestreActuals/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTrimestreActual,nombre,estado")] TrimestreActual trimestreActual)
        {
            if (ModelState.IsValid)
            {
                db.TrimestreActual.Add(trimestreActual);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trimestreActual);
        }

        // GET: TrimestreActuals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrimestreActual trimestreActual = db.TrimestreActual.Find(id);
            if (trimestreActual == null)
            {
                return HttpNotFound();
            }
            return View(trimestreActual);
        }

        // POST: TrimestreActuals/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTrimestreActual,nombre,estado")] TrimestreActual trimestreActual)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trimestreActual).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trimestreActual);
        }

        // GET: TrimestreActuals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrimestreActual trimestreActual = db.TrimestreActual.Find(id);
            if (trimestreActual == null)
            {
                return HttpNotFound();
            }
            return View(trimestreActual);
        }

        // POST: TrimestreActuals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrimestreActual trimestreActual = db.TrimestreActual.Find(id);
            db.TrimestreActual.Remove(trimestreActual);
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
