using System;
using System.Collections.Generic;
using System.Linq;

public class Premio
{
    public string Tipo { get; private set; }
    public string Lugar { get; private set; }

    public Premio(string tipo, string lugar)
    {
        if (string.IsNullOrWhiteSpace(tipo)) throw new ArgumentException("Tipo no válido.");
        if (string.IsNullOrWhiteSpace(lugar)) throw new ArgumentException("Lugar no válido.");
        Tipo = tipo;
        Lugar = lugar;
    }

    public override string ToString() => $"- {Tipo} en {Lugar}";
}

public class Deportista
{
    public string Nombre { get; private set; }
    public string Deporte { get; private set; }
    public List<Premio> Premios { get; private set; }

    public Deportista(string nombre, string deporte)
    {
        if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("Nombre no válido.");
        if (string.IsNullOrWhiteSpace(deporte)) throw new ArgumentException("Deporte no válido.");
        Nombre = nombre;
        Deporte = deporte;
        Premios = new List<Premio>();
    }

    public void AgregarPremio(Premio premio)
    {
        if (premio == null) throw new ArgumentNullException(nameof(premio));
        Premios.Add(premio);
    }

    public override string ToString()
    {
        var premios = Premios.Count > 0 
            ? string.Join("\n", Premios.Select(p => $"  {p}"))
            : "  (Ninguno)";
        return $"Nombre: {Nombre}\nDeporte: {Deporte}\nPremios:\n{premios}";
    }
}

public class SistemaPremiacion
{
    private Dictionary<string, Deportista> deportistas = new Dictionary<string, Deportista>();

    public void PremiarDeportista(string nombre, string deporte, string tipo, string lugar)
    {
        if (!deportistas.TryGetValue(nombre, out Deportista deportista))
        {
            deportista = new Deportista(nombre, deporte);
            deportistas[nombre] = deportista;
        }
        deportista.AgregarPremio(new Premio(tipo, lugar));
    }

    public void VerTodos()
    {
        foreach (var d in deportistas.Values)
        {
            Console.WriteLine(d);
            Console.WriteLine(new string('-', 30));
        }
    }

    public void Consultar(string nombre)
    {
        if (deportistas.TryGetValue(nombre, out Deportista d))
            Console.WriteLine(d);
        else
            Console.WriteLine($"No se encontró al deportista '{nombre}'.");
    }
}

public class Program
{
    static void Main()
    {
        SistemaPremiacion sistema = new SistemaPremiacion();
        int opcion;

        do
        {
            Console.Clear();
            Console.WriteLine("*******************************************************************");
            Console.WriteLine("                    UNIVERSIDAD ESTATAL AMAZONICA                   ");
            Console.WriteLine("*******************************************************************");
            Console.WriteLine("\n--- MENÚ DE PREMIACIÓN DE DEPORTISTAS ---");
            Console.WriteLine("1. Premiar Deportista");
            Console.WriteLine("2. Visualizar Todos");
            Console.WriteLine("3. Consultar Deportista");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");

            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        Console.Write("Nombre: "); string n = Console.ReadLine();
                        Console.Write("Deporte: "); string d = Console.ReadLine();
                        Console.Write("Tipo de premio: "); string t = Console.ReadLine();
                        Console.Write("Lugar: "); string l = Console.ReadLine();
                        sistema.PremiarDeportista(n, d, t, l);
                        break;
                    case 2:
                        sistema.VerTodos();
                        Console.WriteLine("Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Write("Nombre a consultar: ");
                        sistema.Consultar(Console.ReadLine());
                        Console.WriteLine("Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        Console.ReadKey();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida.");
                Console.ReadKey();
            }
        } while (opcion != 4);
    }
}