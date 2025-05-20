using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace catalogo_web
{
    public partial class PanelModificarAdmin : System.Web.UI.Page
    {
        public string id;
        public bool ConfirmaEliminar { get; set; }
        public bool eliminar = false;
        
        public Articulo seleccionado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
           
           
            id = Request.QueryString["id"];
          
            if (!IsPostBack)
            {
                
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

                    eliminar = true;
                    List<Articulo> temp = (List<Articulo>)Session["ProductosAdmin"];     
                    seleccionado = temp.Find(x => x.IdArticulo == int.Parse(id));
                    txtId.Text = seleccionado.IdArticulo.ToString();
                    txtCodigo.Text = seleccionado.CodArticulo.ToString();
                    txtNombreArticulo.Text = seleccionado.NombreArticulo.ToString();
                    ddlMarca.Text = seleccionado.Marca.NombreMarca;
                    ddlMarca.Text = seleccionado.Marca.IdMarca.ToString();
                    ddlCategoria.Text = seleccionado.Categoria.IdCategoria.ToString();
                    txtUrlImagen.Text = seleccionado.Imagen.ToString();
                    txtPrecio.Text = seleccionado.Precio.ToString(CultureInfo.InvariantCulture);
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
                if(id != null)
                {
                    articuloNuevo.IdArticulo = int.Parse(id);
                    articuloNuevo.NombreArticulo = txtNombreArticulo.Text;
                    articuloNuevo.Descripcion = txtDescripcion.Text;
                    articuloNuevo.Precio = decimal.Parse(txtPrecio.Text, CultureInfo.InvariantCulture);
                    articuloNuevo.CodArticulo = txtCodigo.Text.ToString();
                    articuloNuevo.Imagen = txtUrlImagen.Text;
                    articuloNuevo.Marca = new Marca();
                    articuloNuevo.Marca.IdMarca = int.Parse(ddlMarca.SelectedValue);
                    articuloNuevo.Categoria = new Categoria();
                    articuloNuevo.Categoria.IdCategoria = int.Parse(ddlCategoria.SelectedValue);
                    negocioArticulo.EditarArticulo(articuloNuevo);
                    Response.Redirect("Default.aspx", false);
                    
                }
                else
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
                    Response.Redirect("Default.aspx", false);
                }
            }
            catch (Exception ex) {
                Session.Add("Error", "Tenemos un error: " + ex.Message);
                Response.Redirect("Error.aspx", false);
            }



        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ConfirmaEliminar = true;
             
            }
            catch (Exception ex)
            {
                Session.Add("Error", "Tenemos un error: " + ex.Message);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void ConfirmarEliminar_Click(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                try
                {
                    NegocioArticulo negocioArticulo = new NegocioArticulo();
                    negocioArticulo.eliminar(int.Parse(id));
                    Response.Redirect("PanelAdmin.aspx", false);
                }
                catch (Exception ex)
                {
                    Session.Add("Error", "Tenemos un error: " + ex.Message);
                    Response.Redirect("Error.aspx", false);
                }
            }
        }
    }
}