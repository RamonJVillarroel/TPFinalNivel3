using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulo
    {
      
        public int IdArticulo { get; set; }
        
        public string CodArticulo { get; set; }
        
        public string NombreArticulo { get; set; }

        public string Descripcion { get; set; }

        public string Imagen { get; set; }
        
        public decimal Precio { get; set; }

        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public Favoritos Favorito { get; set; }
    }
}
