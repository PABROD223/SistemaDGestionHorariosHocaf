using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HOCAF.Models;
using HOCAF.ViewModels;

namespace HOCAF.Controllers
{
    public class TrimestresFormacionsController : Controller
    {
        private HocafModel db = new HocafModel();

        // GET: TrimestresFormacions
        public ActionResult Index()
        {
            var trimestresFormacion = db.TrimestresFormacion.Include(t => t.JornadaTipoFormacion).Include(t => t.Trimestre);
            return View(trimestresFormacion.ToList());
        }

        // GET: TrimestresFormacions/Details/5
        public ActionResult Details(int? idTrimestre, int? idJornadaJTF, int? idTipoFormacionJTF)
        {
            if (idTrimestre == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (idJornadaJTF == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (idTipoFormacionJTF == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrimestresFormacion trimestresFormacion = db.TrimestresFormacion.Find(idTrimestre, idJornadaJTF, idTipoFormacionJTF);
            if (trimestresFormacion == null)
            {
                return HttpNotFound();
            }
            return View(trimestresFormacion);
        }

        // GET: TrimestresFormacions/Creat
        public ActionResult Create()
        {
            ViewBag.idjornadaJTF = new SelectList(db.Jornada,"idJornada","nombre");
            ViewBag.idTipoFormacionJTF = new SelectList(db.TipoFormacion, "idTipoFormacion", "nombre");
            ViewBag.idTrimestre = new SelectList(db.Trimestre, "idTrimestre", "nombre");
            return View();
        }
        public JsonResult TiposDeFormacionDeLaJornada(int codigo) {
            List<TipoFormacionViewModel> tiposFormacion = new List<TipoFormacionViewModel>();
            tiposFormacion = obtenerTiposFormacion(codigo);
            return Json(tiposFormacion.ToList(),JsonRequestBehavior.AllowGet);
        }

        public List<TipoFormacionViewModel> obtenerTiposFormacion(int codigo)
        {
            List<TipoFormacionViewModel> tiposFormacion = new List<TipoFormacionViewModel>();
            var lista = db.JornadaTipoFormacion.Where(x => x.idJornada == codigo).ToList();

            foreach (var item in lista)
            {
                TipoFormacionViewModel tipo = new TipoFormacionViewModel();
                var model = db.TipoFormacion.Find(item.idTipoFormacion);
                tipo.codigo = model.idTipoFormacion;
                tipo.nombre = model.nombre;
                tiposFormacion.Add(tipo);
            }
            return tiposFormacion;
        }


        // POST: TrimestresFormacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTrimestre,idjornadaJTF,idTipoFormacionJTF,estado")] TrimestresFormacion trimestresFormacion)
        {
            if (ModelState.IsValid)
            {
                if (trimestresFormacion.idTipoFormacionJTF==0)
                {
                    ViewBag.idjornadaJTF = new SelectList(db.Jornada, "idJornada", "nombre", trimestresFormacion.idjornadaJTF);
                    ViewBag.idTrimestre = new SelectList(db.Trimestre, "idTrimestre", "nombre", trimestresFormacion.idTrimestre);
                    ViewBag.idTipoFormacionJTF = new SelectList(obtenerTiposFormacion(trimestresFormacion.idjornadaJTF), "idTipoFormacion", "nombre", trimestresFormacion.idTipoFormacionJTF);
                    ModelState.AddModelError("idTipoFormacionJTF", "Esta jornada no tiene asignada algun tpo de formacion.");
                    return View(trimestresFormacion);
                }

                TrimestresFormacion existe = db.TrimestresFormacion.Find(trimestresFormacion.idTrimestre, trimestresFormacion.idjornadaJTF, trimestresFormacion.idTipoFormacionJTF);
                if (existe!=null)
                {
                    ViewBag.idjornadaJTF = new SelectList(db.Jornada, "idJornada", "nombre", trimestresFormacion.idjornadaJTF);
                    ViewBag.idTrimestre = new SelectList(db.Trimestre, "idTrimestre", "nombre", trimestresFormacion.idTrimestre);
                    ViewBag.idTipoFormacionJTF = new SelectList(obtenerTiposFormacion(trimestresFormacion.idjornadaJTF), "idTipoFormacion", "nombre", trimestresFormacion.idTipoFormacionJTF);
                    ModelState.AddModelError("", "Este item ya existe.");
                    return View(trimestresFormacion);
                }

                db.TrimestresFormacion.Add(trimestresFormacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idjornadaJTF = new SelectList(db.Jornada, "idJornada", "nombre", trimestresFormacion.idjornadaJTF);
            ViewBag.idTrimestre = new SelectList(db.Trimestre, "idTrimestre", "nombre", trimestresFormacion.idTrimestre);
            ViewBag.idTipoFormacionJTF = new SelectList(obtenerTiposFormacion(trimestresFormacion.idjornadaJTF), "idTipoFormacion", "nombre", trimestresFormacion.idTipoFormacionJTF);
            return View(trimestresFormacion);
        }

        // GET: TrimestresFormacions/Edit/5
        public ActionResult Edit(int? idTrimestre, int? idJornadaJTF, int? idTipoFormacionJTF)
        {
            if (idTrimestre == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (idJornadaJTF == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (idTipoFormacionJTF == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrimestresFormacion trimestresFormacion = db.TrimestresFormacion.Find(idTrimestre, idJornadaJTF,idTipoFormacionJTF);
            if (trimestresFormacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idjornadaJTF = new SelectList(db.JornadaTipoFormacion, "idJornada", "idJornada", trimestresFormacion.idjornadaJTF);
            ViewBag.idTrimestre = new SelectList(db.Trimestre, "idTrimestre", "nombre", trimestresFormacion.idTrimestre);
            return View(trimestresFormacion);
        }

        // POST: TrimestresFormacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTrimestre,idjornadaJTF,idTipoFormacionJTF,estado")] TrimestresFormacion trimestresFormacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trimestresFormacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idjornadaJTF = new SelectList(db.JornadaTipoFormacion, "idJornada", "idJornada", trimestresFormacion.idjornadaJTF);
            ViewBag.idTrimestre = new SelectList(db.Trimestre, "idTrimestre", "nombre", trimestresFormacion.idTrimestre);
            return View(trimestresFormacion);
        }

        // GET: TrimestresFormacions/Delete/5
        public ActionResult Delete(int? idTrimestre, int? idJornadaJTF, int? idTipoFormacionJTF)
        {
            if (idTrimestre == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (idJornadaJTF == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (idTipoFormacionJTF == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrimestresFormacion trimestresFormacion = db.TrimestresFormacion.Find(idTrimestre, idJornadaJTF, idTipoFormacionJTF);
            if (trimestresFormacion == null)
            {
                return HttpNotFound();
            }
            return View(trimestresFormacion);
        }

        // POST: TrimestresFormacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? idTrimestre, int? idJornadaJTF, int? idTipoFormacionJTF)
        {
            TrimestresFormacion trimestresFormacion = db.TrimestresFormacion.Find(idTrimestre, idJornadaJTF, idTipoFormacionJTF);
            db.TrimestresFormacion.Remove(trimestresFormacion);
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
