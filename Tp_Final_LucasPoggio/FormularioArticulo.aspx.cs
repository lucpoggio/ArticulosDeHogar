using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp_Final_LucasPoggio
{
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        public bool BanderaFavorito = false;
        public string id = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

            if (id != null && id != "") { 

                FavoritoNegocio negocio = new FavoritoNegocio();
                Favorito nuevoFavorito = new Favorito();

                precargarFavorito(nuevoFavorito);
                if (negocio.ValidarFavorito(nuevoFavorito))
                    BanderaFavorito = true;
                else
                    BanderaFavorito = false;
            }

            try
            {
                //Configuracion inicial
                if (!IsPostBack)
                {                    
                    MarcaNegocio negocioMarca = new MarcaNegocio();
                    List<Marca> listaMarca = negocioMarca.Listar();

                    ddlMarca.DataSource = listaMarca;
                    ddlMarca.DataValueField = "id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();

                    CategoriaNegocio negocioCategoria = new CategoriaNegocio();
                    List<Categoria> listaCategoria = negocioCategoria.Listar();

                    ddlCategoria.DataSource = listaCategoria;
                    ddlCategoria.DataValueField = "id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();
                }
        
                //Configuracion si estamos modificando.
                if (id != "" && !IsPostBack)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Articulo articulo = negocio.ListarUnArticulo(id);
                    Articulo seleccionado = articulo; 
           
                    Session.Add("ArticuloSeleccionado", seleccionado);
           
                    //Pre-cargar todos los campos
                    txtId.Text = id;
                    txtNombre.Text = seleccionado.Nombre;
                    txtCodigo.Text = seleccionado.Codigo;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtImagenUrl.Text = seleccionado.ImagenUrl;
                    txtPrecio.Text = seleccionado.Precio.ToString();
           
                    BindearDdList();
                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();  
           
                    txtImagenUrl_TextChanged(sender, e);
                }
                
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        //Asigna la url de imagen a la propiedad ImageUrl del artículo
        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;
        }

        //Agrega un articulo nuevo a la base de datos
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;

            if (Validaciones())
                return;

            try
            {
                if (txtId.Text == "" || txtId.Text is null)
                {
                    Articulo nuevoArticulo = new Articulo();
                    ArticuloNegocio negocio = new ArticuloNegocio();

                    SetearArticulo(nuevoArticulo);
                    negocio.InsertarArticulo(nuevoArticulo);
                    Response.Redirect("ArticulosLista.aspx",false);
                }
                else
                {
                    string script = "alert('Presione el boton Limpiar para luego agregar un nuevo articulo!')";
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", script, true);
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx",false);
            }
        }

        //Modifica el articulo elegido
        protected void btnModificar_Click(object sender, EventArgs e)
        {
             Page.Validate();
             if (!Page.IsValid)
                 return;

            if(Validaciones())
                return;

            try
            {
                if (!(txtId.Text == "" || txtId.Text is null))
                {
                    Articulo nuevoArticulo = new Articulo();
                    ArticuloNegocio negocio = new ArticuloNegocio();

                    nuevoArticulo.Id = int.Parse(txtId.Text);
                    SetearArticulo(nuevoArticulo);

                    negocio.ModificarArticulo(nuevoArticulo);
                    Response.Redirect("ArticulosLista.aspx",false);
                }
                else
                {
                    string script = "alert('Seleccione un articulo para modificar!')";
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", script, true);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        //Elimina el articulo elegido
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!(txtId.Text == "" || txtId.Text is null))
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                negocio.EliminarArticulo(int.Parse(txtId.Text));

                Favorito favorito = new Favorito();
                FavoritoNegocio favoritoNegocio = new FavoritoNegocio();
                precargarFavorito(favorito);

                if (favoritoNegocio.ValidarFavorito(favorito))
                    favoritoNegocio.EliminarFavorito(favorito);

                string script = "alert('Articulo eliminado con éxito!')";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", script, true);

            }
            else { 
                string script = "alert('Seleccione un articulo para eliminar!')";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", script, true);
                return;
            }
            Response.Redirect("ArticulosLista.aspx", false);
        }

        //Vacia todos los casilleros de texto del formulario
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtId.Text = null;
            txtCodigo.Text = null;
            txtNombre.Text = null;
            txtDescripcion.Text = null;
            txtImagenUrl.Text = null;
            txtPrecio.Text = null;
        }

        //Asigna valores a un nuevo objeto
        private void SetearArticulo(Articulo nuevoArticulo) {
            nuevoArticulo.Codigo = txtCodigo.Text;
            nuevoArticulo.Nombre = txtNombre.Text;
            nuevoArticulo.Descripcion = txtDescripcion.Text;

            nuevoArticulo.Marca = new Marca();
            nuevoArticulo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
            nuevoArticulo.Categoria = new Categoria();
            nuevoArticulo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

            nuevoArticulo.ImagenUrl = txtImagenUrl.Text;
            nuevoArticulo.Precio = decimal.Parse(txtPrecio.Text);
        }

        //Guarda o quita el articulo de favoritos
        protected void btnFavorito_Click(object sender, EventArgs e)
        {
           FavoritoNegocio negocio = new FavoritoNegocio();
           Favorito Nuevofavorito = new Favorito();
           precargarFavorito(Nuevofavorito);

           if (txtId.Text is null || txtId.Text == "")
           {
                string script = "alert('Seleccione un articulo para agregar a favoritos!')";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", script, true);
                Response.Redirect("ArticulosLista.aspx", false);
                
           }
           else { 
                bool bandera = negocio.ValidarFavorito(Nuevofavorito);

                 if (bandera == false)
                 {
                     negocio.InsertarFavorito(Nuevofavorito);
                     BanderaFavorito = true;
                 }
                 else { 
                     negocio.EliminarFavorito(Nuevofavorito);
                     BanderaFavorito = false;    
                 }
           }
        }

        //Asigna valores al nuevo favorito
        private void precargarFavorito(Favorito nuevoFavorito) {
            
            User usuarioLogueado = new User();
            usuarioLogueado = (User)Session["User"];

            //FavoritoNegocio negocio = new FavoritoNegocio();
            nuevoFavorito.IdArticulo = new Articulo();
            nuevoFavorito.IdUser = new User();
            nuevoFavorito.IdArticulo.Id = int.Parse(Request.QueryString["id"].ToString());
            nuevoFavorito.IdUser.id = usuarioLogueado.id;
        }

        //Bindea los DropDownList de Marca y Categoria
        private void BindearDdList()
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            ddlMarca.DataSource = marcaNegocio.Listar();
            ddlMarca.DataTextField = "Descripcion";
            ddlMarca.DataValueField = "Id";
            ddlMarca.DataBind();

            ddlCategoria.DataSource = categoriaNegocio.Listar();
            ddlCategoria.DataTextField = "Descripcion";
            ddlCategoria.DataValueField = "Id";
            ddlCategoria.DataBind();

        }

        //Validaciones backEnd de los campos del formulario
        private bool Validaciones() {

            bool bandera = false;
            if (txtNombre.Text == "" || txtCodigo.Text == "" || txtPrecio.Text == "") {
                bandera = true;
            }
            else { 
                if (txtPrecio.Text.Any(char.IsLetter) || txtDescripcion.Text.Length > 150 || txtCodigo.Text.Length > 8)
                    bandera = true;
            }
            return bandera;
        }


    }
}