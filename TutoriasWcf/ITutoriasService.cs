using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TutoriasWcf.App_Data;

namespace TutoriasWcf
{
    
    [ServiceContract]
    public interface ITutoriasService
    {

        [OperationContract]
        Boolean RegistrarEstudiante(Estudiante estudiante);

        [OperationContract]
        Boolean IniciarSesion(string matricula, string contraseña);

        [OperationContract]
        Boolean RegistrarTurno(Turno turno);

        [OperationContract]
        Boolean CambiarEstadoTurno(string asunto, int estado);

        [OperationContract]
        Estudiante ConsultarEstudiante(string matricula);

        [OperationContract]
        Turno ConsultarTurno(string matricula);

        [OperationContract]
        List<Tutor> ConsultarListaTutores();

        [OperationContract]
        Horario ConsultarHorario(int idTutor);

        [OperationContract]
        Tutor ConsultarTutor(string correo);

        [OperationContract]
        Boolean RegristrarPuntaje(string asunto, int puntaje);
    }
}