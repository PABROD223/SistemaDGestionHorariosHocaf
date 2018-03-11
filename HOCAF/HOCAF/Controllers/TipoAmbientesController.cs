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
    public class TipoAmbientesController : Controller
    {
        private HocafModel db = new HocafModel();

        // GET: TipoAmbientes
        public ActionResult Index()
        {
            return View(db.TipoAmbiente.ToList());
        }

        // GET: TipoAmbientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAmbiente tipoAmbiente = db.TipoAmbiente.Find(id);
            if (tipoAmbiente == null)
            {
                return HttpNotFound();
            }
            return View(tipoAmbiente);
        }

        // GET: TipoAmbientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoAmbientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoAmbiente,nombre")] TipoAmbiente tipoAmbiente)
        {
            if (ModelState.IsValid)
            {
                db.TipoAmbiente.Add(tipoAmbiente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoAmbiente);
        }

        // GET: TipoAmbientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAmbiente tipoAmbiente = db.TipoAmbiente.Find(id);
            if (tipoAmbiente == null)
            {
                return HttpNotFound();
            }
            return View(tipoAmbiente);
        }

        // POST: TipoAmbientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoAmbiente,nombre")] TipoAmbiente tipoAmbiente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoAmbiente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoAmbiente);
        }

        // GET: TipoAmbientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAmbiente tipoAmbiente = db.TipoAmbiente.Find(id);
            if (tipoAmbiente == null)
            {
                return HttpNotFound();
            }
            return View(tipoAmbiente);
        }

        // POST: TipoAmbientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoAmbiente tipoAmbiente = db.TipoAmbiente.Find(id);
            db.TipoAmbiente.Remove(tipoAmbiente);
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
