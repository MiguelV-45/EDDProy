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

            using (StreamReader reader1 = new StreamReader(archivo1))
            using (StreamReader reader2 = new StreamReader(archivo2))
            {
                string linea1 = reader1.ReadLine();
                string linea2 = reader2.ReadLine();

                // Intercalación
                while (linea1 != null && linea2 != null)
                {
                    int valor1 = int.Parse(linea1.Trim());
                    int valor2 = int.Parse(linea2.Trim());

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

                // Agregar los elementos restantes de archivo1
                while (linea1 != null)
                {
                    resultado.Add(int.Parse(linea1.Trim()));
                    linea1 = reader1.ReadLine();
                }

                // Agregar los elementos restantes de archivo2
                while (linea2 != null)
                {
                    resultado.Add(int.Parse(linea2.Trim()));
                    linea2 = reader2.ReadLine();
                }
            }

            return resultado;
        }
    }
}
