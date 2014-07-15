using ServicioCRM.Models;
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

        /// <summary>
        /// Operacion del servicio que devuelve una lista con los contactos de una empresa
        /// </summary>
        /// <param name="idEmpresa">identificador de la empresa en la que queremos buscar</param>
        /// <returns>listado de contactos</returns>
        [OperationContract]
        List<ContactoData> GetAllContactos(int idEmpresa);

        /// <summary>
        /// Operacion del servicio que devuelve una lista con los cargos que existen
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<CargoData> GetAllCargos();

        /// <summary>
        /// Operacion del servicio que devuelve los datos de la empresa que se solicita
        /// </summary>
        /// <param name="idEmpresa">identificador de la empresa</param>
        /// <returns>datos de la empresa en concreto</returns>
        [OperationContract]
        EmpresaData GetEmpresa(int idEmpresa);


        /// <summary>
        /// Operacion del servicio que guarda una empresa al editarla
        /// </summary>
        /// <param name="empresa">datos de la empresa</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        [OperationContract]
        bool EditEmpresa(EmpresaData empresa);

        /// <summary>
        /// Operacion del servicio que guarda los datos de una empresa nueva
        /// </summary>
        /// <param name="empresa">datos de la empresa</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        [OperationContract]
        bool AddEmpresa(EmpresaData empresa);

        /// <summary>
        /// Operacion del Servicio que Borra una empresa segun su identificador
        /// </summary>
        /// <param name="idEmpresa">identificador de la empresa a borrar</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        [OperationContract]
        bool BorrarEmpresa(int idEmpresa);

        /// <summary>
        /// Operacion del servicio que añade un tipo de empresa a la BD
        /// </summary>
        /// <param name="tipo">nombre con el tipo nuevo</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        [OperationContract]
        bool AddTipoEmpresa(String tipo);

        /// <summary>
        /// Operacion del servicio que borra un tipo de empresa de la BD
        /// </summary>
        /// <param name="idTipo">identificador del tipo de empresa a borrar</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        [OperationContract]
        bool BorrarTipoEmpresa(int idTipo);


        /// <summary>
        /// Operacion del servicio que añade un tipo de accion a la BD
        /// </summary>
        /// <param name="tipo">nombre con el tipo nuevo</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        [OperationContract]
        bool AddTipoAccion(String tipo);


        /// <summary>
        /// Operacion del servicio que borra un tipo de Accion de la BD
        /// </summary>
        /// <param name="idTipo">identificador del tipo de Accion a borrar</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        [OperationContract]
        bool BorrarTipoAccion(int idTipo);


        /// <summary>
        /// Operacion del servicio que añade un telefono a una empresa
        /// </summary>
        /// <param name="telefono">nombre con el telefono nuevo y el identificador de la empresa</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        [OperationContract]
        bool AddTelefonoEmpresa(TelefonosData telefono);


        /// <summary>
        ///Operacion del servicio que borra un telefono de una empresa
        /// </summary>
        /// <param name="telefono">identificador del telefono a borrar</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        [OperationContract]
        bool BorrarTelefonoEmpresa(String telefono);


        /// <summary>
        /// Operacion del servicio que añade un telefono a un contacto
        /// </summary>
        /// <param name="telefono">nombre con el telefono nuevo y el identificador del contacto</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        [OperationContract]
        bool AddTelefonoContacto(TelefonosData telefono);


        /// <summary>
        ///Operacion del servicio que borra un telefono de un contacto
        /// </summary>
        /// <param name="telefono">identificador del telefono a borrar</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        [OperationContract]
        bool BorrarTelefonoContacto(String telefono);




    }







    /****************************************************************************
    //TIPOS DE DATOS
    ****************************************************************************/




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
        public int IDTipoEmpresa { get; set; }
        [DataMember]
        public string TipoEmpresa { get; set; }
        /// <summary>
        /// Este telefono es el primero de la lista de telefonos de la empresa. Será el que salga por defecto.
        /// </summary>
        [DataMember]
        public string Telefono { get; set; }
        
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
    /// datos que definen un listado de telefonos
    /// </summary>
    [DataContract]
    public class TelefonosData
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Telefono { get; set; }
    }


    /// <summary>
    /// datos que definen un contacto
    /// </summary>
    [DataContract]
    public class ContactoData
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int IDEmpresa { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Email { get; set; }
        /// <summary>
        /// Este telefono es el primero de la lista de telefonos del contacto. Será el que salga por defecto.
        /// </summary>
        [DataMember]
        public string Telefono { get; set; }
    }


    /// <summary>
    /// datos que definen un cargo
    /// </summary>
    [DataContract]
    public class CargoData
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Cargo { get; set; }
        
    }


}