﻿using dominio;
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
        //public bool btnFavorioseditar = false;
        //public bool btnEliminarFvs = true;
        //public bool noidart;
        public Articulo seleccionado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["usuario"] != null && Session["IdArticulo"] != null)
                {
                    user = true;
                    if (Seguridad.EsAdmin(Session["usuario"]))
                    {
                        esAdmin = false;
                    }
                }
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
                    {
                        seleccionado = temp.Find(x => x.IdArticulo == int.Parse(IdArticulo));
                    }
                    else
                    {
                        seleccionado = tempfavoritos.Find(x => x.IdArticulo == int.Parse(IdArticulo));
                    }

                }
            }
            catch (Exception ex)
            {
                Session.Add("error", "tenemos un error" + ex.Message);
                Response.Redirect("error.aspx", false);
            }
            //validacion de favoritos
            //aparece el boton si el articulo no esta en los favoritos de el usuario
            //eliminara de favoritos si el articulo le pertenece a los favo del usuario

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

                    //mirar que no este agregando un favorito que ya tenga, buscar por id de articulo
                    if (true)
                    {
                        negocioFavorito.NuevoFavorito(favorito);
                        Response.Redirect("Perfil.aspx", false);
                    }



                }
            }
            catch (Exception ex)
            {
                Session.Add("error", "tenemos un error" + ex.Message);
                Response.Redirect("error.aspx", false);
            }



        }

        protected void btnEliminarFavoritos_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["IdArticulo"] != null && Session["usuario"] != null)
                {
                    IdArticulo = Session["IdArticulo"].ToString();
                    List<Articulo> temp = (List<Articulo>)Session["favoritos"];
                    seleccionado = temp.Find(x => x.IdArticulo == int.Parse(IdArticulo));
                    NegocioFavorito negocioFavorito = new NegocioFavorito();
                    //validar que tenga favoritos antes de eliminar
                    negocioFavorito.EliminarFavorito(seleccionado.Favorito.IdFavorito);
                    Response.Redirect("Perfil.aspx", false);
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