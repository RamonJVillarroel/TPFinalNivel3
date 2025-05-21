<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="catalogo_web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1 class="text-center">Bienvenido al catalogo web</h1>
    <div id="carouselExampleControls" class="carousel slide" data-bs-ride="carousel">
        <div class="carousel-inner">
            <div class="carousel-item active">
                <img src="https://img.freepik.com/vector-gratis/ilustracion-contorno-sudadera-capucha-dibujada-mano_23-2150918506.jpg?semt=ais_hybrid&w=500" class="d-block mx-auto w-70" alt="...">
            </div>
            <div class="carousel-item">
                <img src="https://img.freepik.com/vector-gratis/ilustracion-contorno-sudadera-capucha-dibujada-mano_23-2150918506.jpg?semt=ais_hybrid&w=500" class="d-block mx-auto w-70" alt="...">
            </div>
            <div class="carousel-item">
                <img src="https://img.freepik.com/vector-gratis/ilustracion-contorno-sudadera-capucha-dibujada-mano_23-2150918506.jpg?semt=ais_hybrid&w=500" class="d-block mx-auto w-70" alt="...">
            </div>
        </div>
        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
        </button>
    </div>

</asp:Content>
