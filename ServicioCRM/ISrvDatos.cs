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
        /// <summary>
        /// Operacion del servicio que deuvelve una lista con todos los usuarios
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<UserData> GetAllUsers();

        /// <summary>
        /// Operacion del servicio que devuelve una lista con todas las empresas
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<EmpresaData> GetAllEmpresas();

        /// <summary>
        /// Operacion del servicio que devuelve una lista con todas las acciones comerciales
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<AccionComercialData> GetAllAccionesComerciales();

        /// <summary>
        /// Operacion del servicio que devuelve una lista con los tipos de empresas
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<TipoEmpresaData> GetAllTiposEmpresa();

        /// <summary>
        /// Operacion del servicio que devuelve una lista con los telefonos de la empresa concreta
        /// </summary>
        /// <param name="id">identificador de la empresa</param>
        /// <returns>lista con telefonos</returns>
        [OperationContract]
        List<TelefonosData> GetAllTelefonosEmpresa(int id);

        /// <summary>
        /// Operacion del servicio que devuelve una lista con los telefonos del contacto concreto
        /// </summary>
        /// <param name="id">identificador del contacto</param>
        /// <returns>lista con telefonos</returns>
        [OperationContract]
        List<TelefonosData> GetAllTelefonosContacto(int id);


        /// <summary>
        /// Operacion del servicio que devuelve una lista con los tipos de acciones comerciales
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<TipoAccionData> GetAllTiposAccion();
        
    }

    /// <summary>
    /// Datos que definen un usuario
    /// </summary>
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

    /// <summary>
    /// Datos que definen una empresa
    /// </summary>
    [DataContract]
    public class EmpresaData
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string CIF { get; set; }
        [DataMember]
        public string RazonSocial { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Web { get; set; }
        [DataMember]
        public int TipoEmpresa { get; set; }
    }


    /// <summary>
    /// Datos que definen una accion comercial
    /// </summary>
    [DataContract]
    public class AccionComercialData
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int Usuario { get; set; }
        [DataMember]
        public int IDEmpresa { get; set; }
        [DataMember]
        public System.DateTime Fecha { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string Comentarios { get; set; }
        [DataMember]
        public int IDAccion { get; set; }
        [DataMember]
        public int IDEstado { get; set; }
    }

    /// <summary>
    /// datos que definen el tipo de empresa
    /// </summary>
    [DataContract]
    public class TipoEmpresaData
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Tipo { get; set; }
    }

    /// <summary>
    /// datos que definen el tipo de accion comercial
    /// </summary>
    [DataContract]
    public class TipoAccionData
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Tipo { get; set; }
    }

    /// <summary>
    /// datos que defienen un listado de telefonos
    /// </summary>
    [DataContract]
    public class TelefonosData
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Telefono { get; set; }
    }
}