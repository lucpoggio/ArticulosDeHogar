<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Tp_Final_LucasPoggio.Error2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        body {
            background-image: url("./Images/Homero.png");
            background-size: 50%; /* Ajusta la imagen para cubrir toda la pantalla */
            background-repeat: no-repeat;
            background-position: center calc(100% + 600px);
        }
    </style>

    <asp:Label text="text" id="lblError" runat="server" />

</asp:Content>
