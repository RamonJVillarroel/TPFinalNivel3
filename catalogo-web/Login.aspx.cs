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
                if(!string.IsNullOrWhiteSpace(usuario.Email) && !string.IsNullOrWhiteSpace(usuario.Password) )
                  usuarioNegocio.NuevoUsuario(usuario);

                Response.Redirect("Productos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error","Tenemos el siguiente error: " + ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}