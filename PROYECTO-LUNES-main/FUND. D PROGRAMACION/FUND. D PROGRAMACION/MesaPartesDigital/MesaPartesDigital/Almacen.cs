using System;

namespace MesaPartesDigital
{
    // Aca guardamos todos los expedientes usando arreglos paralelos, osea que
    // la posicion i de cada arreglo pertenece al mismo tramite. Tambien pusimos
    // los metodos para buscar y ordenar.
    internal static class Almacen
    {
        public const int CAPACIDAD = 500;

        public static string[] Codigos = new string[CAPACIDAD];
        public static string[] Ciudadanos = new string[CAPACIDAD];
        public static string[] Tipos = new string[CAPACIDAD];
        public static string[] Asuntos = new string[CAPACIDAD];
        public static string[] Fechas = new string[CAPACIDAD];
        public static string[] Estados = new string[CAPACIDAD];

        // Este contador lleva la cuenta de cuantos expedientes vamos registrando
        public static int Cantidad = 0;

        // Opciones que van a salir en el combobox de tipo de documento
        public static readonly string[] TiposDocumento = { "Solicitud", "Carta", "Reclamo", "Otro" };

        public const string ESTADO_INICIAL = "Recibido";

        // --- PARTE DE REGISTRO ---

        // Con esto metemos un nuevo expediente al final de cada arreglo.
        // Si ya llegamos al limite de 500 devuelve false para avisar que esta lleno.
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

        // Revisa si el codigo ya existe para no repetirlo (da igual si es mayuscula o minuscula)
        public static bool ExisteCodigo(string codigo)
        {
            return BuscarLineal(codigo) != -1;
        }

        // --- PARTE DE BUSQUEDA ---

        // Busqueda normal uno por uno desde el inicio hasta encontrar el codigo, si no esta devuelve -1
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

        // Busqueda binaria que va partiendo a la mitad el arreglo para encontrar mas rapido.
        // Ojo que solo funciona si los codigos ya estan ordenados de menor a mayor.
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

        // Verifica si los codigos estan ordenados para saber si podemos usar la busqueda binaria
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

        // Este metodo decide cual busqueda usar: si ya esta ordenado usa la binaria, sino la lineal
        public static int Buscar(string codigo)
        {
            if (EstaOrdenadoPorCodigo())
            {
                return BuscarBinaria(codigo);
            }
            return BuscarLineal(codigo);
        }

        // --- PARTE DE ORDENAMIENTO ---

        // Ordena todos los expedientes por su codigo de menor a mayor usando seleccion
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

        // Como usamos arreglos paralelos, si movemos un codigo tenemos que mover
        // tambien todos los demas datos de esa misma posicion para que no se mezclen
        private static void Intercambiar(int a, int b)
        {
            CambiarPosiciones(Codigos, a, b);
            CambiarPosiciones(Ciudadanos, a, b);
            CambiarPosiciones(Tipos, a, b);
            CambiarPosiciones(Asuntos, a, b);
            CambiarPosiciones(Fechas, a, b);
            CambiarPosiciones(Estados, a, b);
        }

        // Metodo auxiliar para cambiar de sitio dos elementos dentro de un mismo arreglo
        private static void CambiarPosiciones(string[] arreglo, int a, int b)
        {
            string temporal = arreglo[a];
            arreglo[a] = arreglo[b];
            arreglo[b] = temporal;
        }
    }
}