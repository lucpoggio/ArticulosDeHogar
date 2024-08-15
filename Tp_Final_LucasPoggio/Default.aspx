<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Tp_Final_LucasPoggio.Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Te mostramos un poco de nuestro stock :)</h1>

    <div class="row row-cols-1 row-cols-md-3 g-4">

        <%foreach (dominio.Articulo art in ListaArticulo)
            {%>
        <div class="col">
            <div class="card">
                <img src="<%: art.ImagenUrl %>" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title"><%: art.Nombre %></h5>
                    <p class="card-text"><%: art.Descripcion %></p>
                    <a href="FormularioArticulo.aspx?id=<%: art.Id %>">Ver detalle</a>
                </div>
            </div>
        </div>
        <%  } %>
    </div>


</asp:Content>
