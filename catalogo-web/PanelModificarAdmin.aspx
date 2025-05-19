<%@ Page Title="Formulario de producto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PanelModificarAdmin.aspx.cs" Inherits="catalogo_web.PanelModificarAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="text-center">Administración de producto</h3>
    <div class="container d-flex justify-content-center">
        <div class="row">
            <div class="">
                <label class=" form-label">Id</label>
                <asp:TextBox ID="txtId" runat="server" ReadOnly="true" CssClass="form-control" Enabled="true"></asp:TextBox>
                <label class="form-label">Codigo</label>
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
                <label class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombreArticulo" runat="server" CssClass="form-control"></asp:TextBox>


                <label class="form-label">Descripción</label>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>

                <label class="form-label">Marca</label>
                <div>
                    <asp:DropDownList ID="ddlMarca" CssClass="btn btn-outline-primary dropdown-toggle" runat="server"></asp:DropDownList>

                </div>

                <label class="form-label">Categoria</label>
                <div>
                    <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="btn  btn-outline-primary dropdown-toggle"></asp:DropDownList>

                </div>

                <label class="form-label">Precio</label>
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>

                <label class="form-label">Url Imagen</label>
                <asp:TextBox ID="txtUrlImagen" runat="server" CssClass="form-control" OnTextChanged="txtUrlImagen_TextChanged"></asp:TextBox>
                <img src="<%= txtUrlImagen %>" alt="Alternate Text" />
            </div>
            <asp:Button ID="btnNuevoArt" runat="server" Text="Enviar" CssClass="btn btn-primary" OnClick="btnNuevoArt_Click" />
        </div>

    </div>


</asp:Content>
