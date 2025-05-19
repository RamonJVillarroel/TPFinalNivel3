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
    public partial class PanelModificarAdmin : System.Web.UI.Page
    {
        public string id;
        public Articulo seleccionado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];
                NegocioCategoria negocioCategoria = new NegocioCategoria();
                ddlCategoria.DataSource = negocioCategoria.ListarCategoria();
                ddlCategoria.DataTextField = "NombreCategoria";
                ddlCategoria.DataValueField = "IdCategoria";
                ddlCategoria.DataBind();
                NegocioMarca negocioMarca = new NegocioMarca();
                ddlMarca.DataSource = negocioMarca.ListarMarcas();
                ddlMarca.DataTextField = "NombreMarca";
                ddlMarca.DataValueField = "IdMarca";
                ddlMarca.DataBind();

                if (Session["ProductosAdmin"] != null && id != null)
                {
                    List<Articulo> temp = (List<Articulo>)Session["ProductosAdmin"];
                    seleccionado = temp.Find(x => x.IdArticulo == int.Parse(id));
                    txtId.Text = seleccionado.IdArticulo.ToString();
                    txtCodigo.Text = seleccionado.CodArticulo.ToString();
                    txtNombreArticulo.Text = seleccionado.NombreArticulo.ToString();
                    ddlMarca.Text = seleccionado.Marca.NombreMarca;
                    ddlMarca.Text = seleccionado.Marca.ToString();
                    ddlCategoria.Text = seleccionado.Categoria.ToString();
                    txtUrlImagen.Text = seleccionado.Imagen.ToString();
                    txtPrecio.Text = seleccionado.Precio.ToString();
                    txtDescripcion.Text = seleccionado.Descripcion.ToString();
                }

            }

        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
           // txtUrlImagen.Text = seleccionado.Imagen.ToString();
        }

        protected void btnNuevoArt_Click(object sender, EventArgs e)
        {
            NegocioArticulo negocioArticulo = new NegocioArticulo();
            Articulo articuloNuevo = new Articulo();
            try
            {
                articuloNuevo.NombreArticulo = txtNombreArticulo.Text;
                articuloNuevo.Descripcion = txtDescripcion.Text;
                articuloNuevo.Precio = int.Parse(txtPrecio.Text);
                articuloNuevo.CodArticulo = txtCodigo.Text;
                articuloNuevo.Imagen = txtUrlImagen.Text;
                articuloNuevo.Marca = new Marca();
                articuloNuevo.Marca.IdMarca = int.Parse(ddlMarca.SelectedValue);
                articuloNuevo.Categoria = new Categoria();
                articuloNuevo.Categoria.IdCategoria = int.Parse(ddlCategoria.SelectedValue);
                negocioArticulo.NuevoArticulo(articuloNuevo);
                Response.Redirect("Default.aspx",false);
            }
            catch (Exception ex) {
                Session.Add("Error", "Tenemos un error: " + ex.Message);
                Response.Redirect("Error.aspx", false);
            }



        }
    }
}