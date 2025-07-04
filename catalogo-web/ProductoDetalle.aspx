﻿<%@ Page Title="Produto Detalle" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductoDetalle.aspx.cs" Inherits="catalogo_web.ProductoDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="text-center">Detalle del producto</h1>

    <div class="container mt-4">
        <div class="row justify-content-center">
            <div class="col-md-6 col-lg-4">
                <div class="card text-center">
                    <% if (seleccionado != null)
                        { %>
                    <img src="<%: seleccionado.Imagen %>" class="img-fluid mx-auto mt-3" style="width: 200px; height: 200px; object-fit: cover;" alt="<%: seleccionado.NombreArticulo %>">
                    <div class="card-body">
                        <h5 class="card-title">Titulo del articulo: <%: seleccionado.NombreArticulo %></h5>
                        <p class="card-text"><b>Descripcion del articulo:</b> <%: seleccionado.Descripcion %></p>
                        <p class="card-text"><b>Precio:</b> <%: seleccionado.Precio.ToString("N2") %></p>
                        <p class="card-text"><b>Marca:</b> <%: seleccionado.Marca %></p>
                        <p class="card-text"><b>Categoria:</b> <%: seleccionado.Categoria %></p>
                        <p class="card-text"><b>Codigo:</b> <%: seleccionado.CodArticulo %></p>
                    </div>
                    <%}
                        else
                        { %>
                    <h4>Producto no encontrado</h4>
                    <%} %>
                    <%
                        if (user && esAdmin == true)
                        {


                    %>
                    <div class="d-flex justify-content-center">


                        <asp:Button ID="btnFavorios" runat="server" Text="Añadir a favoritos" CssClass="btn btn-outline-warning m-2" OnClick="btnFavorios_Click" />

                    </div>
                    <div class="d-flex justify-content-center">

                        <asp:Button ID="btnEliminarFavoritos" runat="server" Text="Eliminar de Favoritos" CssClass="btn btn-outline-danger m-1" OnClick="btnEliminarFavoritos_Click" />

                    </div>
                    <%} %>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
