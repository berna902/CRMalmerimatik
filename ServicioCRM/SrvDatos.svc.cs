using ServicioCRM;
using System;
using System.Collections.Generic;
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
        public List<UserData> GetAllUsers()
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
                                        Username = tabla.Username,
                                        Password = tabla.Password

                                   };
                    lst = consulta.ToList();
                    return lst;        
                }
            }
            catch(Exception ex)
            {
                throw new FaultException("ERROR EN ACCESO A DATOS. " + ex.Message);
            }           
        }

        /// <summary>
        /// metodo que devuelve los datos de las empresas en forma de lista
        /// </summary>
        /// <returns></returns>
        public List<EmpresaData> GetAllEmpresas()
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
                                       TipoEmpresa = tabla.TipoEmpresa

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
        public List<AccionComercialData> GetAllAccionesComerciales()
        {
            List<AccionComercialData> lst = new List<AccionComercialData>();
            try
            {
                using (BDCRMEntities datos = new BDCRMEntities())
                {
                    var consulta = from tabla in datos.AccionComercial
                                   select new AccionComercialData()
                                   {
                                       ID  = tabla.ID,
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
        public List<TipoEmpresaData> GetAllTiposEmpresa()
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
        public List<TipoAccionData> GetAllTiposAccion()
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
        public List<TelefonosData> GetAllTelefonosEmpresa(int id)
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
        public List<TelefonosData> GetAllTelefonosContacto(int id)
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

    }
}
