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
    public partial class Perfil : System.Web.UI.Page
    {
        public bool usuariosesion;
        public List<Articulo> ListaArticulos { get; set; }
        public Articulo seleccionado { get; set; }
        public Favoritos seleccionadofav {  get; set; }
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
                    imgPerfil.ImageUrl = usuario.UrlImg ?? "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQDCXek_M1agTePOBcSZfP1O9qobtNXYz4OVg&s";
                   
                    NegocioFavorito negocioFavorito = new NegocioFavorito();
                    Session.Add("favoritos", negocioFavorito.FavoritosUsuarios(usuario));
                    ListaArticulos = (List<Articulo>)Session["favoritos"];
                    
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", "tenemos un error");
                Response.Redirect("error.aspx", false);
            }


        }

        protected void btnEliminarFavoritos_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (Session["usuario"] != null)
                {
                    
                    NegocioFavorito negocioFavorito = new NegocioFavorito();
                    //obtengo id de favoritos
                    List<Favoritos> tempfav = negocioFavorito.ListaFavoritos();
                    //saco los articulos del usuario en la session
                    List<Articulo> temp = (List<Articulo>)Session["favoritos"];
                    //intento de comparar con un while

                 
                    


                    negocioFavorito.EliminarFavorito(favIdUsuario.Favorito.IdFavorito);
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