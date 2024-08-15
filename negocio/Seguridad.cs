using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class Seguridad
    {
        //Valida si la la sesion está activa. Es decir, si el usuario inició sesión
        public static bool sesionActiva(object usuarioAuxiliar)
        {
            User user = usuarioAuxiliar != null ? (User)usuarioAuxiliar : null;
            if (user != null)
                return true;
            else
                return false;
        }

    }
}
