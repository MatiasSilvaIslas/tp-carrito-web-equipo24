<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="carritoCompras.home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Te damos la bienvenida</h1>
    <h3>Estos son algunos de nuestros productos mas destacados</h3>
    <div class="container" id="container-carousel">
        <div id="carouselExample" class="carousel slide">
      <div class="carousel-inner">
        <div class="carousel-item active">
          <img src="https://images.samsung.com/is/image/samsung/co-galaxy-s10-sm-g970-sm-g970fzyjcoo-frontcanaryyellow-thumb-149016542" class="d-block w-100" alt="...">
        </div>
        <div class="carousel-item">
          <img src="https://i.blogs.es/9da288/moto-g7-/1366_2000.jpg" class="d-block w-100" alt="...">
        </div>
        <div class="carousel-item">
          <img src="https://www.euronics.cz/image/product/800x800/532620.jpg" class="d-block w-100" alt="...">
        </div>
      </div>

      <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Previous</span>
      </button>
      <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
        <span class="carousel-control-next-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Next</span>
      </button>
        </div>
    </div>

    <div class="container mt-4 px-4">
        <div class="d-grid gap-1">
            <asp:Button ID="btnProductos" CssClass="btn btn-primary btn-lg btn-block" runat="server" Text="Ir a productos"  OnClick="btnProductos_Click" style="background-color:#372880 !important"/>
        </div>
    </div>
</asp:Content>
