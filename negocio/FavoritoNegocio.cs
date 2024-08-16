using dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace negocio
{
    public class FavoritoNegocio
    {
        AccesoDatos datos = new AccesoDatos();

        //Agrega un favorito a la base de datos
        public void InsertarFavorito(Favorito nuevoFavorito)
        {

            string consulta = $"INSERT INTO FAVORITOS (idUser,idArticulo) VALUES\r\n" +
                $"('{nuevoFavorito.IdUser.id}','{nuevoFavorito.IdArticulo.Id}')";

            try
            {
                datos.SetearConsulta(consulta);
                datos.EjecutarAccion();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        //Elimina un favorito de la base de datos
        public void EliminarFavorito(Favorito favorito)
        {
            try
            {
                string consulta = $"delete from FAVORITOS where IdArticulo = {favorito.IdArticulo.Id} and IdUser = {favorito.IdUser.id}";

                datos.SetearConsulta(consulta);
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

        //Valida si el favorito ya existe
        public bool ValidarFavorito(Favorito favorito) {        

            try
            {
                bool bandera = false;

                string consulta = $"select id from FAVORITOS where IdArticulo = {favorito.IdArticulo.Id} and IdUser = {favorito.IdUser.id}";
                               
                datos.SetearConsulta(consulta);
                datos.EjecutarLectura();

                if (datos.Lector.Read())
                {
                    bandera = true;
                }
                return bandera;
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
        //Cuenta los favoritos de un usuario
        public int ContarFavoritos(int id) {

            try
            {
                int resultado = 0;

                string consulta = $"select count(1) from FAVORITOS where IdUser = {id}";

                datos.SetearConsulta(consulta);
                datos.EjecutarLectura();

                if (datos.Lector.Read())
                {
                    resultado = (int)datos.Lector.GetInt32(0);
                }
                return resultado;
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



    }
}
