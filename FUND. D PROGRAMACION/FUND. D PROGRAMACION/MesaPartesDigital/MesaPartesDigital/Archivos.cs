using System;
using System.IO;
using System.Text;

namespace MesaPartesDigital
{
    /// <summary>
    /// Persistencia en archivo de texto. Cada línea es un expediente con 6 campos
    /// separados por '|':  codigo|ciudadano|tipo|asunto|fecha|estado
    /// El archivo expedientes.txt se guarda junto al ejecutable.
    /// </summary>
    internal static class Archivos
    {
        private const char SEPARADOR = '|';
        private const int CAMPOS = 6;

        public static string Ruta()
        {
            return Path.Combine(AppContext.BaseDirectory, "expedientes.txt");
        }

        /// <summary>
        /// Guarda todos los expedientes, reemplazando el contenido del archivo.
        /// Devuelve true si se guardó correctamente.
        /// </summary>
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

        /// <summary>
        /// Lee el archivo y llena los arreglos del almacén.
        /// Devuelve cuántos expedientes se cargaron (0 si el archivo no existe).
        /// Las líneas con formato incorrecto se cuentan en lineasIgnoradas y no se cargan.
        /// </summary>
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
