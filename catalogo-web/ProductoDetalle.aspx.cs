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
        public bool esAdmin = true;
       
        public Articulo seleccionado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
              
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
                    List<Articulo> tempfavoritos = (List<Articulo>)Session["favoritos"];

                    if (temp != null)
                        seleccionado = temp.Find(x => x.IdArticulo == int.Parse(IdArticulo));
                    else
                        seleccionado = tempfavoritos.Find(x => x.IdArticulo == int.Parse(IdArticulo));
                }

                if (Session["usuario"] != null && Session["IdArticulo"] != null)
                {
                    user = true;
                    if (Seguridad.EsAdmin(Session["usuario"]))
                    {
                        esAdmin = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", "tenemos un error: " + ex.Message);
                Response.Redirect("error.aspx", false);
            }
        }

        protected void btnFavorios_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["IdArticulo"] != null && Session["usuario"] != null)
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
                    //busqueda de favoritos
                    //mirar que no este agregando un favorito que ya tenga, buscar por id de articulo
                    //Niego si es verdadero para que no entre en el if
                    if (!(negocioFavorito.BuscarFavoritoId(usuario.Id, seleccionado.IdArticulo)))
                    {
                        negocioFavorito.NuevoFavorito(favorito);
                        Response.Redirect("Perfil.aspx", false);
                    }

                }
            }
            catch (Exception ex)
            {
                Session.Add("error", "tenemos un error: " + ex.Message);
                Response.Redirect("error.aspx", false);
            }



        }

        protected void btnEliminarFavoritos_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["IdArticulo"] != null && Session["usuario"] != null)
                {
                    Usuarios usuario = new Usuarios();
                    usuario = (Usuarios)Session["usuario"];
                    IdArticulo = Session["IdArticulo"].ToString();
                  
                    NegocioFavorito negocioFavorito = new NegocioFavorito(); 
                    //busco si tiene el articulo en favorito
                    //si lo tiene continuo a buscarlos en los favoritos en sesion para eliminarlo
                    if (negocioFavorito.BuscarFavoritoId(usuario.Id, int.Parse(IdArticulo)))
                    {
                        List<Articulo> temp = (List<Articulo>)Session["favoritos"];
                        seleccionado = temp.Find(x => x.IdArticulo == int.Parse(IdArticulo));
                        if (seleccionado != null && seleccionado.Favorito != null)
                        {
                            negocioFavorito.EliminarFavorito(seleccionado.Favorito.IdFavorito);
                            Response.Redirect("Perfil.aspx", false);
                        }
                        
                    }
                    else
                    {
                        Response.Redirect("Productos.aspx", false);
                    }

                }
            }
            catch (Exception ex)
            {
                Session.Add("error", "tenemos un error: "+ ex.Message.ToString());
                Response.Redirect("error.aspx", false);
            }

        }
    }
}