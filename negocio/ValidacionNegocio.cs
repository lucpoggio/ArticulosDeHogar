using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace negocio
{
    public class ValidacionNegocio
    {
        //Valida si hay datos en un TextBox
        public static bool ValidaTextoVacio(object control)
        {
            if (control is TextBox)
            {
                if (string.IsNullOrEmpty(((TextBox)control).Text))
                    return false;
                else
                    return true;
            }

            return false;
        }

    }
}
