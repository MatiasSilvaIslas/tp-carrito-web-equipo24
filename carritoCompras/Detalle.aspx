<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="carritoCompras.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Detalles del producto</h2>
    <div class="container">
        <img src="<%: articulo.Imagenes.Count > 0 ? articulo.Imagenes[0].ImagenUrl : "https://www.redeszone.net/app/uploads-redeszone.net/2021/09/Error-404-01-e1633683457508.jpg" %>" class="card-img-top " alt="Imagen del articulo" style="max-width: 50%;" />

        <div class="card-body">
            <asp:Label Text="Nombre: " ID="lblNombre" runat="server" CssClass="d-block"/>
            <asp:Label Text="$" ID="lblPrecio" runat="server" CssClass="d-block"/>
            <asp:Label Text="" ID="lblMarca" runat="server" CssClass="d-block"/>
            <asp:Label Text="" ID="lblCategoria" runat="server" CssClass="d-block"/>
            <asp:Label Text="" ID="lblDescripcion" runat="server" CssClass="d-block" />
        </div>
    </div>

</asp:Content>
