// using: importamos los espacios de nombres necesarios.
using System;
using System.Collections.Generic;

class Traductor
{
    // Diccionario principal: inglés → español.
    // StringComparer.OrdinalIgnoreCase permite buscar sin importar mayúsculas/minúsculas (case-insensitive).
    static Dictionary<string, string> diccionario = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        // Palabras iniciales (≥ 10 como exige el enunciado).
        {"time", "tiempo"},
        {"person", "persona"},
        {"year", "año"},
        {"way", "camino"},       // puedes interpretar "way" como "camino" o "forma"
        {"day", "día"},
        {"thing", "cosa"},
        {"man", "hombre"},
        {"world", "mundo"},
        {"life", "vida"},
        {"hand", "mano"},
        {"part", "parte"},
        {"child", "niño"},
        {"eye", "ojo"},
        {"woman", "mujer"},
        {"place", "lugar"},
        {"work", "trabajo"},
        {"week", "semana"},
        {"case", "caso"},
        {"point", "punto"},
        {"government", "gobierno"},
        {"company", "empresa"},
        {"small", "pequeño"},
        {"good", "bueno"},
        {"now", "ahora"},
    };

    // Main: punto de entrada. Controla el menú y el flujo del programa.
    static void Main(string[] args)
    {
        int opcion; // variable para leer la opción de menú
        do
        {
            Console.Clear(); // limpia la consola en cada iteración del menú
            Console.WriteLine("==================== MENÚ ====================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            // TryParse evita excepción si el usuario escribe algo no numérico.
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                opcion = -1; // fuerza “inválido” si la entrada no es número
            }

            // switch: ejecuta la acción según la opción elegida.
            switch (opcion)
            {
                case 1:
                    TraducirFrase(); // llama al método que traduce frases
                    break;
                case 2:
                    AgregarPalabra(); // llama al método que agrega nuevas palabras
                    break;
                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Presione una tecla para continuar...");
                    Console.ReadKey();
                    break;
            }

        } while (opcion != 0); // el menú se repite hasta que el usuario elija salir
    }

    // TraducirFrase: procesa una frase y traduce solo las palabras que existan en el diccionario.
    static void TraducirFrase()
    {
        Console.WriteLine("\nIngrese una frase en inglés o español:");
        string frase = Console.ReadLine(); // lee la frase completa

        // Split básico por separadores comunes. (Simple y suficiente para el requisito).
        // Nota: si quisieras conservar signos exactamente, se puede mejorar con Regex, pero no es obligatorio.
        string[] tokens = frase.Split(new char[] { ' ', ',', '.', ';', '!', '?', ':' }, StringSplitOptions.RemoveEmptyEntries);

        // Para reconstruir la frase traducida de forma simple, concatenamos palabra por palabra.
        string resultado = "";

        foreach (string token in tokens) // recorre cada “palabra” detectada
        {
            string palabra = token;       // conserva el original para no perder mayúsculas/acentos
            string limpio = palabra.ToLower(); // versión en minúsculas para comparar

            // 1) Si está como clave (inglés): traducimos al español.
            if (diccionario.ContainsKey(limpio))
            {
                resultado += diccionario[limpio] + " ";
            }
            // 2) Si está como valor (español): traducimos de vuelta al inglés (búsqueda inversa simple).
            else if (diccionario.ContainsValue(limpio))
            {
                // Búsqueda lineal sobre valores para encontrar su clave asociada.
                foreach (var kvp in diccionario)
                {
                    if (kvp.Value.Equals(limpio, StringComparison.OrdinalIgnoreCase))
                    {
                        resultado += kvp.Key + " ";
                        break;
                    }
                }
            }
            // 3) Si no existe en el diccionario: dejamos la palabra intacta.
            else
            {
                resultado += palabra + " ";
            }
        }

        Console.WriteLine("\nTraducción (parcial según diccionario):");
        Console.WriteLine(resultado.TrimEnd()); // muestra la frase traducida
        Console.WriteLine("\nPresione una tecla para continuar...");
        Console.ReadKey(); // pausa para que el usuario vea el resultado
    }

    // AgregarPalabra: permite al usuario incorporar nuevas traducciones al diccionario.
    static void AgregarPalabra()
    {
        Console.Write("\nIngrese la palabra en inglés: ");
        string ingles = (Console.ReadLine() ?? "").Trim();

        Console.Write("Ingrese la traducción en español: ");
        string espanol = (Console.ReadLine() ?? "").Trim();

        // Validaciones mínimas para evitar entradas vacías.
        if (string.IsNullOrWhiteSpace(ingles) || string.IsNullOrWhiteSpace(espanol))
        {
            Console.WriteLine("Entrada inválida. Ningún campo puede estar vacío.");
        }
        else if (!diccionario.ContainsKey(ingles))
        {
            diccionario.Add(ingles, espanol); // inserción O(1) promedio
            Console.WriteLine($"Palabra agregada: {ingles} → {espanol}");
        }
        else
        {
            Console.WriteLine("La palabra en inglés ya existe en el diccionario.");
        }

        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadKey(); // pausa para volver al menú
    }
}

