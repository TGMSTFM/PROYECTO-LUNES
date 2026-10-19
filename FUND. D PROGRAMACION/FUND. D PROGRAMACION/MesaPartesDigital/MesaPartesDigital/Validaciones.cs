using System;

namespace MesaPartesDigital
{
    /// <summary>
    /// Funciones de validación y limpieza de cadenas de caracteres.
    /// Son funciones puras: reciben un texto y devuelven un resultado.
    /// </summary>
    internal static class Validaciones
    {
        /// <summary>
        /// El código debe tener de 4 a 12 caracteres, empezar con una letra
        /// y contener solo letras y dígitos (sin espacios). Ejemplo: EXP001.
        /// </summary>
        public static bool EsCodigoValido(string codigo)
        {
            if (codigo == null || codigo.Length < 4 || codigo.Length > 12)
            {
                return false;
            }

            if (!char.IsLetter(codigo[0]))
            {
                return false;
            }

            for (int i = 0; i < codigo.Length; i++)
            {
                if (!char.IsLetterOrDigit(codigo[i]))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// El nombre debe tener entre 5 y 60 caracteres, solo letras y espacios,
        /// y al menos dos palabras (nombre y apellido).
        /// </summary>
        public static bool EsNombreValido(string nombre)
        {
            if (nombre == null)
            {
                return false;
            }

            string limpio = nombre.Trim();
            if (limpio.Length < 5 || limpio.Length > 60)
            {
                return false;
            }

            for (int i = 0; i < limpio.Length; i++)
            {
                if (!char.IsLetter(limpio[i]) && limpio[i] != ' ')
                {
                    return false;
                }
            }

            string[] palabras = limpio.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return palabras.Length >= 2;
        }

        /// <summary>El asunto debe tener entre 5 y 150 caracteres (sin contar espacios de los extremos).</summary>
        public static bool EsAsuntoValido(string asunto)
        {
            if (string.IsNullOrWhiteSpace(asunto))
            {
                return false;
            }
            int longitud = asunto.Trim().Length;
            return longitud >= 5 && longitud <= 150;
        }

        /// <summary>Quita espacios de los extremos y pasa el código a mayúsculas: " exp001 " -> "EXP001".</summary>
        public static string NormalizarCodigo(string codigo)
        {
            return codigo.Trim().ToUpper();
        }

        /// <summary>Deja el nombre con un solo espacio entre palabras y cada palabra con inicial mayúscula.</summary>
        public static string NormalizarNombre(string nombre)
        {
            string[] palabras = nombre.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < palabras.Length; i++)
            {
                palabras[i] = palabras[i].Substring(0, 1).ToUpper() + palabras[i].Substring(1).ToLower();
            }
            return string.Join(" ", palabras);
        }

        /// <summary>
        /// Quita el carácter '|' porque se usa como separador en el archivo de texto
        /// y rompería la estructura del registro.
        /// </summary>
        public static string LimpiarTexto(string texto)
        {
            return texto.Trim().Replace('|', ' ');
        }
    }
}
