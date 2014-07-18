using ServicioCRM;
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


        /// <summary>
        /// metodo que devuelve una lista de contactos que pertenecen a una empresa
        /// </summary>
        /// <param name="idEmpresa">identificador de la empresa</param>
        /// <returns></returns>
        public List<ContactoData> GetAllContactos(int idEmpresa)
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
        public List<CargoData> GetAllCargos()
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
        public int AddEmpresa(EmpresaData empresa)
        {
            try
            {
                using (BDCRMEntities db = new BDCRMEntities())
                {
                    if (empresa != null)
                    {
                        Empresa nuevo = new Empresa();


                        nuevo.Nombre = empresa.Nombre;
                        nuevo.RazonSocial = empresa.RazonSocial;
                        nuevo.CIF = empresa.CIF;
                        nuevo.Email = empresa.Email;
                        nuevo.Web = empresa.Web;
                        nuevo.TipoEmpresa = empresa.IDTipoEmpresa;

                        db.Empresa.Add(nuevo);
                        db.SaveChanges();
                        return nuevo.ID;

                    }
                    else
                    {
                        return -1;
                    }

                    
                }

            }
            catch (SqlException ex)
            {
                FaultException fault = new FaultException("Error SQL: " + ex.Message, new FaultCode("SQL"));
                return -1;

            }
            catch (Exception ex)
            {
                FaultException fault = new FaultException("Error: " + ex.Message, new FaultCode("GENERAL"));
                return -1;
            }
        }


        /// <summary>
        /// metodo que guardara los cambios al editar una empresa
        /// </summary>
        /// <param name="empresa">datos de la empresa a editar</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        public bool EditEmpresa(EmpresaData empresa)
        {
            try
            {
                if (empresa != null)
                {
                    using (BDCRMEntities db = new BDCRMEntities())
                    {
                        var consulta = from tabla in db.Empresa where tabla.ID == empresa.ID select tabla;

                        Empresa nuevo = consulta.First();

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
        public EmpresaData GetEmpresa(int idEmpresa)
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
        public bool BorrarEmpresa(int idEmpresa)
        {
            try
            {
                using (BDCRMEntities db = new BDCRMEntities())
                {
                    var consulta = from tabla in db.Empresa where tabla.ID == idEmpresa select tabla;
                    Empresa emp = consulta.First();

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
        public int AddTipoEmpresa(String tipo)
        {
            try
            {
                if (tipo != "" && tipo != null)
                {

                    using (BDCRMEntities db = new BDCRMEntities())
                    {
                        TipoEmpresa nuevo = new TipoEmpresa();


                        nuevo.Tipo = tipo;

                        db.TipoEmpresa.Add(nuevo);
                        db.SaveChanges();
                        return nuevo.ID;
                    }

                }
                else
                {
                    return -1;
                }
                

            }
            catch (SqlException ex)
            {
                FaultException fault = new FaultException("Error SQL: " + ex.Message, new FaultCode("SQL"));
                return -1;

            }
            catch (Exception ex)
            {
                FaultException fault = new FaultException("Error: " + ex.Message, new FaultCode("GENERAL"));
                return -1;
            }
        }



        /// <summary>
        /// metodo que borra un tipo de empresa de la BD
        /// </summary>
        /// <param name="idTipo">identificador del tipo de empresa a borrar</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        public bool BorrarTipoEmpresa(int idTipo)
        {
            try
            {
                using (BDCRMEntities db = new BDCRMEntities())
                {
                    var consulta = from tabla in db.TipoEmpresa where tabla.ID == idTipo select tabla;
                    TipoEmpresa borrar = consulta.First();

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
        public int AddTipoAccion(String tipo)
        {
            try
            {
                if (tipo != "" && tipo != null)
                {
                    using (BDCRMEntities db = new BDCRMEntities())
                    {
                        TipoAccion nuevo = new TipoAccion();


                        nuevo.Tipo = tipo;

                        db.TipoAccion.Add(nuevo);
                        db.SaveChanges();
                        return nuevo.ID;
                    }
                }
                else
                {
                    return -1;
                }

                

            }
            catch (SqlException ex)
            {
                FaultException fault = new FaultException("Error SQL: " + ex.Message, new FaultCode("SQL"));
                return -1;

            }
            catch (Exception ex)
            {
                FaultException fault = new FaultException("Error: " + ex.Message, new FaultCode("GENERAL"));
                return -1;
            }
        }


        /// <summary>
        /// metodo que borra un tipo de Accion de la BD
        /// </summary>
        /// <param name="idTipo">identificador del tipo de Accion a borrar</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        public bool BorrarTipoAccion(int idTipo)
        {
            try
            {
                using (BDCRMEntities db = new BDCRMEntities())
                {
                    var consulta = from tabla in db.TipoAccion where tabla.ID == idTipo select tabla;
                    TipoAccion borrar = consulta.First();

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


        /// <summary>
        /// metodo que añade un telefono a una empresa
        /// </summary>
        /// <param name="telefono">nombre con el telefono nuevo yla empresa a la que pertenece</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        public bool AddTelefonoEmpresa(TelefonosData telefono)
        {
            try
            {
                if (telefono != null)
                {
                    using (BDCRMEntities db = new BDCRMEntities())
                    {
                        TelefonoEmpresa nuevo = new TelefonoEmpresa();


                        nuevo.IDEmpresa = telefono.ID;
                        nuevo.Telefono = telefono.Telefono;

                        db.TelefonoEmpresa.Add(nuevo);
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
        /// metodo que borra un telefono de una empresa
        /// </summary>
        /// <param name="telefono">identificador del telefono a borrar</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        public bool BorrarTelefonoEmpresa(String telefono)
        {
            try
            {
                using (BDCRMEntities db = new BDCRMEntities())
                {
                    var consulta = from tabla in db.TelefonoEmpresa where tabla.Telefono == telefono select tabla;
                    TelefonoEmpresa borrar = consulta.First();

                    db.TelefonoEmpresa.Remove(borrar);
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
        /// metodo que añade un telefono a un contacto
        /// </summary>
        /// <param name="telefono">nombre con el telefono nuevo y el contacto al que pertenece</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        public bool AddTelefonoContacto(TelefonosData telefono)
        {
            try
            {
                if (telefono != null)
                {
                    using (BDCRMEntities db = new BDCRMEntities())
                    {
                        TelefonoContacto nuevo = new TelefonoContacto();


                        nuevo.IDContacto = telefono.ID;
                        nuevo.Telefono = telefono.Telefono;

                        db.TelefonoContacto.Add(nuevo);
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
        /// metodo que borra un telefono de un contacto
        /// </summary>
        /// <param name="telefono">identificador del telefono a borrar</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        public bool BorrarTelefonoContacto(String telefono)
        {
            try
            {
                using (BDCRMEntities db = new BDCRMEntities())
                {
                    var consulta = from tabla in db.TelefonoContacto where tabla.Telefono == telefono select tabla;
                    TelefonoContacto borrar = consulta.First();

                    db.TelefonoContacto.Remove(borrar);
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
        /// metodo que inserta un usuario nuevo en la BD
        /// </summary>
        /// <param name="user">datos del usuario</param>
        /// <returns>devuelve el identificador del usuario nuevo o -1 si no se ha insertado</returns>
        public int AddUser(UserData user)
        {
            try
            {
                using (BDCRMEntities db = new BDCRMEntities())
                {
                    if (user != null)
                    {
                        User nuevo = new User();


                        nuevo.Nombre = user.Nombre;
                        nuevo.Username = user.Username;
                        nuevo.Password = user.Password;
                        

                        db.User.Add(nuevo);
                        db.SaveChanges();
                        return nuevo.IDUsuario;

                    }
                    else
                    {
                        return -1;
                    }


                }

            }
            catch (SqlException ex)
            {
                FaultException fault = new FaultException("Error SQL: " + ex.Message, new FaultCode("SQL"));
                return -1;

            }
            catch (Exception ex)
            {
                FaultException fault = new FaultException("Error: " + ex.Message, new FaultCode("GENERAL"));
                return -1;
            }
        }


        /// <summary>
        /// metodo que borra un usuario dado su identificador
        /// </summary>
        /// <param name="idUsuario">identificador del usuario</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        public bool BorrarUser(int idUsuario)
        {
            try
            {
                using (BDCRMEntities db = new BDCRMEntities())
                {
                    var consulta = from tabla in db.User where tabla.IDUsuario == idUsuario select tabla;
                    User emp = consulta.First();

                    db.User.Remove(emp);
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
        /// metodo que edita un usuario existente
        /// </summary>
        /// <param name="user">datos del usuario</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        public bool EditUser(UserData user)
        {
            try
            {
                if (user != null)
                {
                    using (BDCRMEntities db = new BDCRMEntities())
                    {
                        var consulta = from tabla in db.User where tabla.IDUsuario == user.IDUsuario select tabla;

                        User nuevo = consulta.First();

                        nuevo.Nombre = user.Nombre;
                        nuevo.Username = user.Username;
                        nuevo.Password = user.Password;
                        
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
        /// metodo que devuelve los datos de un usuario especifico
        /// </summary>
        /// <param name="idUsuario">identificador del usuario a buscar</param>
        /// <returns>devuelve los datos del usuario</returns>
        public UserData GetUser(int idUsuario)
        {
            List<UserData> lst = new List<UserData>();
            try
            {
                using (BDCRMEntities datos = new BDCRMEntities())
                {
                    var consulta = from tabla in datos.User where tabla.IDUsuario == idUsuario
                                   select new UserData()
                                   {
                                       IDUsuario = tabla.IDUsuario,
                                       Username = tabla.Username,
                                       Password = tabla.Password,
                                       Nombre = tabla.Nombre,
                                      
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
        /// metodo que devuelve los datos de un contacto especifico
        /// </summary>
        /// <param name="idContacto">identificador del contacto</param>
        /// <returns>devuelve los datos del contacto</returns>
        public ContactoData GetContacto(int idContacto)
        {
            List<ContactoData> lst = new List<ContactoData>();
            try
            {
                using (BDCRMEntities datos = new BDCRMEntities())
                {
                    var consulta = from tabla in datos.Contacto
                                   where tabla.ID == idContacto
                                   select new ContactoData()
                                   {
                                       ID = tabla.ID,
                                       IDEmpresa = tabla.IDEmpresa,
                                       Nombre = tabla.Nombre,
                                       Email = tabla.Email
                                       //telefono y cargo principales??

                                   };
                    lst = consulta.ToList();
                    ContactoData c = lst.First();

                    return c;
                }
            }
            catch (Exception ex)
            {
                throw new FaultException("ERROR EN ACCESO A DATOS. " + ex.Message);
            }
        }


        /// <summary>
        /// metodo que añade un contacto a una empresa
        /// </summary>
        /// <param name="contacto">datos del contacto a añadir</param>
        /// <returns>devuelve el identificador del nuevo contacto o -1 si hubo algun error</returns>
        public int AddContacto(ContactoData contacto){
            try
            {
                using (BDCRMEntities db = new BDCRMEntities())
                {
                    if (contacto != null)
                    {
                        Contacto nuevo = new Contacto();


                        nuevo.Nombre = contacto.Nombre;
                        nuevo.Email = contacto.Email;
                        nuevo.IDEmpresa = contacto.IDEmpresa;
                        //faltan cargo y telefono????

                        db.Contacto.Add(nuevo);
                        db.SaveChanges();
                        return nuevo.ID;

                    }
                    else
                    {
                        return -1;
                    }


                }

            }
            catch (SqlException ex)
            {
                FaultException fault = new FaultException("Error SQL: " + ex.Message, new FaultCode("SQL"));
                return -1;

            }
            catch (Exception ex)
            {
                FaultException fault = new FaultException("Error: " + ex.Message, new FaultCode("GENERAL"));
                return -1;
            }
        }


        /// <summary>
        /// metodo que borra un contacto de una empresa
        /// </summary>
        /// <param name="idContacto">identificador del contacto</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        public bool BorrarContacto(int idContacto)
        {
            try
            {
                using (BDCRMEntities db = new BDCRMEntities())
                {
                    var consulta = from tabla in db.Contacto where tabla.ID == idContacto select tabla;
                    Contacto c = consulta.First();

                    db.Contacto.Remove(c);
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
        /// metodo que edita un contacto existente
        /// </summary>
        /// <param name="contacto">datos del contacto</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        public bool EditContacto(ContactoData contacto)
        {
            try
            {
                if (contacto != null)
                {
                    using (BDCRMEntities db = new BDCRMEntities())
                    {
                        var consulta = from tabla in db.Contacto where tabla.ID == contacto.ID select tabla;

                        Contacto nuevo = consulta.First();

                        nuevo.Nombre = contacto.Nombre;
                        nuevo.Email = contacto.Email;
                        

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
        /// metodo que devuelve los datos de una accion comercial
        /// </summary>
        /// <param name="idAccionComercial">identificador de dicha accion</param>
        /// <returns>los datos de la accion</returns>
        public AccionComercialData GetAccionComercial(int idAccionComercial)
        {
            List<AccionComercialData> lst = new List<AccionComercialData>();
            try
            {
                using (BDCRMEntities datos = new BDCRMEntities())
                {
                    var consulta = from tabla in datos.AccionComercial
                                   where tabla.ID == idAccionComercial
                                   select new AccionComercialData()
                                   {
                                       ID = tabla.ID,
                                       IDEmpresa = tabla.IDEmpresa,
                                       IDAccion = tabla.IDAccion,
                                       IDEstado = tabla.IDEstado,
                                       Comentarios = tabla.Comentarios,
                                       Descripcion = tabla.Descripcion,
                                       Fecha = tabla.Fecha,
                                       Usuario = tabla.Usuario
                                       
                                   };
                    lst = consulta.ToList();
                    AccionComercialData c = lst.First();

                    return c;
                }
            }
            catch (Exception ex)
            {
                throw new FaultException("ERROR EN ACCESO A DATOS. " + ex.Message);
            }
        }
        

        /// <summary>
        /// metodo que añade una accion comercial a una empresa y un usuario
        /// </summary>
        /// <param name="contacto">datos de la accion a añadir</param>
        /// <returns>devuelve el identificador de la nueva accion o -1 si hubo algun error</returns>
        public int AddAccionComercial(AccionComercialData accion)
        {
            try
            {
                using (BDCRMEntities db = new BDCRMEntities())
                {
                    if (accion != null)
                    {
                        AccionComercial nuevo = new AccionComercial();


                        
                        nuevo.IDEmpresa = accion.IDEmpresa;
                        nuevo.IDAccion = accion.IDAccion;
                        nuevo.IDEstado = accion.IDEstado;
                        nuevo.Comentarios = accion.Comentarios;
                        nuevo.Descripcion = accion.Descripcion;
                        nuevo.Fecha = accion.Fecha;
                        nuevo.Usuario = accion.Usuario;
                        

                        db.AccionComercial.Add(nuevo);
                        db.SaveChanges();
                        return nuevo.ID;

                    }
                    else
                    {
                        return -1;
                    }


                }

            }
            catch (SqlException ex)
            {
                FaultException fault = new FaultException("Error SQL: " + ex.Message, new FaultCode("SQL"));
                return -1;

            }
            catch (Exception ex)
            {
                FaultException fault = new FaultException("Error: " + ex.Message, new FaultCode("GENERAL"));
                return -1;
            }
        }


        /// <summary>
        /// metodo que borra una accion comercial de una empresa y un usuario
        /// </summary>
        /// <param name="idContacto">identificador de la accion</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        public bool BorrarAccionComercial(int idaccion)
        {
            try
            {
                using (BDCRMEntities db = new BDCRMEntities())
                {
                    var consulta = from tabla in db.AccionComercial where tabla.ID == idaccion select tabla;
                    AccionComercial c = consulta.First();

                    db.AccionComercial.Remove(c);
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
        /// metodo que edita una accion comercial existente
        /// </summary>
        /// <param name="contacto">datos de la accion</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        public bool EditAccionComercial(AccionComercialData accion)
        {
            try
            {
                if (accion != null)
                {
                    using (BDCRMEntities db = new BDCRMEntities())
                    {
                        var consulta = from tabla in db.AccionComercial where tabla.ID == accion.ID select tabla;

                        AccionComercial nuevo = consulta.First();

                        nuevo.IDAccion = accion.IDAccion;
                        nuevo.IDEstado = accion.IDEstado;
                        nuevo.Fecha = accion.Fecha;
                        nuevo.Descripcion = accion.Descripcion;
                        nuevo.Comentarios = accion.Comentarios;


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




    }
}
