using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using almerimatik.ServicioCRM;

namespace Pruebas
{
    /// <summary>
    /// Summary description for SrvDatosTest
    /// </summary>
    [TestClass]
    public class SrvDatosTest
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // USUARIOS
        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Test del metodo GetAllUsers
        /// </summary>
        [TestMethod]
        public void GetAllUsersTest()
        {
            //comprobamos cuantos usuarios hay en la BD
            SrvDatos d = new SrvDatos();
            List<UserData> lst = d.GetAllUsers();
            int contador1 = lst.Count;

            //insertamos un usuario nuevo
            UserData u = new UserData();
            u.Nombre = "Flanders";
            u.Username = "Amiguito";
            u.Password = "holahola";
            int id = d.AddUser(u);

            //volvemos a ver cuantos usuarios hay
            lst = d.GetAllUsers();
            int contador2 = lst.Count;

            //comprobamos que ha aumentado en uno
            Assert.AreEqual(contador1 + 1, contador2);

            //borramos el usuario creada
            bool b = d.BorrarUser(id);
            
        }

        /// <summary>
        /// Test del metodo AddUser
        /// </summary>
        [TestMethod]
        public void AddUserTest()
        {
            
            SrvDatos d = new SrvDatos();
           
            //insertamos un usuario nuevo
            UserData u = new UserData();
            u.Nombre = "Flanders";
            u.Username = "Amiguito";
            u.Password = "holahola";
            int id = d.AddUser(u);

            
            //comprobamos que ha aumentado en uno
            Assert.AreNotEqual(id, -1);

            //borramos el usuario creado
            bool b = d.BorrarUser(id);
        }

        /// <summary>
        /// Test del metodo BorrarUser
        /// </summary>
        [TestMethod]
        public void BorrarUserTest()
        {
            SrvDatos d = new SrvDatos();

            //insertamos un usuario nuevo
            UserData u = new UserData();
            u.Nombre = "Flanders";
            u.Username = "Amiguito";
            u.Password = "holahola";
            int id = d.AddUser(u);


            //borramos el usuario creado
            bool b = d.BorrarUser(id);

            //comprobamos que ha aumentado en uno
            Assert.AreEqual(b, true);
        }

        /// <summary>
        /// Test del metodo EditUser
        /// </summary>
        [TestMethod]
        public void EditUserTest()
        {
            SrvDatos d = new SrvDatos();
            UserData u = d.GetUser(2);
            if (u.Nombre == "berna")
            {
                u.Nombre = "PAKITO";
            }
            else
            {
                u.Nombre = "berna";
            }
            bool b = d.EditUser(u);
            Assert.AreEqual(b, true);
        }
        
        /// <summary>
        /// Test del metodo GetUser
        /// </summary>
        [TestMethod]
        public void GetUserTest()
        {
            SrvDatos d = new SrvDatos();
            UserData u = d.GetUser(23);
            Assert.AreEqual(u.Username, "admin");
        }


        /// <summary>
        /// Test del metodo ExisteUser
        /// </summary>
        [TestMethod]
        public void ExisteUserTest()
        {
            SrvDatos d = new SrvDatos();
            UserData u = new UserData();
            u.Username = "admin";
            bool b = d.ExisteUser(u);
            Assert.AreEqual(b, true);
        }


        /// <summary>
        /// Test del metodo ValidarUser
        /// </summary>
        [TestMethod]
        public void ValidarUserTest()
        {
            SrvDatos d = new SrvDatos();
            bool b = d.ValidaUser("admin", "admin");
            Assert.AreEqual(b,true);
        }

        //////////////////////////////////////////////////////////////////////////
        // EMPRESAS
        /////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// Test del metodo GetAllEmpresas
        /// </summary>
        [TestMethod]
        public void GetAllEmpresasTest()
        {
            //comprobamos cuantas empresas hay en la BD
            SrvDatos d = new SrvDatos();
            List<EmpresaData> lst = d.GetAllEmpresas();
            int contador1 = lst.Count;

            //insertamos una empresa nueva
            EmpresaData emp = new EmpresaData();
            emp.CIF = "75721776B";
            emp.Web = "www.webempresa.com";
            emp.IDTipoEmpresa = 1;
            emp.Email = "email@empresa.com";
            emp.Nombre = "mi empresa";
            emp.RazonSocial = "empresa SL";
            int id = d.AddEmpresa(emp);

            //volvemos a ver cuantas empresas hay
            lst = d.GetAllEmpresas();
            int contador2 = lst.Count;

            //comprobamos que ha aumentado en uno
            Assert.AreEqual(contador1 +1, contador2);

            //borramos la empresa creada
            bool b = d.BorrarEmpresa(id);
        }


