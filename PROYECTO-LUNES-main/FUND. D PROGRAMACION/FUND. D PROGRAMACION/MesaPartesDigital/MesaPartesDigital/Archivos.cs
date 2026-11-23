using System;
using System.IO;
using System.Text;

namespace MesaPartesDigital
{
    // Aca manejamos el guardado y lectura de los datos en un txt para que no se pierdan al cerrar.
    // Cada linea tiene 6 datos separados por '|': codigo|ciudadano|tipo|asunto|fecha|estado
    // El archivo expedientes.txt se crea en la misma carpeta donde corre el programa.
    internal static class Archivos
    {
        private const char SEPARADOR = '|';
        private const int CAMPOS = 6;

        // Saca la ruta exacta donde se va a guardar o buscar el archivo txt
        public static string Ruta()
        {
            return Path.Combine(AppContext.BaseDirectory, "expedientes.txt");
        }

        // Recorre todo lo que hay en memoria, arma cada linea con '|' y lo guarda en el txt.
        // Devuelve true si todo salio bien o false si hubo algun error con el archivo.
        public static bool Guardar()
        {
            try
            {
                string[] lineas = new string[Almacen.Cantidad];
                for (int i = 0; i < Almacen.Cantidad; i++)
                {
                    lineas[i] = Almacen.Codigos[i] + SEPARADOR
                              + Almacen.Ciudadanos[i] + SEPARADOR
                              + Almacen.Tipos[i] + SEPARADOR
                              + Almacen.Asuntos[i] + SEPARADOR
                              + Almacen.Fechas[i] + SEPARADOR
                              + Almacen.Estados[i];
                }

                File.WriteAllLines(Ruta(), lineas, Encoding.UTF8);
                return true;
            }
            catch (IOException)
            {
                return false;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
        }

        // Lee el txt linea por linea, las separa por '|' y las vuelve a meter a los arreglos.
        // Devuelve cuantos expedientes se pudieron cargar. Si hay lineas vacias o mal escritas
        // las salta y las va contando en lineasIgnoradas para avisar despues.
        public static int Cargar(out int lineasIgnoradas)
        {
            lineasIgnoradas = 0;

            if (!File.Exists(Ruta()))
            {
                return 0;
            }

            int cargados = 0;
            try
            {
                string[] lineas = File.ReadAllLines(Ruta(), Encoding.UTF8);

                for (int i = 0; i < lineas.Length; i++)
                {
                    if (lineas[i].Trim().Length == 0)
                    {
                        continue;
                    }

                    string[] partes = lineas[i].Split(SEPARADOR);
                    if (partes.Length != CAMPOS)
                    {
                        lineasIgnoradas++;
                        continue;
                    }

                    bool agregado = Almacen.Agregar(partes[0], partes[1], partes[2],
                                                    partes[3], partes[4], partes[5]);
                    if (agregado)
                    {
                        cargados++;
                    }
                    else
                    {
                        lineasIgnoradas++;
                    }
                }
            }
            catch (IOException)
            {
                lineasIgnoradas++;
            }
            return cargados;
        }
    }
}