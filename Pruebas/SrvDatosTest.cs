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
       
        [TestMethod]
        public void GetAllUsersTest()
        {
            SrvDatos d = new SrvDatos();
            List<UserData> lst = d.GetAllUsers();
            Assert.AreEqual(lst.Count, 3);
            
        }
    }
}
