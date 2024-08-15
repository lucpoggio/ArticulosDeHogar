using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class CategoriaNegocio
    {
        AccesoDatos datos = new AccesoDatos();

        //Lista las categorias
        public List<Categoria> Listar()
        {
            List<Categoria> lista = new List<Categoria>();

            try
            {
                datos.SetearConsulta("select Id,Descripcion from CATEGORIAS");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria auxiliar = new Categoria();
                    auxiliar.Id = (int)datos.Lector["Id"];
                    auxiliar.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(auxiliar);
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

        //Inserta una nueva categoria a la base de datos
        public void CargarNuevaCategoria(string categoria)
        {
            try
            {
                datos.SetearConsulta($"insert into CATEGORIAS (Descripcion) VALUES ('{categoria}')");
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

        //Elimina una categoria de la base de datos
        public void EliminarCategoria(Categoria nuevaCategoria)
        {
            try
            {
                string consulta = "DELETE FROM CATEGORIAS WHERE id = @id";
                datos.SetearParametro("@id", nuevaCategoria.Id);

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

    }
}
