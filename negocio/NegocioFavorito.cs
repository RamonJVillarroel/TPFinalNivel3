using dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class NegocioFavorito
    {
        /*para añadir nuevos favorios a un usuario*/
        // insert into FAVORITOS(IdArticulo, IdUser) VALUES(14,1);
        /*para buscar todos los favoritos*/
        // select* from FAVORITOS;
        /*consulta para buscar favoritos de un usuario*/
        //select IdArticulo from FAVORITOS where IdUser = 1;
        public void NuevoFavorito(Favoritos NuevoFavorito)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "insert into FAVORITOS(IdArticulo, IdUser) VALUES(@IdArticulo,@IdUsuario)";

                datos.Parametro("@IdArticulo", NuevoFavorito.Articulo.IdArticulo);
                datos.Parametro("@IdUsuario", NuevoFavorito.Usuarios.Id);
                
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
                },
                Favorito = new Favoritos
                {
                    IdFavorito = (int)lector["fav"]
                }
            };
        }
        public List<Articulo> FavoritosUsuarios(Usuarios usuario)
        {
            List<Articulo> articulos = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, a.IdCategoria as IdCategoria, a.IdMarca as IdMarca, a.ImagenUrl, a.Precio, m.Descripcion as marca, c.Descripcion as categoria, fav.Id as fav FROM ARTICULOS AS a \r\ninner join CATEGORIAS as c on a.IdCategoria= c.Id \r\ninner join MARCAS as m on a.IdMarca= m.Id\r\ninner join FAVORITOS as fav ON IdUser = 1 AND IdArticulo = a.Id";
                datos.Parametro("@IdUsuario", usuario.Id);

                datos.nuevaConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo articulo = MapearArticulo(datos.Lector);
                    articulos.Add(articulo);
                }
                return articulos;
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
        private Favoritos MapearFavorito(IDataReader lector)
        {
            return new Favoritos
            {
                IdFavorito = (int)lector["Id"], 
            };
        }
        public List<Favoritos> ListaFavoritos()
        {
            List<Favoritos> Favoritoslist = new List<Favoritos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "select * from favoritos";
               
                datos.nuevaConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    
                    Favoritos favorito = MapearFavorito(datos.Lector);
                    Favoritoslist.Add(favorito);
                }
                return Favoritoslist;
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
        public void EliminarFavorito(int IdFavorito)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                
                string consulta = "delete From FAVORITOS where Id=@IdFavorito;";
                datos.Parametro("@IdFavorito", IdFavorito);
                datos.nuevaConsulta(consulta);
                datos.ejecutarAccion();
            }
            catch (Exception ex) { 
                throw ex; 
            }
            finally
            {

                datos.terminarConexion();
            }
        }
    }
}
