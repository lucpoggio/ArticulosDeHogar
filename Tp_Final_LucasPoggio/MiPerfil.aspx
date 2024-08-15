<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="Tp_Final_LucasPoggio.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>
        function validar() {
            const nombre = document.getElementById("txtNombre");
            const apellido = document.getElementById("txtApellido")
            const pass = document.getElementById("txtPass");
            const email = document.getElementById("txtEmail");

            if (nombre.value == "" || apellido.value == "" || pass.value == "" || email.value == "" ) {
                alert("Campo Requerido!");
                return false;
            }
            return true;
        }
    </script>

    <style>
        .validacion {
            color: red;
            font-size: 12px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Mi Perfil</h2>

    <%--Campos del formulario--%>
    <div class="row">
        <div class="col-md-4">

            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" ClientIDMode="Static" Enabled="false" />
                <asp:RegularExpressionValidator ErrorMessage="Ingresar formato de mail!" CssClass="validacion" ControlToValidate="txtEmail" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="Email Requerido!" CssClass="validacion" ControlToValidate="txtEmail" runat="server" />
            </div>

    <%--Si el usuario es admin se habilitan las siguientes opciones--%> 
            <%if ((dominio.User)Session["User"] != null && ((dominio.User)Session["User"]).Admin)
                { %>
            <div class="mb-3">
                <label class="form-label">Pass</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtPass" ClientIDMode="Static" TextMode="Password" />
                <asp:RequiredFieldValidator ErrorMessage="Password Requerido!" CssClass="validacion" ControlToValidate="txtPass" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Es Admin?</label>
                <asp:CheckBox Text="Si" ID="chkSi" runat="server" />
                <asp:CheckBox Text="No" ID="chkNo" runat="server" />
            </div>
            <%} %>

            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" ClientIDMode="Static" MaxLength ="15"/>
                <asp:RequiredFieldValidator ErrorMessage="Nombre Requerido" CssClass="validacion" ControlToValidate="txtNombre" runat="server" />
                <asp:RegularExpressionValidator ErrorMessage="Ingrese solo letras!" CssClass="validacion" ValidationExpression="^[a-zA-Z]+$" ControlToValidate="txtNombre" runat="server" />
            </div>

            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido" ClientIDMode="Static" MaxLength ="15"/>
                <asp:RequiredFieldValidator ErrorMessage="Apellido Requerido!" CssClass="validacion" ControlToValidate="txtApellido" runat="server" />
                <asp:RegularExpressionValidator ErrorMessage="Ingrese solo letras!" CssClass="validacion" ValidationExpression="^[a-zA-Z]+$" ControlToValidate ="txtApellido" runat="server" />
            </div>

            <div class="mb-3">
                <asp:Button Text="Modificar" runat="server" CssClass="btn btn-primary" ID="btnModificar" OnClick="btnModificar_Click" OnClientClick="return validar()" />
                <a href="/">Regresar</a>
            </div>

      <%--Si el usuario es admin se habilita un boton para agregar usuarios--%>
            <%if ((dominio.User)Session["User"] != null && ((dominio.User)Session["User"]).Admin)
                { %>
            <div class="mb-3">
                <asp:Button Text="Agregar" runat="server" CssClass="btn btn-primary" ID="btnAgregar" OnClientClick="return validar()" OnClick="btnAgregar_Click" />
            </div>
            <%} %>
        </div>


        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Imagen Perfil</label>
                <input type="file" id="txtImagen" runat="server" class="form-control" />
            </div>
            <asp:Image ID="imgNuevoPerfil" ImageUrl="https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg"
                runat="server" CssClass="img-fluid mb-3" />
        </div>
    </div>

</asp:Content>
