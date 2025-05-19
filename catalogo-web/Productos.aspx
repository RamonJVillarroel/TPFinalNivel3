<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="catalogo_web.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="text-center">Listado de productos</h1>
    <div class="container bg-dark-subtle p-2 mb-1">
        <label>Filtros:</label>
        <asp:Button ID="btnMayorPrecio" runat="server" Text="Buscar por Mayor precio" CssClass="btn btn-outline-primary" OnClick="btnMayorPrecio_Click" />
        <asp:Button ID="btnMenorPrecio" runat="server" Text="Buscar por Menor precio" CssClass="btn btn-outline-primary" OnClick="btnMenorPrecio_Click" />
        <div class="p-1">
            <label>Busqueda por categoria:</label>
            <asp:DropDownList ID="ddlBusquedaCategoria" runat="server" CssClass="btn btn-outline-primary"></asp:DropDownList>
            <asp:Button ID="btnBuscarCategoria" runat="server" Text="Buscar categoria" CssClass="btn btn-outline-primary" OnClick="btnBuscarCategoria_Click" />
        </div>

        <label>Limpiar filtro:</label>
        <asp:Button ID="btnLimpiarFiltro" runat="server" Text="Limpiar filtro" OnClick="btnLimpiarFiltro_Click" CssClass="btn btn-outline-danger" />
    </div>
    <div class="row row-cols-1 row-cols-md-3 g-4">

        <%
            if (ListaArticulos != null)
            {
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
            }
            else
            {
        %>
        <p>No hay articulos para mostrar</p>
        <%} %>
    </div>
</asp:Content>
