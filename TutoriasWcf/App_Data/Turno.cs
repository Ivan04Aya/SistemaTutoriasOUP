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
    
    public partial class Turno
    {
        public int idTurno { get; set; }
        public string asunto { get; set; }
        public string nombreEstudiante { get; set; }
        public string nombreTutor { get; set; }
        public int estadoTurno { get; set; }
        public System.DateTime fechaTurno { get; set; }
        public System.TimeSpan horaInicio { get; set; }
        public string matriculaEstudiante { get; set; }
        public Nullable<int> tiempoTutoria { get; set; }
        public Nullable<int> puntaje { get; set; }
    }
}
