// Archivo: Program.cs
// Aplicación de consola: Catálogo de Revistas con Búsqueda Recursiva
// Semana 13 – Árboles y Búsquedas

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
    // Catálogo implementado como lista ordenada alfabéticamente
    private readonly System.Collections.Generic.List<string> _revistas =
        new System.Collections.Generic.List<string>
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

    public System.Collections.Generic.List<global::System.String> Revistas => _revistas;

    public void Run()
    {
        // Ordenamos el catálogo para aplicar búsqueda binaria
        Revistas.Sort();

        while (true)
        {
            System.Console.WriteLine("===== MENÚ CATÁLOGO DE REVISTAS =====");
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
        foreach (var revista in Revistas)
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

        bool encontrado = BusquedaBinariaRecursiva(Revistas, titulo, 0, Revistas.Count - 1);

        if (encontrado)
            System.Console.WriteLine("Encontrado\n");
        else
            System.Console.WriteLine("No encontrado\n");
    }

    // Método de búsqueda binaria recursiva
    private bool BusquedaBinariaRecursiva(System.Collections.Generic.List<string> lista, string objetivo, int inicio, int fin)
    {
        if (inicio > fin) return false; // Caso base: no encontrado

        int medio = (inicio + fin) / 2;
        int comparacion = string.Compare(objetivo, lista[medio], ignoreCase: true);

        if (comparacion == 0) return true; // Encontrado
        else if (comparacion < 0)
            return BusquedaBinariaRecursiva(lista, objetivo, inicio, medio - 1); // Buscar en la izquierda
        else
            return BusquedaBinariaRecursiva(lista, objetivo, medio + 1, fin);   // Buscar en la derecha
    }
}
