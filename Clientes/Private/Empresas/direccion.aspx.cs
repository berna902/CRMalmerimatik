using Clientes.ServicioDatos2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clientes.Private.Empresas
{
    public partial class direccion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                String s = Request.QueryString["estado"];
                String id = Request.QueryString["id"];
                String ide = Request.QueryString["ide"];
                try
                {
                    int estado;
                    int idEmpresa;
                    int idireccion;

                    estado = -1;
                    idEmpresa = -1;
                    idireccion = -1;
                    if (s != null)
                        estado = Int32.Parse(s);
                    //si estado es igual a 0 es para dar de alta una empresa nueva. Si es 1, es para modificar una empresa.
                    if (ide != null)
                        idEmpresa = Int32.Parse(ide);

                    if (id != null)
                        idireccion = Int32.Parse(id);


                    SrvDatosClient proxy = new SrvDatosClient();

                    switch (estado)
                    {
                        case 0:
                            this.lbIDireccion.Visible = false;
                            this.tbIDireccion.Visible = false;
                            this.H1Titulo.InnerHtml = "Nuevo dirección";
                            this.btnAltaDireccion.Text = "Alta";
                            this.btnAltaDireccion.Visible = true;

                            break;

                        case 1:
                            this.lbIDireccion.Visible = true;
                            this.tbIDireccion.Visible = true;
                            this.tbIDireccion.ReadOnly = true;
                            this.H1Titulo.InnerHtml = "Modificar dirección";
                            this.btnAltaDireccion.Text = "Guardar";
                            this.btnAltaDireccion.Visible = true;

                            DireccionData direccion = proxy.GetDireccion(idireccion);

                            tbCP.Text = direccion.CP;
                            tbDomicilio.Text = direccion.Domicilio;
                            tbIDireccion.Text = direccion.ID.ToString();
                            tbPoblacion.Text = direccion.Poblacion;
                            tbProvincia.Text = direccion.Provincia;


                            break;

                        default:
                            Response.Redirect("Default.aspx");
                            break;
                    }

                }
                catch (Exception ex) { }
            }
            else
            {
            }
        }

        protected void btnAltaDireccion_Click(object sender, EventArgs e)
        {
            try
            {
                SrvDatosClient proxy = new SrvDatosClient();
                String s = Request.QueryString["estado"];
                String ide = Request.QueryString["ide"];
                int estado = -1;
                int idEmpresa = -1;
                if (s != null)
                    estado = Int32.Parse(s);
                if (ide != null)
                        idEmpresa = Int32.Parse(ide);
                
                switch (estado)
                {
                    case 0:
                        DireccionData direccion = new DireccionData();
                        direccion.Provincia = tbProvincia.Text;
                        direccion.CP = tbCP.Text;
                        direccion.Domicilio = tbDomicilio.Text;
                        direccion.Poblacion = tbPoblacion.Text;
                        
                        int id = proxy.AddDireccionEmpresa(direccion,idEmpresa);
                        if (id != -1)
                        {
                            
                            Response.Redirect("empresa.aspx?estado=1&id=" + idEmpresa);
                            //string script = "alert('No se pudo modificar la empresa');";
                            //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
                        }
                        else
                        {
                            string script = "alert('No se pudo insertar la direccion');";
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
                        }

                        break;

                    case 1:
                        DireccionData direccion2 = new DireccionData();
                        direccion2.Provincia = tbProvincia.Text;
                        direccion2.CP = tbCP.Text;
                        direccion2.Domicilio = tbDomicilio.Text;
                        direccion2.Poblacion = tbPoblacion.Text;

                        if (proxy.EditDireccion(direccion2))
                        {

                            Response.Redirect("empresa.aspx?estado=1&id=" + idEmpresa);
                            //string script = "alert('No se pudo modificar la empresa');";
                            //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
                        }
                        else
                        {
                            string script = "alert('No se pudo modificar la direccion');";
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex) { }
        }
    }
}