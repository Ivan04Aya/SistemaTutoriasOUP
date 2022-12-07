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
        Boolean registrarEstudiante(Estudiante estudiante);
    }
}
