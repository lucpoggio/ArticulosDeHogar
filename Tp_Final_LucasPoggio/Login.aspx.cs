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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //Loguea al usuario para ingresar a la app
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            User user = new User();
            UserNegocio negocio = new UserNegocio();

            try
            {
                if (ValidacionNegocio.ValidaTextoVacio(txtEmail.Text) || ValidacionNegocio.ValidaTextoVacio(txtPassword.Text))
                {
                    Session.Add("Error", "Debes cargar ambos campos!");
                    Response.Redirect("Error.aspx");
                }
                user.Email = txtEmail.Text;
                user.Pass = txtPassword.Text;

                if (negocio.Login(user))
                {
                    Session.Add("User", user);
                    Response.Redirect("MiPerfil.aspx", false);
                }
                else
                {
                    Session.Add("error", "User o Pass incorrectos!!!");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
                throw;
            }

        }
    }
}