        /// <summary>
        /// Test del metodo AddEmpresa
        /// </summary>
        [TestMethod]
        public void AddEmpresaTest()
        {
            //insertamos una empresa nueva
            SrvDatos d = new SrvDatos();
            EmpresaData emp = new EmpresaData();
            emp.CIF = "75721776B";
            emp.Web = "www.webempresa.com";
            emp.IDTipoEmpresa = 1;
            emp.Email = "email@empresa.com";
            emp.Nombre = "mi empresa";
            emp.RazonSocial = "empresa SL";
            int id = d.AddEmpresa(emp);

            //comprobamos que devuelve verdadero la accion
            Assert.AreNotEqual(id,-1);

            //borramos la empresa creada
            bool b = d.BorrarEmpresa(id);
        }


        /// <summary>
        /// Test del metodo BorrarEmpresa
        /// </summary>
        [TestMethod]
        public void BorrarEmpresaTest()
        {
            //insertamos una empresa nueva
            SrvDatos d = new SrvDatos();
            EmpresaData emp = new EmpresaData();
            emp.CIF = "75721776B";
            emp.Web = "www.webempresa.com";
            emp.IDTipoEmpresa = 1;
            emp.Email = "email@empresa.com";
            emp.Nombre = "mi empresa";
            emp.RazonSocial = "empresa SL";
            int id = d.AddEmpresa(emp);

            //borramos la empresa creada
            bool b = d.BorrarEmpresa(id);

            //comprobamos que devuelve verdadero la accion
            Assert.AreEqual(b, true);
        }


        /// <summary>
        /// Test del metodo GetEmpresa
        /// </summary>
        [TestMethod]
        public void GetEmpresaTest()
        {
            SrvDatos d = new SrvDatos();
            EmpresaData emp = d.GetEmpresa(2);
            Assert.AreEqual(emp.CIF,"75721776A");
        }



        /// <summary>
        /// Test del metodo EditarEmpresa
        /// </summary>
        [TestMethod]
        public void EditEmpresaTest()
        {
            SrvDatos d = new SrvDatos();
            EmpresaData emp = d.GetEmpresa(2);
            if (emp.IDTipoEmpresa == 1)
            {
                emp.IDTipoEmpresa = 2;
            }
            else
            {
                emp.IDTipoEmpresa = 1;
            }
            bool b = d.EditEmpresa(emp);
            Assert.AreEqual(b, true);
        }


        /// <summary>
        /// Test del metodo ExisteEmpresa
        /// </summary>
        [TestMethod]
        public void ExisteEmpresaTest()
        {
            SrvDatos d = new SrvDatos();
            EmpresaData e = new EmpresaData();
            e.CIF = "75721776A";
            bool b = d.ExisteEmpresa(e);
            Assert.AreEqual(b, true);
        }

        //////////////////////////////////////////////////////////////////////////////////////
        // TIPO DE EMPRESA
        /////////////////////////////////////////////////////////////////////////////
        
        /// <summary>
        /// Test del metodo GetAllTiposEmpresa
        /// </summary>
        [TestMethod]
        public void GetAllTiposEmpresaTest()
        {
            //comprobamos cuantos tipos de empresas hay en la BD
            SrvDatos d = new SrvDatos();
            List<TipoEmpresaData> lst = d.GetAllTiposEmpresa();
            int contador1 = lst.Count;

            //insertamos un tipo de empresa nuevo
            TipoEmpresaData emp = new TipoEmpresaData();
            emp.Tipo = "CHUSQUERA";
            int id = d.AddTipoEmpresa(emp.Tipo);

            //volvemos a ver cuantos tipos de empresas hay
            lst = d.GetAllTiposEmpresa();
            int contador2 = lst.Count;

            //comprobamos que ha aumentado en uno
            Assert.AreEqual(contador1 + 1, contador2);

            //borramos el tipo de empresa creado
            bool b = d.BorrarTipoEmpresa(id);
        }


