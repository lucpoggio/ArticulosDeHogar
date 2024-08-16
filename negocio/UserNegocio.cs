using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;


namespace negocio
{
    public class UserNegocio
    {
        AccesoDatos datos = new AccesoDatos();

        //Loguea al usuario en la aplicacion
        public bool Login(User user)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("select id,email,pass,nombre,apellido,urlImagenPerfil,admin from users where email = @email and pass = @pass");
                datos.SetearParametro("@email", user.Email);
                datos.SetearParametro("@pass", user.Pass);

                datos.EjecutarLectura();
                if (datos.Lector.Read())
                {
                    user.id = (int)datos.Lector["Id"];

                    if (!(datos.Lector["nombre"] is DBNull))
                        user.Nombre = (string)datos.Lector["nombre"];
                    if (!(datos.Lector["apellido"] is DBNull))
                        user.Apellido = (string)datos.Lector["apellido"];
                    if (!(datos.Lector["urlImagenPerfil"] is DBNull))
                        user.UrlImagenPerfil = (string)datos.Lector["urlImagenPerfil"];

                    user.Admin = (bool)datos.Lector["admin"];

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }

        }

        //Modifica los datos de un usuario
        public void ModificarUsuario(User user)
        {
            try
            {
                if(user.Admin)
                    datos.SetearConsulta("Update USERS set Nombre = @nombre, Apellido = @apellido, Pass = @pass, UrlImagenPerfil = @imagen Where id = @id");
                else
                    datos.SetearConsulta("Update USERS set Nombre = @nombre, Apellido = @apellido, UrlImagenPerfil = @imagen Where id = @id");

                datos.SetearParametro("@nombre", user.Nombre);
                datos.SetearParametro("@apellido", user.Apellido);
                datos.SetearParametro("@pass",user.Pass);
                datos.SetearParametro("@imagen", (object)user.UrlImagenPerfil ?? DBNull.Value);

                datos.SetearParametro("@id", user.id);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }

        }

        //Agrega usuarios nuevos a la base de datos
        public void AgregarUsuario(User nuevo)
        {
            int bandera = 0;
            if (nuevo.Admin)
            {
                bandera = 1;
            }

            try
            {
                datos.SetearConsulta($"insert into USERS values ('{nuevo.Email}','{nuevo.Pass}','{nuevo.Nombre}','{nuevo.Apellido}','{nuevo.UrlImagenPerfil}',{bandera})");
      
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
      
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        //Lista los mails de los usuarios registrados 
        private List<string> ListarMailUsuarios() {

            List<string> lista = new List<string>();
            try
            {
                string consulta = "select email from users";
                datos.SetearConsulta(consulta);
                datos.EjecutarLectura();

                while (datos.Lector.Read()) { 
                    User auxiliar = new User();
                    auxiliar.Email = (string)datos.Lector["email"];
                    lista.Add(auxiliar.Email.ToString());
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }

        }

        //Valida si el mail ingresado ya existe
        public bool ValidarUsuario(string nuevoMail) {

            bool bandera = false;
            List<string> lista = null;
            lista = ListarMailUsuarios();

            foreach (string mails in lista)
            {
                if (mails.ToUpper() == nuevoMail.ToUpper()) {
                    bandera = true;
                    break;
                }
            }
            return bandera;
        }

    }
}
