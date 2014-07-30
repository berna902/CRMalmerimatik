using Clientes.ServicioDatos2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clientes.Private
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SrvDatosClient proxy = new SrvDatosClient();
            AccionComercialData[] acciones = proxy.GetAllAccionesComerciales();
            EmpresaData[] empresas = proxy.GetAllEmpresas();
            UserData[] usuarios = proxy.GetAllUsers();

            this.lbNAcciones.Text = acciones.Length.ToString();
            this.lbNEmpresas.Text = empresas.Length.ToString();
            this.lbNUsuarios.Text = usuarios.Length.ToString();

            
        }
    }
}