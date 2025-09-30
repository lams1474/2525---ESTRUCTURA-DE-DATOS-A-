public class TraductorEspanolIngles
{
    public static void run()
    {
        // Diccionario español → inglés (con comparación insensible a mayúsculas)
        var diccionario = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "tiempo", "time" },
            { "persona", "person" },
            { "año", "year" },
            { "camino", "way" },
            { "día", "day" },
            { "cosa", "thing" },
            { "hombre", "man" },
            { "mundo", "world" },
            { "vida", "life" },
            { "mano", "hand" },
            { "parte", "part" },
            { "niño", "child" },
            { "ojo", "eye" },
            { "mujer", "woman" },
            { "lugar", "place" },
            { "trabajo", "work" },
            { "semana", "week" },
            { "caso", "case" },
            { "punto", "point" },
            { "gobierno", "government" },
            { "empresa", "company" },
            { "hola", "hello" }
        };

        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n==================== MENÚ ====================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabra al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            var input = Console.ReadLine();
            if (!int.TryParse(input, out int opcion))
            {
                Console.WriteLine("Opción inválida. Por favor, ingrese un número.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    TraducirFrase(diccionario);
                    break;

                case 2:
                    AgregarPalabra(diccionario);
                    break;

                case 0:
                    salir = true;
                    Console.WriteLine("\nGracias por usar el traductor.");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    private static void TraducirFrase(Dictionary<string, string> diccionario)
    {
        Console.Write("\nIngrese una frase en español: ");
        var frase = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(frase))
        {
            Console.WriteLine("Frase vacía. No se puede traducir.");
            return;
        }

        var palabras = frase.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var traduccion = new List<string>();

        foreach (var palabra in palabras)
        {
            var limpia = palabra.Trim().ToLowerInvariant();
            if (diccionario.TryGetValue(limpia, out var traduccionIngles))
            {
                traduccion.Add(traduccionIngles);
            }
            else
            {
                traduccion.Add($"[{limpia}]");
            }
        }

        Console.WriteLine("\nTraducción: " + string.Join(" ", traduccion));
    }

    private static void AgregarPalabra(Dictionary<string, string> diccionario)
    {
        Console.Write("\nIngrese palabra en español: ");
        var espanol = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(espanol))
        {
            Console.WriteLine("Palabra en español no válida.");
            return;
        }
        espanol = espanol.Trim().ToLowerInvariant();

        Console.Write("Ingrese su traducción al inglés: ");
        var ingles = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(ingles))
        {
            Console.WriteLine("Traducción no válida.");
            return;
        }
        ingles = ingles.Trim().ToLowerInvariant();

        if (diccionario.ContainsKey(espanol))
        {
            Console.WriteLine("La palabra ya existe en el diccionario.");
        }
        else
        {
            diccionario[espanol] = ingles;
            Console.WriteLine("Palabra agregada correctamente.");
        }
    }
}