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
    public class EstadoHorariosController : Controller
    {
        private HocafModel db = new HocafModel();

        // GET: EstadoHorarios
        public ActionResult Index()
        {
            return View(db.EstadoHorario.ToList());
        }

        // GET: EstadoHorarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoHorario estadoHorario = db.EstadoHorario.Find(id);
            if (estadoHorario == null)
            {
                return HttpNotFound();
            }
            return View(estadoHorario);
        }

        // GET: EstadoHorarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoHorarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEstado,nombre")] EstadoHorario estadoHorario)
        {
            if (ModelState.IsValid)
            {
                db.EstadoHorario.Add(estadoHorario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadoHorario);
        }

        // GET: EstadoHorarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoHorario estadoHorario = db.EstadoHorario.Find(id);
            if (estadoHorario == null)
            {
                return HttpNotFound();
            }
            return View(estadoHorario);
        }

        // POST: EstadoHorarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEstado,nombre")] EstadoHorario estadoHorario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadoHorario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadoHorario);
        }

        // GET: EstadoHorarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoHorario estadoHorario = db.EstadoHorario.Find(id);
            if (estadoHorario == null)
            {
                return HttpNotFound();
            }
            return View(estadoHorario);
        }

        // POST: EstadoHorarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstadoHorario estadoHorario = db.EstadoHorario.Find(id);
            db.EstadoHorario.Remove(estadoHorario);
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
