using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using System.Text.RegularExpressions;
using System.Globalization;


namespace negocio
{
    public class ArticuloNegocio
    {
        private AccesoDatos datos = new AccesoDatos();

        //Retorna una lista con los articulos obtenidos de la base de datos
        public List<Articulo> ListarArticulos(string id = "") 
        {
            List<Articulo> lista = new List<Articulo>();

            try
            {
                string consulta = "select a.id, codigo, nombre, a.descripcion, m.Descripcion as marcaDesc,m.id as idMarca,c.Descripcion as categoriaDesc,c.id as idCategoria," +
                    " ImagenUrl, precio from ARTICULOS a\r\ninner join MARCAS m on m.id = a.IdMarca" +
                    "\r\ninner join CATEGORIAS c on c.Id = a.IdCategoria";

                if (id != "")
                {
                    consulta = "select a.id,codigo,nombre,a.descripcion,m.Descripcion as marcaDesc,m.id as idMarca,c.Descripcion as categoriaDesc,c.id as idCategoria," +
                        "ImagenUrl,precio from ARTICULOS a\r\n" +
                        $"inner join MARCAS m on m.id = a.IdMarca\r\ninner join CATEGORIAS c on c.Id = a.IdCategoria where a.id in (select idArticulo from FAVORITOS where idUser = {id})";
                }

                datos.SetearConsulta(consulta);
                datos.EjecutarLectura();

                while (datos.Lector.Read()) //lector.Read()
                {
                    Articulo auxiliar = new Articulo();

                    auxiliar.Id = (int)datos.Lector["id"];
                    auxiliar.Codigo = (string)datos.Lector["Codigo"];

                    auxiliar.Categoria = new Categoria();
                    auxiliar.Categoria.Id = (int)datos.Lector["idCategoria"];
                    auxiliar.Categoria.Descripcion = (string)datos.Lector["categoriaDesc"];

                    auxiliar.Nombre = (string)datos.Lector["Nombre"];
                    auxiliar.Descripcion = (string)datos.Lector["Descripcion"];

                    auxiliar.Marca = new Marca();
                    auxiliar.Marca.Id = (int)datos.Lector["idMarca"];
                    auxiliar.Marca.Descripcion = (string)datos.Lector["marcaDesc"];

                    if (!(datos.Lector["imagenUrl"] is DBNull))
                        auxiliar.ImagenUrl = (string)datos.Lector["imagenUrl"];

                    auxiliar.Precio = (decimal)datos.Lector["Precio"];

                    lista.Add(auxiliar);
                }

                return lista;
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

        //Retorna un solo articulo
        public Articulo ListarUnArticulo(string id) {
            Articulo auxiliar = new Articulo();

            try
            {
                string consulta = $"select a.id,m.id as idMarca,c.id as idCategoria,codigo,nombre,a.descripcion as articuloDesc,m.Descripcion as marcaDesc,c.Descripcion as categoriaDesc,ImagenUrl,precio from ARTICULOS a" +
                    $"\r\ninner join MARCAS m on m.id = a.IdMarca\r\ninner join CATEGORIAS c on c.Id = a.IdCategoria\r\nwhere a.id ={id}";
                datos.SetearConsulta(consulta);
                datos.EjecutarLectura();
            while (datos.Lector.Read())
            {
                auxiliar.Id = (int)datos.Lector["id"];
                auxiliar.Codigo = (string)datos.Lector["Codigo"];

                auxiliar.Categoria = new Categoria();
                auxiliar.Categoria.Descripcion = (string)datos.Lector["categoriaDesc"];
                auxiliar.Categoria.Id = (int)datos.Lector["IdCategoria"];

                auxiliar.Nombre = (string)datos.Lector["Nombre"];
                auxiliar.Descripcion = (string)datos.Lector["articuloDesc"];

                auxiliar.Marca = new Marca();
                auxiliar.Marca.Descripcion = (string)datos.Lector["marcaDesc"];
                auxiliar.Marca.Id = (int)datos.Lector["IdMarca"];


                    if (!(datos.Lector["imagenUrl"] is DBNull))
                    auxiliar.ImagenUrl = (string)datos.Lector["imagenUrl"];

                auxiliar.Precio = (decimal)datos.Lector["Precio"];
            }
                return auxiliar;
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

        //Cargar un nuevo articulo a la base de datos
        public void InsertarArticulo(Articulo nuevoArticulo)
        {

            string consulta = $"INSERT INTO articulos (codigo,nombre,descripcion,idMarca,idCategoria,imagenUrl,precio) VALUES\r\n" +
                $"('{nuevoArticulo.Codigo}','{nuevoArticulo.Nombre}','{nuevoArticulo.Descripcion}',@idMarca,@idCategoria,@imagenUrl,'{nuevoArticulo.Precio}')";

            datos.SetearParametro("@idMarca", nuevoArticulo.Marca.Id);
            datos.SetearParametro("@idCategoria", nuevoArticulo.Categoria.Id);
            datos.SetearParametro("@imagenUrl", nuevoArticulo.ImagenUrl);

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

        //Modifica valores de un articulo ya existente
        public void ModificarArticulo(Articulo nuevo)
        {
            try
            {
                string consulta = "UPDATE articulos SET Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca, IdCategoria = @idCategoria, " +
                    "ImagenUrl = @imagenUrl, Precio = @precio WHERE Id = @id";
                datos.SetearParametro("@id", nuevo.Id);
                datos.SetearParametro("@codigo", nuevo.Codigo);
                datos.SetearParametro("@nombre", nuevo.Nombre);
                datos.SetearParametro("@descripcion", nuevo.Descripcion);
                datos.SetearParametro("@idMarca", nuevo.Marca.Id);
                datos.SetearParametro("@idCategoria", nuevo.Categoria.Id);
                datos.SetearParametro("@imagenUrl", nuevo.ImagenUrl);
                datos.SetearParametro("@precio", nuevo.Precio);
                
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

        //Elimina un articulo de la base de datos
        public void EliminarArticulo(int id)
        {
            try
            {
                string consulta = "DELETE FROM articulos WHERE id = @id";
                datos.SetearParametro("@id", id);

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
