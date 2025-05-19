using dominio;
using System;
using System.Collections.Generic;
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
                string consulta = "insert into Favorito( Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl,Precio) VALUES(@Codigo,@NombreArt,@Descripcion,@IdCategoria,@IdMarca,@img,@Precio)";

                datos.Parametro("@Codigo", NuevoArt.CodArticulo);
                datos.Parametro("@NombreArt", NuevoArt.NombreArticulo);
                datos.Parametro("@Descripcion", NuevoArt.Descripcion);
                datos.Parametro("@IdMarca", NuevoArt.Marca.IdMarca);
                datos.Parametro("@IdCategoria", NuevoArt.Categoria.IdCategoria);
                datos.Parametro("@img", NuevoArt.Imagen);
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
    }
}