        /// <summary>
        /// Test del metodo AddTipoEmpresa
        /// </summary>
        [TestMethod]
        public void AddTipoEmpresaTest()
        {
            
            SrvDatos d = new SrvDatos();
            
            //insertamos un tipo de empresa nuevo
            TipoEmpresaData emp = new TipoEmpresaData();
            emp.Tipo = "CHUSQUERA";
            int id = d.AddTipoEmpresa(emp.Tipo);

            //comprobamos que se ha insertado
            Assert.AreNotEqual(id, -1);

            //borramos el tipo de empresa creado
            bool b = d.BorrarTipoEmpresa(id);
        }

        /// <summary>
        /// Test del metodo BorrarTipoEmpresa
        /// </summary>
        [TestMethod]
        public void BorrarTipoEmpresaTest()
        {
            SrvDatos d = new SrvDatos();

            //insertamos un tipo de empresa nuevo
            TipoEmpresaData emp = new TipoEmpresaData();
            emp.Tipo = "CHUSQUERA";
            int id = d.AddTipoEmpresa(emp.Tipo);

            
            //borramos el tipo de empresa creado
            bool b = d.BorrarTipoEmpresa(id);

            //comprobamos que se ha borrado
            Assert.AreEqual(b, true);
        }

        /// <summary>
        /// Test del metodo GetTipoEmpresa
        /// </summary>
        [TestMethod]
        public void GetTipoEmpresaTest()
        {
            SrvDatos d = new SrvDatos();
            TipoEmpresaData ted = d.GetTipoEmpresa(1);
            Assert.AreEqual(ted.Tipo, "S.L.");
        }




        ////////////////////////////////////////////////////////////////////////////////////
        // TIPOS DE ACCIONES
        /////////////////////////////////////////////////////////////////////////////////
        

        /// <summary>
        /// Test del metodo GetAllTiposAccion
        /// </summary>
        [TestMethod]
        public void GetAllTiposAccionTest()
        {
            //comprobamos cuantos tipos de accion hay en la BD
            SrvDatos d = new SrvDatos();
            List<TipoAccionData> lst = d.GetAllTiposAccion();
            int contador1 = lst.Count;

            //insertamos un tipo de accion nuevo
            TipoAccionData emp = new TipoAccionData();
            emp.Tipo = "CHUSQUERA";
            int id = d.AddTipoAccion(emp.Tipo);

            //volvemos a ver cuantos tipos de accion hay
            lst = d.GetAllTiposAccion();
            int contador2 = lst.Count;

            //comprobamos que ha aumentado en uno
            Assert.AreEqual(contador1 + 1, contador2);

            //borramos el tipo de accion creado
            bool b = d.BorrarTipoAccion(id);
        }

        /// <summary>
        /// Test del metodo AddTipoAccion
        /// </summary>
        [TestMethod]
        public void AddTipoAccionTest()
        {

            SrvDatos d = new SrvDatos();

            //insertamos un tipo de Accion nuevo
            TipoAccionData emp = new TipoAccionData();
            emp.Tipo = "CHUSQUERA";
            int id = d.AddTipoAccion(emp.Tipo);

            //comprobamos que se ha insertado
            Assert.AreNotEqual(id, -1);

            //borramos el tipo de Accion creado
            bool b = d.BorrarTipoAccion(id);
        }

        /// <summary>
        /// Test del metodo BorrarTipoAccion
        /// </summary>
        [TestMethod]
        public void BorrarTipoAccionTest()
        {
            SrvDatos d = new SrvDatos();

            //insertamos un tipo de Accion nuevo
            TipoAccionData emp = new TipoAccionData();
            emp.Tipo = "CHUSQUERA";
            int id = d.AddTipoAccion(emp.Tipo);


            //borramos el tipo de Accion creado
            bool b = d.BorrarTipoAccion(id);

            //comprobamos que se ha borrado
            Assert.AreEqual(b, true);
        }

