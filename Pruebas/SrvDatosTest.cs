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
            UserData u = d.GetUser(2);
            Assert.AreEqual(u.Username, "berna");
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
            emp.CIF = "75721776A";
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
            emp.CIF = "75721776A";
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
            emp.CIF = "75721776A";
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

    }
}
