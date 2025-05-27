<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="catalogo_web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   
    <div class="container col-3">

        <h4 class="text-center">Inicio</h4>

        <label for="email" class="form-label">Email</label>
        <asp:TextBox ID="txtEmaillogin" CssClass="form-control" runat="server" TextMode="Email"></asp:TextBox>

        <label for="password" class="form-label">Password</label>
        <asp:TextBox ID="txtPasswordlogin" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
        <div class="d-flex justify-content-center">
            <asp:Button ID="btnLogin" OnClick="btnLogin_Click" CssClass="btn btn-primary mt-2  " runat="server" Text="Login" />
        </div>



        <h4 class="text-center pt-2">Registro de usuario</h4>
        <label for="email" class="form-label">Email</label>
        <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" TextMode="Email"></asp:TextBox>

        <label for="password" class="form-label">Password</label>
        <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>

        <label for="nombre" class="form-label">Nombre</label>
        <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>

        <label for="apellido" class="form-label">Apellido</label>
        <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"></asp:TextBox>

        <label for="urlimg" class="form-label">UrlImagen</label>
        <asp:TextBox ID="txtUrlImg" CssClass="form-control" runat="server"></asp:TextBox>
        <div class="d-flex justify-content-center">
            <asp:Button ID="btnRegistrar" OnClick="btnRegistrar_Click" CssClass="btn btn-primary mt-2  " runat="server" Text="Registrar" />
        </div>

    </div>

</asp:Content>