        /// <summary>
        /// Test del metodo GetTipoAccion
        /// </summary>
        [TestMethod]
        public void GetTipoAccionTest()
        {
            SrvDatos d = new SrvDatos();
            TipoAccionData ted = d.GetTipoAccion(1);
            Assert.AreEqual(ted.Tipo, "Alta");
        }


        ////////////////////////////////////////////////////////////////////////////////////////////
        // CONTACTOS DE EMPRESAS
        //////////////////////////////////////////////////////////////////////////////////////////
        

        /// <summary>
        /// Test del metodo GetAllContactos
        /// </summary>
        [TestMethod]
        public void GetAllContactosTest()
        {
            //comprobamos cuantos usuarios hay
            SrvDatos d = new SrvDatos();
            List<ContactoData> lst = d.GetAllContactos();
            int contador1 = lst.Count;

            //insertamos un usuario nuevo
            ContactoData u = new ContactoData();
            u.Nombre = "Flanders";
            u.Email = "contacto@mail.com";
            u.IDEmpresa = 2;
            
            int id = d.AddContacto(u);

            //volvemos a ver cuantos usuarios hay
            lst = d.GetAllContactos();
            int contador2 = lst.Count;

            //comprobamos que ha aumentado en uno
            Assert.AreEqual(contador1 + 1, contador2);

            //borramos el contacto creado
            bool b = d.BorrarContacto(id);
        }

        /// <summary>
        /// Test del metodo GetAllContactosEmpresa
        /// </summary>
        [TestMethod]
        public void GetAllContactosEmpresaTest()
        {
            //comprobamos cuantos usuarios hay
            SrvDatos d = new SrvDatos();
            List<ContactoData> lst = d.GetAllContactosEmpresa(2);
            int contador1 = lst.Count;

            //insertamos un usuario nuevo
            ContactoData u = new ContactoData();
            u.Nombre = "Flanders";
            u.Email = "contacto@mail.com";
            u.IDEmpresa = 2;

            int id = d.AddContacto(u);

            //volvemos a ver cuantos usuarios hay
            lst = d.GetAllContactosEmpresa(2);
            int contador2 = lst.Count;

            //comprobamos que ha aumentado en uno
            Assert.AreEqual(contador1 + 1, contador2);

            //borramos el contacto creado
            bool b = d.BorrarContacto(id);
        }


        /// <summary>
        /// Test del metodo GetContacto
        /// </summary>
        [TestMethod]
        public void GetContactoTest()
        {
            SrvDatos d = new SrvDatos();
            ContactoData u = d.GetContacto(1);
            Assert.AreEqual(u.Email, "laurica@gmail.com");
        }


        /// <summary>
        /// Test del metodo AddContacto
        /// </summary>
        [TestMethod]
        public void AddContactoTest()
        {
            SrvDatos d = new SrvDatos();

            //insertamos un usuario nuevo
            ContactoData u = new ContactoData();
            u.Nombre = "Flanders";
            u.IDEmpresa = 2;
            u.Email = "contacto@email.com";
            int id = d.AddContacto(u);


            //comprobamos que ha aumentado en uno
            Assert.AreNotEqual(id, -1);

            //borramos el usuario creado
            bool b = d.BorrarContacto(id);
        }


        /// <summary>
        /// Test del metodo BorrarContacto
        /// </summary>
        [TestMethod]
        public void BorrarContactoTest()
        {
            SrvDatos d = new SrvDatos();

            //insertamos un usuario nuevo
            ContactoData u = new ContactoData();
            u.Nombre = "Flanders";
            u.IDEmpresa = 2;
            u.Email = "contacto@email.com";
            int id = d.AddContacto(u);

            //borramos el usuario creado
            bool b = d.BorrarContacto(id);
            //comprobamos que no da error al borrar
            Assert.AreEqual(b, true);
        }

        /// <summary>
        /// Test del metodo EditContacto
        /// </summary>
        [TestMethod]
        public void EditContactoTest()
        {
            SrvDatos d = new SrvDatos();
            ContactoData u = d.GetContacto(1);
            if (u.Nombre == "laura")
            {
                u.Nombre = "PAKITA";
            }
            else
            {
                u.Nombre = "laura";
            }
            bool b = d.EditContacto(u);
            Assert.AreEqual(b, true);
        }


