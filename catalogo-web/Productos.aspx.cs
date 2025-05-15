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
    public partial class Productos : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];
                Session["IdArticulo"] = id;
                try
                {
                    NegocioArticulo negocioArticulo = new NegocioArticulo();
                    ListaArticulos = negocioArticulo.ListarArticulos();
                }
                catch (Exception ex)
                {
                    Session.Add("Error", "Tenemos un error: " + ex.Message);
                    Response.Redirect("Error.aspx", false);
                }
            }

        }
    }
}