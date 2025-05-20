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

    public partial class SiteMaster : MasterPage
    {
        public bool usuariosesion = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.sesionActiva((Usuarios)Session["usuario"]))
            {
                if (!(Page is Login || Page is Error || Page is Productos || Page is ProductoDetalle || Page is _Default))
                {


                    //Response.Redirect("Login.aspx", false);
                    if (Seguridad.sesionActiva((Usuarios)Session["usuario"]))
                    {
                        usuariosesion = true;
                        Usuarios usuario = new Usuarios();
                        usuario = (Usuarios)Session["usuario"];
                        imgPerfil.ImageUrl = usuario.UrlImg ?? "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQDCXek_M1agTePOBcSZfP1O9qobtNXYz4OVg&s";
                    }
                }
            }


        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx", false);
        }
    }
}