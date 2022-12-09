using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;
using TutoriasWcf.App_Data;

namespace TutoriasWcf
{
    public class TutoriasService : ITutoriasService
    {

        public bool CambiarEstadoTurno(string asunto, int estado)
        {
            Turno turno = new Turno();
            bool resultado;
            TutoriasDBEntities entities = new TutoriasDBEntities();
            try
            {
                turno = entities.Turnoes.FirstOrDefault(t => t.asunto == asunto);
                if (turno != null)
                {
                    turno.estadoTurno = estado;
                    entities.SaveChanges();
                    resultado = true;
                }
                else
                {
                    resultado = false;
                }
            }
            catch (Exception)
            {
                resultado = false;
            }
            return resultado;
        }

        public Estudiante ConsultarEstudiante(string matricula)
        {
            Estudiante estudiante = new Estudiante();
            TutoriasDBEntities entities = new TutoriasDBEntities();
            try
            {
                estudiante = entities.Estudiantes.Single(e => e.matricula == matricula);
            }
            catch (Exception)
            {
                estudiante = null;
            }
            return estudiante;
        }

        public Horario ConsultarHorario(int idTutor)
        {
            Horario horario = new Horario();
            TutoriasDBEntities entities = new TutoriasDBEntities();
            try
            {
                horario = entities.Horarios.Single(h => h.idTutor == idTutor);
            }
            catch(Exception)
            {
                horario = null;
            }
            return horario;
        }

        public List<Tutor> ConsultarListaTutores()
        {
            List<Tutor> tutores;
            TutoriasDBEntities entities = new TutoriasDBEntities();
            try
            {
                tutores = entities.Tutors.ToList();
            }
            catch (Exception)
            {
                tutores = null;
            }
            return tutores;
        }

        public Turno ConsultarTurno(string matricula)
        {
            Turno turno = new Turno();
            List<Turno> turnoList = new List<Turno>();
            TutoriasDBEntities entities = new TutoriasDBEntities();
            try
            {
                turnoList = entities.Turnoes.Where(t => t.matriculaEstudiante == matricula).ToList();
                if(turnoList.Count > 0)
                {
                    for(int i = 0; i < turnoList.Count; i++)
                    {
                        if(turnoList[i].estadoTurno == 0)
                        {
                            turno = turnoList[i];
                        }
                    }
                }
            }
            catch (Exception)
            {
                turno = null;
            }
            return turno;
        }

        public Tutor ConsultarTutor(string correo)
        {
            Tutor tutor = new Tutor();
            TutoriasDBEntities entities = new TutoriasDBEntities();
            try
            {
                tutor = entities.Tutors.Single(t => t.correo == correo);
            }
            catch (Exception)
            {
                tutor = null;
            }
            return tutor;
        }

        public bool IniciarSesion(string matricula, string contrasena)
        {
            bool resultado;
            TutoriasDBEntities entities = new TutoriasDBEntities();
            try
            {
                var estudiante = from estudianteAUX in entities.Estudiantes
                                        where estudianteAUX.matricula == matricula && estudianteAUX.contrasena == contrasena
                                        select estudianteAUX;
                if (estudiante != null)
                {
                    resultado = true;
                }
                else
                {
                    resultado = false;
                }
            }
            catch (Exception)
            {
                resultado = false;
            }
            return resultado;
        }

        public bool RegistrarEstudiante(Estudiante estudiante)
        {
            bool resultado;
            TutoriasDBEntities entities = new TutoriasDBEntities();
            try
            {
                entities.Estudiantes.Add(estudiante);
                entities.SaveChanges();
                resultado = true;
            }
            catch (Exception)
            {
                resultado = false;
            }
            return resultado;
        }

        public bool RegistrarTurno(Turno turno)
        {
            bool resultado;
            TutoriasDBEntities entities = new TutoriasDBEntities();
            try
            {
                entities.Turnoes.Add(turno);
                entities.SaveChanges();
                resultado = true;
            }
            catch (Exception)
            {
                resultado = false;
            }
            return resultado;
        }

        public bool RegristrarPuntaje(string asunto, int puntaje)
        {
            Turno turno = new Turno();
            bool resultado;
            TutoriasDBEntities entities = new TutoriasDBEntities();
            try
            {
                turno = entities.Turnoes.FirstOrDefault(t => t.asunto == asunto);
                if (turno != null)
                {
                    turno.puntaje = puntaje;
                    entities.SaveChanges();
                    resultado = true;
                }
                else
                {
                    resultado = false;
                }
            }
            catch (Exception)
            {
                resultado = false;
            }
            return resultado;
        }
    }
}
