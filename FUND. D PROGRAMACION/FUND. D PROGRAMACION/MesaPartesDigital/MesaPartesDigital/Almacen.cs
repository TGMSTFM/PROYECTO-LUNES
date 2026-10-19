using System;

namespace MesaPartesDigital
{
    /// <summary>
    /// Guarda los expedientes en memoria usando ARREGLOS PARALELOS:
    /// la posición i de cada arreglo corresponde al mismo expediente.
    /// Contiene también los algoritmos de búsqueda y ordenamiento.
    /// </summary>
    internal static class Almacen
    {
        public const int CAPACIDAD = 500;

        public static string[] Codigos = new string[CAPACIDAD];
        public static string[] Ciudadanos = new string[CAPACIDAD];
        public static string[] Tipos = new string[CAPACIDAD];
        public static string[] Asuntos = new string[CAPACIDAD];
        public static string[] Fechas = new string[CAPACIDAD];
        public static string[] Estados = new string[CAPACIDAD];

        /// <summary>Cantidad de expedientes realmente registrados (posiciones usadas).</summary>
        public static int Cantidad = 0;

        /// <summary>Opciones del ComboBox de tipo de documento.</summary>
        public static readonly string[] TiposDocumento = { "Solicitud", "Carta", "Reclamo", "Otro" };

        public const string ESTADO_INICIAL = "Recibido";

        // ---------------------------------------------------------------
        // REGISTRO
        // ---------------------------------------------------------------

        /// <summary>
        /// Inserta un expediente al final de los arreglos.
        /// Devuelve false si el almacén está lleno.
        /// </summary>
        public static bool Agregar(string codigo, string ciudadano, string tipo,
                                   string asunto, string fecha, string estado)
        {
            if (Cantidad >= CAPACIDAD)
            {
                return false;
            }

            Codigos[Cantidad] = codigo;
            Ciudadanos[Cantidad] = ciudadano;
            Tipos[Cantidad] = tipo;
            Asuntos[Cantidad] = asunto;
            Fechas[Cantidad] = fecha;
            Estados[Cantidad] = estado;
            Cantidad++;
            return true;
        }

        /// <summary>Indica si ya existe un expediente con ese código (sin distinguir mayúsculas).</summary>
        public static bool ExisteCodigo(string codigo)
        {
            return BuscarLineal(codigo) != -1;
        }

        // ---------------------------------------------------------------
        // BÚSQUEDA
        // ---------------------------------------------------------------

        /// <summary>Búsqueda lineal: recorre el arreglo desde el inicio. Devuelve la posición o -1.</summary>
        public static int BuscarLineal(string codigo)
        {
            for (int i = 0; i < Cantidad; i++)
            {
                if (string.Equals(Codigos[i], codigo, StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Búsqueda binaria: solo funciona si los códigos están ordenados de menor a mayor.
        /// Divide el rango a la mitad en cada paso. Devuelve la posición o -1.
        /// </summary>
        public static int BuscarBinaria(string codigo)
        {
            int inicio = 0;
            int fin = Cantidad - 1;

            while (inicio <= fin)
            {
                int medio = (inicio + fin) / 2;
                int comparacion = string.Compare(Codigos[medio], codigo, StringComparison.OrdinalIgnoreCase);

                if (comparacion == 0)
                {
                    return medio;
                }
                if (comparacion < 0)
                {
                    inicio = medio + 1;
                }
                else
                {
                    fin = medio - 1;
                }
            }
            return -1;
        }

        /// <summary>Comprueba si los códigos ya están en orden ascendente (condición de la búsqueda binaria).</summary>
        public static bool EstaOrdenadoPorCodigo()
        {
            for (int i = 0; i < Cantidad - 1; i++)
            {
                if (string.Compare(Codigos[i], Codigos[i + 1], StringComparison.OrdinalIgnoreCase) > 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Busca un código eligiendo el algoritmo más eficiente según el estado del arreglo.
        /// Devuelve la posición o -1.
        /// </summary>
        public static int Buscar(string codigo)
        {
            if (EstaOrdenadoPorCodigo())
            {
                return BuscarBinaria(codigo);
            }
            return BuscarLineal(codigo);
        }

        // ---------------------------------------------------------------
        // ORDENAMIENTO (selección)
        // ---------------------------------------------------------------

        /// <summary>Ordena todos los expedientes por código, de menor a mayor.</summary>
        public static void OrdenarPorCodigo()
        {
            for (int i = 0; i < Cantidad - 1; i++)
            {
                int menor = i;
                for (int j = i + 1; j < Cantidad; j++)
                {
                    if (string.Compare(Codigos[j], Codigos[menor], StringComparison.OrdinalIgnoreCase) < 0)
                    {
                        menor = j;
                    }
                }
                if (menor != i)
                {
                    Intercambiar(i, menor);
                }
            }
        }

        /// <summary>
        /// Intercambia dos expedientes completos. Como los datos están en arreglos paralelos,
        /// hay que intercambiar la misma posición en TODOS los arreglos.
        /// </summary>
        private static void Intercambiar(int a, int b)
        {
            CambiarPosiciones(Codigos, a, b);
            CambiarPosiciones(Ciudadanos, a, b);
            CambiarPosiciones(Tipos, a, b);
            CambiarPosiciones(Asuntos, a, b);
            CambiarPosiciones(Fechas, a, b);
            CambiarPosiciones(Estados, a, b);
        }

        private static void CambiarPosiciones(string[] arreglo, int a, int b)
        {
            string temporal = arreglo[a];
            arreglo[a] = arreglo[b];
            arreglo[b] = temporal;
        }
    }
}
