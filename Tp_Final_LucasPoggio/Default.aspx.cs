using dominio;
using negocio;
using System;
using System.Collections.Generic;

namespace Tp_Final_LucasPoggio
{
    public partial class Default2 : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulo = negocio.ListarArticulos();
        }
    }
}