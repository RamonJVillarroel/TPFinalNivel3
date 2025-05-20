using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace negocio
{
    public class Seguridad
    {
        public static bool sesionActiva(object user)
        {
            Usuarios usuariocomun = user != null ? (Usuarios)user : null;
            if (usuariocomun != null && usuariocomun.Id != 0)
                return true;
            else
                return false;
        }

        public static bool EsAdmin(object user)
        {
            if (user is Usuarios usuario &&usuario != null && usuario.Id != 0 && usuario.TipoUser == TipoUser.Admin)
                return true;
            return false;
        }

    }
}
