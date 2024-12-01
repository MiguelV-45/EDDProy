using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDDemo.Estructuras_Lineales.Clases
{
    public class ColaSimpleEstatica
    {
        private int[] cola;
        private int frente;
        private int fin;
        private int tamañoMaximo;

        public ColaSimpleEstatica(int tamañoInicial)
        {
            tamañoMaximo = tamañoInicial;
            cola = new int[tamañoMaximo];
            frente = 0;
            fin = 0;
        }

        public bool EstaVacia()
        {
            return frente == fin;
        }

        public bool EstaLlena()
        {
            return fin == tamañoMaximo;
        }

        public void AgregarElemento(int elemento)
        {
            if (EstaLlena())
                throw new InvalidOperationException("La cola está llena.");

            cola[fin] = elemento;
            fin++;
        }

        public void EliminarElemento()
        {
            if (EstaVacia())
                throw new InvalidOperationException("La cola está vacía.");

            frente++;
        }

        public void VaciarCola()
        {
            frente = 0;
            fin = 0;
        }

        public bool BuscarElemento(int elemento)
        {
            for (int i = frente; i < fin; i++)
            {
                if (cola[i] == elemento)
                    return true;
            }
            return false;
        }

        public int[] ObtenerElementos()
        {
            int[] elementos = new int[fin - frente];
            for (int i = frente; i < fin; i++)
            {
                elementos[i - frente] = cola[i];
            }
            return elementos;
        }

        public void EstablecerTamaño(int nuevoTamaño)
        {
            tamañoMaximo = nuevoTamaño;
            Array.Resize(ref cola, tamañoMaximo);
            if (fin > tamañoMaximo)
            {
                fin = tamañoMaximo;
            }
        }

        public int ObtenerTamaño()
        {
            return tamañoMaximo;
        }
    }
}
