<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="catalogo_web.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="text-center">Listado de productos</h1>
    <div class="row row-cols-1 row-cols-md-3 g-4">

        <%

            foreach (dominio.Articulo articulo in ListaArticulos)
            {
        %>

        <div class="col">
            <div class="card" id="<%: articulo.IdArticulo %>">
                <img src="<%: articulo.Imagen %>" class=" img-fluid" style="width: 200px; height: 200px; object-fit: cover;" alt="<%: articulo.NombreArticulo %>">
                <div class="card-body">
                    <h5 class="card-title"><%:articulo.NombreArticulo%></h5>
                    <p class="card-text"><%: articulo.Descripcion %></p>
                    <p class="card-text"><%: articulo.Precio %></p>

                </div>
             
               <a class="btn btn-primary m-2" href='ProductoDetalle.aspx?id=<%:articulo.IdArticulo %>'>Detalle</a>



            </div>
        </div>
        <%     
            }

        %>
    </div>
</asp:Content>
