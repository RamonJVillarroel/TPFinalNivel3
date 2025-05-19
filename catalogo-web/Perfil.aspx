<%@ Page Title="Perfil" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="catalogo_web.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h4>Este es perfil</h4>
      <div class="container mt-5">
            <div class="card p-4 shadow rounded">
                <div class="d-flex align-items-center">
                    <asp:Image ID="imgPerfil" runat="server" CssClass="rounded-circle me-3" Width="100" Height="100" />
                    <div>
                        <h3><asp:Label ID="lblNombre" runat="server" /></h3>
                        <p class="text-muted"><asp:Label ID="lblEmail" runat="server" /></p>
                        <span class="badge bg-primary"><asp:Label ID="lblTipo" runat="server" /></span>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
