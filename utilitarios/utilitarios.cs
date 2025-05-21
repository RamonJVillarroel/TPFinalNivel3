using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static System.Net.Mime.MediaTypeNames;

namespace utilitarios
{
    public class util
    {
        //metodo para la carga generica de imagenes
     
            private const string ImagenPorDefecto = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQDCXek_M1agTePOBcSZfP1O9qobtNXYz4OVg&s";

            public static string ObtenerUrlImagen(string imagen)
            {
                if (!string.IsNullOrWhiteSpace(imagen)|| imagen ==" ")
                {
                    return imagen;
                }

                return ImagenPorDefecto;
            }
        

        //metedo para eliminacion generica de columnas
        public void EliminadorColumnas(DataGridView dataGrid, string columna)
        {
            dataGrid.Columns[columna].Visible = false;
        }
        //mensaje generico de error
        public void MensajeError()
        {
            MessageBox.Show("Sigue la recomendacion o contacta al administrador.");
        }

        // Validar si la cadena tiene 50 caracteres, si no los tiene, pregunto si autoriza recortarla
        public string ValidadorCadena50caracteres(string cadena)
        {
            if (string.IsNullOrWhiteSpace(cadena))
            {
                MessageBox.Show("La cadena ingresada está vacía o es nula. No se puede continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            if (cadena.Length > 50)
            {
                DialogResult resultado = MessageBox.Show("La cadena no puede tener más de 50 caracteres. Se recortará automáticamente, eliminando las últimas letras.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)
                {
                    return cadena.Substring(0, 50);
                }
                else
                {
                    return null;
                }
            }
            return cadena;
        }

        // Validar si la cadena tiene 150 caracteres, si no los tiene, pregunto si autoriza recortarla
        public string ValidadorCadena150caracteres(string cadena)
        {
            if (string.IsNullOrWhiteSpace(cadena))
            {
                MessageBox.Show("La cadena ingresada está vacía o es nula. No se puede continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            if (cadena.Length > 150)
            {
                DialogResult resultado = MessageBox.Show("La cadena no puede tener más de 150 caracteres. Se recortará automáticamente, eliminando las últimas letras.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)
                {
                    return cadena.Substring(0, 150);
                }
                else
                {
                    return null;
                }
            }
            return cadena;
        }

        // Validar si la cadena tiene 1000 caracteres, si no los tiene, pregunto si autoriza recortarla
        // Verifica que sea una imagen de internet
        // Verifica que no este vacia o nula
        public string ValidadorCadena1000caracteres(string cadena)
        {
            if (string.IsNullOrWhiteSpace(cadena))
            {
                MessageBox.Show("La cadena ingresada está vacía o es nula. No se puede continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            if (!cadena.StartsWith("https://"))
            {
                MessageBox.Show($"Cadena: {cadena} no inicia con https://. Solo se permiten imagenes de internet");
                return null;
            }
          if (cadena.Length > 1000)
            {
                DialogResult resultado = MessageBox.Show("La cadena no puede tener más de 1000 caracteres. Se recortará automáticamente, eliminando las últimas letras.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)
                {
                    return cadena.Substring(0, 1000);
                }
                else
                {
                    return null;
                }
            }
            return cadena;
        }

    }
}
