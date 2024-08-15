using Microsoft.Win32;
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
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgAvatar.ImageUrl = "https://simg.nicepng.com/png/small/202-2022264_usuario-annumo-usuario-annimo-user-icon-png-transparent.png";
           
            if (!(Page is Login || Page is Default2 || Page is Error2))
            {
                if (!Seguridad.sesionActiva(Session["User"]))
                    Response.Redirect("Login.aspx", false);
            }
           
            if (Seguridad.sesionActiva(Session["User"]) && ((User)Session["User"]).UrlImagenPerfil != null)
                imgAvatar.ImageUrl = "~/Images/" + ((User)Session["User"]).UrlImagenPerfil;
            else
            {
                imgAvatar.ImageUrl = "https://media.istockphoto.com/id/1458683533/es/vector/signo-de-interrogaci%C3%B3n-en-persona-cabeza-icono-vector-como-desconocido-secreto-an%C3%B3nimo.jpg?s=612x612&w=0&k=20&c=sG5GQQKtxiqCAisySy8gDe5FDJdSaIJVLHzZTrRxVtQ=";
            }
        }
    }
}