        //////////////////////////////////////////////////////////////////////////////////////////
        // ACCIONES COMERCIALES
        //////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// Test del metodo GetAllAccionesComerciales
        /// </summary>
        [TestMethod]
        public void GetAllAccionesComercialesTest()
        {
            //comprobamos cuantas acciones hay
            SrvDatos d = new SrvDatos();
            List<AccionComercialData> lst = d.GetAllAccionesComerciales();
            int contador1 = lst.Count;

            //insertamos una accion nueva
            AccionComercialData u = new AccionComercialData();
            u.Comentarios = "Flanders";
            u.Descripcion = "contacto@mail.com";
            u.IDAccion = 1;
            u.IDEstado = 1;
            u.IDEmpresa = 2;
            u.Usuario = 2;
            u.Fecha = DateTime.Now;         

            int id = d.AddAccionComercial(u);

            //volvemos a ver cuantas acciones hay
            lst = d.GetAllAccionesComerciales();
            int contador2 = lst.Count;

            //comprobamos que ha aumentado en uno
            Assert.AreEqual(contador1 + 1, contador2);

            //borramos la accion creado
            bool b = d.BorrarAccionComercial(id);
        }

        /// <summary>
        /// Test del metodo GetAllAccionComercialEmpresa
        /// </summary>
        [TestMethod]
        public void GetAllAccionComercialEmpresaTest()
        {
            //comprobamos cuantas acciones hay
            SrvDatos d = new SrvDatos();
            List<AccionComercialData> lst = d.GetAllAccionesComercialesEmpresa(2);
            int contador1 = lst.Count;

            //insertamos una accion nueva
            AccionComercialData u = new AccionComercialData();
            u.Comentarios = "Flanders";
            u.Descripcion = "contacto@mail.com";
            u.IDAccion = 1;
            u.IDEstado = 1;
            u.IDEmpresa = 2;
            u.Usuario = 2;
            u.Fecha = DateTime.Now;
            int id = d.AddAccionComercial(u);

            //volvemos a ver cuantas acciones hay
            lst = d.GetAllAccionesComercialesEmpresa(2);
            int contador2 = lst.Count;

            //comprobamos que ha aumentado en uno
            Assert.AreEqual(contador1 + 1, contador2);

            //borramos la accion creada
            bool b = d.BorrarAccionComercial(id);
        }


        /// <summary>
        /// Test del metodo GetAllAccionComercialUsuario
        /// </summary>
        [TestMethod]
        public void GetAllAccionComercialUsuarioTest()
        {
            //comprobamos cuantas acciones hay
            SrvDatos d = new SrvDatos();
            List<AccionComercialData> lst = d.GetAllAccionesComercialesUsuario(2);
            int contador1 = lst.Count;

            //insertamos una accion nueva
            AccionComercialData u = new AccionComercialData();
            u.Comentarios = "Flanders";
            u.Descripcion = "contacto@mail.com";
            u.IDAccion = 1;
            u.IDEstado = 1;
            u.IDEmpresa = 2;
            u.Usuario = 2;
            u.Fecha = DateTime.Now;
            int id = d.AddAccionComercial(u);

            //volvemos a ver cuantas acciones hay
            lst = d.GetAllAccionesComercialesUsuario(2);
            int contador2 = lst.Count;

            //comprobamos que ha aumentado en uno
            Assert.AreEqual(contador1 + 1, contador2);

            //borramos la accion creada
            bool b = d.BorrarAccionComercial(id);
        }


        /// <summary>
        /// Test del metodo GetAccionComercial
        /// </summary>
        [TestMethod]
        public void GetAccionComercialTest()
        {
            SrvDatos d = new SrvDatos();
            AccionComercialData u = d.GetAccionComercial(2);
            Assert.AreEqual(u.Usuario, 1);
        }


