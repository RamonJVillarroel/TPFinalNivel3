using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class NegocioCategoria
    {
        //Listado de categorias
        public List<Categoria> ListarCategoria()
        {
            List<Categoria> categorias = new List<Categoria>();

            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "Select Id, Descripcion from Categorias;";
                datos.nuevaConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.IdCategoria = (int)datos.Lector["Id"];
                    categoria.NombreCategoria = (string)datos.Lector["Descripcion"];
                    categorias.Add(categoria);
                }

                return categorias;

            }
            catch (Exception ex) { throw ex; }
            finally { datos.terminarConexion(); }
        
        }
    }
}
