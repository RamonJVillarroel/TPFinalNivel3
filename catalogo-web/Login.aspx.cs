using dominio;
using Microsoft.Ajax.Utilities;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace catalogo_web
{
    public partial class Login : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Seguridad.sesionActiva(Session["usuario"]))
                {
                    Session.Clear();
                    return;
                }
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {

            try
            {
                NegocioUsuario usuarioNegocio = new NegocioUsuario();
                Usuarios usuario = new Usuarios();
                usuario.Email = txtEmail.Text;
                usuario.Password = txtPassword.Text;
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;
                usuario.UrlImg = txtUrlImg.Text;
                usuario.TipoUser = 0;
                //validar usuario nuevo
                if(!string.IsNullOrWhiteSpace(usuario.Email) && !string.IsNullOrWhiteSpace(usuario.Password) )
                  usuarioNegocio.NuevoUsuario(usuario);

                Response.Redirect("Login.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error","Tenemos el siguiente error: " + ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();
            NegocioUsuario negocioUsuario = new NegocioUsuario();
            try
            {
                usuario.Email = txtEmaillogin.Text;
                usuario.Password = txtPasswordlogin.Text;
                if (negocioUsuario.Login(usuario))
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("Perfil.aspx", false);
                }
                else
                {
                    Session.Add("error", "User o Pass incorrectos");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx",false);
            }
        }
    }
}