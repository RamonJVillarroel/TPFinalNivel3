using dominio;
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

            if (Seguridad.EsAdmin((Usuarios)Session["usuario"]))
            {
                NegocioArticulo negocioArticulo = new NegocioArticulo();
                Session.Add("ProductosAdmin", negocioArticulo.ListarArticulos());
                dgvListadoProductos.DataSource = Session["ProductosAdmin"];
                dgvListadoProductos.DataBind();
            }
            if (Seguridad.sesionActiva((Usuarios)Session["usuario"]))
            {
                Response.Redirect("Perfil.aspx", false);
            }
            else
            {
                Response.Redirect("Login.aspx", false);
            }


        }

        protected void dgvListadoProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

            var id = dgvListadoProductos.SelectedDataKey.Value.ToString();
            Response.Redirect("PanelModificarAdmin.aspx?id=" + id);
        }
    }
}