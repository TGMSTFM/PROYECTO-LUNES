using System;

namespace MesaPartesDigital
{
    // Aca pusimos todos los metodos para revisar y arreglar los textos que mete el usuario
    // antes de guardarlos, para que no entren datos vacios ni mal escritos.
    internal static class Validaciones
    {
        // Revisa que el codigo tenga entre 4 y 12 caracteres, arranque con letra
        // y no tenga espacios ni simbolos raros (tipo EXP001).
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

        // Verifica que el nombre tenga de 5 a 60 letras, sin numeros ni simbolos,
        // y que por lo menos tenga 2 palabras para que pongan nombre y apellido.
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

        // Controla que el asunto no este vacio y tenga entre 5 y 150 caracteres
        public static bool EsAsuntoValido(string asunto)
        {
            if (string.IsNullOrWhiteSpace(asunto))
            {
                return false;
            }
            int longitud = asunto.Trim().Length;
            return longitud >= 5 && longitud <= 150;
        }

        // Le borra los espacios sobrantes y pasa el codigo a mayusculas (ej: " exp001 " -> "EXP001")
        public static string NormalizarCodigo(string codigo)
        {
            return codigo.Trim().ToUpper();
        }

        // Acomoda el nombre quitando espacios dobles y poniendo la primera letra de cada palabra en mayuscula
        public static string NormalizarNombre(string nombre)
        {
            string[] palabras = nombre.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < palabras.Length; i++)
            {
                palabras[i] = palabras[i].Substring(0, 1).ToUpper() + palabras[i].Substring(1).ToLower();
            }
            return string.Join(" ", palabras);
        }

        // Cambia el simbolo '|' por un espacio porque ese caracter lo usamos para separar
        // los datos en el txt y si lo dejan se malogra todo el archivo.
        public static string LimpiarTexto(string texto)
        {
            return texto.Trim().Replace('|', ' ');
        }
    }
}