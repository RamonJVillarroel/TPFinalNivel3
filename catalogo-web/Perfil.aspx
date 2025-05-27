<%@ Page Title="Perfil" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="catalogo_web.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h4 class="text-center">Perfil</h4>
    <div class="container mt-5">
        <div class="card p-4 shadow rounded">
            <div class="d-flex align-items-center">
                <%if (usuariosesion)
                    {


                %>
                <asp:Image ID="imgPerfil" runat="server" CssClass="rounded-circle me-3" Width="100" Height="100" />
                <div>
                    <h3>
                        <asp:Label ID="lblNombre" runat="server" />
                    </h3>
                    <p class="text-muted">
                        <asp:Label ID="lblEmail" runat="server" />
                    </p>
                    <span class="badge bg-primary">
                        <asp:Label ID="lblTipo" runat="server" /></span>
                    <%if (esAdmin)
                        {  %>
                    <div class="bg-dark m-2">
                        <asp:Button ID="btnEditarUsuario" runat="server" Text="Editar Cuenta" CssClass="btn btn-outline-primary" OnClick="btnEditarUsuario_Click" />
                        <asp:Button ID="btnEliminarCuenta" runat="server" Text="Eliminar Cuenta" CssClass="btn btn-danger" OnClick="btnEliminarCuenta_Click" />
                    </div>
                    <%} %>

                    <%if (editarCuenta && esAdmin)
                        {  %>
                    <div class="container">
                        <div class="row">
                            <label class="alert alert-info mt-2 mb-1">Editar cuenta</label>
                            <label class=" form-label">Id</label>
                            <asp:TextBox ID="txtIdUsuario" runat="server" ReadOnly="true" CssClass="form-control" Enabled="true"></asp:TextBox>
                            <label class="form-label">Editar Email: </label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                            <label class="form-label">Editar Password: </label>
                            <asp:TextBox ID="txtPass" runat="server" CssClass="form-control"></asp:TextBox>
                            <label class="form-label">Editar nombre: </label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                            <label class="form-label">Editar apellido: </label>
                            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                            <label class="form-label">Editar url de imagen: </label>

                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txturlImagen" runat="server"
                                        CssClass="form-control"
                                        AutoPostBack="true"
                                        OnTextChanged="txturlImagen_TextChanged"
                                        UpdateMode="Conditional" />

                                    <img src="<%= UrlImagenUpdate %>" alt="Alternate Text" />
                                </ContentTemplate>
                            </asp:UpdatePanel>




                        </div>

                        <div>
                            <asp:CheckBox ID="chkEditarCuenta" runat="server" />
                            <asp:Button ID="EditarCuentabtn" runat="server" Text="Editar" CssClass="btn btn-primary" OnClick="EditarCuentabtn_Click" />
                        </div>


                    </div>

                    <%} %>
                    <%if (eliminarCuenta && esAdmin)
                        {  %>
                    <label class="alert alert-danger">Eliminar cuenta</label>
                    <div>
                        <asp:CheckBox ID="chkEliminarCuenta" runat="server" />
                        <asp:Button ID="EliminarCuentabtn" runat="server" Text="Eliminar" CssClass="btn btn-outline-danger" OnClick="EliminarCuentabtn_Click" />
                    </div>
                    <%} %>
                </div>
                <%}
                    else
                    { %>
            </div>
            <div class="container">
                <p class="alert alert-danger form-label">Anda al login</p>
            </div>
            <%} %>
        </div>

    </div>
    <div class="container mt-2">
        <div class="card p-4 shadow rounded">
            <h4 class="text-center pb-2">Lista de favoritos.</h4>
            <div class="d-flex align-items-center">
                <div class="row row-cols-1 row-cols-md-3 g-4">

                    <%
                        if (ListaArticulos != null && esAdmin)
                        {
                            foreach (dominio.Articulo articulo in ListaArticulos)
                            {
                    %>


                    <div class="card m-2 shadow-sm p-2" style="width: 18rem;" id="<%: articulo.IdArticulo %>">
                        <img src="<%: articulo.Imagen %>" class="card-img-top img-fluid" style="height: 200px; object-fit: cover;" alt="<%: articulo.NombreArticulo %>">
                        <div class="card-body">
                            <h5 class="card-title"><%: articulo.NombreArticulo %></h5>
                            <p class="card-text text-truncate"><%: articulo.Descripcion %></p>
                            <p class="card-text fw-bold">$<%: articulo.Precio.ToString("N2") %></p>
                            <a href='ProductoDetalle.aspx?id=<%: articulo.IdArticulo %>' class="btn btn-primary w-100">Detalle</a>
                        </div>
                    </div>


                    <%     
                            }
                        }
                        else
                        {
                    %>
                </div>
                <div class="container">
                    <p class="alert alert-danger form-label">No tienes favoritos para mostrar</p>
                </div>
                <%} %>
            </div>
        </div>
    </div>
</asp:Content>
