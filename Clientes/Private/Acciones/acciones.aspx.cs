using Clientes.Models;
using Clientes.ServicioDatos2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clientes.Private.Acciones
{
    public partial class acciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                String s = Request.QueryString["estado"];
                String id = Request.QueryString["id"];
                
                try
                {
                    int estado;
                    int idAccion;

                    estado = -1;
                    idAccion = -1;
                 
                    if (s != null)
                        estado = Int32.Parse(s);
                    //si estado es igual a 0 es para dar de alta una empresa nueva. Si es 1, es para modificar una empresa.
                    if (id != null)
                        idAccion = Int32.Parse(id);

                    SrvDatosClient proxy = new SrvDatosClient();

                    switch (estado)
                    {
                        case 0:

                            this.lbIDAccion.Visible = false;
                            this.tbIDAcciones.Visible = false;
                            this.formGroupID.Visible = false;
                            this.H1Titulo.InnerHtml = "Nueva acción";
                            this.btnAlta.Text = "Alta";
                            this.btnAlta.Visible = true;

                            UserData[] usuarios = proxy.GetAllUsers();

                            tbUsuario.DataSource = usuarios;
                            tbUsuario.DataValueField = "IDUsuario";
                            tbUsuario.DataTextField = "Nombre";
                            tbUsuario.DataBind();

                            TipoAccionData[] tiposAcciones = proxy.GetAllTiposAccion();

                            tbTipoAccion.DataSource = tiposAcciones;
                            tbTipoAccion.DataValueField = "ID";
                            tbTipoAccion.DataTextField = "Tipo";
                            tbTipoAccion.DataBind();

                            EmpresaData[] empresa = proxy.GetAllEmpresas();

                            tbEmpresa.DataSource = empresa;
                            tbEmpresa.DataValueField = "ID";
                            tbEmpresa.DataTextField = "Nombre";
                            tbEmpresa.DataBind();
                            
                            EstadoData[] estados = proxy.GetAllEstados();
                            tbEstado.DataSource = estados;
                            tbEstado.DataValueField = "ID";
                            tbEstado.DataTextField = "Estado";
                            tbEstado.DataBind();

                            break;

                        case 1:

                            this.lbIDAccion.Visible = true;
                            this.lbIDAccion.Visible = true;
                            this.tbIDAcciones.ReadOnly = true;
                            this.H1Titulo.InnerHtml = "Modificar acción";
                            this.btnAlta.Text = "Guardar";
                            this.btnAlta.Visible = true;

                            AccionComercialData accion = proxy.GetAccionComercial(idAccion);

                            tbComentarios.Text = accion.Comentarios;
                            tbDescripcion.Text = accion.Descripcion;
                            tbFecha.Text = accion.Fecha.ToString();
                            tbIDAcciones.Text = accion.ID.ToString();

                            UserData[] usuarios2 = proxy.GetAllUsers();

                            tbUsuario.DataSource = usuarios2;
                            tbUsuario.DataValueField = "IDUsuario";
                            tbUsuario.DataTextField = "Nombre";
                            tbUsuario.SelectedValue = accion.Usuario.ToString();
                            tbUsuario.DataBind();
                        

                            TipoAccionData[] tiposAcciones2 = proxy.GetAllTiposAccion();

                            tbTipoAccion.DataSource = tiposAcciones2;
                            tbTipoAccion.DataValueField = "ID";
                            tbTipoAccion.DataTextField = "Tipo";
                            tbTipoAccion.SelectedValue = accion.IDAccion.ToString();
                            tbTipoAccion.DataBind();

                            EstadoData[] estados2 = proxy.GetAllEstados();
                            tbEstado.DataSource = estados2;
                            tbEstado.DataValueField = "ID";
                            tbEstado.DataTextField = "Estado";
                            tbEstado.SelectedValue = accion.IDEstado.ToString();
                            tbEstado.DataBind();

                            EmpresaData[] empresa2 = proxy.GetAllEmpresas();

                            tbEmpresa.DataSource = empresa2;
                            tbEmpresa.DataValueField = "ID";
                            tbEmpresa.DataTextField = "Nombre";
                            tbEmpresa.SelectedValue = accion.IDEmpresa.ToString();
                            tbEmpresa.DataBind();

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

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                SrvDatosClient proxy = new SrvDatosClient();
                String s = Request.QueryString["estado"];
                int estado = -1;
                if (s != null)
                    estado = Int32.Parse(s);
                switch (estado)
                {
                    case 0:
                        AccionComercialData accion = new AccionComercialData();

                        //accion.ID = Int32.Parse(tbIDAcciones.Text);                        
                        accion.Fecha = DateTime.Parse(tbFecha.Text);
                        accion.Comentarios = tbComentarios.Text;
                        accion.Descripcion = tbDescripcion.Text;
                        accion.IDAccion = Int32.Parse(tbTipoAccion.SelectedValue);
                        accion.IDEstado = Int32.Parse(tbEstado.SelectedValue);
                        accion.IDEmpresa = Int32.Parse(tbEmpresa.SelectedValue);
                        accion.Usuario = Int32.Parse(tbUsuario.SelectedValue);

                        if (proxy.AddAccionComercial(accion) != -1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensaje", "<script type='text/javascript'> alert('ACCIÓN INSERTADA'); </script>", false);
                            
                            List<Clientes.Models.ERROR> historial = new List<Clientes.Models.ERROR>();
                            historial = (List<Clientes.Models.ERROR>)Session["historial"];

                            ERROR err = new ERROR(0, "Acción insertada con exito");
                            historial.Add(err);
                            Session["historial"] = historial;

                            this.Response.Redirect("default.aspx");
                        }
                        else {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensaje", "<script type='text/javascript'> alert('ERROR AL INSERTAR'); </script>", false);
                            List<Clientes.Models.ERROR> historial = new List<Clientes.Models.ERROR>();
                            historial = (List<Clientes.Models.ERROR>)Session["historial"];

                            ERROR err = new ERROR(1, "ERROR al insertada acción");
                            historial.Add(err);
                            Session["historial"] = historial;
                        }
 
                        break;

                    case 1:
                        AccionComercialData accion2 = new AccionComercialData();

                        accion2.ID = Int32.Parse(tbIDAcciones.Text);                        
                        accion2.Fecha = DateTime.Parse(tbFecha.Text);
                        accion2.Comentarios = tbComentarios.Text;
                        accion2.Descripcion = tbDescripcion.Text;
                        accion2.IDAccion = Int32.Parse(tbTipoAccion.SelectedValue);
                        accion2.IDEstado = Int32.Parse(tbEstado.SelectedValue);
                        accion2.IDEmpresa = Int32.Parse(tbEmpresa.SelectedValue);
                        accion2.Usuario = Int32.Parse(tbUsuario.SelectedValue);

                        if (proxy.EditAccionComercial(accion2))
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensaje", "<script type='text/javascript'> alert('ACCIÓN MODIFICADA'); </script>", false);
                        }
                        else {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensaje", "<script type='text/javascript'> alert('ERROR AL MODIFICACIÓN'); </script>", false);
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