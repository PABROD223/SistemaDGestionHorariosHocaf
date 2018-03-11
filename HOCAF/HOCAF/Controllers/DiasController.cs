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
    public class DiasController : Controller
    {
        private HocafModel db = new HocafModel();

        // GET: Dias
        public ActionResult Index()
        {
            return View(db.Dia.ToList());
        }

        // GET: Dias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dia dia = db.Dia.Find(id);
            if (dia == null)
            {
                return HttpNotFound();
            }
            return View(dia);
        }

        // GET: Dias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDia,nombre")] Dia dia)
        {
            if (ModelState.IsValid)
            {
                db.Dia.Add(dia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dia);
        }

        // GET: Dias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dia dia = db.Dia.Find(id);
            if (dia == null)
            {
                return HttpNotFound();
            }
            return View(dia);
        }

        // POST: Dias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDia,nombre")] Dia dia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dia);
        }

        // GET: Dias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dia dia = db.Dia.Find(id);
            if (dia == null)
            {
                return HttpNotFound();
            }
            return View(dia);
        }

        // POST: Dias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dia dia = db.Dia.Find(id);
            db.Dia.Remove(dia);
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
