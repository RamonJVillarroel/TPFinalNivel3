using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    //dato para tipo de usuario
    public enum TipoUser
    {
        User = 0,
        Admin = 1,
    }
    public class Usuarios
    {   
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string UrlImg { get; set; }
        public TipoUser TipoUser {  get; set; }

    }
}
