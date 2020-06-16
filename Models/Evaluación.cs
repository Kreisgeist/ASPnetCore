using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_.NET_Core.Models
{
    public class Evaluación:ObjetoEscuelaBase
    {
        public Alumno Alumno { get; set; }
        public string AlumnoId { get; set; }
        public Asignatura Asignatura  { get; set; }
        public string AsignaturaId { get; set; }
        [Required(ErrorMessage = "Se requiere la nueva nota")]
        public float Nota { get; set; }
    }
}