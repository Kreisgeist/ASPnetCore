using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_.NET_Core.Models
{
    public class Curso:ObjetoEscuelaBase
    {
        [Display(Name = "Nombre", Prompt="Nombre del curso")]
        [Required(ErrorMessage = "El nombre del curso es requerido")]
        [StringLength(3, ErrorMessage = "Longitud maxima 3")]
        public override string Nombre { get; set; }
        [Required(ErrorMessage = "El tipo de jornada es requerido")]
        public TiposJornada Jornada { get; set; }
        public List<Asignatura> Asignaturas{ get; set; }
        public List<Alumno> Alumnos{ get; set; }

        [Display(Prompt="Dirección del curso", Name = "Dirección")]
        [Required(ErrorMessage = "Se requiere incluir una dirección")]
        [MinLength(10, ErrorMessage="La longitud minima de la dirección es 10")]
        public string Dirección { get; set; }
        public string EscuelaId { get; set; }
        public virtual Escuela Escuela { get; set; }
    }
}