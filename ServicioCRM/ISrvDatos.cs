using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;

namespace almerimatik.ServicioCRM
{
    public class ISrvDatos
    {
        [ServiceContract]
        public interface ISrvDatos
        {
            [OperationContract]
            List<LibroData> GetAllLibros();
            [OperationContract]
            bool GuardarLibro(LibroData libro);
        }
        [DataContract]
        public class LibroData
        {
            [DataMember]
            public string isbn;
            [DataMember]
            public string titulo;
            [DataMember]
            public string Tema;
            [DataMember]
            public string portada;
        }
    }
}