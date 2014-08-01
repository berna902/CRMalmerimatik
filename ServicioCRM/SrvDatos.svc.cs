using ServicioCRM;
using ServicioCRM.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
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
                                       TipoEmpresa = tabla.TipoEmpresa1.Tipo,
                                       Telefono = tabla.TelefonoEmpresa.FirstOrDefault().Telefono

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
                                       Username = tabla.User.Username,
                                       IDEmpresa = tabla.IDEmpresa,
                                       CIF = tabla.Empresa.CIF,
                                       Fecha = tabla.Fecha,
                                       Descripcion = tabla.Descripcion,
                                       Comentarios = tabla.Comentarios,
                                       IDAccion = tabla.IDAccion,
                                       Accion = tabla.TipoAccion.Tipo,
                                       IDEstado = tabla.IDEstado,
                                       Estado = tabla.Estado.Estado1

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
        /// metodo que devuelve los datos de las acciones comerciales realizadas en una empresa
        /// </summary>
        /// <returns></returns>
        public List<AccionComercialData> GetAllAccionesComercialesEmpresa(int idEmpresa)
        {
            List<AccionComercialData> lst = new List<AccionComercialData>();
            try
            {
                using (BDCRMEntities datos = new BDCRMEntities())
                {
                    var consulta = from tabla in datos.AccionComercial
                                   where tabla.IDEmpresa == idEmpresa
                                   select new AccionComercialData()
                                   {
                                       ID = tabla.ID,
                                       Usuario = tabla.Usuario,
                                       Username = tabla.User.Username,
                                       IDEmpresa = tabla.IDEmpresa,
                                       CIF = tabla.Empresa.CIF,
                                       Fecha = tabla.Fecha,
                                       Descripcion = tabla.Descripcion,
                                       Comentarios = tabla.Comentarios,
                                       IDAccion = tabla.IDAccion,
                                       Accion = tabla.TipoAccion.Tipo,
                                       IDEstado = tabla.IDEstado,
                                       Estado = tabla.Estado.Estado1

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
        /// metodo que devuelve los datos de las acciones comerciales de un usuario
        /// </summary>
        /// <returns></returns>
        public List<AccionComercialData> GetAllAccionesComercialesUsuario(int idUsuario)
        {
            List<AccionComercialData> lst = new List<AccionComercialData>();
            try
            {
                using (BDCRMEntities datos = new BDCRMEntities())
                {
                    var consulta = from tabla in datos.AccionComercial
                                   where tabla.Usuario == idUsuario
                                   select new AccionComercialData()
                                   {
                                       ID = tabla.ID,
                                       Usuario = tabla.Usuario,
                                       Username = tabla.User.Username,
                                       IDEmpresa = tabla.IDEmpresa,
                                       CIF = tabla.Empresa.CIF,
                                       Fecha = tabla.Fecha,
                                       Descripcion = tabla.Descripcion,
                                       Comentarios = tabla.Comentarios,
                                       IDAccion = tabla.IDAccion,
                                       Accion = tabla.TipoAccion.Tipo,
                                       IDEstado = tabla.IDEstado,
                                       Estado = tabla.Estado.Estado1

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
        public List<ContactoData> GetAllContactosEmpresa(int idEmpresa)
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
                                       CIF = tabla.Empresa.CIF,
                                       Nombre = tabla.Nombre,
                                       Email = tabla.Email,
                                       Telefono = tabla.TelefonoContacto.FirstOrDefault().Telefono,
                                       Cargo = tabla.Cargo.FirstOrDefault().Carg,
                                       IDCargo = tabla.Cargo.FirstOrDefault().ID

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
        /// metodo que devuelve una lista de todos contactos
        /// </summary>
        /// <returns>listado con todos los contactos</returns>
        public List<ContactoData> GetAllContactos()
        {
            List<ContactoData> lst = new List<ContactoData>();
            try
            {
                using (BDCRMEntities datos = new BDCRMEntities())
                {
                    var consulta = from tabla in datos.Contacto
                                   select new ContactoData()
                                   {
                                       ID = tabla.ID,
                                       IDEmpresa = tabla.IDEmpresa,
                                       CIF = tabla.Empresa.CIF,
                                       Nombre = tabla.Nombre,
                                       Email = tabla.Email,
                                       Telefono = tabla.TelefonoContacto.FirstOrDefault().Telefono,
                                       IDCargo = tabla.Cargo.FirstOrDefault().ID,
                                       Cargo = tabla.Cargo.FirstOrDefault().Carg
                                       

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
        /// metodo que devolvera los cargos de un contacto
        /// </summary>
        /// <returns></returns>
        public List<CargoData> GetAllCargosContacto(int contacto)
        {
            List<CargoData> lst = new List<CargoData>();
            try
            {
                using (BDCRMEntities datos = new BDCRMEntities())
                {
                    var consulta = from tabla in datos.Contacto
                                   where (tabla.ID == contacto)
                                   select tabla;
                                   
                                                      
                    
                    Contacto c = consulta.First();
                    CargoData cd;
                    foreach(var ele in c.Cargo){
                        cd = new CargoData();
                        cd.ID = ele.ID;
                        cd.Cargo = ele.Carg;
                        lst.Add(cd);
                    }
                    
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

                        if (!ExisteEmpresa(empresa))
                        {
                            //insertamos empresa
                            Empresa nuevo = new Empresa();

                            nuevo.Nombre = empresa.Nombre;
                            nuevo.RazonSocial = empresa.RazonSocial;
                            nuevo.CIF = empresa.CIF;
                            nuevo.Email = empresa.Email;
                            nuevo.Web = empresa.Web;
                            nuevo.TipoEmpresa = empresa.IDTipoEmpresa;

                            db.Empresa.Add(nuevo);

                            //insertamos el telefono
                            if (empresa.Telefono != null && empresa.Telefono != "")
                            {
                                TelefonosData nuevoTlf = new TelefonosData();
                                nuevoTlf.ID = nuevo.ID;
                                nuevoTlf.Telefono = empresa.Telefono;
                                AddTelefonoEmpresa(nuevoTlf);
                            }


                            db.SaveChanges();
                            return nuevo.ID;
                        }
                        else
                        {
                            return -1;
                            //ya existe la empresa
                        }
                        

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
                    var consulta = from tabla in datos.Empresa
                                   where tabla.ID == idEmpresa
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
                                       Telefono = tabla.TelefonoEmpresa.FirstOrDefault().Telefono
                                       

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
                    //borramos los telefonos asociados a la empresa
                    var consultaT = from tabla in db.TelefonoEmpresa where tabla.IDEmpresa == idEmpresa select tabla;
                    foreach(var element in consultaT){
                        //se peude pasar solo el tlf pues es clave primaria
                        BorrarTelefonoEmpresa(element.Telefono);
                    }

                    //borramos la empresa
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
                        if (!ExisteUser(user))
                        {
                            User nuevo = new User();


                            nuevo.Nombre = user.Nombre;
                            nuevo.Username = user.Username;
                            String hash = EncodePassword(String.Concat(user.Username, user.Password));
                            nuevo.Password = hash;
                            


                            db.User.Add(nuevo);
                            db.SaveChanges();
                            return nuevo.IDUsuario;
                        }
                        else
                        {
                            //ya existe el usuario
                            return -1;
                        }

                        

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
                        if (user.Password != "")
                        {
                            String hash = EncodePassword(String.Concat(user.Username, user.Password));
                            nuevo.Password = hash;
                        }
                        
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
                                       Email = tabla.Email,
                                       Telefono = tabla.TelefonoContacto.FirstOrDefault().Telefono,
                                       Cargo = tabla.Cargo.FirstOrDefault().Carg
                                       

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
                        
                         //insertamos un cargo
                        if (contacto.Cargo != null && contacto.Cargo != "")
                        {
                            var consulta = from tabla in db.Cargo
                                           where tabla.Carg == contacto.Cargo
                                           select tabla;
                            Cargo c = consulta.First();
                            nuevo.Cargo.Add(c);

                        }


                        db.Contacto.Add(nuevo);

                        //insertamos el telefono
                        if (contacto.Telefono != null && contacto.Telefono != "")
                        {
                            TelefonosData nuevoTlf = new TelefonosData();
                            nuevoTlf.ID = nuevo.ID;
                            nuevoTlf.Telefono = contacto.Telefono;
                            AddTelefonoEmpresa(nuevoTlf);
                        }

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
                    //borramos los telefonos asociados a al contacto
                    var consultaT = from tabla in db.TelefonoContacto where tabla.IDContacto == idContacto select tabla;
                    foreach (var element in consultaT)
                    {
                        //se puede pasar solo el tlf pues es clave primaria
                        BorrarTelefonoContacto(element.Telefono);
                    }


                    var consulta = from tabla in db.Contacto where tabla.ID == idContacto select tabla;
                    Contacto c = consulta.First();

                    //borramos los cargos de este contacto
                    foreach (var ele in c.Cargo)
                    {
                        c.Cargo.Remove(ele);
                    }

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
                                       Usuario = tabla.Usuario,
                                       Username = tabla.User.Username,
                                       IDEmpresa = tabla.IDEmpresa,
                                       CIF = tabla.Empresa.CIF,
                                       Fecha = tabla.Fecha,
                                       Descripcion = tabla.Descripcion,
                                       Comentarios = tabla.Comentarios,
                                       IDAccion = tabla.IDAccion,
                                       Accion = tabla.TipoAccion.Tipo,
                                       IDEstado = tabla.IDEstado,
                                       Estado = tabla.Estado.Estado1
                                       
                                       
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
                        if (accion.Fecha != null)
                        {
                            nuevo.Fecha = accion.Fecha;
                        }
                        else
                        {
                            nuevo.Fecha = new DateTime();
                            nuevo.Fecha = DateTime.Now;
                        }
                        
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


        /// <summary>
        /// metodo que devuelve la lista de todos los estados
        /// </summary>
        /// <returns></returns>
        public List<EstadoData> GetAllEstados()
        {
            List<EstadoData> lst = new List<EstadoData>();
            try
            {
                using (BDCRMEntities datos = new BDCRMEntities())
                {
                    var consulta = from tabla in datos.Estado
                                   select new EstadoData()
                                   {
                                       ID = tabla.ID,
                                       Estado = tabla.Estado1

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
        /// metodo que añade un estado a la BD
        /// </summary>
        /// <param name="estado">nombre con el estado nuevo</param>
        /// <returns>id del estado nuevo</returns>
        public int AddEstado(String estado)
        {
            try
            {
                if (estado != "" && estado != null)
                {
                    using (BDCRMEntities db = new BDCRMEntities())
                    {
                        Estado nuevo = new Estado();


                        nuevo.Estado1 = estado;

                        db.Estado.Add(nuevo);
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
        /// metodo que borra un estado de la BD
        /// </summary>
        /// <param name="idEstado">identificador del estado a borrar</param>
        /// <returns>verdadero o falso segun si la accion se llevo a cabo o no</returns>
        public bool BorrarEstado(int idEstado)
        {
            try
            {
                using (BDCRMEntities db = new BDCRMEntities())
                {
                    var consulta = from tabla in db.Estado where tabla.ID == idEstado select tabla;
                    Estado borrar = consulta.First();

                    db.Estado.Remove(borrar);
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
        /// metodo que añade nu cargo a la BD
        /// </summary>
        /// <param name="cargo">cargo a insertar</param>
        /// <returns>identificador del cargo nuevo</returns>
        public int AddCargo(string cargo)
        {
            try
            {
                if (cargo != null && cargo !="")
                {
                    using (BDCRMEntities db = new BDCRMEntities())
                    {
                        Cargo nuevo = new Cargo();


                        nuevo.Carg = cargo;

                        db.Cargo.Add(nuevo);
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
        /// metodo que borra un cargo especifico
        /// </summary>
        /// <param name="idCargo">identificador del cargo</param>
        /// <returns>verdadero o falso segun si realiza la operacion o no</returns>
        public bool BorrarCargo(int idCargo)
        {
            try
            {
                using (BDCRMEntities db = new BDCRMEntities())
                {
                    var consulta = from tabla in db.Cargo where tabla.ID == idCargo select tabla;
                    Cargo borrar = consulta.First();

                    db.Cargo.Remove(borrar);
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
        /// metodo que devuelve todas las direcciones de una empresa
        /// </summary>
        /// <param name="idEmpresa">identificador de la empresa</param>
        /// <returns>listado de direcciones</returns>
        public List<DireccionData> GetAllDireccionesEmpresa(int idEmpresa)
        {
            List<DireccionData> lst = new List<DireccionData>();
            try
            {
                using (BDCRMEntities datos = new BDCRMEntities())
                {
                    var consulta = from tabla in datos.Empresa
                                   where tabla.ID == idEmpresa
                                   select tabla;

                    Empresa c = consulta.First();
                    DireccionData dd;
                    foreach (var ele in c.Direccion)
                    {
                        dd = new DireccionData();
                        dd.ID = ele.ID;
                        dd.CP = ele.CP;
                        dd.Domicilio = ele.Domicilio;
                        dd.Poblacion = ele.Poblacion;
                        dd.Provincia = ele.Provincia;
                        
                        lst.Add(dd);
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw new FaultException("ERROR EN ACCESO A DATOS. " + ex.Message);
            }
            
        }


        /// <summary>
        /// metodo que devuelve todas las direcciones de un contacto
        /// </summary>
        /// <param name="idContacto">identificador del contacto</param>
        /// <returns>listado de direcciones</returns>
        public List<DireccionData> GetAllDireccionesContacto(int idContacto)
        {
            List<DireccionData> lst = new List<DireccionData>();
            try
            {
                using (BDCRMEntities datos = new BDCRMEntities())
                {
                    var consulta = from tabla in datos.DireccionContacto
                                   where tabla.IDContacto == idContacto
                                   select tabla;

                    DireccionData dd;
                    foreach(var ele in consulta){
                        
                        dd = new DireccionData();
                        dd.ID = ele.Direccion.ID;
                        dd.CP = ele.Direccion.CP;
                        dd.Domicilio = ele.Direccion.Domicilio;
                        dd.Poblacion = ele.Direccion.Poblacion;
                        dd.Provincia = ele.Direccion.Provincia;

                        lst.Add(dd);
 
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw new FaultException("ERROR EN ACCESO A DATOS. " + ex.Message);
            }

        }


        /// <summary>
        /// metodo que devuelve los datos de una direccion
        /// </summary>
        /// <param name="idDireccion">identificador de la direccion</param>
        /// <returns>datos de la direccion</returns>
        public DireccionData GetDireccion(int idDireccion)
        {
            List<DireccionData> lst = new List<DireccionData>();
            try
            {
                using (BDCRMEntities datos = new BDCRMEntities())
                {
                    var consulta = from tabla in datos.Direccion
                                   where tabla.ID == idDireccion
                                   select new DireccionData()
                                   {
                                       ID = tabla.ID,
                                       CP = tabla.CP,
                                       Domicilio = tabla.Domicilio,
                                       Provincia = tabla.Provincia,
                                       Poblacion = tabla.Poblacion
                                  };

                    lst = consulta.ToList();
                    DireccionData d = lst.First();

                    return d;
                }
            }
            catch (Exception ex)
            {
                throw new FaultException("ERROR EN ACCESO A DATOS. " + ex.Message);
            }
        }



        /// <summary>
        /// metodo que añade una direccion
        /// </summary>
        /// <param name="direccion">datos de la direccion a añadir</param>
        /// <returns>devuelve el identificador de la nueva direccion o -1 si hubo algun error</returns>
        public int AddDireccion(DireccionData direccion)
        {
            try
            {
                using (BDCRMEntities db = new BDCRMEntities())
                {
                    if (direccion != null)
                    {
                        Direccion nuevo = new Direccion();
                        
                        nuevo.CP = direccion.CP;
                        nuevo.Poblacion = direccion.Poblacion;
                        nuevo.Provincia = direccion.Provincia;
                        nuevo.Domicilio = direccion.Domicilio;
                        
                        db.Direccion.Add(nuevo);
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
        /// metodo que edita una direccion
        /// </summary>
        /// <param name="direccion">datos de la direccion</param>
        /// <returns>verdadero o falso segun si realiza la accion o no</returns>
        public bool EditDireccion(DireccionData direccion)
        {
            try
            {
                if (direccion != null)
                {
                    using (BDCRMEntities db = new BDCRMEntities())
                    {
                        var consulta = from tabla in db.Direccion where tabla.ID == direccion.ID select tabla;

                        Direccion nuevo = consulta.First();

                        nuevo.Domicilio = direccion.Domicilio;
                        nuevo.CP = direccion.CP;
                        nuevo.Provincia = direccion.Provincia;
                        nuevo.Poblacion = direccion.Poblacion;


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
        /// metodo que borra una direccion
        /// </summary>
        /// <param name="idDireccion">identificador de la direccion</param>
        /// <returns>verdadero o falso segun si realiza la accion o no</returns>
        public bool BorrarDireccion(int idDireccion)
        {
            try
            {
                using (BDCRMEntities db = new BDCRMEntities())
                {
                    var consulta = from tabla in db.Direccion where tabla.ID == idDireccion select tabla;
                    Direccion borrar = consulta.First();

                    db.Direccion.Remove(borrar);
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
        /// metodo que añade una direccion y la coloca en una empresa
        /// </summary>
        /// <param name="direccion">datos de la direccion</param>
        /// <param name="idEmpresa">identificador de la empresa</param>
        /// <returns>devuelve el identificador de la direccion nueva o -1 si existe algun error</returns>
        public int AddDireccionEmpresa(DireccionData direccion, int idEmpresa)
        {
            try
            {
                using (BDCRMEntities db = new BDCRMEntities())
                {
                    if (direccion != null)
                    {

                        int id = AddDireccion(direccion);

                        //añadimos la direccion a la empresa                        
                        
                        var consulta = from tabla in db.Direccion
                                        where tabla.ID == id
                                        select tabla;

                        var consulta2 = from tabla2 in db.Empresa
                                        where tabla2.ID == idEmpresa
                                        select tabla2;

                        Direccion d = consulta.First();
                        Empresa e = consulta2.First();
                        
                        //añadimos la direccion a la empresa
                        e.Direccion.Add(d);
                        
                        
                        db.SaveChanges();
                        return id;

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
        /// metodo que añade una direccion y la coloca en un contacto
        /// </summary>
        /// <param name="direccion">datos de la direccion</param>
        /// <param name="idContacto">identificador del contacto</param>
        /// <returns>devuelve el identificador de la direccion nueva o -1 si existe algun error</returns>
        public int AddDireccionContacto(DireccionData direccion, int idContacto)
        {
            try
            {
                using (BDCRMEntities db = new BDCRMEntities())
                {
                    if (direccion != null)
                    {

                        int id = AddDireccion(direccion);

                        //añadimos la direccion al contacto                        
                         
                        DireccionContacto dc = new DireccionContacto();
                        dc.IDDireccion = id;
                        dc.IDContacto = idContacto;

                        db.DireccionContacto.Add(dc);
                        db.SaveChanges();
                        return id;

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
        /// metodo que borrar una direccion de una empresa
        /// </summary>
        /// <param name="idEmpresa">identificador de la empresa</param>
        /// <param name="idDireccion">identificador de la direccion</param>
        /// <returns>verdadero o falso segun si realiza con exito la operacion o no</returns>
        public bool BorrarDireccionEmpresa(int idEmpresa, int idDireccion){
            try
            {
                using (BDCRMEntities db = new BDCRMEntities())
                {
                    var consulta = from tabla in db.Empresa where tabla.ID == idEmpresa select tabla;
                    Empresa borrar = consulta.First();

                    var consulta2 = from tabla in db.Direccion where tabla.ID == idDireccion select tabla;
                    Direccion d = consulta2.First();

                   
                    borrar.Direccion.Remove(d);
                    bool b = BorrarDireccion(idDireccion);
                    if(b == true){
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
        /// metodo que borrar una direccion de un contacto
        /// </summary>
        /// <param name="idContacto">identificador del contacto</param>
        /// <param name="idDireccion">identificador de la direccion</param>
        /// <returns>verdadero o falso segun si realiza con exito la operacion o no</returns>
        public bool BorrarDireccionContacto(int idContacto, int idDireccion)
        {
            try
            {
                using (BDCRMEntities db = new BDCRMEntities())
                {
                    var consulta = from tabla in db.DireccionContacto
                                   where (tabla.IDContacto == idContacto && tabla.IDDireccion == idDireccion)
                                   select tabla;
                    DireccionContacto borrar = consulta.First();

                    
                    db.DireccionContacto.Remove(borrar);
                    bool b = BorrarDireccion(idDireccion);
                    if (b == true)
                    {
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
        /// metodo que edita un tipo de empresa
        /// </summary>
        /// <param name="tipo">datos del tipo de empresa</param>
        /// <returns>verdadero o falso segun si se realiza la accion o no</returns>
        public bool EditTipoEmpresa(TipoEmpresaData tipo)
        {
            try
            {
                if (tipo != null)
                {
                    using (BDCRMEntities db = new BDCRMEntities())
                    {
                        var consulta = from tabla in db.TipoEmpresa where tabla.ID == tipo.ID select tabla;

                        TipoEmpresa nuevo = consulta.First();

                        nuevo.Tipo = tipo.Tipo;

                        if (tipo.Tipo != "")
                        {
                            db.SaveChanges();
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                        
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
        /// metodo que devuelve los datos de un tipo de empresa
        /// </summary>
        /// <param name="idTipo">identificador del tipo de empresa</param>
        /// <returns></returns>
        public TipoEmpresaData GetTipoEmpresa(int idTipo)
        {
            List<TipoEmpresaData> lst = new List<TipoEmpresaData>();
            try
            {
                using (BDCRMEntities datos = new BDCRMEntities())
                {
                    var consulta = from tabla in datos.TipoEmpresa
                                   where tabla.ID == idTipo
                                   select new TipoEmpresaData()
                                   {
                                       ID = tabla.ID,
                                       Tipo = tabla.Tipo
                                       
                                   };

                    lst = consulta.ToList();
                    TipoEmpresaData d = lst.First();

                    return d;
                }
            }
            catch (Exception ex)
            {
                throw new FaultException("ERROR EN ACCESO A DATOS. " + ex.Message);
            }
        }


        /// <summary>
        /// metodo que edita un tipo de accion
        /// </summary>
        /// <param name="tipo">datos del tipo de accion</param>
        /// <returns>verdadero o falso segun si se realiza la accion o no</returns>
        public bool EditTipoAccion(TipoAccionData tipo)
        {
            try
            {
                if (tipo != null)
                {
                    using (BDCRMEntities db = new BDCRMEntities())
                    {
                        var consulta = from tabla in db.TipoAccion where tabla.ID == tipo.ID select tabla;

                        TipoAccion nuevo = consulta.First();

                        nuevo.Tipo = tipo.Tipo;

                        if (tipo.Tipo != "")
                        {
                            db.SaveChanges();
                            return true;
                        }
                        else
                        {
                            return false;
                        }

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
        /// metodo que devuelve los datos de un tipo de accion
        /// </summary>
        /// <param name="idTipo">identificador del tipo de accion</param>
        /// <returns></returns>
        public TipoAccionData GetTipoAccion(int idTipo)
        {
            List<TipoAccionData> lst = new List<TipoAccionData>();
            try
            {
                using (BDCRMEntities datos = new BDCRMEntities())
                {
                    var consulta = from tabla in datos.TipoAccion
                                   where tabla.ID == idTipo
                                   select new TipoAccionData()
                                   {
                                       ID = tabla.ID,
                                       Tipo = tabla.Tipo

                                   };

                    lst = consulta.ToList();
                    TipoAccionData d = lst.First();

                    return d;
                }
            }
            catch (Exception ex)
            {
                throw new FaultException("ERROR EN ACCESO A DATOS. " + ex.Message);
            }
        }


        /// <summary>
        /// metodo que edita un cargo
        /// </summary>
        /// <param name="cargo">datos del cargo</param>
        /// <returns>verdadero o falso segun si se realiza la accion o no</returns>
        public bool EditCargo(CargoData cargo)
        {
            try
            {
                if (cargo != null)
                {
                    using (BDCRMEntities db = new BDCRMEntities())
                    {
                        var consulta = from tabla in db.Cargo where tabla.ID == cargo.ID select tabla;

                        Cargo nuevo = consulta.First();

                        nuevo.Carg = cargo.Cargo;

                        if (cargo.Cargo != "")
                        {
                            db.SaveChanges();
                            return true;
                        }
                        else
                        {
                            return false;
                        }

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
        /// metodo que devuelve los datos de un cargo
        /// </summary>
        /// <param name="idCargo">identificador del cargo</param>
        /// <returns></returns>
        public CargoData GetCargo(int idCargo)
        {
            List<CargoData> lst = new List<CargoData>();
            try
            {
                using (BDCRMEntities datos = new BDCRMEntities())
                {
                    var consulta = from tabla in datos.Cargo
                                   where tabla.ID == idCargo
                                   select new CargoData()
                                   {
                                       ID = tabla.ID,
                                       Cargo = tabla.Carg

                                   };

                    lst = consulta.ToList();
                    CargoData d = lst.First();

                    return d;
                }
            }
            catch (Exception ex)
            {
                throw new FaultException("ERROR EN ACCESO A DATOS. " + ex.Message);
            }
        }



        /// <summary>
        /// metodo que edita un estado
        /// </summary>
        /// <param name="estado">datos del estado</param>
        /// <returns>verdadero o falso segun si se realiza la accion o no</returns>
        public bool EditEstado(EstadoData estado)
        {
            try
            {
                if (estado != null)
                {
                    using (BDCRMEntities db = new BDCRMEntities())
                    {
                        var consulta = from tabla in db.Estado where tabla.ID == estado.ID select tabla;

                        Estado nuevo = consulta.First();

                        nuevo.Estado1 = estado.Estado;

                        if (estado.Estado != "")
                        {
                            db.SaveChanges();
                            return true;
                        }
                        else
                        {
                            return false;
                        }

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
        /// metodo que devuelve los datos de un estado
        /// </summary>
        /// <param name="idEstado">identificador del estado</param>
        /// <returns></returns>
        public EstadoData GetEstado(int idEstado)
        {
            List<EstadoData> lst = new List<EstadoData>();
            try
            {
                using (BDCRMEntities datos = new BDCRMEntities())
                {
                    var consulta = from tabla in datos.Estado
                                   where tabla.ID == idEstado
                                   select new EstadoData()
                                   {
                                       ID = tabla.ID,
                                       Estado = tabla.Estado1

                                   };

                    lst = consulta.ToList();
                    EstadoData d = lst.First();

                    return d;
                }
            }
            catch (Exception ex)
            {
                throw new FaultException("ERROR EN ACCESO A DATOS. " + ex.Message);
            }
        }


        /// <summary>
        /// metodo que devuelve la direccion como una cadena
        /// </summary>
        /// <param name="direccion">datos de la direccion</param>
        /// <returns>string con la direccion completa unida</returns>
        public String DireccionToString(DireccionData direccion)
        {
            
            if (direccion != null)
            {
                return direccion.Domicilio + " (" + direccion.CP + ") " + direccion.Poblacion + " - " + direccion.Provincia;
            }
            else
            {
                return "";
            }
        }


        /// <summary>
        /// metodo que indica si existe un usuario en la BD (compara por username)
        /// </summary>
        /// <param name="user">datos del usuario</param>
        /// <returns>devuelve verdadero o falso segun si existe o no</returns>
        public bool ExisteUser(UserData user){
            List<UserData> lst = new List<UserData>();
            try
            {
                using (BDCRMEntities datos = new BDCRMEntities())
                {

                    if(user != null){
                        var consulta = from tabla in datos.User
                                       where tabla.Username == user.Username
                                       select new UserData()
                                       {
                                           IDUsuario = tabla.IDUsuario,
                                           Nombre = tabla.Nombre,
                                           Username = tabla.Username
                                           
                                       };


                        lst = consulta.ToList();
                        
                        if(lst.Count > 0){
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }else{
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
        /// metodo que indica si existe una empresa en la BD (compara por CIF)
        /// </summary>
        /// <param name="empresa">datos de la empresa</param>
        /// <returns>devuelve verdadero o falso segun si existe o no</returns>
        public bool ExisteEmpresa(EmpresaData empresa)
        {
            List<EmpresaData> lst = new List<EmpresaData>();
            try
            {
                using (BDCRMEntities datos = new BDCRMEntities())
                {

                    if (empresa != null)
                    {
                        var consulta = from tabla in datos.Empresa
                                       where tabla.CIF == empresa.CIF
                                       select new EmpresaData()
                                       {
                                           ID = tabla.ID,
                                           CIF = tabla.CIF,
                                           Email = tabla.Email,
                                           Nombre = tabla.Nombre,
                                           RazonSocial = tabla.RazonSocial,
                                           Web = tabla.Web,
                                           IDTipoEmpresa = tabla.TipoEmpresa,
                                           TipoEmpresa = tabla.TipoEmpresa1.Tipo,
                                           Telefono = tabla.TelefonoEmpresa.FirstOrDefault().Telefono
                                       };


                        lst = consulta.ToList();
                        if (lst.Count > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

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
        /// metodo que indica si existe un telefono en una empresa
        /// </summary>
        /// <param name="telefono">datos del telefono y empresa</param>
        /// <returns>devuelve verdadero o falso segun si existe o no</returns>
        public bool ExisteTelefonoEmpresa(TelefonosData telefono)
        {
            List<TelefonosData> lst = new List<TelefonosData>();
            try
            {
                using (BDCRMEntities datos = new BDCRMEntities())
                {

                    if (telefono != null)
                    {
                        var consulta = from tabla in datos.TelefonoEmpresa
                                       where tabla.Telefono == telefono.Telefono
                                       select new TelefonosData()
                                       {
                                           ID = tabla.IDEmpresa,
                                           Telefono = tabla.Telefono
                                           
                                       };


                        lst = consulta.ToList();
                        if (lst.Count > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

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
        /// metodo que indica si existe un telefono en un contacto
        /// </summary>
        /// <param name="telefono">datos del telefono y contacto</param>
        /// <returns>devuelve verdadero o falso segun si existe o no</returns>
        public bool ExisteTelefonoContacto(TelefonosData telefono)
        {
            List<TelefonosData> lst = new List<TelefonosData>();
            try
            {
                using (BDCRMEntities datos = new BDCRMEntities())
                {

                    if (telefono != null)
                    {
                        var consulta = from tabla in datos.TelefonoContacto
                                       where tabla.Telefono == telefono.Telefono
                                       select new TelefonosData()
                                       {
                                           ID = tabla.IDContacto,
                                           Telefono = tabla.Telefono

                                       };


                        lst = consulta.ToList();
                        if (lst.Count > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

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
        /// metodo que valida un usuario 
        /// </summary>
        /// <param name="username">username del usuario</param>
        /// <param name="password">password del usuario</param>
        /// <returns>verdadero o falso segun si el usuario esta validado o no</returns>
        public bool ValidaUser(String username, String password)
        {
            List<UserData> lst = new List<UserData>();
            try
            {
                using (BDCRMEntities datos = new BDCRMEntities())
                {

                    if (username != "" && password != "")
                    {
                        var consulta = from tabla in datos.User
                                       where tabla.Username == username
                                       select new UserData()
                                       {
                                           IDUsuario = tabla.IDUsuario,
                                           Nombre = tabla.Nombre,
                                           Username = tabla.Username,
                                           Password = tabla.Password
                                       };

                        String hash = EncodePassword(String.Concat(username, password));
                        lst = consulta.ToList();
                        if (lst.Count > 0)
                        {
                            UserData ud = lst.First();
                            if (ud.Username == username && ud.Password == hash)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                                //usuario o contraseña no correctos
                            }
                        }
                        else
                        {
                            return false;
                            //el username no existe
                        }
                        

                    }
                    else
                    {
                        return false;
                        //datos vacios. falta username o password o ambos
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
        /// metodo que devuelve la lista de terminos que coinciden con una cadena
        /// </summary>
        /// <param name="cadena">termino de busqueda</param>
        /// <returns></returns>
        public List<BusquedaData> BusquedaRapida(String cadena)
        {
            List<BusquedaData> busqueda = new List<BusquedaData>();
            List<Empresa> empresas = new List<Empresa>();
            List<User> users = new List<User>();
            List<AccionComercial> accion = new List<AccionComercial>();
            List<Contacto> contacto = new List<Contacto>();
            try
            {
                using (BDCRMEntities datos = new BDCRMEntities())
                {
                    //busqueda rapida de empresas
                    var consulta = from tabla in datos.Empresa
                                   where (tabla.Nombre.Contains(cadena) || tabla.RazonSocial.Contains(cadena))
                                   select tabla;
                                   

                    empresas = consulta.ToList();
                    BusquedaData bd;
                    foreach (var ele in empresas)
                    {
                        bd = new BusquedaData();
                        if(ele.Nombre.Contains(cadena))
                        {
                            bd.Nombre = ele.Nombre;
                        }
                        else
                        {
                            bd.Nombre = ele.RazonSocial;
                        }
                        
                        bd.Tipo = "Empresa";
                        bd.ID = ele.ID;

                        busqueda.Add(bd);
                    }

                    //busqueda rapida de usuarios
                    var consulta2 = from tabla in datos.User
                                   where (tabla.Nombre.Contains(cadena) || tabla.Username.Contains(cadena))
                                   select tabla;


                    users = consulta2.ToList();
                    
                    foreach (var ele in users)
                    {
                        bd = new BusquedaData();
                        if (ele.Nombre.Contains(cadena))
                        {
                            bd.Nombre = ele.Nombre;
                        }
                        else
                        {
                            bd.Nombre = ele.Username;
                        }
                        
                        bd.Tipo = "Usuario";
                        bd.ID = ele.IDUsuario;

                        busqueda.Add(bd);
                    }


                    //busqueda rapida de acciones comerciales
                    var consulta3 = from tabla in datos.AccionComercial
                                    where (tabla.Descripcion.Contains(cadena) || tabla.Comentarios.Contains(cadena))
                                    select tabla;


                    accion = consulta3.ToList();

                    foreach (var ele in accion)
                    {
                        bd = new BusquedaData();
                        if (ele.Descripcion.Contains(cadena))
                        {
                            bd.Nombre = ele.Descripcion;
                        }
                        else
                        {
                            bd.Nombre = ele.Comentarios;
                        }

                        bd.Tipo = "AccionComercial";
                        bd.ID = ele.ID;

                        busqueda.Add(bd);
                    }


                    //busqueda rapida de contactos
                    var consulta4 = from tabla in datos.Contacto
                                    where tabla.Nombre.Contains(cadena)
                                    select tabla;


                    contacto = consulta4.ToList();

                    foreach (var ele in contacto)
                    {
                        bd = new BusquedaData();
                        
                        bd.Nombre = ele.Nombre;
                        bd.Tipo = "Contacto";
                        bd.ID = ele.ID;

                        busqueda.Add(bd);
                    }



                    return busqueda;
                }
            }
            catch (Exception ex)
            {
                throw new FaultException("ERROR EN ACCESO A DATOS. " + ex.Message);
            }
        }


        /// <summary>
        /// metodo privado para encriptar el password de los usuarios
        /// </summary>
        /// <param name="originalPassword"></param>
        /// <returns></returns>
        private string EncodePassword(string originalPassword)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();

            byte[] inputBytes = (new UnicodeEncoding()).GetBytes(originalPassword);
            byte[] hash = sha1.ComputeHash(inputBytes);
            
            return Convert.ToBase64String(hash);
        }


        /// <summary>
        /// metodo que realiza una busqueda avanzada por varios campos en los usuarios
        /// </summary>
        /// <param name="nombre">nombre del usuario</param>
        /// <param name="username">username del usuario</param>
        /// <returns>devuelve la lista de usuarios que coinciden en la busqueda. Devuelve null si los campos de busqueda estan vacios</returns>
        public List<UserData> BusquedaAvanzadaUser(String nombre, String username)
        {
            List<UserData> users = new List<UserData>();
            try
            {
                using (BDCRMEntities datos = new BDCRMEntities())
                {

                    //busqueda avanzada de usuarios
                    if (nombre != "" && username != "")
                    {
                        var consulta2 = from tabla in datos.User
                                        where (tabla.Nombre.Contains(nombre) && tabla.Username.Contains(username))
                                        select new UserData
                                        {
                                            IDUsuario = tabla.IDUsuario,
                                            Nombre =  tabla.Nombre,
                                            Username = tabla.Username
                                        };
                        users = consulta2.ToList();
                        return users;
                    }
                    else
                    {
                        if (nombre != "" && username == "")
                        {
                            var consulta2 = from tabla in datos.User
                                            where (tabla.Nombre.Contains(nombre))
                                            select new UserData
                                            {
                                                IDUsuario = tabla.IDUsuario,
                                                Nombre = tabla.Nombre,
                                                Username = tabla.Username
                                            };
                            users = consulta2.ToList();
                            return users;
                        }
                        else
                        {
                            if (nombre == "" && username != "")
                            {
                                var consulta2 = from tabla in datos.User
                                                where (tabla.Username.Contains(username))
                                                select new UserData
                                                {
                                                    IDUsuario = tabla.IDUsuario,
                                                    Nombre = tabla.Nombre,
                                                    Username = tabla.Username
                                                };
                                users = consulta2.ToList();
                                return users;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                    

                    
                }
            }
            catch (Exception ex)
            {
                throw new FaultException("ERROR EN ACCESO A DATOS. " + ex.Message);
            }
            
        }


        
        /// <summary>
        /// metodo que realiza una busqueda avanzada por varios campos en los contactos
        /// </summary>
        /// <param name="nombre">nombre del contacto</param>
        /// <param name="email">email del contacto</param>
        /// <returns>devuelve la lista de contactos que coinciden en la busqueda. Devuelve null si los campos de busqueda estan vacios</returns>
        public List<ContactoData> BusquedaAvanzadaContacto(String nombre, String email)
        {
            List<ContactoData> contactos = new List<ContactoData>();
            try
            {
                using (BDCRMEntities datos = new BDCRMEntities())
                {

                    //busqueda avanzada de contactos
                    if (nombre != "" && email != "")
                    {
                        var consulta2 = from tabla in datos.Contacto
                                        where (tabla.Nombre.Contains(nombre) && tabla.Email.Contains(email))
                                        select new ContactoData
                                        {
                                            ID = tabla.ID,
                                            IDEmpresa = tabla.IDEmpresa,
                                            IDCargo = tabla.Cargo.FirstOrDefault().ID,
                                            Nombre = tabla.Nombre,
                                            Email = tabla.Email,
                                            Cargo = tabla.Cargo.FirstOrDefault().Carg,
                                            Telefono = tabla.TelefonoContacto.FirstOrDefault().Telefono
                                        };
                        contactos = consulta2.ToList();
                        return contactos;
                    }
                    else
                    {
                        if (nombre != "" && email == "")
                        {
                            var consulta2 = from tabla in datos.Contacto
                                            where (tabla.Nombre.Contains(nombre))
                                            select new ContactoData
                                            {
                                                ID = tabla.ID,
                                                IDEmpresa = tabla.IDEmpresa,
                                                IDCargo = tabla.Cargo.FirstOrDefault().ID,
                                                Nombre = tabla.Nombre,
                                                Email = tabla.Email,
                                                Cargo = tabla.Cargo.FirstOrDefault().Carg,
                                                Telefono = tabla.TelefonoContacto.FirstOrDefault().Telefono
                                            };
                            contactos = consulta2.ToList();
                            return contactos;
                        }
                        else
                        {
                            if (nombre == "" && email != "")
                            {
                                var consulta2 = from tabla in datos.Contacto
                                                where (tabla.Email.Contains(email))
                                                select new ContactoData
                                                {
                                                    ID = tabla.ID,
                                                    IDEmpresa = tabla.IDEmpresa,
                                                    IDCargo = tabla.Cargo.FirstOrDefault().ID,
                                                    Nombre = tabla.Nombre,
                                                    Email = tabla.Email,
                                                    Cargo = tabla.Cargo.FirstOrDefault().Carg,
                                                    Telefono = tabla.TelefonoContacto.FirstOrDefault().Telefono
                                                };
                                contactos = consulta2.ToList();
                                return contactos;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }



                }
            }
            catch (Exception ex)
            {
                throw new FaultException("ERROR EN ACCESO A DATOS. " + ex.Message);
            }

        }


        /// <summary>
        /// metodo que realiza una busqueda avanzada por varios campos en las empresas. Se devuelve lo que coincida al comprar en todos los campos por lo que se busque.
        /// </summary>
        /// <param name="nombre">nombre de la empresa</param>
        /// <param name="razon">razon de la empresa</param>
        /// <param name="cif">cif de la empresa</param>
        /// <param name="email">email de la empresa</param>
        /// <param name="web">web de la empresa</param>
        /// <returns>devuelve la lista de empresas que coinciden en la busqueda. Devuelve null si los campos de busqueda estan vacios</returns>
        public List<EmpresaData> BusquedaAvanzadaEmpresa(String nombre, String razon, String cif, String email, String web)
        {
            List<EmpresaData> empresas = new List<EmpresaData>();
            List<EmpresaData> empresas2 = new List<EmpresaData>();
            try
            {
                using (BDCRMEntities datos = new BDCRMEntities())
                {

                    //busqueda avanzada de empresas
                    var consulta2 = from tabla in datos.Empresa
                                    select new EmpresaData
                                    {
                                        ID = tabla.ID,
                                        CIF = tabla.CIF,
                                        RazonSocial = tabla.RazonSocial,
                                        Nombre = tabla.Nombre,
                                        Email = tabla.Email,
                                        Web = tabla.Web,
                                        IDTipoEmpresa = tabla.TipoEmpresa,
                                        TipoEmpresa = tabla.TipoEmpresa1.Tipo,
                                        Telefono = tabla.TelefonoEmpresa.FirstOrDefault().Telefono
                                    };
                    empresas = consulta2.ToList();
                    bool borrado = false;
                    if(nombre == "" && razon == "" && cif == "" && email == "" && web == ""){
                        return null;
                    }else{
                        //vamos descartando empresas segun los campos de busqueda
                        
                        foreach(var ele in empresas){
                            borrado = false;
                            if(nombre != "" && (!ele.Nombre.Contains(nombre)) && borrado == false)
                            {
                                
                                borrado = true;
                            }

                            if (razon != "" && (!ele.RazonSocial.Contains(razon)) && borrado == false)
                            {
                                
                                borrado = true;
                            }

                            if (cif != "" && (!ele.CIF.Contains(cif)) && borrado == false)
                            {
                                
                                borrado = true;
                            }

                            if (email != "" && (!ele.Email.Contains(email)) && borrado == false)
                            {
                                
                                borrado = true;
                            }

                            if (web != "" && (!ele.Web.Contains(web)) && borrado == false)
                            {
                                
                                borrado = true;
                            }

                            if (borrado == false)
                            {
                                empresas2.Add(ele);
                            }

                            
                            
                        }
                        


                        return empresas2;
                    }
                    

                    

                }
            }
            catch (Exception ex)
            {
                throw new FaultException("ERROR EN ACCESO A DATOS. " + ex.Message);
            }

        }



        /// <summary>
        /// metodo que realiza una busqueda avanzada por varios campos en las acciones. Se devuelve lo que coincida al comprar en todos los campos por lo que se busque.
        /// </summary>
        /// <param name="comentario">comentario de la accion</param>
        /// <param name="descripcion">descripcion de la accion</param>
        /// <param name="tipo">tipo de la accion</param>
        /// <param name="estado">estado de la accion</param>
        /// <returns>devuelve la lista de acciones que coinciden en la busqueda. Devuelve null si los campos de busqueda estan vacios</returns>
        public List<AccionComercialData> BusquedaAvanzadaAccionComercial(String comentario, String descripcion, String tipo, String estado)
        {
            List<AccionComercialData> acciones = new List<AccionComercialData>();
            List<AccionComercialData> acciones2 = new List<AccionComercialData>();
            try
            {
                using (BDCRMEntities datos = new BDCRMEntities())
                {

                    //busqueda avanzada de acciones
                    var consulta2 = from tabla in datos.AccionComercial
                                    select new AccionComercialData
                                    {
                                        ID = tabla.ID,
                                        Comentarios = tabla.Comentarios,
                                        Descripcion = tabla.Descripcion,
                                        Fecha = tabla.Fecha,
                                        IDAccion = tabla.IDAccion,
                                        IDEmpresa = tabla.IDEmpresa,
                                        IDEstado = tabla.IDEstado,
                                        Estado = tabla.Estado.Estado1,
                                        CIF = tabla.Empresa.CIF,
                                        Usuario = tabla.Usuario,
                                        Username = tabla.User.Username,
                                        Accion = tabla.TipoAccion.Tipo
                                                                           
                                    };
                    acciones = consulta2.ToList();
                    bool borrado = false;
                    if (descripcion == "" && comentario == "" && estado == "" && tipo == "")
                    {
                        return null;
                    }
                    else
                    {
                        //vamos descartando empresas segun los campos de busqueda

                        foreach (var ele in acciones)
                        {
                            borrado = false;
                            if (comentario != "" && (!ele.Comentarios.Contains(comentario)) && borrado == false)
                            {
                               
                                borrado = true;
                            }

                            if (descripcion != "" && (!ele.Descripcion.Contains(descripcion)) && borrado == false)
                            {
                                
                                borrado = true;
                            }

                            if (estado != "" && (!ele.Estado.Contains(estado)) && borrado == false)
                            {
                                
                                borrado = true;
                            }

                            if (tipo != "" && (!ele.Accion.Contains(tipo)) && borrado == false)
                            {
                                
                                borrado = true;
                            }

                            if (!borrado) acciones2.Add(ele);

                        }



                        return acciones2;
                    }

                }
            }
            catch (Exception ex)
            {
                throw new FaultException("ERROR EN ACCESO A DATOS. " + ex.Message);
            }

        }



    }
}




//busqueda avanzada
//AddCargoContacto
//BorrarCargoContacto