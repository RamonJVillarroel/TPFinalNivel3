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
        //solo usuarios comunes, no admins
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

        public bool Login(Usuarios usuarioLogin)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.nuevaConsulta("Select id, email, pass, admin, urlImagenPerfil, nombre, apellido from USERS Where email = @email And pass = @pass");
                datos.Parametro("@email", usuarioLogin.Email);
                datos.Parametro("@pass", usuarioLogin.Password);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    usuarioLogin.Id = (int)datos.Lector["id"];
                    bool esAdmin = (bool)datos.Lector["admin"];
                    usuarioLogin.TipoUser = esAdmin ? TipoUser.Admin : TipoUser.User;
                    if (!(datos.Lector["urlImagenPerfil"] is DBNull))
                        usuarioLogin.UrlImg = (string)datos.Lector["urlImagenPerfil"];
                    if (!(datos.Lector["nombre"] is DBNull))
                        usuarioLogin.Nombre = (string)datos.Lector["nombre"];
                    if (!(datos.Lector["apellido"] is DBNull))
                        usuarioLogin.Apellido = (string)datos.Lector["apellido"];

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
                datos.terminarConexion();
            }
        }

        //modificar usuario solo para comunes
        public void actualizarUsuario(Usuarios ActualizarUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "update USERS SET email=@MailUsuario,pass=@PassUsuario,nombre=@NombreUsuario,apellido=@ApellidoUsuario, urlImagenPerfil=@img, admin=0 WHERE Id =@IdUsuario";
                datos.Parametro("@IdUsuario", ActualizarUsuario.Id);
                datos.Parametro("@MailUsuario", ActualizarUsuario.Email);
                datos.Parametro("@PassUsuario", ActualizarUsuario.Password);
                datos.Parametro("@NombreUsuario", ActualizarUsuario.Nombre);
                datos.Parametro("@ApellidoUsuario", ActualizarUsuario.Apellido);
                datos.Parametro("@img", ActualizarUsuario.UrlImg);

                datos.nuevaConsulta(consulta);
                datos.ejecutarAccion();
            }
            catch (Exception ex) { throw ex; }
            finally { datos.terminarConexion(); }
        }
        //eliminar usuario  solo para comunes
        public void EliminarUsuario(int IdUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                string consulta = "delete From USERS where Id=@IdUsuario";
                datos.Parametro("@IdUsuario", IdUsuario);
                datos.nuevaConsulta(consulta);
                datos.ejecutarAccion();
            }
            catch (Exception ex) { throw ex; }
            finally { datos.terminarConexion(); }
        }
    }
}
