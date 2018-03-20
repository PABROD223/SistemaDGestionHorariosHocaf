using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using HOCAF.Models;

namespace HOCAF.ViewModels
{
    public class PersonaViewModel
    {
        public int idPersona { get; set; }

        [Required(ErrorMessage = "Ingrese los datos requeridos para el campo {0}")]
        [StringLength(50)]
        [Display(Name = "Nombres")]
        public string nombres { get; set; }

        [Required(ErrorMessage = "Ingrese los datos requeridos para el campo {0}")]
        [StringLength(50)]
        [Display(Name = "Apellidos")]
        public string apellidos { get; set; }

        [Required(ErrorMessage = "Seleccione el tipo de documento")]
        [Display(Name = "Tipo de Documento")]
        public int idDocumento { get; set; }

        [Display(Name = "Nombre Tipo de Documento")]
        public string nombreTipoDocumento { get; set; }

        [Required(ErrorMessage = "Ingrese los datos requeridos para el campo {0}")]
        [StringLength(50)]
        [Display(Name = "Numero de Documento")]
        public string numeroDocumento { get; set; }

        [StringLength(7)]
        [Required(ErrorMessage = "Ingrese los datos requeridos para el campo {0}")]
        [Display(Name = "Telefono")]
        public string telefono { get; set; }


        [Required(ErrorMessage = "Ingrese los datos requeridos para el campo {0}")]
        [StringLength(10)]
        [Display(Name = "Telefono Celular")]
        public string celular { get; set; }

        [Required(ErrorMessage = "Ingrese los datos requeridos para el campo {0}")]
        [StringLength(50)]
        [Display(Name = "Direccion")]
        public string direccion { get; set; }

        [Required(ErrorMessage = "Ingrese los datos requeridos para el campo {0}")]
        [StringLength(50)]
        [Display(Name = "Correo")]
        public string correo { get; set; }

        [Display(Name = "Es Intructor")]
        public bool EsInstructor { get; set; }

        [StringLength(50)]
        [Display(Name = "Cargo")]
        public string cargo { get; set; }

        [Display(Name = " Programa de Formacion")]
        public int idProgramaFormacion { get; set; }

        public List<ProgramaFormacionDetalleInstructorViewModel> programasDelInstructor { get; set; }
    }
}