        /// <summary>
        /// Test del metodo AddAccionComercial
        /// </summary>
        [TestMethod]
        public void AddAccionComercialTest()
        {
            SrvDatos d = new SrvDatos();

            //insertamos una accion nueva
            AccionComercialData u = new AccionComercialData();
            u.Comentarios = "Flanders";
            u.Descripcion = "contacto@mail.com";
            u.IDAccion = 1;
            u.IDEstado = 1;
            u.IDEmpresa = 2;
            u.Usuario = 2;
            u.Fecha = DateTime.Now;
            int id = d.AddAccionComercial(u);


            //comprobamos que no hay error
            Assert.AreNotEqual(id, -1);

            //borramos la accion creado
            bool b = d.BorrarAccionComercial(id);
        }


        /// <summary>
        /// Test del metodo BorrarAccionComercial
        /// </summary>
        [TestMethod]
        public void BorrarAccionComercialTest()
        {
            SrvDatos d = new SrvDatos();

            //insertamos una accion nueva
            AccionComercialData u = new AccionComercialData();
            u.Comentarios = "Flanders";
            u.Descripcion = "contacto@mail.com";
            u.IDAccion = 1;
            u.IDEstado = 1;
            u.IDEmpresa = 2;
            u.Usuario = 2;
            u.Fecha = DateTime.Now;
            int id = d.AddAccionComercial(u);

            //borramos la accion creada
            bool b = d.BorrarAccionComercial(id);
            //comprobamos que no da error al borrar
            Assert.AreEqual(b, true);
        }

        /// <summary>
        /// Test del metodo EditAccionComercial
        /// </summary>
        [TestMethod]
        public void EditAccionComercialTest()
        {
            SrvDatos d = new SrvDatos();
            AccionComercialData u = d.GetAccionComercial(2);
            
            if (u.Comentarios == "este comentario explica la accion")
            {
                u.Comentarios = "este comentario esta editado";
            }
            else
            {
                u.Comentarios = "este comentario explica la accion";
            }
            bool b = d.EditAccionComercial(u);
            Assert.AreEqual(b, true);
        }


        //////////////////////////////////////////////////////////////////////////////////////////
        // TELEFONOS
        //////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// Test del metodo GetAllTelefonosEmpresa
        /// </summary>
        [TestMethod]
        public void GetAllTelefonosEmpresaTest()
        {
            //comprobamos cuantos telefonos hay
            SrvDatos d = new SrvDatos();
            List<TelefonosData> lst = d.GetAllTelefonosEmpresa(2);
            int contador1 = lst.Count;

            //insertamos un telefono nuevo
            TelefonosData u = new TelefonosData();
            u.ID = 2;
            u.Telefono = "699999996";
            
            bool b = d.AddTelefonoEmpresa(u);

            //volvemos a ver cuantos telefonos hay
            lst = d.GetAllTelefonosEmpresa(2);
            int contador2 = lst.Count;

            //comprobamos que ha aumentado en uno
            Assert.AreEqual(contador1 + 1, contador2);

            //borramos el telefono creado
            b = d.BorrarTelefonoEmpresa(u.Telefono);
        }


        /// <summary>
        /// Test del metodo AddTelefonoEmpresa
        /// </summary>
        [TestMethod]
        public void AddTelefonoEmpresaTest()
        {
            //comprobamos cuantos telefonos hay
            SrvDatos d = new SrvDatos();
            List<TelefonosData> lst = d.GetAllTelefonosEmpresa(2);
            int contador1 = lst.Count;

            //insertamos un telefono nuevo
            TelefonosData u = new TelefonosData();
            u.ID = 2;
            u.Telefono = "699999996";

            bool b = d.AddTelefonoEmpresa(u);
            Assert.AreEqual(b, true);

            //volvemos a ver cuantos telefonos hay
            lst = d.GetAllTelefonosEmpresa(2);
            int contador2 = lst.Count;

           
           

            //borramos el telefono creado
            b = d.BorrarTelefonoEmpresa(u.Telefono);
        }


