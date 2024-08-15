<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="Tp_Final_LucasPoggio.FormularioArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <%--Estilos Css--%>
    <style>
        a.neon {
            text-decoration: none;
            color: #fff;
            font-weight: bold;
            padding: 10px 20px;
            background-color: #222;
            border-radius: 5px;
            box-shadow: 0 0 5px #0ff, 0 0 10px #0ff, 0 0 15px #0ff, 0 0 20px #0ff;
            transition: all 0.3s ease-in-out;
        }

            a.neon:hover {
                color: #0ff;
                box-shadow: 0 0 10px #0ff, 0 0 20px #0ff, 0 0 30px #0ff, 0 0 40px #0ff;
            }

        .heart-btn {
            background-color: transparent;
            border: none;
            color: red;
            font-size: 30px;
            cursor: pointer;
            outline: none;
            padding: 0px;
            margin-top: 50px;
            margin-left: 50px;
        }

        .validacion {
            color: red;
            font-size: 14px;
        }
    </style>

    <%--Campos del formulario con sus validaciones--%>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                <asp:RequiredFieldValidator ErrorMessage="El nombre es requerido!" ControlToValidate="txtNombre" CssClass="validacion" runat="server" />
                <asp:RegularExpressionValidator ErrorMessage="Ingrese solo letras!" CssClass="validacion" ValidationExpression="^[a-zA-Z]+$" ControlToValidate="txtNombre" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Codigo</label>
                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />
                <asp:RequiredFieldValidator ErrorMessage="El código es requerido!" CssClass="validacion" ControlToValidate="txtCodigo" runat="server" />
                <asp:RegularExpressionValidator ErrorMessage="Maximo de 6 caracteres!" CssClass="validacion" ValidationExpression="^.{1,6}$" ControlToValidate="txtCodigo" runat="server" />
            </div>
            <div class="mb-3">
                <label for="ddlMarca" class="form-label">Marca: </label>
                <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Categoria: </label>
                <asp:DropDownList ID="ddlCategoria" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
                <asp:RequiredFieldValidator ErrorMessage="El precio es requerido!" CssClass="validacion" ControlToValidate="txtPrecio" runat="server" />
                <asp:RangeValidator ErrorMessage="Ingrese un precio real!" CssClass="validacion" MinimumValue="1" MaximumValue="99999999" ControlToValidate="txtPrecio" runat="server" />
            </div>

            <%--Si el usuario es administrador puede acceder a los siguientes botones de modificacion--%>

            <%if ((dominio.User)Session["User"] != null && ((dominio.User)Session["User"]).Admin)
              { %>

                <div class="mb-3">
                    <asp:Button Text="Agregar" ID="btnAgregar" CssClass="btn btn-success" OnClick="btnAgregar_Click" runat="server" />
                    <asp:Button Text="Modificar" ID="btnModificar" CssClass="btn btn-primary" OnClick="btnModificar_Click" runat="server" />
                    <asp:Button Text="Eliminar" ID="btnEliminar" CssClass="btn btn-danger" OnClick="btnEliminar_Click" runat="server" />
                    <asp:Button Text="Limpiar Formulario" ID="btnLimpiar" CssClass="btn btn-light" OnClick="btnLimpiar_Click" runat="server" />
                </div>

            <%} %>

            <div class="mb-3">
                <a href="ArticulosLista.aspx" class="neon">Volver</a>
            </div>
        </div>

        <div class="col-6">
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripcion</label>
                <asp:TextBox runat="server" TextMode="MultiLine" ID="txtDescripcion" CssClass="form-control" />
                <asp:RegularExpressionValidator ErrorMessage="El texto debe contener menos de 150 caracteres!" ValidationExpression="^.{1,150}$" CssClass="validacion" ControlToValidate="txtDescripcion" runat="server" />
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtImagenUrl" class="form-label">Url Imagen</label>
                        <asp:TextBox runat="server" ID="txtImagenUrl" CssClass="form-control" AutoPostBack="true"
                            OnTextChanged="txtImagenUrl_TextChanged" />
                    </div>

                    <asp:Image ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQyGugGnJH-OQqFvnwEotslfDyO28f7muEhrg&s"
                        runat="server" ID="imgArticulo" Width="60%" />

                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>

                            <%--Si hay un articulo en el formulario, aparece la opcion de agregarlo a favoritos--%>

                            <%if (id != null && id != "")
                              { %>

                                <%if (BanderaFavorito == false)
                                  { %>
                                    <asp:Button ID="btnFavorito" runat="server" OnClick="btnFavorito_Click" CssClass="btn btn-primary" Text="Agregar a Favoritos" />
                                <%} %>

                                <%else
                                  { %>
                                    <asp:Button ID="Button1" runat="server" OnClick="btnFavorito_Click" class="heart-btn" Text="❤" />
                                <%} %>

                            <%} %>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div class="col-6">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>

</asp:Content>
