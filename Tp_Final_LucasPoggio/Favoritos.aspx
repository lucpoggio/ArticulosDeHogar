<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="Tp_Final_LucasPoggio.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        #myCarousel {
            margin-top: 60px;
        }

        .carousel-item img {
            width: 50%;
            height: 50%;
            margin: 0 auto;
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .carousel-control-prev-icon::before {
            content: '\2039';
            font-size: 50px;
            color: black;
        }

        .carousel-control-next-icon::before {
            content: '\203A';
            font-size: 50px;
            color: black;
        }
    </style>

    <%--Titulo con cantidad de productos favoritos--%>

    <%if ((dominio.User)Session["User"] != null)
        { %>
    <h1>Tenes <%: CantidadFavoritos %> productos en tu lista de favoritos 😊</h1>
    <%  } %>

    <%--Carousel con lista de productos favoritos--%>

    <%if (ListaFavoritos != null)
        { %>
    <div id="myCarousel" class="carousel slide" data-ride="carousel">
        <!-- Indicadores -->
        <ul class="carousel-indicators">
            <% 
                int index = 0;
                foreach (var item in ListaFavoritos)
                { %>
            <li data-target="#myCarousel" data-slide-to="<%= index %>" class="<%= index == 0 ? "active" : "" %>"></li>
            <% index++;
                } %>
        </ul>

        <!-- Slides -->
        <div class="carousel-inner">
            <% 
                index = 0;
                foreach (var item in ListaFavoritos)
                { %>
            <div class="carousel-item <%= index == 0 ? "active" : "" %>">
                <img src="<%: item.ImagenUrl %>" alt="<%= item.Nombre %>">

                <div>
                    <h3><%= item.Nombre %></h3>
                    <p><%= item.Descripcion %></p>
                </div>


            </div>
            <% index++;
                } %>
        </div>

        <!-- Controles del carrusel -->
        <a class="carousel-control-prev" href="#myCarousel" data-slide="prev">
            <span class="carousel-control-prev-icon"></span>
        </a>
        <a class="carousel-control-next" href="#myCarousel" data-slide="next">
            <span class="carousel-control-next-icon"></span>
        </a>
    </div>


    <%  } %>
</asp:Content>
