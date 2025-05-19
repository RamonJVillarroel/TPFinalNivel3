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
        public bool user = false;
        public string id;
        public Articulo seleccionado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                user = true;
            }
            if (!IsPostBack)
            {
                id = Request.QueryString["id"];
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

            }
        }

        protected void btnFavorios_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["IdArticulo"] != null && Session["usuario"]!=null)
                {
                    IdArticulo = Session["IdArticulo"].ToString();
                    List<Articulo> temp = (List<Articulo>)Session["productos"];
                    seleccionado = temp.Find(x => x.IdArticulo == int.Parse(IdArticulo));
                    Favoritos favorito = new Favoritos();
                    favorito.Articulo = seleccionado;
                    Usuarios usuario = new Usuarios();
                    usuario = (Usuarios)Session["usuario"];
                    favorito.Usuarios = usuario;
                    NegocioFavorito negocioFavorito = new NegocioFavorito();
                    //mirar que no este agregando un favorito que ya tenga
                    if (true)
                    {
                        negocioFavorito.NuevoFavorito(favorito);
                    }
                    

                }
            }catch(Exception ex)
            {
                Session.Add("error", "tenemos un error");
                Response.Redirect("error.aspx", false);
            }



        }
    }
}