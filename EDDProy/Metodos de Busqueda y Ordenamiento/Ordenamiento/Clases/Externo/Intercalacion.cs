using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDDemo.Metodos_de_Busqueda_y_Ordenamiento.Ordenamiento.Clases.Externo
{
    public class Intercalacion
    {
        public List<int> IntercalarEnLista(string archivo1, string archivo2)
        {
            List<int> resultado = new List<int>();

            try
            {
                using (StreamReader reader1 = new StreamReader(archivo1))
                using (StreamReader reader2 = new StreamReader(archivo2))
                {
                    string linea1 = reader1.ReadLine();
                    string linea2 = reader2.ReadLine();

                    // Intercalación
                    while (linea1 != null && linea2 != null)
                    {
                        // Asegurarse de que las líneas contienen números
                        if (int.TryParse(linea1.Trim(), out int valor1) && int.TryParse(linea2.Trim(), out int valor2))
                        {
                            if (valor1 <= valor2)
                            {
                                resultado.Add(valor1);
                                linea1 = reader1.ReadLine();
                            }
                            else
                            {
                                resultado.Add(valor2);
                                linea2 = reader2.ReadLine();
                            }
                        }
                        else
                        {
                            throw new Exception("El archivo contiene datos no numéricos.");
                        }
                    }

                    // Agregar los elementos restantes de archivo1
                    while (linea1 != null)
                    {
                        if (int.TryParse(linea1.Trim(), out int valor1))
                        {
                            resultado.Add(valor1);
                        }
                        else
                        {
                            throw new Exception("El archivo contiene datos no numéricos.");
                        }
                        linea1 = reader1.ReadLine();
                    }

                    // Agregar los elementos restantes de archivo2
                    while (linea2 != null)
                    {
                        if (int.TryParse(linea2.Trim(), out int valor2))
                        {
                            resultado.Add(valor2);
                        }
                        else
                        {
                            throw new Exception("El archivo contiene datos no numéricos.");
                        }
                        linea2 = reader2.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar los archivos: " + ex.Message);
            }

            // Asegurarse de que la lista esté ordenada (en caso de que los archivos no estén ordenados)
            resultado.Sort();

            return resultado;
        }
    }
}
