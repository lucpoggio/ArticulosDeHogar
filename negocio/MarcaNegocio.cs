using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class MarcaNegocio
    {
        AccesoDatos datos = new AccesoDatos();

        //Lista las marcas
        public List<Marca> Listar()
        {

            List<Marca> lista = new List<Marca>();

            try
            {
                datos.SetearConsulta("select Id,Descripcion from MARCAS");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca auxiliar = new Marca();
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

        //Inserta una nueva marca a la base de datos
        public void CargarNuevaMarca(string marca)
        {
            try
            {
                datos.SetearConsulta($"insert into MARCAS (Descripcion) VALUES ('{marca}')");
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

        //Elimina una marca de la base de datos
        public void EliminarMarca(Marca nuevaMarca)
        {
            try
            {
                string consulta = "DELETE FROM MARCAS WHERE id = @id";
                datos.SetearParametro("@id", nuevaMarca.Id);

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
