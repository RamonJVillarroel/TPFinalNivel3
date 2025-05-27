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

    public partial class SiteMaster : MasterPage
    {
        public bool usuariosesion = false;
        public bool btnlogin =true;
        public bool EsAdmin = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
 Usuarios usuario = Session["usuario"] as Usuarios;

            bool esPaginaPublica = Page is Login || Page is Error || Page is Productos || Page is ProductoDetalle || Page is _Default;

            if (!esPaginaPublica && !Seguridad.sesionActiva(usuario))
            {
                Response.Redirect("Login.aspx");
               
            }
            if (Seguridad.EsAdmin(usuario))
            {
                EsAdmin = true;
                
            }
            if (Seguridad.sesionActiva(usuario))
            {
                usuariosesion = true;
                btnlogin = false;
                imgPerfil.ImageUrl = util.ObtenerUrlImagen(usuario.UrlImg);
            }
            }
            catch (Exception ex)
            {
                Session.Add("Error", "Tenemos un error: " + ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx", false);
        }
    }
}