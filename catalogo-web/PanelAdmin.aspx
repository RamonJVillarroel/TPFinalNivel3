<%@ Page Title="PanelAdministracion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PanelAdmin.aspx.cs" Inherits="catalogo_web.PanelAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="text-center">Panel de administración.</h1>
    <div class="container">
        <asp:GridView ID="dgvListadoProductos" OnSelectedIndexChanged="dgvListadoProductos_SelectedIndexChanged" runat="server" CssClass="table mt-3" DataKeyNames="IdArticulo" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="Id" DataField="IdArticulo" />
                <asp:BoundField HeaderText="Nombre" DataField="NombreArticulo" />
                <asp:BoundField HeaderText="Precio" DataField="Precio" />
                <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="Modificar" />

            </Columns>

        </asp:GridView>
        <a href="" class="btn btn-primary ">Agregar</a>

    </div>

</asp:Content>
