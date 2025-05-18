using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace catalogo_web
{
    public partial class ProductoDetalle : System.Web.UI.Page
    {
        public string IdArticulo;
        public Articulo seleccionado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(id))
                {
                    Session["IdArticulo"] = id;
                }
            }

            if (Session["IdArticulo"] != null)
            {
                IdArticulo = Session["IdArticulo"].ToString();
                List<Articulo> temp = (List<Articulo>)Session["productos"];
                seleccionado = temp.Find(x => x.IdArticulo == int.Parse(IdArticulo));
                //if (seleccionado != null)
               // {
                  
                    
                //}

            }
        }
    }
}