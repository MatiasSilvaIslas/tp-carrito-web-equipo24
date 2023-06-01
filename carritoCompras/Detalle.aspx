<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="carritoCompras.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Detalles del producto</h2>
    <div class="container">
        <div class="card-body">
            <asp:Label Text="Nombre: " ID="lblNombre" runat="server" CssClass="d-block" />
            <asp:Label Text="$" ID="lblPrecio" runat="server" CssClass="d-block" />
            <asp:Label Text="" ID="lblMarca" runat="server" CssClass="d-block" />
            <asp:Label Text="" ID="lblCategoria" runat="server" CssClass="d-block" />
            <asp:Label Text="" ID="lblDescripcion" runat="server" CssClass="d-block" />
        </div>
        <div id="Carrusel" class="carousel slide" data-ride="carousel">
            <div class="carousel-inner">
                <asp:Repeater ID="repImg" runat="server">
                    <ItemTemplate>
                        <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>">
                            <img src='<%# Eval("ImagenUrl") %>' alt="Alternate Text" class="d-block w-100" />
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

    <script>
        $(document).ready(function () {
            $('.carousel').carousel();
        });
    </script>
</asp:Content>
