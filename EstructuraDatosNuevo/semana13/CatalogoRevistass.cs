public class CatalogoRevistass
{
    public static void run()
    {
        Console.WriteLine("=== Catálogo de Revistas ===");

        // Catálogo inicial (¡debe estar ordenado para búsqueda binaria!)
        var revistas = new List<string>
        {
            "Chasqui",
            "Ecuador debate",
            "Elle",
            "Glamour",
            "lams",
            "Letras verdes",
            "Lex",
            "Oconos",
            "Vistazo",
            "Vogue",
            "Yuyay"
        };

        int opcion;
        do
        {
            Console.WriteLine("===== MENÚ CATÁLOGO DE REVISTAS =====");
            Console.WriteLine("1. Buscar revista");
            Console.WriteLine("2. Mostrar catálogo");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            var entrada = Console.ReadLine();
            if (!int.TryParse(entrada, out opcion))
            {
                opcion = -1;
            }

            switch (opcion)
            {
                case 1:
                    BuscarRevista(revistas);
                    break;
                case 2:
                    MostrarCatalogo(revistas);
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

        } while (opcion != 0);

        Console.WriteLine("Gracias por usar el catálogo.");
    }

    private static void MostrarCatalogo(List<string> revistas)
    {
        Console.WriteLine("Catálogo completo de revistas:");
        foreach (var revista in revistas)
        {
            Console.WriteLine(" - " + revista);
        }
    }

    private static void BuscarRevista(List<string> revistas)
    {
        Console.Write("Ingrese el título de la revista a buscar: ");
        var entrada = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(entrada))
        {
            Console.WriteLine("Debe ingresar un título válido.");
            return;
        }

        string objetivo = entrada.Trim();
        bool encontrado = BusquedaBinariaRecursiva(revistas, objetivo, 0, revistas.Count - 1);

        Console.WriteLine(encontrado ? " Encontrado" : " No encontrado");
    }

    private static bool BusquedaBinariaRecursiva(List<string> lista, string objetivo, int inicio, int fin)
    {
        if (inicio > fin) return false;

        int medio = inicio + (fin - inicio) / 2;
        int comparacion = string.Compare(objetivo, lista[medio], StringComparison.OrdinalIgnoreCase);

        if (comparacion == 0)
            return true;
        if (comparacion < 0)
            return BusquedaBinariaRecursiva(lista, objetivo, inicio, medio - 1);
        else
            return BusquedaBinariaRecursiva(lista, objetivo, medio + 1, fin);
    }
}