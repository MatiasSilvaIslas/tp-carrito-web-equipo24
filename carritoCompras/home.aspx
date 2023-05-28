<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="carritoCompras.home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <%-- %><%
            foreach (dominio.Articulo articulo in articulos)
            { %>        

        <div class="col">
            <div class="card">
                <img src="<%: articulo.Imagenes.Count > 0 ? articulo.Imagenes[0].ImagenUrl : "https://www.redeszone.net/app/uploads-redeszone.net/2021/09/Error-404-01-e1633683457508.jpg" %>" class="card-img-top" alt="..." />
                <div class="card-body">
                    <h5 class="card-title"><%: articulo.Nombre  %></h5>
                    <p class="card-text"> $<%: articulo.Precio %></p>
                    <asp:Button Text="text" runat="server" />
                </div>
            </div>
        </div>
         <% } %>--%>

        <asp:Repeater ID="repArticulos" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src='<%# ((List<dominio.Imagen>)Eval("Imagenes")).Count > 0 ? ((List<dominio.Imagen>)Eval("Imagenes"))[0].ImagenUrl : "https://www.redeszone.net/app/uploads-redeszone.net/2021/09/Error-404-01-e1633683457508.jpg" %>' class="card-img-top" alt="..." />
                        <div class="card-body">
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                <p class="card-text">$<%#Eval("Precio") %></p>
                                <asp:Button Text="Ver detalle" CssClass="btn btn-info" runat="server" ID="btnDetalle" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" OnClick="btnDetalle_Click"/>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
