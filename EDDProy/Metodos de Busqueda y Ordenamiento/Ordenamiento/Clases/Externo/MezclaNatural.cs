using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDDemo.Metodos_de_Busqueda_y_Ordenamiento.Ordenamiento.Clases.Externo
{
    public class MezclaNatural
    {
        public List<int> OrdenarPorMezclaNatural(string archivo)
        {
            List<int> datos = new List<int>();

            try
            {
                // Leer números del archivo
                using (StreamReader reader = new StreamReader(archivo))
                {
                    string linea;
                    while ((linea = reader.ReadLine()) != null)
                    {
                        if (int.TryParse(linea.Trim(), out int numero))
                        {
                            datos.Add(numero);
                        }
                        else
                        {
                            Console.WriteLine("Línea no válida: " + linea);
                        }
                    }
                }

                Console.WriteLine($"Archivo leído correctamente. Total de elementos: {datos.Count}");

                if (datos.Count == 0)
                {
                    Console.WriteLine("El archivo está vacío o no contiene datos válidos.");
                    return new List<int>();
                }

                // Ordenar usando mezcla natural
                return MezclaNaturalOrdenar(datos);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer el archivo: " + ex.Message);
                return new List<int>();
            }
        }

        private List<int> MezclaNaturalOrdenar(List<int> lista)
        {
            while (true)
            {
                List<List<int>> subsecuencias = DividirEnSubsecuencias(lista);

                if (subsecuencias.Count <= 1)
                {
                    return subsecuencias[0];
                }

                lista = FusionarSubsecuencias(subsecuencias);
            }
        }

        private List<List<int>> DividirEnSubsecuencias(List<int> lista)
        {
            List<List<int>> subsecuencias = new List<List<int>>();
            List<int> actual = new List<int>();

            foreach (int numero in lista)
            {
                if (actual.Count == 0 || numero >= actual[actual.Count - 1])
                {
                    actual.Add(numero);
                }
                else
                {
                    subsecuencias.Add(new List<int>(actual));
                    actual.Clear();
                    actual.Add(numero);
                }
            }

            if (actual.Count > 0)
            {
                subsecuencias.Add(actual);
            }

            return subsecuencias;
        }

        private List<int> FusionarSubsecuencias(List<List<int>> subsecuencias)
        {
            List<int> resultado = new List<int>();

            while (subsecuencias.Count > 0)
            {
                int menor = int.MaxValue;
                int indiceMenor = -1;

                for (int i = 0; i < subsecuencias.Count; i++)
                {
                    if (subsecuencias[i][0] < menor)
                    {
                        menor = subsecuencias[i][0];
                        indiceMenor = i;
                    }
                }

                resultado.Add(menor);
                subsecuencias[indiceMenor].RemoveAt(0);

                if (subsecuencias[indiceMenor].Count == 0)
                {
                    subsecuencias.RemoveAt(indiceMenor);
                }
            }

            return resultado;
        }
    }
}
