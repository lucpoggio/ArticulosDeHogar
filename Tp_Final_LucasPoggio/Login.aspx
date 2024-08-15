<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Tp_Final_LucasPoggio.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <%--Formulario de login--%>

    <h1>Login</h1>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" type="email" REQUIRED CssClass="form-control"/>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtPassword" class="form-label">Password</label>
                <asp:TextBox runat="server" ID="txtPassword" type="Password" REQUIRED CssClass="form-control" />
            </div>
        </div>
    </div>
        <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Button Text="Ingresar" ID="btnIngresar" CssClass="btn btn-primary" OnClick="btnIngresar_Click" runat="server" />
            </div>
        </div>
    </div>

</asp:Content>
