using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;

namespace almerimatik.ServicioCRM
{
    [ServiceContract]
    public interface ISrvDatos
    {
        [OperationContract]
        List<UserData> GetAllUsers();
        
    }
    [DataContract]
    public class UserData
    {
        [DataMember]
        public int IDUsuario { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}