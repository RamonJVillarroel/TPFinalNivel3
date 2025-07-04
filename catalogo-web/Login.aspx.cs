﻿using dominio;
using Microsoft.Ajax.Utilities;
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
                usuario.UrlImg = util.ObtenerUrlImagen(txtUrlImg.Text);
                usuario.TipoUser = 0;
                //validar que mail y password no sean vacios
                if(!string.IsNullOrWhiteSpace(usuario.Email) && !string.IsNullOrWhiteSpace(usuario.Password) )
                  usuarioNegocio.NuevoUsuario(usuario);

                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error","Tenemos el siguiente error: " + ex.Message.ToString());
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
                    Response.Redirect("Login.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", "Tenemos un error no esperado: "+ ex.ToString());
                Response.Redirect("Error.aspx",false);
            }
        }
    }
}