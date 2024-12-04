using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDDemo.Metodos_de_Busqueda_y_Ordenamiento.Ordenamiento.Clases.Externo
{
    public class MezclaDirecta
    {
        public List<int> OrdenarPorMezclaDirecta(string archivo)
        {
            // Leer todos los números del archivo y almacenarlos en una lista
            List<int> datos = new List<int>();
            using (StreamReader reader = new StreamReader(archivo))
            {
                string linea;
                while ((linea = reader.ReadLine()) != null)
                {
                    datos.Add(int.Parse(linea.Trim()));
                }
            }

            // Ordenar usando el algoritmo de mezcla directa
            return MergeSort(datos);
        }

        private List<int> MergeSort(List<int> lista)
        {
            if (lista.Count <= 1) return lista;

            // Dividir la lista en dos mitades
            int mitad = lista.Count / 2;
            List<int> izquierda = lista.GetRange(0, mitad);
            List<int> derecha = lista.GetRange(mitad, lista.Count - mitad);

            // Ordenar recursivamente cada mitad
            izquierda = MergeSort(izquierda);
            derecha = MergeSort(derecha);

            // Combinar las mitades ordenadas
            return MezclarListas(izquierda, derecha);
        }

        private List<int> MezclarListas(List<int> izquierda, List<int> derecha)
        {
            List<int> resultado = new List<int>();
            int i = 0, j = 0;

            // Comparar y fusionar los elementos de ambas listas
            while (i < izquierda.Count && j < derecha.Count)
            {
                if (izquierda[i] <= derecha[j])
                {
                    resultado.Add(izquierda[i]);
                    i++;
                }
                else
                {
                    resultado.Add(derecha[j]);
                    j++;
                }
            }

            // Agregar los elementos restantes de cada lista
            while (i < izquierda.Count)
            {
                resultado.Add(izquierda[i]);
                i++;
            }

            while (j < derecha.Count)
            {
                resultado.Add(derecha[j]);
                j++;
            }

            return resultado;
        }
    }
}
