using dominio;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                Usuarios usuario = new Usuarios();
                usuario = (Usuarios)Session["usuario"];
                lblNombre.Text = usuario.Nombre;
                lblEmail.Text = usuario.Email;
                lblTipo.Text = usuario.TipoUser.ToString();
                imgPerfil.ImageUrl = usuario.UrlImg ?? "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQDCXek_M1agTePOBcSZfP1O9qobtNXYz4OVg&s";
            }
        }
    }
}