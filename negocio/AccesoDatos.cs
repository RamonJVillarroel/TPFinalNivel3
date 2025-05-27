using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    internal class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        //Clase de acceso a datos
        public SqlDataReader Lector
        {
            get { return lector; }
        }
        /// <summary>
        /// testttetststtet
        /// </summary>
        public AccesoDatos()
        {
            //configuracion local
            //conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_WEB_DB; integrated security=true");
            //configuracion remota
            conexion = new SqlConnection("workstation id=catalogo-web-tpfinal.mssql.somee.com;packet size=4096;user id=Rambiz_SQLLogin_2;pwd=b144soar3j;data source=catalogo-web-tpfinal.mssql.somee.com;persist security info=False;initial catalog=catalogo-web-tpfinal;TrustServerCertificate=True");
            comando = new SqlCommand();
        }
        public void nuevaConsulta(string consulta)
        {
            comando.CommandType =System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
        }

        public void Parametro(string parametro, object valor)
        {
            comando.Parameters.AddWithValue(parametro, valor);
        }

        public void terminarConexion()
        {
            if (lector != null)
            {
                lector.Close();
            }
            conexion.Close();
        }

    }
}
