//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TutoriasWcf.App_Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Calificacion
    {
        public string comentarios { get; set; }
        public int puntaje { get; set; }
        public int idCalificacion { get; set; }
        public int idTurno { get; set; }
    
        public virtual Turno Turno { get; set; }
    }
}
