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
    public class ProgramaDeFormacionsController : Controller
    {
        private HocafModel db = new HocafModel();

        // GET: ProgramaDeFormacions
        public ActionResult Index()
        {
            var programaDeFormacion = db.ProgramaDeFormacion.Include(p => p.Especialidad).Include(p => p.TipoFormacion);
            return View(programaDeFormacion.ToList());
        }

        // GET: ProgramaDeFormacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramaDeFormacion programaDeFormacion = db.ProgramaDeFormacion.Find(id);
            if (programaDeFormacion == null)
            {
                return HttpNotFound();
            }
            return View(programaDeFormacion);
        }

        // GET: ProgramaDeFormacions/Create
        public ActionResult Create()
        {
            ViewBag.idEspecialidad = new SelectList(db.Especialidad, "idEspecialidad", "nombre");
            ViewBag.idTipoFormacion = new SelectList(db.TipoFormacion, "idTipoFormacion", "nombre");
            return View();
        }

        // POST: ProgramaDeFormacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPrograma,nombre,siglas,idEspecialidad,idTipoFormacion")] ProgramaDeFormacion programaDeFormacion)
        {
            if (ModelState.IsValid)
            {
                db.ProgramaDeFormacion.Add(programaDeFormacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEspecialidad = new SelectList(db.Especialidad, "idEspecialidad", "nombre", programaDeFormacion.idEspecialidad);
            ViewBag.idTipoFormacion = new SelectList(db.TipoFormacion, "idTipoFormacion", "nombre", programaDeFormacion.idTipoFormacion);
            return View(programaDeFormacion);
        }

        // GET: ProgramaDeFormacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramaDeFormacion programaDeFormacion = db.ProgramaDeFormacion.Find(id);
            if (programaDeFormacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEspecialidad = new SelectList(db.Especialidad, "idEspecialidad", "nombre", programaDeFormacion.idEspecialidad);
            ViewBag.idTipoFormacion = new SelectList(db.TipoFormacion, "idTipoFormacion", "nombre", programaDeFormacion.idTipoFormacion);
            return View(programaDeFormacion);
        }

        // POST: ProgramaDeFormacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPrograma,nombre,siglas,idEspecialidad,idTipoFormacion")] ProgramaDeFormacion programaDeFormacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(programaDeFormacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEspecialidad = new SelectList(db.Especialidad, "idEspecialidad", "nombre", programaDeFormacion.idEspecialidad);
            ViewBag.idTipoFormacion = new SelectList(db.TipoFormacion, "idTipoFormacion", "nombre", programaDeFormacion.idTipoFormacion);
            return View(programaDeFormacion);
        }

        // GET: ProgramaDeFormacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProgramaDeFormacion programaDeFormacion = db.ProgramaDeFormacion.Find(id);
            if (programaDeFormacion == null)
            {
                return HttpNotFound();
            }
            return View(programaDeFormacion);
        }

        // POST: ProgramaDeFormacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProgramaDeFormacion programaDeFormacion = db.ProgramaDeFormacion.Find(id);
            db.ProgramaDeFormacion.Remove(programaDeFormacion);
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
