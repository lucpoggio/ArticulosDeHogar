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
    public partial class Favoritos : System.Web.UI.Page
    {
        public List<Articulo> ListaFavoritos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {    
            User usuarioLogueado = new User();
            usuarioLogueado = (User)Session["User"];

            if (usuarioLogueado != null) {
                ArticuloNegocio negocio = new ArticuloNegocio();
                ListaFavoritos = negocio.ListarArticulos(usuarioLogueado.id.ToString());
            }
        }
    }

}



