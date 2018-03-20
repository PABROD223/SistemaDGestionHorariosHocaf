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
    public class PersonaController : Controller
    {
        private HocafModel db = new HocafModel();
        // GET: Persona
        public ActionResult Index()
        {
            List<PersonaViewModel> personasRegistradas = new List<PersonaViewModel>();
            var lista = db.Personas.ToList();
            foreach (var item in lista)
            {
                PersonaViewModel persona = new PersonaViewModel();
                persona.apellidos = item.apellidos;
                if (item.Instructor != null)
                {
                    persona.cargo = item.Instructor.cargo;
                }
                persona.celular = item.celular;
                persona.correo = item.Usuario.correo;
                persona.direccion = item.direccion;
                persona.nombreTipoDocumento = item.TipoDocumento.nombreDocumento;
                persona.nombres = item.nombres;
                persona.numeroDocumento = item.numeroDocumento;
                persona.telefono = item.telefono;
                persona.idPersona = item.idPersona;

                personasRegistradas.Add(persona);
            }

            return View(personasRegistradas);
        }

        public ActionResult Create()
        {
            ViewBag.idDocumento = new SelectList(db.TipoDocumento, "idDocumento", "nombreDocumento");
            ViewBag.idProgramaFormacion = new SelectList(db.ProgramaDeFormacion, "idPrograma", "nombre");
            return View();
        }

        [HttpPost]
        public ActionResult Create(PersonaViewModel viewModel)
        {

            ViewBag.idDocumento = new SelectList(db.TipoDocumento, "idDocumento", "nombreDocumento", viewModel.idDocumento);
            ViewBag.idProgramaFormacion = new SelectList(db.ProgramaDeFormacion, "idPrograma", "nombre", viewModel.idProgramaFormacion);
            if (ModelState.IsValid)
            {
                Personas existe = db.Personas.FirstOrDefault(x => x.numeroDocumento == viewModel.numeroDocumento);
                if (existe != null)
                {
                    ModelState.AddModelError("", "El número de documento ya existe.");
                    return View(viewModel);
                }

                if (viewModel.EsInstructor)
                {
                    if (viewModel.cargo == null)
                    {
                        ModelState.AddModelError("cargo", "El cargo es obligatorio.");
                        return View(viewModel);
                    }

                    if (viewModel.idProgramaFormacion == 0)
                    {
                        ModelState.AddModelError("idProgramaFormacion", "El programa de formación es obligatorio.");
                        return View(viewModel);
                    }

                }

                Usuario existeCorreo = db.Usuario.FirstOrDefault(x => x.correo == viewModel.correo);
                if (existeCorreo != null)
                {
                    ModelState.AddModelError("correo", "El correo ya existe.");
                    return View(viewModel);
                }

                Personas persona = new Personas();
                persona.apellidos = viewModel.apellidos;
                persona.celular = viewModel.celular;
                persona.direccion = viewModel.direccion;
                persona.idDocumento = viewModel.idDocumento;
                persona.nombres = viewModel.nombres;
                persona.numeroDocumento = viewModel.numeroDocumento;
                persona.telefono = viewModel.telefono;

                db.Personas.Add(persona);
                db.SaveChanges();

                Personas registro = db.Personas.FirstOrDefault(x => x.numeroDocumento == persona.numeroDocumento);
                if (registro != null)
                {
                    Usuario usuario = new Usuario();
                    usuario.idPersona = registro.idPersona;
                    usuario.correo = viewModel.correo;
                    usuario.estado = true;
                    usuario.fechaIngreso = DateTime.Now;
                    usuario.contraseña = "123";

                    db.Usuario.Add(usuario);
                    db.SaveChanges();

                    RolDePersona rol = new RolDePersona();
                    rol.idPersona = registro.idPersona;
                    rol.idRol = 1;
                    rol.estado = true;

                    if (viewModel.EsInstructor)
                    {
                        Instructor instructor = new Instructor();
                        instructor.idPersona = registro.idPersona;
                        instructor.cargo = viewModel.cargo;
                        db.Instructor.Add(instructor);
                        db.SaveChanges();

                        InstructorProgramaDeFormacion programa = new InstructorProgramaDeFormacion();
                        programa.idPersonaInstructor = instructor.idPersona;
                        programa.idPrograma = viewModel.idProgramaFormacion;
                        programa.estado = true;

                        db.InstructorProgramaDeFormacion.Add(programa);
                        db.SaveChanges();

                        rol.idRol = 2;
                    }

                    db.RolDePersona.Add(rol);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            return View(viewModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personas persona = db.Personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            ViewBag.idProgramaFormacion = new SelectList(db.ProgramaDeFormacion, "idPrograma", "nombre");
            ViewBag.idDocumento = new SelectList(db.TipoDocumento, "idDocumento", "nombreDocumento", persona.idDocumento);

            PersonaViewModel viewModel = new PersonaViewModel();
            viewModel.apellidos = persona.apellidos;
            viewModel.celular = persona.celular;
            viewModel.correo = persona.Usuario.correo;
            viewModel.direccion = persona.direccion;
            viewModel.idDocumento = persona.idDocumento;
            viewModel.idPersona = persona.idPersona;
            viewModel.nombres = persona.nombres;
            viewModel.numeroDocumento = persona.numeroDocumento;
            viewModel.telefono = persona.telefono;
            if (persona.Instructor != null)
            {
                viewModel.EsInstructor = true;
                viewModel.cargo = persona.Instructor.cargo;
            }
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(PersonaViewModel viewModel)
        {
            try
            {
                ViewBag.idDocumento = new SelectList(db.TipoDocumento, "idDocumento", "nombreDocumento", viewModel.idDocumento);
                viewModel.idProgramaFormacion = 1;
                if (ModelState.IsValid)
                {
                    Personas existe = db.Personas.FirstOrDefault(x => x.numeroDocumento == viewModel.numeroDocumento);
                    if (existe != null)
                    {
                        ModelState.AddModelError("", "El número de documento ya existe.");
                        return View(viewModel);
                    }

                    Usuario existeCorreo = db.Usuario.FirstOrDefault(x => x.correo == viewModel.correo);
                    if (existeCorreo != null)
                    {
                        ModelState.AddModelError("correo", "El correo ya existe.");
                        return View(viewModel);
                    }

                    Personas persona = db.Personas.Find(viewModel.idPersona);
                    persona.apellidos = viewModel.apellidos;
                    persona.celular = viewModel.celular;
                    persona.direccion = viewModel.direccion;
                    persona.idDocumento = viewModel.idDocumento;
                    persona.nombres = viewModel.nombres;
                    persona.numeroDocumento = viewModel.numeroDocumento;
                    persona.telefono = viewModel.telefono;

                    db.SaveChanges();

                    Usuario usuario = db.Usuario.Find(persona.idPersona);
                    usuario.correo = viewModel.correo;
                    usuario.estado = true;

                    db.SaveChanges();

                    if (viewModel.EsInstructor)
                    {
                        Instructor instructor = db.Instructor.Find(persona.idPersona);
                        instructor.cargo = viewModel.cargo;

                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }

                return View(viewModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error: " + ex.Message.ToString());
                return View(viewModel);
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personas persona = db.Personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            PersonaViewModel viewModel = new PersonaViewModel();
            viewModel.apellidos = persona.apellidos;
            viewModel.celular = persona.celular;
            viewModel.correo = persona.Usuario.correo;
            viewModel.direccion = persona.direccion;
            viewModel.idDocumento = persona.idDocumento;
            viewModel.nombreTipoDocumento = persona.TipoDocumento.nombreDocumento;
            viewModel.idPersona = persona.idPersona;
            viewModel.nombres = persona.nombres;
            viewModel.numeroDocumento = persona.numeroDocumento;
            viewModel.telefono = persona.telefono;
            if (persona.Instructor != null)
            {
                viewModel.EsInstructor = true;
                viewModel.cargo = persona.Instructor.cargo;

                List<ProgramaFormacionDetalleInstructorViewModel> programasDelInstructor = new List<ProgramaFormacionDetalleInstructorViewModel>();

                foreach (var item in persona.Instructor.InstructorProgramaDeFormacion)
                {
                    ProgramaFormacionDetalleInstructorViewModel vmodel = new ProgramaFormacionDetalleInstructorViewModel();
                    ProgramaDeFormacion programa = db.ProgramaDeFormacion.Find(item.idPrograma);
                    vmodel.idPrograma = programa.idPrograma;
                    vmodel.nombre = programa.nombre;
                    vmodel.estado = item.estado;
                    programasDelInstructor.Add(vmodel);
                }

                viewModel.programasDelInstructor = programasDelInstructor;
            }

            ViewBag.idProgramaFormacion = new SelectList(db.ProgramaDeFormacion, "idPrograma", "nombre");
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Details(PersonaViewModel viewModel, string opcion)
        {
            ViewBag.idProgramaFormacion = new SelectList(db.ProgramaDeFormacion, "idPrograma", "nombre");
            if ("Agregar".Equals(opcion))
            {
                InstructorProgramaDeFormacion registro = db.InstructorProgramaDeFormacion.Find(viewModel.idPersona, viewModel.idProgramaFormacion);

                if (registro != null)
                {
                    ModelState.AddModelError("idProgramaFormacion", "Este programa ya esta registrado.");
                    return View(viewModel);
                }
                InstructorProgramaDeFormacion nuevoPrograma = new InstructorProgramaDeFormacion();
                nuevoPrograma.idPersonaInstructor = viewModel.idPersona;
                nuevoPrograma.idPrograma = viewModel.idProgramaFormacion;
                nuevoPrograma.estado = true;

                db.InstructorProgramaDeFormacion.Add(nuevoPrograma);
                db.SaveChanges();
            }

            if ("Guardar".Equals(opcion))
            {
                foreach (var item in viewModel.programasDelInstructor)
                {
                    InstructorProgramaDeFormacion registro = db.InstructorProgramaDeFormacion.Find(viewModel.idPersona, item.idPrograma);
                    registro.estado = item.estado;

                    db.SaveChanges();
                }
            }

            if (opcion.Contains("Eliminar"))
            {
                string[] datos = opcion.Split(new char[] { '/' });
                InstructorProgramaDeFormacion registro = db.InstructorProgramaDeFormacion.Find(viewModel.idPersona, Convert.ToInt32(datos[1]));

                db.InstructorProgramaDeFormacion.Remove(registro);
                db.SaveChanges();
            }

            return RedirectToAction("Details", new { id = viewModel.idPersona });
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personas persona = db.Personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Fichas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personas persona = db.Personas.Find(id);
            var roles = db.RolDePersona.Where(x=>x.idPersona==persona.idPersona).ToList();

            foreach (var item in roles)
            {
                db.RolDePersona.Remove(item);
                db.SaveChanges();
            }

            if (persona.Instructor!=null)
            {
                var programas = db.InstructorProgramaDeFormacion.Where(x => x.idPersonaInstructor == persona.Instructor.idPersona).ToList();
                foreach (var item in programas)
                {
                    db.InstructorProgramaDeFormacion.Remove(item);
                    db.SaveChanges();
                }

                db.Instructor.Remove(persona.Instructor);
                db.SaveChanges();
            }

            db.Usuario.Remove(persona.Usuario);
            db.SaveChanges();

            db.Personas.Remove(persona);
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