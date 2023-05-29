<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="carritoCompras.home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row row-cols-1 row-cols-md-3 g-4">
         %><%
            foreach (dominio.Articulo articulo in articulos)
            { %>        

        <div class="col">
            <div class="card">
                <img src="<%: articulo.Imagenes.Count > 0 ? articulo.Imagenes[0].ImagenUrl : "https://www.redeszone.net/app/uploads-redeszone.net/2021/09/Error-404-01-e1633683457508.jpg" %>" class="card-img-top" alt="..." />
                <div class="card-body">
                    <h5 class="card-title"><%: articulo.Nombre  %></h5>
                    <p class="card-text"> $<%: articulo.Precio %></p>
                    <a href="Detalle.aspx?id=<%: articulo.Id %>" >Ver detalle </a>
                    <div class="input-group mb-3">
                        <!--Hay que ver como hacer para que agregar en la sesion, una lista de articulos y se multiplique por la cantidad de artículos ingresados
                            <input type="number" id="cantidad_<%: articulo.Id %>" class="form-control" placeholder="Cantidad" min="1" value="1">
                        <button class="btn btn-success" onclick="agregarAlCarrito('<%: articulo.Id %>')"> -->
                        <button class="btn btn-success">
                        <i class="fa fa-shopping-cart"></i> 
                        </button>
                    </div>
                </div>
            </div> 
        </div>
         <% } %>
    </div>
</asp:Content>
