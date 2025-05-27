<%@ Page Title="Formulario de producto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PanelModificarAdmin.aspx.cs" Inherits="catalogo_web.PanelModificarAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="text-center">Administración de producto</h3>
    <div class="container d-flex justify-content-center">
        <div class="row">
            <div class=" col-10">
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
                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>

                <label class="form-label">Url Imagen</label>
                <asp:TextBox ID="txtUrlImagen" runat="server" CssClass="form-control" OnTextChanged="txtUrlImagen_TextChanged" AutoPostBack="true"></asp:TextBox>
                <img src="<%= UrlImagen %>" alt="Alternate Text" />
            </div>
            <asp:Button ID="btnNuevoArt" runat="server" Text="Enviar" CssClass="btn btn-primary" OnClick="btnNuevoArt_Click" />
            <%if (eliminar)
                { %>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                 
                        <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" CssClass="btn btn-danger  mt-1" />

                   

                    <asp:CheckBox ID="chkEliminar" runat="server" Text="Confirmar Eliminar" />
                    <%if (ConfirmaEliminar)
                        { %>

                    <div>
                        <label class="alert alert-danger form-label">Eliminas completamente el Articulo, no lo podras recuperar. Debe estar marcado el check.</label>
                        <div>
                            <asp:Button ID="ConfirmarEliminar" OnClick="ConfirmarEliminar_Click" runat="server" Text="Eliminar" CssClass="btn btn-outline-danger" />
                        </div>


                    </div>
                    <% }%>
                </ContentTemplate>
            </asp:UpdatePanel>
            <% } %>
        </div>
    </div>
</asp:Content>
