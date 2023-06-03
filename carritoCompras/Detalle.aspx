<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="carritoCompras.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Detalles del producto</h2>
    <div class="row sombra">
        <div class="col-md-6">
            <div id="Carrusel" class="carousel slide" data-ride="carousel">
                <div class="carousel-inner">
                    <asp:Repeater ID="repImg" runat="server">
                        <ItemTemplate>
                            <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>">
                                <img src='<%# Eval("ImagenUrl") %>' alt="Alternate Text" class="d-block w-100" onerror="this.src='https://img.freepik.com/premium-vector/no-photo-available-vector-icon-default-image-symbol-picture-coming-soon-web-site-mobile-app_87543-10615.jpg?size=626&ext=jpg&ga=GA1.1.70386129.1685633354&semt=location_fest_v1'" />
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <a class="carousel-control-prev" href="#Carrusel" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="sr-only">Anterior</span>
                </a>
                <a class="carousel-control-next" href="#Carrusel" role="button" data-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="sr-only">Siguiente</span>
                </a>
            </div>
        </div>
        <div class="col-md-6">

            <div class="card-body">
            <ul class="lista-detalles">
    <li>
        <span class="detalle-titulo">Nombre:</span>
        <asp:Label Text="Nombre" ID="lblNombre" runat="server" CssClass="detalle-contenido" />
    </li>
    <li>
        <span class="detalle-titulo">Precio:</span>
        <asp:Label Text="$" ID="lblPrecio" runat="server" CssClass="detalle-contenido" />
    </li>
    <li>
        <span class="detalle-titulo">Marca:</span>
        <asp:Label Text="Marca" ID="lblMarca" runat="server" CssClass="detalle-contenido" />
    </li>
    <li>
        <span class="detalle-titulo">Categoría:</span>
        <asp:Label Text="Categoría" ID="lblCategoria" runat="server" CssClass="detalle-contenido" />
    </li>
    <li>
        <span class="detalle-titulo">Descripción:</span>
        <asp:Label Text="Descripción" ID="lblDescripcion" runat="server" CssClass="detalle-contenido" />
    </li>
</ul>

            <a  href="Productos.aspx?id=<%#Eval("Id") %>"><button type="button" class="btn btn-primary" id="btn-volver">Volver</button></a>
        </div>
    </div>

    <script>
        $(document).ready(function () {
            $('.carousel').carousel();
        });
    </script>
</asp:Content>
