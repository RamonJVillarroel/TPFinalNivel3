﻿using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace catalogo_web
{
    public partial class PanelAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            
            if (Session["usuario"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            Usuarios usuario = (Usuarios)Session["usuario"];
            if (!Seguridad.EsAdmin(usuario))
            {
                Response.Redirect("Perfil.aspx");
                return;
            }
            if (!IsPostBack)
            {
                NegocioArticulo negocioArticulo = new NegocioArticulo();
                Session["ProductosAdmin"] = negocioArticulo.ListarArticulos();
                dgvListadoProductos.DataSource = Session["ProductosAdmin"];
                dgvListadoProductos.DataBind();
            }

        }

        protected void dgvListadoProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

            var id = dgvListadoProductos.SelectedDataKey.Value.ToString();
            Response.Redirect("PanelModificarAdmin.aspx?id=" + id);
        }
    }
}