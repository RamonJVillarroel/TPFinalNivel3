using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class NegocioUsuario
    {
        public void NuevoUsuario(Usuarios NuevoUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "insert into USERS( email,pass, nombre, apellido, urlImagenPerfil, admin) VALUES(@email,@password,@nombre,@apellido,@urlimg, @tipouser)";

                datos.Parametro("@email", NuevoUsuario.Email);
                datos.Parametro("@password", NuevoUsuario.Password);
                datos.Parametro("@nombre", NuevoUsuario.Nombre);
                datos.Parametro("@apellido", NuevoUsuario.Apellido);
                datos.Parametro("@urlimg",NuevoUsuario.UrlImg);
                datos.Parametro("@tipouser", NuevoUsuario.TipoUser);
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
