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
    public class AmbientesController : Controller
    {
        private HocafModel db = new HocafModel();

        // GET: Ambientes
        public ActionResult Index()
        {
            var ambiente = db.Ambiente.Include(a => a.Sede).Include(a => a.TipoAmbiente);
            return View(ambiente.ToList());
        }

        // GET: Ambientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ambiente ambiente = db.Ambiente.Find(id);
            if (ambiente == null)
            {
                return HttpNotFound();
            }
            return View(ambiente);
        }

        // GET: Ambientes/Create
        public ActionResult Create()
        {
            ViewBag.idSede = new SelectList(db.Sede, "idSede", "nombre");
            ViewBag.idTipoAmbiente = new SelectList(db.TipoAmbiente, "idTipoAmbiente", "nombre");
            return View();
        }

        // POST: Ambientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAmbiente,idSede,nombre,idTipoAmbiente,estado")] Ambiente ambiente)
        {
            if (ModelState.IsValid)
            {
                db.Ambiente.Add(ambiente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idSede = new SelectList(db.Sede, "idSede", "nombre", ambiente.idSede);
            ViewBag.idTipoAmbiente = new SelectList(db.TipoAmbiente, "idTipoAmbiente", "nombre", ambiente.idTipoAmbiente);
            return View(ambiente);
        }

        // GET: Ambientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ambiente ambiente = db.Ambiente.Find(id);
            if (ambiente == null)
            {
                return HttpNotFound();
            }
            ViewBag.idSede = new SelectList(db.Sede, "idSede", "nombre", ambiente.idSede);
            ViewBag.idTipoAmbiente = new SelectList(db.TipoAmbiente, "idTipoAmbiente", "nombre", ambiente.idTipoAmbiente);
            return View(ambiente);
        }

        // POST: Ambientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAmbiente,idSede,nombre,idTipoAmbiente,estado")] Ambiente ambiente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ambiente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idSede = new SelectList(db.Sede, "idSede", "nombre", ambiente.idSede);
            ViewBag.idTipoAmbiente = new SelectList(db.TipoAmbiente, "idTipoAmbiente", "nombre", ambiente.idTipoAmbiente);
            return View(ambiente);
        }

        // GET: Ambientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ambiente ambiente = db.Ambiente.Find(id);
            if (ambiente == null)
            {
                return HttpNotFound();
            }
            return View(ambiente);
        }

        // POST: Ambientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ambiente ambiente = db.Ambiente.Find(id);
            db.Ambiente.Remove(ambiente);
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
