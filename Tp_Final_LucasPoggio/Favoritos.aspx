<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="Tp_Final_LucasPoggio.Favoritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <h1>Tus productos favoritos</h1>

    <div class="row row-cols-1 row-cols-md-3 g-4">

        <%if(ListaFavoritos != null) { %>
        <%foreach (dominio.Articulo art in ListaFavoritos)
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
      <%  } %>
    </div>


</asp:Content>
