using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace Tp_Final_LucasPoggio
{
    public partial class FormularioMarcaCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
                //FormularioArticulo negocio = new FormularioArticulo();
                BindearDdList();
            } 
         
        }

        //Agregar una marca a la base de datos
        protected void btnAgregarMacar_Click(object sender, EventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();

            if (txtMarca.Text == "" || txtMarca.Text == null)
            {
                string script = "alert('Ingrese una marca para agregar!')";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", script, true);
                return;
            }
            else {
                string marca = txtMarca.Text;
                negocio.CargarNuevaMarca(marca);
                Response.Redirect("FormularioMarcaCategoria.aspx", false);
            }
        }

        //Agregar una categoria a la base de datos
        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();

            if (TxtCategoria.Text == "" || TxtCategoria == null)
            {
                string script = "alert('Ingrese una categoria para agregar!')";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", script, true);
                return;
            }
            else {
                string categoria = TxtCategoria.Text;
                negocio.CargarNuevaCategoria(categoria);
                Response.Redirect("FormularioMarcaCategoria.aspx", false);
            }


        }

        //Elimina una marca
        protected void btnEliminarMarca_Click(object sender, EventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();
            Marca marca = new Marca();

            marca.Id = int.Parse(ddlMarca.SelectedValue);

            if (validarEliminacion(marca.Id))
            {
                string script = "alert('La marca esta siendo usada por articulos de stock!')";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", script, true);
                return;
            }
            else
            {
                negocio.EliminarMarca(marca);
                Response.Redirect("FormularioMarcaCategoria.aspx",false);
            }
        }

        //Elimina una categoria
        protected void btnEliminarCategoria_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            Categoria categoria = new Categoria();

            categoria.Id =  int.Parse(ddlCategoria.SelectedValue);

            if (validarEliminacion(categoria.Id)) {
                string script = "alert('La categoria esta siendo usada por articulos de stock!')";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", script, true);
                return;
            }
            else {     
                negocio.EliminarCategoria(categoria);
                Response.Redirect("FormularioMarcaCategoria.aspx", false);
            }
        }

        //Valida que el id no este siendo usado en los articulos
        private bool validarEliminacion(int id) {

            bool bandera = false;
            ArticuloNegocio negocio = new ArticuloNegocio();
            List<Articulo> ListaArticulos = negocio.ListarArticulos();

            foreach (var articulo in ListaArticulos)
            {
                if (id == articulo.Categoria.Id) {  
                    bandera = true;
                    break;
                }
            }
            return bandera;

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

    }
}