using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_.NET_Core.Models
{
    public class Alumno: ObjetoEscuelaBase
    {
        [Display(Name = "Nombre", Prompt="Nombre del alumno")]
        [Required(ErrorMessage = "El nombre del alumno es requerido")]
        [StringLength(45, ErrorMessage = "Longitud maxima 45")]
        public override string Nombre { get; set; }
        [Required(ErrorMessage = "Es necesario indicar el grupo del alumno")]
        public string CursoId { get; set; }
        public virtual Curso Curso { get; set; }
        public List<Evaluación> Evaluaciones { get; set; }
    }
}