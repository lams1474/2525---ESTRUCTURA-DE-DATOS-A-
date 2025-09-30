public class Program
{
    public static void Main(string[] args)
    {
        var app = new CatalogoRevistas();
        app.Run();
    }
}

public class CatalogoRevistas
{
    // Catálogo implementado como arreglo de cadenas
    private string[] _revistas = new string[]
    {
        "Chasqui",
            "Oconos",
            "Ecuador debate",
            "Revista amazónica",
            "Letras verdes",
            "Lex",
            "Yuyay",
            "Vogue",
            "Elle",
            "Glamour",
            "Cosmopolitan",
    };

    public void Run()
    {
        // Ordenamos el catálogo para aplicar búsqueda binaria
        System.Array.Sort(_revistas);

        while (true)
        {
            System.Console.WriteLine("===== MENÚ CATÁLOGO DE REVISTAS (con Arreglo) =====");
            System.Console.WriteLine("1. Buscar revista");
            System.Console.WriteLine("2. Mostrar catálogo");
            System.Console.WriteLine("0. Salir");
            System.Console.Write("Seleccione una opción: ");

            var opcion = System.Console.ReadLine();
            System.Console.WriteLine();

            if (opcion == "0") break;
            if (opcion == "1") BuscarRevista();
            else if (opcion == "2") MostrarCatalogo();
            else System.Console.WriteLine("Opción no válida.\n");
        }
    }

    private void MostrarCatalogo()
    {
        System.Console.WriteLine("Catálogo de revistas:");
        foreach (var revista in _revistas)
        {
            System.Console.WriteLine(" - " + revista);
        }
        System.Console.WriteLine();
    }

    private void BuscarRevista()
    {
        System.Console.Write("Ingrese el título de la revista a buscar: ");
        var titulo = System.Console.ReadLine();

        if (string.IsNullOrWhiteSpace(titulo))
        {
            System.Console.WriteLine("Debe ingresar un título válido.\n");
            return;
        }

        bool encontrado = BusquedaBinariaRecursiva(_revistas, titulo, 0, _revistas.Length - 1);

        if (encontrado)
            System.Console.WriteLine("Encontrado\n");
        else
            System.Console.WriteLine("No encontrado\n");
    }

    // Método de búsqueda binaria recursiva sobre arreglo
    private bool BusquedaBinariaRecursiva(string[] arreglo, string objetivo, int inicio, int fin)
    {
        if (inicio > fin) return false; // Caso base: no encontrado

        int medio = (inicio + fin) / 2;
        int comparacion = string.Compare(objetivo, arreglo[medio], ignoreCase: true);

        if (comparacion == 0) return true; // Encontrado
        else if (comparacion < 0)
            return BusquedaBinariaRecursiva(arreglo, objetivo, inicio, medio - 1); // Buscar en izquierda
        else
            return BusquedaBinariaRecursiva(arreglo, objetivo, medio + 1, fin);   // Buscar en derecha
    }
}
