using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using utilitarios;

namespace catalogo_web
{
    public partial class Perfil : System.Web.UI.Page
    {
        public bool usuariosesion;
        public List<Articulo> ListaArticulos { get; set; }
      
        public bool esAdmin = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["usuario"] != null)
                {
                    usuariosesion = true;
                    Usuarios usuario = new Usuarios();
                    usuario = (Usuarios)Session["usuario"];
                    lblNombre.Text = usuario.Nombre;
                    lblEmail.Text = usuario.Email;
                    lblTipo.Text = usuario.TipoUser.ToString();
                    imgPerfil.ImageUrl = util.ObtenerUrlImagen(usuario.UrlImg);
                   
                    NegocioFavorito negocioFavorito = new NegocioFavorito();
                    Session.Add("favoritos", negocioFavorito.FavoritosUsuarios(usuario));
                    ListaArticulos = (List<Articulo>)Session["favoritos"];
                    if (Seguridad.EsAdmin((Usuarios)Session["usuario"]))
                    {
                        esAdmin = false;
                    }

                }
            }
            catch (Exception ex)
            {
                Session.Add("error", "tenemos un error");
                Response.Redirect("error.aspx", false);
            }


        }

       
    }
}