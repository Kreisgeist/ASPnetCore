using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_.NET_Core.Models
{
    public class Asignatura:ObjetoEscuelaBase
    {
        [Display(Name = "Nombre", Prompt="Nombre de la asignatura")]
        [Required(ErrorMessage = "El nombre de la asignatura es requerido")]
        [StringLength(30, ErrorMessage = "Longitud maxima de nombre 30")]
        public override string Nombre { set; get; }
        public string CursoId { get; set; }
        public Curso Curso { get; set; }
        public List<Evaluación> Evaluaciones { get; set; }
    }
}