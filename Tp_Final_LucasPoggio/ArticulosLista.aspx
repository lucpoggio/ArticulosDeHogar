<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ArticulosLista.aspx.cs" Inherits="Tp_Final_LucasPoggio.ArticulosLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h2>Articulos en Stock</h2>


    <%----Filtro de busqueda----%>

    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Criterio de Busqueda" runat="server" />
                <asp:DropDownList ID="dllCampo" CssClass="form-control" runat="server" AutoPostBack="true">
                    <asp:ListItem Text="Nombre" />
                    <asp:ListItem Text="Marca" />
                    <asp:ListItem Text="Categoria" />
                </asp:DropDownList>
            </div>
        </div>

        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Buscar" runat="server" />
                <asp:TextBox ID="txtFiltro" runat="server" CssClass="form-control" />
            </div>
        </div>
    </div>


    <%--Boton Buscar--%>
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Button Text="Buscar" runat="server" ID="btnBuscar" CssClass="btn btn-outline-primary" OnClick="btnBuscar_Click"/>
            </div>
        </div>
    </div>


    <%--Lista de articulos--%>
    <asp:UpdatePanel ID="FiltrarNombre" runat="server">
        <ContentTemplate>

            <asp:GridView ID="dgvArticulos" runat="server" DataKeyNames="Id" CssClass=" table table-sm table-dark btn-outline-warning"
                AutoGenerateColumns="false" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged"
                OnPageIndexChanging="dgvArticulos_PageIndexChanging" AllowPaging="true" PageSize="4">
                <Columns>
                    <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                    <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />                   
                    <asp:BoundField HeaderText="Precio" DataField="Precio" />
                    <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="✍️" />
                </Columns>
            </asp:GridView>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>