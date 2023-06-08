<%@ Page Title="Contacto" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="carritoCompras.Formulario_web11" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--<section id="contacto">
        <div class="contact-section" id="contact">
            <div class="contact-headings">
                <h2>Contacto</h2>
                <div class="divider"></div>
            </div>
    
            <div class="container-contact">
                <div class="contact-form">
                    <h4> Enviame un mensaje </h4>
    
                    <form id="myForm" class="form" action="https://formsubmit.co/illanes.mariajose@gmail.com" method="POST">
                        <label for="nombre">Nombre</label>
                        <input type="text" placeholder="Name" required>
                        <label for="mail">Email</label>
                        <input type="email" placeholder="Email" required>
                        <label for="mensaje">Mensaje</label>
                        <textarea placeholder="Escriba aquí su mensaje..." required>
                        </textarea>
                        
                        <input type="submit" class="btn-send" value="enviar">
                        <input type="hidden" name="next" value="home.aspx">
                    </form>
                </div>
            </div>
    
        </div>
    </section>
        <script>
        document.getElementById("myForm").addEventListener("submit", function(event) {
            event.preventDefault();  
            Swal.fire({
            title: "Mensaje enviado",
            icon: "success",
            showConfirmButton: false,
            timer: 2000 
        }).then(() => {
            document.getElementById("myForm").reset();
        });
        });
        </script>--%>
    <div class="mb-3 col-4">
        <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="form-label">Email:</asp:Label>
        <input type="email" class="form-control" id="exampleFormControlInput1" placeholder="nombre@ejemplo.com">
    </div>
    <div class="mb-3 col-4">
        <asp:Label ID="lblMensaje" runat="server" CssClass="form-label">Tu mensaje:</asp:Label>
        <textarea class="form-control" id="txtAreaMensaje" rows="3"></textarea>
        <asp:Button ID="btnEnviar" cssClass="btn btn-primary mt-3" runat="server" Text="Enviar" />
    </div>
</asp:Content>
