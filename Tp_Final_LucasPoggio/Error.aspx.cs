using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp_Final_LucasPoggio
{
    public partial class Error2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["error"] == null))
                lblError.Text = Session["error"].ToString();
        }
    }
}