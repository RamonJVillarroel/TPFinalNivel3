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
    }
}
