<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioMarcaCategoria.aspx.cs" Inherits="Tp_Final_LucasPoggio.FormularioMarcaCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Agregar o Eliminar</h2>

    <%--Campos de Marca y Categoria--%>
    <div class="row">
        <div class="col-md-4">

            <div class="mb-3">
                <label class="form-label">Agregar Marca</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtMarca" />
            </div>
            <div class="mb-3">
                <label for="ddlMarca" class="form-label">Eliminar Marca: </label>
                <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Button Text="Agregar Marca" runat="server" CssClass="btn btn-primary" ID="btnAgregar" OnClick="btnAgregarMacar_Click" />
                <asp:Button Text="Eliminar Marca" runat="server" CssClass="btn btn-danger" ID="btnEliminarMarca" OnClick="btnEliminarMarca_Click"/>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">

            <div class="mb-3">
                <label class="form-label">Agregar Categoria</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="TxtCategoria" />
            </div>
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Eliminar Categoria: </label>
                <asp:DropDownList ID="ddlCategoria" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Button Text="Agregar Categoria" runat="server" CssClass="btn btn-primary" ID="btnAgregarCategoria" OnClick="btnAgregarCategoria_Click" />
                <asp:Button Text="Eliminar Categoria" runat="server" CssClass="btn btn-danger" ID="btnEliminarCategoria" OnClick="btnEliminarCategoria_Click"/>
            </div>
        </div>
    </div>


</asp:Content>
