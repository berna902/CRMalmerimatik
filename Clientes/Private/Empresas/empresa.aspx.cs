using Clientes.Models;
using Clientes.ServicioDatos2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clientes.Private.Empresas
{
    public partial class empresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            //SrvDatosClient proxy = new SrvDatosClient();
            if (!this.IsPostBack)
            {
                String s = Request.QueryString["estado"];
                String id = Request.QueryString["id"];
                try
                {
                    int estado;
                    int idEmpresa;

                    estado = -1;
                    idEmpresa = -1;
                    if (s != null)
                        estado = Int32.Parse(s);
                    //si estado es igual a 0 es para dar de alta una empresa nueva. Si es 1, es para modificar una empresa.
                    if (id != null)
                        idEmpresa = Int32.Parse(id);

                    SrvDatosClient proxy = new SrvDatosClient();
                    
                    TipoEmpresaData[] tiposEmpresas = proxy.GetAllTiposEmpresa();

                    switch (estado)
                    {
                        case 0:
                            this.lbIDEmpresa.Visible = false;
                            this.tbIDEmpresa.Visible = false;
                            this.H1Titulo.InnerHtml = "Alta de empresa";
                            this.btAlta.Text = "Alta";
                            this.btAlta.Visible = true;
                            this.div_contactos_empresa.Visible = false;
                            this.div_direcciones_empresa.Visible = false;
                            //TipoEmpresaData[] tiposEmpresas = proxy.GetAllTiposEmpresa();

                            tbTipoEMpresa.DataSource = tiposEmpresas;
                            tbTipoEMpresa.DataValueField = "ID";
                            tbTipoEMpresa.DataTextField = "Tipo";
                            formularioTelefonos.Visible = true;
                            tbTipoEMpresa.DataBind();

                            break;

                        case 1:
                            this.lbIDEmpresa.Visible = true;
                            this.tbIDEmpresa.Visible = true;
                            this.tbIDEmpresa.ReadOnly = true;
                            this.H1Titulo.InnerHtml = "Modificar empresa";
                            this.btAlta.Text = "Guardar";
                            this.btAlta.Visible = true;

                            EmpresaData empresa = proxy.GetEmpresa(idEmpresa);

                            tbTipoEMpresa.DataSource = tiposEmpresas;
                            tbTipoEMpresa.DataValueField = "ID";
                            tbTipoEMpresa.DataTextField = "Tipo";
                            tbTipoEMpresa.SelectedValue = empresa.IDTipoEmpresa.ToString();
                            tbTipoEMpresa.DataBind();

                            TelefonosData[] telefonos = proxy.GetAllTelefonosEmpresa(idEmpresa);
                            tbTelefonos.DataSource = telefonos;
                            tbTelefonos.DataValueField = "Telefono";
                            tbTelefonos.DataTextField = "Telefono";
                            tbTelefonos.DataBind();

                            this.tbCIF.Text = empresa.CIF;
                            this.tbEmail.Text = empresa.Email;
                            this.tbIDEmpresa.Text = idEmpresa.ToString();
                            this.tbNombre.Text = empresa.Nombre;
                            this.tbRazonSocial.Text = empresa.RazonSocial;
                            this.tbWeb.Text = empresa.Web;


                            ContactoData[] contactos = proxy.GetAllContactosEmpresa(idEmpresa);

                            this.GridView1.DataSource = contactos;
                            this.GridView1.DataBind();
                            //this.tbTipoEMpresa.Text = empresa.TipoEmpresa;

                            DireccionData[] direcciones = proxy.GetAllDireccionesEmpresa(idEmpresa);

                            this.GridView3.DataSource = direcciones;
                            this.GridView3.DataBind();
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

        protected void btAlta_Click(object sender, EventArgs e)
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
                        EmpresaData empresa = new EmpresaData();
                        empresa.Nombre = tbNombre.Text;
                        empresa.IDTipoEmpresa = Int32.Parse(tbTipoEMpresa.SelectedValue);
                        empresa.RazonSocial = tbRazonSocial.Text;
                        empresa.CIF = tbCIF.Text;
                        empresa.Email = tbEmail.Text;
                        empresa.Web = tbWeb.Text;
                        int id = proxy.AddEmpresa(empresa);
                        if(id !=-1){
                            TelefonosData tel = new TelefonosData();
                            tel.ID = id;
                            for (int i = 0; i < tbTelefonos.Items.Count; i++)
                            {
                                tel.Telefono = tbTelefonos.SelectedValue;
                                proxy.AddTelefonoContacto(tel);
                            }
                            List<Clientes.Models.ERROR> historial = new List<Clientes.Models.ERROR>();
                            historial = (List<Clientes.Models.ERROR>)Session["historial"];

                            ERROR err = new ERROR(0, "Empresa insertada con exito");
                            historial.Add(err);
                            Session["historial"] = historial;
                            Response.Redirect("Default.aspx");
                            //string script = "alert('No se pudo modificar la empresa');";
                            //ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
                        }else{
                            List<Clientes.Models.ERROR> historial = new List<Clientes.Models.ERROR>();
                            historial = (List<Clientes.Models.ERROR>)Session["historial"];

                            ERROR err = new ERROR(0, "ERROR al insertar empresa");
                            historial.Add(err);
                            Session["historial"] = historial;
                            string script = "alert('No se pudo insertar la empresa');";
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
                        }

                        break;

                    case 1:
                        EmpresaData empresa2 = new EmpresaData();
                        empresa2.ID = Int32.Parse(tbIDEmpresa.Text);
                        empresa2.Nombre = tbNombre.Text;
                        empresa2.IDTipoEmpresa = Int32.Parse(tbTipoEMpresa.SelectedValue);
                        empresa2.RazonSocial = tbRazonSocial.Text;
                        empresa2.CIF = tbCIF.Text;
                        empresa2.Email = tbEmail.Text;
                        empresa2.Web = tbWeb.Text;
                        if (proxy.EditEmpresa(empresa2))
                        {
                            List<Clientes.Models.ERROR> historial = new List<Clientes.Models.ERROR>();
                            historial = (List<Clientes.Models.ERROR>)Session["historial"];

                            ERROR err = new ERROR(0, "Empresa modificada con exito.");
                            historial.Add(err);
                            Session["historial"] = historial;
                            string script = "alert('Empresa modificada con exito.');";
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
                        }
                        else {
                            List<Clientes.Models.ERROR> historial = new List<Clientes.Models.ERROR>();
                            historial = (List<Clientes.Models.ERROR>)Session["historial"];

                            ERROR err = new ERROR(0, "ERROR al modificar empresa.");
                            historial.Add(err);
                            Session["historial"] = historial;
                            string script = "alert('No se pudo modificar la empresa');";
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "Alert", script, true);
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex) { }
        }

        protected void btAddTelf_Click(object sender, EventArgs e)
        {
            SrvDatosClient proxy = new SrvDatosClient();
            TelefonosData telefono = new TelefonosData();
            telefono.ID = Int32.Parse(tbIDEmpresa.Text);
            telefono.Telefono = tbTelefono.Text;

            if (telefono.Telefono != "" && validar(telefono.Telefono, @"^[+-]?\d+(\.\d+)?$") && telefono.Telefono.Length ==9)
            {
                String s = Request.QueryString["estado"];
                int estado = -1;
                if (s != null)
                    estado = Int32.Parse(s);
                if (estado == 1)
                {
                    if (proxy.AddTelefonoEmpresa(telefono))
                    {
                        //llamar al servicio para que inserte el telefono nuevo. aun no está hecho T_T
                        tbTelefonos.Items.Add(new ListItem(tbTelefono.Text, tbTelefono.Text));
                        tbTelefonos.DataBind();
                        tbTelefono.Text = "";
                        tbTelefono.Focus();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensaje", "<script type='text/javascript'> alert('SE HA INSERTADO CORRECTAMENTE'); parent.$.fancybox.close();</script>", false);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensaje", "<script type='text/javascript'> alert('ERROR AL INSERTAR'); </script>", false);
                    }
                }else
                {
                    tbTelefonos.Items.Add(new ListItem(tbTelefono.Text, tbTelefono.Text));
                    tbTelefonos.DataBind();
                    tbTelefono.Text = "";
                    tbTelefono.Focus();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensaje", "<script type='text/javascript'> alert('SE HA INSERTADO CORRECTAMENTE'); </script>", false);
                }
            }else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensaje", "<script type='text/javascript'> alert('El teléfono no es correcto'); </script>", false);
            }
        }

        protected bool validar(string cadena, string expresion)
        {
            //^\+?\d{1,3}?[- .]?\(?(?:\d{2,3})\)?[- .]?\d\d\d[- .]?\d\d\d\d$
            Regex regex = new Regex(expresion);
            if(regex.IsMatch(cadena))
                return true;
            else return false;
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = e.Values["ID"].ToString();
            SrvDatosClient proxy = new SrvDatosClient();

            if (proxy.BorrarContacto(Int32.Parse(id)))
            {

                this.GridView1.DataSource = proxy.GetAllContactosEmpresa(Int32.Parse(tbIDEmpresa.Text));
                this.GridView1.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensaje", "<script type='text/javascript'> alert('ERROR AL ELIMINAR'); </script>", false);
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

            string idu = this.GridView1.Rows[e.NewEditIndex].Cells[0].Text;
            string id = this.GridView1.Rows[e.NewEditIndex].Cells[1].Text;
            this.Response.Redirect("GContactos.aspx?estado=1&idU=" + idu+"&id="+id);
        }

        protected void btnDeleteTelf_Click(object sender, EventArgs e)
        {
            try
            {
                SrvDatosClient proxy = new SrvDatosClient();
                String s = Request.QueryString["estado"];
                int estado = -1;
                if (s != null)
                    estado = Int32.Parse(s);
                if (estado == 1)
                {
                    if (proxy.BorrarTelefonoEmpresa(tbTelefonos.SelectedValue))
                    {

                        TelefonosData[] telefonos = proxy.GetAllTelefonosEmpresa(Int32.Parse(tbIDEmpresa.Text));
                        tbTelefonos.DataSource = telefonos;
                        tbTelefonos.DataValueField = "Telefono";
                        tbTelefonos.DataTextField = "Telefono";
                        tbTelefonos.DataBind();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensaje", "<script type='text/javascript'> alert('TELÉFONO ELIMINADO'); </script>", false);
                    }
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensaje", "<script type='text/javascript'> alert('NO SE PUDO ELIMINAR'); </script>", false);

                }
                else
                {
                    tbTelefonos.Items.Remove(tbTelefonos.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensaje", "<script type='text/javascript'> alert('NO SE PUDO ELIMINAR'); </script>", false);
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int idEmpresa;
            String id = Request.QueryString["id"];
            idEmpresa = -1;
            
            if (id != null)
                idEmpresa = Int32.Parse(id);

            SrvDatosClient proxy = new SrvDatosClient();
            this.GridView1.PageIndex = e.NewPageIndex;
            this.GridView1.DataSource = proxy.GetAllContactosEmpresa(idEmpresa);
            this.GridView1.DataBind();
        }

        /// <summary>
        /// Funcion que valida un CIF
        /// </summary>
        /// <param name="Numero">El numero del CIF a validar</param>
        /// <returns>True si el CIF es correcto</returns>

        protected void validar_CIF(object source, ServerValidateEventArgs args)
        {
            string Numero = tbCIF.Text;
            //Valida el cif actual
            string[] letrasCodigo = { "J", "A", "B", "C", "D", "E", "F", "G", "H", "I" };

            string LetraInicial = Numero[0].ToString();
            string DigitoControl = Numero[Numero.Length - 1].ToString();
            string n = Numero.ToString().Substring(1, Numero.Length - 2);
            int sumaPares = 0;
            int sumaImpares = 0;
            int sumaTotal = 0;
            int i = 0;
            bool retVal = false;

            // Recorrido por todos los dígitos del número
            // Recorrido por todos los dígitos del número
            for (i = 0; i < n.Length; i++)
            {
                int aux;
                Int32.TryParse(n[i].ToString(), out aux);

                if ((i + 1) % 2 == 0)
                {
                    // Si es una posición par, se suman los dígitos
                    sumaPares += aux;
                }
                else
                {
                    // Si es una posición impar, se multiplican los dígitos por 2
                    aux = aux * 2;

                    // se suman los dígitos de la suma
                    sumaImpares += SumaDigitos(aux);
                }
            }

            // Se suman los resultados de los números pares e impares
            sumaTotal += sumaPares + sumaImpares;

            // Se obtiene el dígito de las unidades
            Int32 unidades = sumaTotal % 10;

            // Si las unidades son distintas de 0, se restan de 10
            if (unidades != 0) unidades = 10 - unidades;

            switch (LetraInicial)
            {
                // Sólo números
                case "A":
                case "B":
                case "E":
                case "H":
                    retVal = DigitoControl == unidades.ToString();
                    break;

                // Sólo letras
                case "K":
                case "P":
                case "Q":
                case "S":
                    retVal = DigitoControl == letrasCodigo[unidades];
                    break;

                default:
                    retVal = (DigitoControl == unidades.ToString()) || (DigitoControl == letrasCodigo[unidades]);
                    break;
            }

            args.IsValid = retVal;
        }

        private Int32 SumaDigitos(Int32 digitos)
        {
            string sNumero = digitos.ToString();
            Int32 suma = 0;

            for (Int32 i = 0; i < sNumero.Length; i++)
            {
                Int32 aux;
                Int32.TryParse(sNumero[i].ToString(), out aux);
                suma += aux;
            }
            return suma;
        }

        protected void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string id = this.GridView3.Rows[e.NewEditIndex].Cells[0].Text;
            string ide = tbIDEmpresa.Text;
            this.Response.Redirect("direccion.aspx?estado=1&ide=" + ide + "&id=" + id);
        }

        protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = e.Values["ID"].ToString();
            SrvDatosClient proxy = new SrvDatosClient();

            if (proxy.BorrarDireccionEmpresa(Int32.Parse(tbIDEmpresa.Text), Int32.Parse(id)))
            {

                int idEmpresa;
                String id_ = Request.QueryString["id"];
                idEmpresa = -1;

                if (id_ != null)
                    idEmpresa = Int32.Parse(id_);
                this.GridView3.DataSource = proxy.GetAllDireccionesEmpresa(idEmpresa);
                this.GridView3.DataBind();
            }
            else {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensaje", "<script type='text/javascript'> alert('ERROR AL ELIMINAR'); </script>", false);
            }
        }

        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int idEmpresa;
            String id = Request.QueryString["id"];
            idEmpresa = -1;

            if (id != null)
                idEmpresa = Int32.Parse(id);

            SrvDatosClient proxy = new SrvDatosClient();
            this.GridView3.PageIndex = e.NewPageIndex;
            this.GridView3.DataSource = proxy.GetAllDireccionesEmpresa(idEmpresa);
            this.GridView3.DataBind();
        }

        protected void btAltaDireccion_Click(object sender, EventArgs e)
        {
            string ide = tbIDEmpresa.Text;
            this.Response.Redirect("direccion.aspx?estado=0&ide=" + ide);
        }

        protected void btNuevoContacto_Click(object sender, EventArgs e)
        {
            string ide = tbIDEmpresa.Text;
            this.Response.Redirect("GContactos.aspx?estado=0&ide=" + ide);
            //PostBackUrl="GContactos.aspx?estado=0"
        }
    }
}