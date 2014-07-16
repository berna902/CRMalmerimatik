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
        /// <summary>
        /// Test del metodo GetAllUsers
        /// </summary>
        [TestMethod]
        public void GetAllUsersTest()
        {
            SrvDatos d = new SrvDatos();
            List<UserData> lst = d.GetAllUsers();
            Assert.AreEqual(lst.Count, 3);
            
        }

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



    }
}
