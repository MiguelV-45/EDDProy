using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDDemo.Metodos_de_Busqueda_y_Ordenamiento.Clases
{
    public class ShellSort
    {
        public List<int> Ordenar(List<int> lista, List<string> pasos)
        {
            int n = lista.Count;
            int intervalo = n / 2;  // Empieza con el intervalo grande

            while (intervalo > 0)
            {
                for (int i = intervalo; i < n; i++)
                {
                    int temp = lista[i];
                    int j = i;

                    // Inserción con intervalo
                    while (j >= intervalo && lista[j - intervalo] > temp)
                    {
                        lista[j] = lista[j - intervalo];
                        j -= intervalo;
                    }

                    lista[j] = temp;
                }

                // Verificar si hubo cambios en la lista y agregar a los pasos
                pasos.Add(string.Join(" -> ", lista));

                intervalo /= 2; // Reducir el intervalo a la mitad
            }

            return lista;  // Devolvemos la lista ordenada
        }
    }
}