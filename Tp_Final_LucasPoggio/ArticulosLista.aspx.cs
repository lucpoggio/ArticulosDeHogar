using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace Tp_Final_LucasPoggio
{
    public partial class ArticulosLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Session.Add("ListaArticulos", negocio.ListarArticulos());
                dgvArticulos.DataSource = Session["ListaArticulos"];
                dgvArticulos.DataBind();
            }
        }

        //Busca el articulo segun el criterio de busqueda elegido
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Articulo> lista = (List<Articulo>)Session["ListaArticulos"];
            List<Articulo> listaFiltrada;

            if (dllCampo.SelectedItem.ToString() == "Nombre")
            {
                listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
                Bindear(listaFiltrada);
            }
            else if (dllCampo.SelectedItem.ToString() == "Marca")
            {
                listaFiltrada = lista.FindAll(x => x.Marca.Descripcion.ToUpper().Contains(txtFiltro.Text.ToUpper()));
                Bindear(listaFiltrada);
            }
            else 
            {
                listaFiltrada = lista.FindAll(x => x.Categoria.Descripcion.ToUpper().Contains(txtFiltro.Text.ToUpper()));
                Bindear(listaFiltrada);
            }
        }

        //Extrae el id del articulo elegido
        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
           string id = dgvArticulos.SelectedDataKey.Value.ToString();  
           Response.Redirect("FormularioArticulo.aspx?id=" + id);
        }

        //Indexa la lista de articulos para pasar de página
        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataSource = Session["ListaArticulos"];
            dgvArticulos.DataBind();
        }

        //Bindea los articulos
        private void Bindear(List<Articulo> listaFiltrada) {
            dgvArticulos.DataSource = listaFiltrada;
            dgvArticulos.DataBind();
        }
    }
}