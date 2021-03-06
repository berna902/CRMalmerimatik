﻿using Clientes.Models;
using Clientes.ServicioDatos2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clientes.Private.Admin
{
    public partial class Estados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                String s = Request.QueryString["estado"];
                String id_ = Request.QueryString["id"];
                try
                {
                    int estado;
                    int id;

                    estado = -1;
                    id = -1;
                    if (s != null)
                        estado = Int32.Parse(s);

                    if (id_ != null)
                        id = Int32.Parse(id_);



                    switch (estado)
                    {
                        case 0:

                            break;

                        case 1:
                            SrvDatosClient proxy = new SrvDatosClient();
                            EstadoData estadoTipo = proxy.GetEstado(id);
                            tbEstado.Text = estadoTipo.Estado;
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
                String id_ = Request.QueryString["id"];
                int estado = -1;
                int id;

                estado = -1;
                id = -1;
                if (s != null)
                    estado = Int32.Parse(s);

                if (id_ != null)
                    id = Int32.Parse(id_);

                switch (estado)
                {
                    case 0:
                        if (proxy.AddEstado(tbEstado.Text) != -1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensaje", "<script type='text/javascript'> alert('SE HA INSERTADO CORRECTAMENTE'); parent.$.fancybox.close();</script>", false);
                            List<Clientes.Models.ERROR> historial = new List<Clientes.Models.ERROR>();
                            historial = (List<Clientes.Models.ERROR>)Session["historial"];

                            ERROR err = new ERROR(0, "Estado insertado con exito");
                            historial.Add(err);
                            Session["historial"] = historial;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensaje", "<script type='text/javascript'> alert('ERROR AL INSERTAR'); parent.$.fancybox.close();</script>", false);
                            List<Clientes.Models.ERROR> historial = new List<Clientes.Models.ERROR>();
                            historial = (List<Clientes.Models.ERROR>)Session["historial"];

                            ERROR err = new ERROR(1, "ERROR al insertar estado");
                            historial.Add(err);
                            Session["historial"] = historial;
                        }
                            break;
                    case 1:
                        EstadoData estadotipo = new EstadoData();
                        estadotipo.Estado = tbEstado.Text;
                        estadotipo.ID = id;
                        if (proxy.EditEstado(estadotipo))
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensaje", "<script type='text/javascript'> alert('SE HA MODIFICADO CORRECTAMENTE'); parent.$.fancybox.close();</script>", false);
                            List<Clientes.Models.ERROR> historial = new List<Clientes.Models.ERROR>();
                            historial = (List<Clientes.Models.ERROR>)Session["historial"];

                            ERROR err = new ERROR(0, "Estado modificado con exito");
                            historial.Add(err);
                            Session["historial"] = historial;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensaje", "<script type='text/javascript'> alert('ERROR AL MODIFICAR'); parent.$.fancybox.close();</script>", false);
                            List<Clientes.Models.ERROR> historial = new List<Clientes.Models.ERROR>();
                            historial = (List<Clientes.Models.ERROR>)Session["historial"];

                            ERROR err = new ERROR(1, "ERROR al modificar estado.");
                            historial.Add(err);
                            Session["historial"] = historial;
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