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
        <asp:Image ImageUrl="" runat="server" ID="imgArticulo" Width="60%" />
    </div>
</asp:Content>
