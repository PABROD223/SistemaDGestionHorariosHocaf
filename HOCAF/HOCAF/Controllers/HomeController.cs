using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HOCAF.Models;
namespace HOCAF.Controllers
{
    public class HomeController : Controller
    {
        private HocafModel db = new HocafModel();
        public ActionResult Index()
        {
            if (Session["Usuario"]==null)
            {
                return RedirectToAction("LogIn");
            }
            Usuario usuario = (Usuario)Session["Usuario"];
            ViewBag.NombreUsuario = usuario.Personas.apellidos + " " + usuario.Personas.nombres;
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Usuario usuario)
        {
            if (usuario.correo==null)
            {
                ModelState.AddModelError("correo","El correo es obligatorio.");
                return View(usuario);
            }

            if (usuario.correo == null)
            {
                ModelState.AddModelError("contraseña", "La contraseña es obligatorio.");
                return View(usuario);
            }

            var ValidUser = db.Usuario.FirstOrDefault(x=>x.correo==usuario.correo);
            if (ValidUser==null)
            {
                ModelState.AddModelError("", "El usuario no existe.");
                return View(usuario);
            }

            if (ValidUser.contraseña!=usuario.contraseña)
            {
                ModelState.AddModelError("", "La contraseña es erronea.");
                return View(usuario);
            }

            Session["Usuario"] = ValidUser;
            Session["NombreUsuario"] = ValidUser.Personas.apellidos + " " + ValidUser.Personas.nombres; ;
            Session["Rol"] = ValidUser.Personas.RolDePersona.ToList()[0].Roles.nombreRol;

            return RedirectToAction("Index","Home");
        }

        public ActionResult LogOut()
        {
            Session["Usuario"] = null;
            Session.Abandon();
            return RedirectToAction("LogIn");
        }
    }
}