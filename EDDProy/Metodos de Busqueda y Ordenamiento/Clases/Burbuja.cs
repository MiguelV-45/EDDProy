using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDDemo.Metodos_de_Busqueda_y_Ordenamiento.Clases
{
    public class Burbuja
    {
        private ListBox lstProceso;

        public Burbuja(ListBox listBox)
        {
            lstProceso = listBox; // Referencia al ListBox para mostrar los pasos
        }

        public void OrdenarBurbuja(int[] array)
        {
            int n = array.Length;
            bool huboIntercambio;

            // Algoritmo de ordenamiento burbuja
            for (int i = 0; i < n - 1; i++)
            {
                huboIntercambio = false; // Reinicia el indicador de intercambio

                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        // Intercambiar los elementos
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;

                        // Mostrar el intercambio realizado
                        lstProceso.Items.Add($"Intercambio: {array[j]} ↔ {array[j + 1]}");
                        huboIntercambio = true; // Indica que hubo un intercambio
                    }
                }

                // Mostrar el estado del arreglo después de cada pasada
                lstProceso.Items.Add("Estado tras pasada " + (i + 1) + ":    " + string.Join(", ", array));

                // Si no hubo intercambios, el arreglo ya está ordenado
                if (!huboIntercambio)
                {
                    lstProceso.Items.Add("El arreglo ya está ordenado.");
                    break;
                }
            }
        }
    }
}
