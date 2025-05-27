using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using utilitarios;
using static System.Net.Mime.MediaTypeNames;

namespace catalogo_web
{
    public partial class Perfil : System.Web.UI.Page
    {
        public bool usuariosesion;
        public List<Articulo> ListaArticulos { get; set; }

        public bool esAdmin = true;
        public bool eliminarCuenta = false;
        public bool editarCuenta = false;
        public string UrlImagenUpdate;
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
                Session.Add("error", "tenemos un error" + ex.Message);
                Response.Redirect("error.aspx", false);
            }


        }

        protected void btnEliminarCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                eliminarCuenta = true;
            }
            catch (Exception ex)
            {
                Session.Add("error", "tenemos un error" + ex);
                Response.Redirect("error.aspx", false);
            }
        }

        protected void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                editarCuenta = true;

                Usuarios usuario = (Usuarios)Session["usuario"];
                txtIdUsuario.Text = usuario.Id.ToString();
                txtEmail.Text = usuario.Email;
                txtPass.Text = usuario.Password;
                txtNombre.Text = usuario.Nombre;
                txtApellido.Text = usuario.Apellido;
                txturlImagen.Text = util.ObtenerUrlImagen(usuario.UrlImg);
                UrlImagenUpdate = util.ObtenerUrlImagen(usuario.UrlImg);

            }
            catch (Exception ex)
            {
                Session.Add("error", "tenemos un error" + ex);
                Response.Redirect("error.aspx", false);
            }
        }
        //editar solo para usuarios comunes
        protected void EditarCuentabtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkEditarCuenta.Checked)
                {
                    NegocioUsuario negocioUsuario = new NegocioUsuario();
                    Usuarios usuario = new Usuarios();
                    usuario = (Usuarios)Session["usuario"];
                    usuario.Id = int.Parse(txtIdUsuario.Text);
                    usuario.Email = txtEmail.Text;
                    usuario.Password = txtPass.Text;
                    usuario.Nombre = txtNombre.Text;
                    usuario.Apellido = txtApellido.Text;
                    usuario.UrlImg = util.ObtenerUrlImagen(txturlImagen.Text);

                    negocioUsuario.actualizarUsuario(usuario);
                    Response.Redirect("Perfil.aspx", false);
                }
                else
                {
                    Session.Add("error", "falta marcar el checkbox");
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", "tenemos un error" + ex);
                Response.Redirect("error.aspx", false);
            }
        }

        protected void txturlImagen_TextChanged(object sender, EventArgs e)
        {
            UrlImagenUpdate = txturlImagen.Text;
        }

        protected void EliminarCuentabtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkEliminarCuenta.Checked)
                {
                    NegocioUsuario negocioUsuario = new NegocioUsuario();
                    Usuarios usuario = (Usuarios)Session["usuario"];
                    negocioUsuario.EliminarUsuario(usuario.Id);
                    Session.Clear();
                    Response.Redirect("Productos.aspx", false);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                Session.Add("error", "tenemos un error" + ex);
                Response.Redirect("error.aspx", false);
            }

        }
    }
}