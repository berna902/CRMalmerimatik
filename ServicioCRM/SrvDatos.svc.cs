﻿using ServicioCRM;
using ServicioCRM.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace almerimatik.ServicioCRM
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class SrvDatos : ISrvDatos
    {
        /// <summary>
        /// metodo que devuelve los datos de los usuarios en forma de lista
        /// </summary>
        /// <returns></returns>
        public static List<UserData> GetAllUsers()
        {
            List<UserData> lst = new List<UserData>();
            try
            {
                using (BDCRMEntities datos = new BDCRMEntities())
                {
                    var consulta = from tabla in datos.User
                                   select new UserData()
                                   {
                                       IDUsuario = tabla.IDUsuario,
                                       Nombre = tabla.Nombre,
                                       Username = tabla.Username
                                       

                                   };
                    lst = consulta.ToList();
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw new FaultException("ERROR EN ACCESO A DATOS. " + ex.Message);
            }
        }

        /// <summary>
        /// metodo que devuelve los datos de las empresas en forma de lista
        /// </summary>
        /// <returns></returns>
        public static List<EmpresaData> GetAllEmpresas()
        {
            List<EmpresaData> lst = new List<EmpresaData>();
            try
            {
                using (BDCRMEntities datos = new BDCRMEntities())
                {
                    var consulta = from tabla in datos.Empresa
                                   select new EmpresaData()
                                   {
                                       ID = tabla.ID,
                                       CIF = tabla.CIF,
                                       RazonSocial = tabla.RazonSocial,
                                       Nombre = tabla.Nombre,
                                       Email = tabla.Email,
                                       Web = tabla.Web,
                                       IDTipoEmpresa = tabla.TipoEmpresa,
                                       TipoEmpresa = tabla.TipoEmpresa1.Tipo

                                   };
                    lst = consulta.ToList();
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw new FaultException("ERROR EN ACCESO A DATOS. " + ex.Message);
            }
        }


        /// <summary>
        /// metodo que devuelve los datos de las acciones comerciales en forma de lista
        /// </summary>
        /// <returns></returns>
        public static List<AccionComercialData> GetAllAccionesComerciales()
        {
            List<AccionComercialData> lst = new List<AccionComercialData>();
            try
            {
                using (BDCRMEntities datos = new BDCRMEntities())
                {
                    var consulta = from tabla in datos.AccionComercial
                                   select new AccionComercialData()
                                   {
                                       ID = tabla.ID,
                                       Usuario = tabla.Usuario,
                                       IDEmpresa = tabla.IDEmpresa,
                                       Fecha = tabla.Fecha,
                                       Descripcion = tabla.Descripcion,
                                       Comentarios = tabla.Comentarios,
                                       IDAccion = tabla.IDAccion,
                                       IDEstado = tabla.IDEstado

                                   };
                    lst = consulta.ToList();
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw new FaultException("ERROR EN ACCESO A DATOS. " + ex.Message);
            }
        }


        /// <summary>
        /// metodo que devuelve los posibles tipos que tendrá una emrpesa
        /// </summary>
        /// <returns></returns>
        public static List<TipoEmpresaData> GetAllTiposEmpresa()
        {
            List<TipoEmpresaData> lst = new List<TipoEmpresaData>();
            try
            {
                using (BDCRMEntities datos = new BDCRMEntities())
                {
                    var consulta = from tabla in datos.TipoEmpresa
                                   select new TipoEmpresaData()
                                   {
                                       ID = tabla.ID,
                                       Tipo = tabla.Tipo

                                   };
                    lst = consulta.ToList();
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw new FaultException("ERROR EN ACCESO A DATOS. " + ex.Message);
            }
        }

        /// <summary>
        /// metodo que devolvera con tipos de acciones comerciales que se pueden realizar
        /// </summary>
        /// <returns></returns>
        public static List<TipoAccionData> GetAllTiposAccion()
        {
            List<TipoAccionData> lst = new List<TipoAccionData>();
            try
            {
                using (BDCRMEntities datos = new BDCRMEntities())
                {
                    var consulta = from tabla in datos.TipoAccion
                                   select new TipoAccionData()
                                   {
                                       ID = tabla.ID,
                                       Tipo = tabla.Tipo

                                   };
                    lst = consulta.ToList();
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw new FaultException("ERROR EN ACCESO A DATOS. " + ex.Message);
            }
        }


        /// <summary>
        /// metodo que devuelve una lista de telefonos que pertenecen a una empresa concreta
        /// </summary>
        /// <param name="id">identificador de la empresa</param>
        /// <returns></returns>
        public static List<TelefonosData> GetAllTelefonosEmpresa(int id)
        {
            List<TelefonosData> lst = new List<TelefonosData>();
            try
            {
                using (BDCRMEntities datos = new BDCRMEntities())
                {
                    var consulta = from tabla in datos.TelefonoEmpresa
                                   where tabla.IDEmpresa == id
                                   select new TelefonosData()
                                   {
                                       ID = tabla.IDEmpresa,
                                       Telefono = tabla.Telefono

                                   };
                    lst = consulta.ToList();

                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw new FaultException("ERROR EN ACCESO A DATOS. " + ex.Message);
            }
        }

        /// <summary>
        /// metodo que devuelve una lista de telefonos que pertenecen a un contacto concreto
        /// </summary>
        /// <param name="id">identificador del contacto</param>
        /// <returns></returns>
        public static List<TelefonosData> GetAllTelefonosContacto(int id)
        {
            List<TelefonosData> lst = new List<TelefonosData>();
            try
            {
                using (BDCRMEntities datos = new BDCRMEntities())
                {
                    var consulta = from tabla in datos.TelefonoContacto
                                   where tabla.IDContacto == id
                                   select new TelefonosData()
                                   {
                                       ID = tabla.IDContacto,
                                       Telefono = tabla.Telefono

                                   };
                    lst = consulta.ToList();

                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw new FaultException("ERROR EN ACCESO A DATOS. " + ex.Message);
            }
        }


        /// <summary>
        /// metodo que devuelve una lista de contactos que pertenecen a una empresa
        /// </summary>
        /// <param name="idEmpresa">identificador de la empresa</param>
        /// <returns></returns>
        public static List<ContactoData> GetAllContactos(int idEmpresa)
        {
            List<ContactoData> lst = new List<ContactoData>();
            try
            {
                using (BDCRMEntities datos = new BDCRMEntities())
                {
                    var consulta = from tabla in datos.Contacto
                                   where tabla.IDEmpresa == idEmpresa
                                   select new ContactoData()
                                   {
                                       ID = tabla.ID,
                                       IDEmpresa = tabla.IDEmpresa,
                                       Nombre = tabla.Nombre,
                                       Email = tabla.Email

                                   };
                    lst = consulta.ToList();

                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw new FaultException("ERROR EN ACCESO A DATOS. " + ex.Message);
            }
        }


        /// <summary>
        /// metodo que devolvera los cargos que los contactos pueden tener
        /// </summary>
        /// <returns></returns>
        public static List<CargoData> GetAllCargos()
        {
            List<CargoData> lst = new List<CargoData>();
            try
            {
                using (BDCRMEntities datos = new BDCRMEntities())
                {
                    var consulta = from tabla in datos.Cargo
                                   select new CargoData()
                                   {
                                       ID = tabla.ID,
                                       Cargo = tabla.Carg

                                   };
                    lst = consulta.ToList();
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw new FaultException("ERROR EN ACCESO A DATOS. " + ex.Message);
            }
        }


        /// <summary>
        /// metodo que guardara una empresa en la BD. Devolvera verdadero o falso
        /// </summary>
        /// <param name="empresa">datos de la empresa nueva</param>
        /// <returns></returns>
        public static bool AddEmpresa(EmpresaData empresa)
        {
            try
            {
                using (BDCRMEntities db = new BDCRMEntities())
                {
                    if (empresa != null)
                    {
                        Empresas nuevo = new Empresas();


                        nuevo.Nombre = empresa.Nombre;
                        nuevo.RazonSocial = empresa.RazonSocial;
                        nuevo.CIF = empresa.CIF;
                        nuevo.Email = empresa.Email;
                        nuevo.Web = empresa.Web;
                        nuevo.TipoEmpresa = empresa.IDTipoEmpresa;

                        db.Empresa.Add(nuevo);
                        db.SaveChanges();
                        return true;

                    }
                    else
                    {
                        return false;
                    }

                    
                }

            }
            catch (SqlException ex)
            {
                FaultException fault = new FaultException("Error SQL: " + ex.Message, new FaultCode("SQL"));
                return false;

            }
            catch (Exception ex)
            {
                FaultException fault = new FaultException("Error: " + ex.Message, new FaultCode("GENERAL"));
                return false;
            }
        }


        /// <summary>
        /// metodo que guardara los cambios al editar una empresa
        /// </summary>
        /// <param name="empresa">datos de la empresa a editar</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        public static bool EditEmpresa(EmpresaData empresa)
        {
            try
            {
                if (empresa != null)
                {
                    using (BDCRMEntities db = new BDCRMEntities())
                    {
                        var consulta = from tabla in db.Empresa where tabla.ID == empresa.ID select tabla;

                        Empresas nuevo = (Empresas)consulta.First();

                        nuevo.Nombre = empresa.Nombre;
                        nuevo.Web = empresa.Web;
                        nuevo.RazonSocial = empresa.RazonSocial;
                        nuevo.Email = empresa.Email;
                        nuevo.CIF = empresa.CIF;
                        nuevo.TipoEmpresa = empresa.IDTipoEmpresa;


                        db.SaveChanges();
                        return true;
                    }
                }
                else
                {
                    return false;
                }


            }
            catch (SqlException ex)
            {
                FaultException fault = new FaultException("Error SQL: " + ex.Message, new FaultCode("SQL"));
                return false;

            }
            catch (Exception ex)
            {
                FaultException fault = new FaultException("Error: " + ex.Message, new FaultCode("GENERAL"));
                return false;
            }
        }


        /// <summary>
        /// metodo que devuelve los datos de una empresa
        /// </summary>
        /// <param name="idEmpresa">identificador de esa empresa</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        public static EmpresaData GetEmpresa(int idEmpresa)
        {
            List<EmpresaData> lst = new List<EmpresaData>();
            try
            {
                using (BDCRMEntities datos = new BDCRMEntities())
                {
                    var consulta = from tabla in datos.Empresa where tabla.ID == idEmpresa
                                   select new EmpresaData()
                                   {
                                       ID = tabla.ID,
                                       CIF = tabla.CIF,
                                       RazonSocial = tabla.RazonSocial,
                                       Nombre = tabla.Nombre,
                                       Email = tabla.Email,
                                       Web = tabla.Web,
                                       IDTipoEmpresa = tabla.TipoEmpresa,
                                       TipoEmpresa = tabla.TipoEmpresa1.Tipo,
                                       

                                   };
                    lst = consulta.ToList();
                    return lst.First();
                }
            }
            catch (Exception ex)
            {
                throw new FaultException("ERROR EN ACCESO A DATOS. " + ex.Message);
            }
        }


        /// <summary>
        /// metodo que borra una empresa de la BD
        /// </summary>
        /// <param name="idEmpresa">identificador de la empresa a borrar</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        public static bool BorrarEmpresa(int idEmpresa)
        {
            try
            {
                using (BDCRMEntities db = new BDCRMEntities())
                {
                    var consulta = from tabla in db.Empresa where tabla.ID == idEmpresa select tabla;
                    Empresas emp = (Empresas)consulta.First();

                    db.Empresa.Remove(emp);
                    db.SaveChanges();
                    return true;


                }
            }
            catch (SqlException ex)
            {
                FaultException fault = new FaultException("Error SQL: " + ex.Message, new FaultCode("SQL"));
                return false;

            }
            catch (Exception ex)
            {
                FaultException fault = new FaultException("Error: " + ex.Message, new FaultCode("GENERAL"));
                return false;
            }
        }


        /// <summary>
        /// metodo que añade un tipo de empresa a la BD
        /// </summary>
        /// <param name="tipo">nombre con el tipo nuevo</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        public static bool AddTipoEmpresa(String tipo)
        {
            try
            {
                if (tipo != "" && tipo != null)
                {

                    using (BDCRMEntities db = new BDCRMEntities())
                    {
                        TipoEmpresas nuevo = new TipoEmpresas();


                        nuevo.Tipo = tipo;

                        db.TipoEmpresa.Add(nuevo);
                        db.SaveChanges();
                        return true;
                    }

                }
                else
                {
                    return false;
                }
                

            }
            catch (SqlException ex)
            {
                FaultException fault = new FaultException("Error SQL: " + ex.Message, new FaultCode("SQL"));
                return false;

            }
            catch (Exception ex)
            {
                FaultException fault = new FaultException("Error: " + ex.Message, new FaultCode("GENERAL"));
                return false;
            }
        }



        /// <summary>
        /// metodo que borra un tipo de empresa de la BD
        /// </summary>
        /// <param name="idTipo">identificador del tipo de empresa a borrar</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        public static bool BorrarTipoEmpresa(int idTipo)
        {
            try
            {
                using (BDCRMEntities db = new BDCRMEntities())
                {
                    var consulta = from tabla in db.TipoEmpresa where tabla.ID == idTipo select tabla;
                    TipoEmpresas borrar = (TipoEmpresas)consulta.First();

                    db.TipoEmpresa.Remove(borrar);
                    db.SaveChanges();
                    return true;


                }
            }
            catch (SqlException ex)
            {
                FaultException fault = new FaultException("Error SQL: " + ex.Message, new FaultCode("SQL"));
                return false;

            }
            catch (Exception ex)
            {
                FaultException fault = new FaultException("Error: " + ex.Message, new FaultCode("GENERAL"));
                return false;
            }
        }

        
        /// <summary>
        /// metodo que añade un tipo de accion a la BD
        /// </summary>
        /// <param name="tipo">nombre con el tipo nuevo</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        public static bool AddTipoAccion(String tipo)
        {
            try
            {
                if (tipo != "" && tipo != null)
                {
                    using (BDCRMEntities db = new BDCRMEntities())
                    {
                        TipoAcciones nuevo = new TipoAcciones();


                        nuevo.Tipo = tipo;

                        db.TipoAccion.Add(nuevo);
                        db.SaveChanges();
                        return true;
                    }
                }
                else
                {
                    return false;
                }

                

            }
            catch (SqlException ex)
            {
                FaultException fault = new FaultException("Error SQL: " + ex.Message, new FaultCode("SQL"));
                return false;

            }
            catch (Exception ex)
            {
                FaultException fault = new FaultException("Error: " + ex.Message, new FaultCode("GENERAL"));
                return false;
            }
        }


        /// <summary>
        /// metodo que borra un tipo de Accion de la BD
        /// </summary>
        /// <param name="idTipo">identificador del tipo de Accion a borrar</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        public static bool BorrarTipoAccion(int idTipo)
        {
            try
            {
                using (BDCRMEntities db = new BDCRMEntities())
                {
                    var consulta = from tabla in db.TipoAccion where tabla.ID == idTipo select tabla;
                    TipoAcciones borrar = (TipoAcciones)consulta.First();

                    db.TipoAccion.Remove(borrar);
                    db.SaveChanges();
                    return true;


                }
            }
            catch (SqlException ex)
            {
                FaultException fault = new FaultException("Error SQL: " + ex.Message, new FaultCode("SQL"));
                return false;

            }
            catch (Exception ex)
            {
                FaultException fault = new FaultException("Error: " + ex.Message, new FaultCode("GENERAL"));
                return false;
            }
        }





    }
}