        /// <summary>
        /// Test del metodo BorrarTelefonoEmpresa
        /// </summary>
        [TestMethod]
        public void BorrarTelefonoEmpresaTest()
        {
            //comprobamos cuantos telefonos hay
            SrvDatos d = new SrvDatos();
            List<TelefonosData> lst = d.GetAllTelefonosEmpresa(2);
            int contador1 = lst.Count;

            //insertamos un telefono nuevo
            TelefonosData u = new TelefonosData();
            u.ID = 2;
            u.Telefono = "699999996";

            bool b = d.AddTelefonoEmpresa(u);

            //volvemos a ver cuantos telefonos hay
            lst = d.GetAllTelefonosEmpresa(2);
            int contador2 = lst.Count;

            

            //borramos el telefono creado
            b = d.BorrarTelefonoEmpresa(u.Telefono);
            Assert.AreEqual(b, true);
        }


        /// <summary>
        /// Test del metodo GetAllTelefonosContacto
        /// </summary>
        [TestMethod]
        public void GetAllTelefonosContactoTest()
        {
            //comprobamos cuantos telefonos hay
            SrvDatos d = new SrvDatos();
            List<TelefonosData> lst = d.GetAllTelefonosContacto(1);
            int contador1 = lst.Count;

            //insertamos un telefono nuevo
            TelefonosData u = new TelefonosData();
            u.ID = 1;
            u.Telefono = "699999996";

            bool b = d.AddTelefonoContacto(u);

            //volvemos a ver cuantos telefonos hay
            lst = d.GetAllTelefonosContacto(1);
            int contador2 = lst.Count;

            //comprobamos que ha aumentado en uno
            Assert.AreEqual(contador1 + 1, contador2);

            //borramos el telefono creado
            b = d.BorrarTelefonoContacto(u.Telefono);
        }


        /// <summary>
        /// Test del metodo AddTelefonoContacto
        /// </summary>
        [TestMethod]
        public void AddTelefonoContactoTest()
        {
            //comprobamos cuantos telefonos hay
            SrvDatos d = new SrvDatos();
            List<TelefonosData> lst = d.GetAllTelefonosContacto(1);
            int contador1 = lst.Count;

            //insertamos un telefono nuevo
            TelefonosData u = new TelefonosData();
            u.ID = 1;
            u.Telefono = "699999996";

            bool b = d.AddTelefonoContacto(u);
            Assert.AreEqual(b, true);

            //volvemos a ver cuantos telefonos hay
            lst = d.GetAllTelefonosContacto(1);
            int contador2 = lst.Count;
            
            //borramos el telefono creado
            b = d.BorrarTelefonoContacto(u.Telefono);
        }


        /// <summary>
        /// Test del metodo BorrarTelefonoContacto
        /// </summary>
        [TestMethod]
        public void BorrarTelefonoContactoTest()
        {
            //comprobamos cuantos telefonos hay
            SrvDatos d = new SrvDatos();
            List<TelefonosData> lst = d.GetAllTelefonosContacto(1);
            int contador1 = lst.Count;

            //insertamos un telefono nuevo
            TelefonosData u = new TelefonosData();
            u.ID = 1;
            u.Telefono = "699999996";

            bool b = d.AddTelefonoContacto(u);

            //volvemos a ver cuantos telefonos hay
            lst = d.GetAllTelefonosContacto(1);
            int contador2 = lst.Count;
            
            //borramos el telefono creado
            b = d.BorrarTelefonoContacto(u.Telefono);
            Assert.AreEqual(b, true);
        }




        //////////////////////////////////////////////////////////////////////////////////////////
        // ESTADOS
        //////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// Test del metodo GetAllEstados
        /// </summary>
        [TestMethod]
        public void GetAllEstadosTest()
        {
            //comprobamos cuantos estados hay en la BD
            SrvDatos d = new SrvDatos();
            List<EstadoData> lst = d.GetAllEstados();
            int contador1 = lst.Count;

            //insertamos un estado nuevo
            EstadoData emp = new EstadoData();
            emp.Estado = "EMPERRADO";
            int id = d.AddEstado(emp.Estado);

            //volvemos a ver cuantos estados hay
            lst = d.GetAllEstados();
            int contador2 = lst.Count;

            //comprobamos que ha aumentado en uno
            Assert.AreEqual(contador1 + 1, contador2);

            //borramos el estado creado
            bool b = d.BorrarEstado(id);
        }

