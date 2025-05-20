using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Favoritos
    {
        public int IdFavorito { get; set; }
        public Articulo Articulo { get; set; }
        public Usuarios Usuarios { get; set; }
    }
}
