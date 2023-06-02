<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="carritoCompras.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <%--<%
              foreach (dominio.Articulo articulo in articulos)
              { %>

        <div class="col">
            <div class="card">
                <img src="<%: articulo.Imagenes.Count > 0 ? articulo.Imagenes[0].ImagenUrl : "https://www.redeszone.net/app/uploads-redeszone.net/2021/09/Error-404-01-e1633683457508.jpg" %>" class="card-img-top" alt="..." />
                <div class="card-body">
                    <h5 class="card-title"><%: articulo.Nombre  %></h5>
                    <%string aux = articulo.Id.ToString(); %>
                    <p class="card-text">$<%: articulo.Precio %></p>
                    <a href="Detalle.aspx?id=<%: articulo.Id %>">Ver detalle </a>
                    <div class="input-group mb-3">
                        <!--Hay que ver como hacer para que agregar en la sesion, una lista de articulos y se multiplique por la cantidad de artículos ingresados
                            <input type="number" id="cantidad_<%: articulo.Id %>" class="form-control" placeholder="Cantidad" min="1" value="1">
                        <button class="btn btn-success" onclick="agregarAlCarrito('<%: articulo.Id %>')"> -->
                        <asp:Button ID="btnAgregar" OnCommand="agregar_Click" runat="server" Text="Agregar" CssClass="btn btn-light" CommandArgument="<# articulo.Id %>" />
                    </div>
                </div>
            </div>
        </div>
        <% } %>--%>

        <asp:Repeater ID="repArticulos" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card sombra">
                        <img src='<%# ((List<dominio.Imagen>)Eval("Imagenes")).Count > 0 ? ((List<dominio.Imagen>)Eval("Imagenes"))[0].ImagenUrl : "https://img.freepik.com/premium-vector/no-photo-available-vector-icon-default-image-symbol-picture-coming-soon-web-site-mobile-app_87543-10615.jpg?size=626&ext=jpg&ga=GA1.1.70386129.1685633354&semt=location_fest_v1" %>' class="card-img-top" alt="..." />
                        <div class="card-body">
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                <p class="card-text">$<%#Eval("Precio") %></p>
                                <a href="Detalle.aspx?id=<%#Eval("Id") %>">Ver detalle </a>
                                <asp:Button ID="btnAgregar" OnClick="agregar_Click" runat="server" Text="Agregar" CssClass="btn btn-light" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" />
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
