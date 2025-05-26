using dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utilitarios;

namespace negocio
{
    public class NegocioArticulo
    {
        //Listado de Articulos
        public List<Articulo> ListarArticulos()
        {
            List<Articulo> articulos = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try {
                string consulta = "SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, a.IdCategoria as IdCategoria, a.IdMarca as IdMarca, a.ImagenUrl, a.Precio, m.Descripcion as marca, c.Descripcion as categoria FROM ARTICULOS AS a inner join CATEGORIAS as c on a.IdCategoria= c.Id inner join MARCAS as m on a.IdMarca= m.Id;";
                datos.nuevaConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo articulo = MapearArticulo(datos.Lector);
                    articulo.Imagen=util.ObtenerUrlImagen(articulo.Imagen);
                    articulos.Add(articulo);
                }  
                return articulos;
            }
            catch(Exception ex) { throw ex; 
            }
            finally
            {
                datos.terminarConexion();
            }
            
        }
        //Nuevo Articulo
        public void NuevoArticulo(Articulo NuevoArt)
        {
                 AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "insert into ARTICULOS( Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl,Precio) VALUES(@Codigo,@NombreArt,@Descripcion,@IdCategoria,@IdMarca,@img,@Precio);";
              
                datos.Parametro("@Codigo", NuevoArt.CodArticulo);
                datos.Parametro("@NombreArt",NuevoArt.NombreArticulo);
                datos.Parametro("@Descripcion",NuevoArt.Descripcion);
                datos.Parametro("@IdMarca",NuevoArt.Marca.IdMarca);
                datos.Parametro("@IdCategoria",NuevoArt.Categoria.IdCategoria);
                datos.Parametro("@img",NuevoArt.Imagen);
                datos.Parametro("@Precio", NuevoArt.Precio);
                datos.nuevaConsulta(consulta);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                
                datos.terminarConexion();
            }
        }
        //Editar Articulos
        public void EditarArticulo(Articulo articuloEditar) {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "update ARTICULOS SET Codigo=@Codigo,Nombre=@NombreArt, Descripcion=@Descripcion, IdCategoria=@IdCategoria, IdMarca=@IdMarca, ImagenUrl=@img,Precio=@Precio WHERE id =@IdArticulo;";
                datos.Parametro("@Codigo", articuloEditar.CodArticulo);
                datos.Parametro("@NombreArt", articuloEditar.NombreArticulo);
                datos.Parametro("@Descripcion", articuloEditar.Descripcion);
                datos.Parametro("@IdMarca",articuloEditar.Marca.IdMarca);
                datos.Parametro("@IdCategoria",articuloEditar.Categoria.IdCategoria);
                datos.Parametro("@img", articuloEditar.Imagen);
                datos.Parametro("@Precio", articuloEditar.Precio);
                datos.Parametro("@IdArticulo", articuloEditar.IdArticulo);

                datos.nuevaConsulta(consulta);
                datos.ejecutarAccion();
            }
            catch (Exception ex) { throw ex; }
            finally { datos.terminarConexion(); }
        }
        //eliminar un articulo por ID
        public void eliminar(int IdArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                
                string consulta = "delete From ARTICULOS where Id=@IdArticulo;";
                datos.Parametro("@IdArticulo", IdArticulo);
                datos.nuevaConsulta(consulta);
                datos.ejecutarAccion();
            }
            catch (Exception ex) { throw ex; }
            finally { datos.terminarConexion(); }

        }
        //Mapeo de articulos
        private Articulo MapearArticulo(IDataReader lector)
        {
            return new Articulo
            {
                IdArticulo = (int)lector["Id"],
                CodArticulo = (string)lector["Codigo"],
                NombreArticulo = (string)lector["Nombre"],
                Descripcion = (string)lector["Descripcion"],
                Imagen = (string)lector["ImagenUrl"],
                Precio = (decimal)lector["Precio"],
                Categoria = new Categoria
                {
                    IdCategoria = (int)lector["IdCategoria"],
                    NombreCategoria = (string)lector["categoria"]
                },
                Marca = new Marca
                {
                    IdMarca = (int)lector["IdMarca"],
                    NombreMarca = (string)lector["marca"]
                }
            };
        }
        //Consultas para las busqueda
        public List<Articulo> ListaMayorPrecio()
        {
            List<Articulo> articulos = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, a.IdCategoria as IdCategoria, a.IdMarca as IdMarca, a.ImagenUrl, a.Precio, m.Descripcion as marca, c.Descripcion as categoria FROM ARTICULOS AS a inner join CATEGORIAS as c on a.IdCategoria= c.Id inner join MARCAS as m on a.IdMarca= m.Id And Precio > 10000 order by Precio DESC;";
                datos.nuevaConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo articulo = MapearArticulo(datos.Lector);
                    articulos.Add(articulo);
                }
                return articulos;

            }
            catch (Exception ex) { throw ex; }
            finally
            {
                datos.terminarConexion();
            }
        }

        public List<Articulo> ListaMenorPrecio()
        {
            List<Articulo> articulos = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, a.IdCategoria as IdCategoria, a.IdMarca as IdMarca, a.ImagenUrl, a.Precio, m.Descripcion as marca, c.Descripcion as categoria FROM ARTICULOS AS a inner join CATEGORIAS as c on a.IdCategoria= c.Id inner join MARCAS as m on a.IdMarca= m.Id And Precio < 10000 order by Precio ASC;";
                datos.nuevaConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo articulo = MapearArticulo(datos.Lector);
                    articulos.Add(articulo);
                }
                return articulos;

            }
            catch (Exception ex) { throw ex; }
            finally
            {
                datos.terminarConexion();
            }
        }

        public List<Articulo> ListaPorCategoria(string categoria)
        {
            List<Articulo> articulos = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, a.IdCategoria as IdCategoria, a.IdMarca as IdMarca, a.ImagenUrl, a.Precio, m.Descripcion as marca, c.Descripcion as categoria FROM ARTICULOS AS a inner join CATEGORIAS as c on a.IdCategoria= c.Id inner join MARCAS as m on a.IdMarca= m.Id where  c.Descripcion like '%'+@Categoria+'%';;";
                datos.Parametro("@Categoria", categoria);
                datos.nuevaConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo articulo = MapearArticulo(datos.Lector);
                    articulos.Add(articulo);
                }
                return articulos;

            }
            catch (Exception ex) { throw ex; }
            finally
            {
                datos.terminarConexion();
            }
        }
    }
}
