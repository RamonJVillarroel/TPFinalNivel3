using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class NegocioMarca
    {
        //Listado de marcas
        public List<Marca> ListarMarcas()
        {
            List<Marca> marcas = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT id, descripcion from MARCAS;";
                datos.nuevaConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca marca = new Marca();
                    marca.IdMarca = (int)datos.Lector["id"];
                    marca.NombreMarca = (string)datos.Lector["descripcion"];
                    marcas.Add(marca);
                }

                return marcas;
            }catch (Exception ex) { 
                throw ex; 
            }
            finally
            {
                datos.terminarConexion();
            }
        }
    }
}
