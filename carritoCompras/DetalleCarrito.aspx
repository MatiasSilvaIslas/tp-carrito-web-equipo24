<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetalleCarrito.aspx.cs" Inherits="carritoCompras.DetalleCarrito" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Carrito</h1>
    <div class="container">
        <div class="row">
            <div class="col-md-8">
                <asp:Repeater ID="repArticulos" runat="server">
                    <HeaderTemplate>
                        <ul class="list-group">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li class="list-group-item">
                            <div class="row align-items-center">
                                <div class="col-2">
                                    <img src='<%# ((List<dominio.Imagen>)Eval("Imagenes")).Count > 0 ? ((List<dominio.Imagen>)Eval("Imagenes"))[0].ImagenUrl : "https://www.redeszone.net/app/uploads-redeszone.net/2021/09/Error-404-01-e1633683457508.jpg" %>' class="img-fluid" alt="..." />
                                </div>
                                <div class="col-5">
                                    <h5><%#Eval("Nombre") %></h5>
                                </div>
                                <div class="col-3">
                                    <p class="text-start">$<%#Eval("Precio") %></p>
                                </div>
                                <div class="col-2">
                                    <asp:Button runat="server" ID="btnEliminar" CssClass="btn btn-danger" Text="Eliminar" OnClick="btnEliminar_Click"  CommandArgument='<%#Eval("Id") %>' />
                                </div>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Label ID="lblTotal" runat="server" Text="" CssClass="col-12 my-3 text-start fs-4 fw-bold"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>



