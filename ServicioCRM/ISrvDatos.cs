﻿using ServicioCRM.Models;
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
        List<ContactoData> GetAllContactosEmpresa(int idEmpresa);

        /// <summary>
        /// Operacion del servicio que devuelve una lista con los cargos que existen
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<CargoData> GetAllCargos();

        /// <summary>
        /// Operacion del servicio que devolvera los cargos de un contacto
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<CargoData> GetAllCargosContacto(int contacto);

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
        /// <returns>devuelve el id de la nueva empresa o -1 si es error</returns>
        [OperationContract]
        int AddEmpresa(EmpresaData empresa);

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
        int AddTipoEmpresa(String tipo);

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
        int AddTipoAccion(String tipo);


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



        /// <summary>
        /// Operacion del servicio que inserta un usuario nuevo en la BD
        /// </summary>
        /// <param name="user">datos del usuario</param>
        /// <returns>devuelve el identificador del usuario nuevo o -1 si no se ha insertado</returns>
        [OperationContract]
        int AddUser(UserData user);


        /// <summary>
        /// Operacion del servicio que borra un usuario dado su identificador
        /// </summary>
        /// <param name="idUsuario">identificador del usuario</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        [OperationContract]
        bool BorrarUser(int idUsuario);


        /// <summary>
        /// Operacion del servicio que edita un usuario existente
        /// </summary>
        /// <param name="user">datos del usuario</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        [OperationContract]
        bool EditUser(UserData user);


        /// <summary>
        /// Operacion del servicio que devuelve los datos de un usuario especifico
        /// </summary>
        /// <param name="idUsuario">identificador del usuario a buscar</param>
        /// <returns>devuelve los datos del usuario</returns>
        [OperationContract]
        UserData GetUser(int idUsuario);


        /// <summary>
        /// Operacion del servicio que devuelve los datos de un contacto especifico
        /// </summary>
        /// <param name="idContacto">identificador del contacto</param>
        /// <returns>devuelve los datos del contacto</returns>
        [OperationContract]
        ContactoData GetContacto(int idContacto);

        /// <summary>
        /// metodo que devuelve una lista de todos contactos
        /// </summary>
        /// <returns>listado con todos los contactos</returns>
        [OperationContract]
        List<ContactoData> GetAllContactos();


        /// <summary>
        /// Operacion del servicio que añade un contacto a una empresa
        /// </summary>
        /// <param name="contacto">datos del contacto a añadir</param>
        /// <returns>devuelve el identificador del nuevo contacto o -1 si hubo algun error</returns>
        [OperationContract]
        int AddContacto(ContactoData contacto);


        /// <summary>
        /// Operacion del servicio que borra un contacto de una empresa
        /// </summary>
        /// <param name="idContacto">identificador del contacto</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        [OperationContract]
        bool BorrarContacto(int idContacto);


        /// <summary>
        /// Operacion del servicio que edita un contacto existente
        /// </summary>
        /// <param name="contacto">datos del contacto</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        [OperationContract]
        bool EditContacto(ContactoData contacto);



        /// <summary>
        /// Operacion del servicio que devuelve los datos de una accion comercial
        /// </summary>
        /// <param name="idAccionComercial">identificador de dicha accion</param>
        /// <returns>los datos de la accion</returns>
        [OperationContract]
        AccionComercialData GetAccionComercial(int idAccionComercial);


        /// <summary>
        /// Operacion del servicio que añade una accion comercial a una empresa y un usuario
        /// </summary>
        /// <param name="contacto">datos de la accion a añadir</param>
        /// <returns>devuelve el identificador de la nueva accion o -1 si hubo algun error</returns>
        [OperationContract]
        int AddAccionComercial(AccionComercialData accion);


        /// <summary>
        /// Operacion del servicio que borra una accion comercial de una empresa y un usuario
        /// </summary>
        /// <param name="idContacto">identificador de la accion</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        [OperationContract]
        bool BorrarAccionComercial(int idaccion);


        /// <summary>
        /// Operacion del servicio que edita una accion comercial existente
        /// </summary>
        /// <param name="contacto">datos de la accion</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        [OperationContract]
        bool EditAccionComercial(AccionComercialData accion);

        /// <summary>
        /// Operacion del servicio que devuelve una lista con todas las acciones comerciales
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<AccionComercialData> GetAllAccionesComercialesEmpresa(int idEmpresa);

        /// <summary>
        /// Operacion del servicio que devuelve una lista con todas las acciones comerciales
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<AccionComercialData> GetAllAccionesComercialesUsuario(int idUsuario);



        /// <summary>
        /// Operacion del servicio que devuelve la lista de todos los estados
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<EstadoData> GetAllEstados();


        /// <summary>
        ///  Operacion del servicio que añade un estado a la BD
        /// </summary>
        /// <param name="estado">nombre con el estado nuevo</param>
        /// <returns>id del estado nuevo</returns>
        [OperationContract]
        int AddEstado(String estado);


        /// <summary>
        ///  Operacion del servicio que borra un estado de la BD
        /// </summary>
        /// <param name="idEstado">identificador del estado a borrar</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        [OperationContract]
        bool BorrarEstado(int idEstado);



        /// <summary>
        /// Operacion del servicio que añade nu cargo a la BD
        /// </summary>
        /// <param name="cargo">cargo a insertar</param>
        /// <returns>identificador del cargo nuevo</returns>
        [OperationContract]
        int AddCargo(string cargo);



        /// <summary>
        /// Operacion del servicio que borra un cargo especifico
        /// </summary>
        /// <param name="idCargo">identificador del cargo</param>
        /// <returns>verdadero o falso segun si realiza la operacion o no</returns>
        [OperationContract]
        bool BorrarCargo(int idCargo);



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
        [DataMember]
        public string Estado { get; set; }
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
        /// Este cargo es el primero de la lista de cargos del contacto.
        /// </summary>
        [DataMember]
        public string Cargo { get; set; }
        [DataMember]
        public int IDCargo { get; set; }
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


    /// <summary>
    /// datos que definen un estado
    /// </summary>
    [DataContract]
    public class EstadoData
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Estado { get; set; }
    }



    [DataContract]
    public class DireccionData
    {

    }


}