        /// <summary>
        /// Test del metodo AddEstado
        /// </summary>
        [TestMethod]
        public void AddEstadoTest()
        {

            SrvDatos d = new SrvDatos();

            //insertamos un estado nuevo
            EstadoData emp = new EstadoData();
            emp.Estado = "EMPERRADO";
            int id = d.AddEstado(emp.Estado);

            //comprobamos que se ha insertado
            Assert.AreNotEqual(id, -1);

            //borramos el estado creado
            bool b = d.BorrarEstado(id);
        }

        /// <summary>
        /// Test del metodo BorrarEstado
        /// </summary>
        [TestMethod]
        public void BorrarEstadoTest()
        {
            SrvDatos d = new SrvDatos();

            //insertamos un estado nuevo
            EstadoData emp = new EstadoData();
            emp.Estado = "EMPERRADO";
            int id = d.AddEstado(emp.Estado);


            //borramos el estado creado
            bool b = d.BorrarEstado(id);

            //comprobamos que se ha borrado
            Assert.AreEqual(b, true);
        }

        /// <summary>
        /// Test del metodo GetEstado
        /// </summary>
        [TestMethod]
        public void GetEstadoTest()
        {
            SrvDatos d = new SrvDatos();
            EstadoData ted = d.GetEstado(1);
            Assert.AreEqual(ted.Estado, "Abierta");
        }


        //////////////////////////////////////////////////////////////////////////////////////////
        // CARGOS
        //////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// Test del metodo GetAllCargos
        /// </summary>
        [TestMethod]
        public void GetAllCargosTest()
        {
            //comprobamos cuantos cargos hay en la BD
            SrvDatos d = new SrvDatos();
            List<CargoData> lst = d.GetAllCargos();
            int contador1 = lst.Count;

            //insertamos un cargo nuevo
            CargoData emp = new CargoData();
            emp.Cargo = "JEFE GOBIERNO";
            int id = d.AddCargo(emp.Cargo);

            //volvemos a ver cuantos cargos hay
            lst = d.GetAllCargos();
            int contador2 = lst.Count;

            //comprobamos que ha aumentado en uno
            Assert.AreEqual(contador1 + 1, contador2);

            //borramos el cargo creado
            bool b = d.BorrarCargo(id);
        }


        /// <summary>
        /// Test del metodo GetAllCargosContacto
        /// </summary>
        [TestMethod]
        public void GetAllCargosContactoTest()
        {
            //comprobamos cuantos cargos tiene un contacto
            SrvDatos d = new SrvDatos();
            List<CargoData> lst = d.GetAllCargosContacto(1);
            Assert.AreEqual(lst.Count,2);
        }

        /// <summary>
        /// Test del metodo AddCargo
        /// </summary>
        [TestMethod]
        public void AddCargoTest()
        {

            SrvDatos d = new SrvDatos();

            //insertamos un cargo nuevo
            CargoData emp = new CargoData();
            emp.Cargo = "PRESIDENTE";
            int id = d.AddCargo(emp.Cargo);

            //comprobamos que se ha insertado
            Assert.AreNotEqual(id, -1);

            //borramos el cargo creado
            bool b = d.BorrarCargo(id);
        }

        /// <summary>
        /// Test del metodo BorrarCargo
        /// </summary>
        [TestMethod]
        public void BorrarCargoTest()
        {
            SrvDatos d = new SrvDatos();

            //insertamos un cargo nuevo
            CargoData emp = new CargoData();
            emp.Cargo = "PRESIDENTE";
            int id = d.AddCargo(emp.Cargo);


            //borramos el cargo creado
            bool b = d.BorrarCargo(id);

            //comprobamos que se ha borrado
            Assert.AreEqual(b, true);
        }

        /// <summary>
        /// Test del metodo GetCargo
        /// </summary>
        [TestMethod]
        public void GetCargoTest()
        {
            SrvDatos d = new SrvDatos();
            CargoData ted = d.GetCargo(1);
            Assert.AreEqual(ted.Cargo, "Administrador");
        }


        //////////////////////////////////////////////////////////////////////////////////////////
        // DIRECCIONES
        //////////////////////////////////////////////////////////////////////////////////////

    }
}
