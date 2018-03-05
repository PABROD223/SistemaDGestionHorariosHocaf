using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HOCAF.Models;

namespace HOCAF.Controllers
{
    public class TipoDocumentoController : Controller
    {
        HOCAF.Models.HocafModel db = new Models.HocafModel(); 
      
        public ActionResult Index()
        {
            var listaDeDocumentos = db.TipoDocumento.ToList();
            return View(listaDeDocumentos);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TipoDocumento model)
        {
            if (ModelState.IsValid)
            {
                db.TipoDocumento.Add(model);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

    }
}