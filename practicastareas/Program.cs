using System;
using System.Collections.Generic;

// Clase Nodo, igual que en la guía del docente (pero ahora usada para strings)
public class Node
{
    public string Value;
    public Node Left;
    public Node Right;

    public Node(string value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

// Implementación de Árbol Binario de Búsqueda (ABB)
public class BinarySearchTree
{
    private Node root;

    public void Insert(string value)
    {
        root = InsertRec(root, value);
    }

    private Node InsertRec(Node node, string value)
    {
        if (node == null)
            return new Node(value);

        if (string.Compare(value, node.Value, StringComparison.OrdinalIgnoreCase) < 0)
            node.Left = InsertRec(node.Left, value);
        else if (string.Compare(value, node.Value, StringComparison.OrdinalIgnoreCase) > 0)
            node.Right = InsertRec(node.Right, value);

        return node;
    }

    // Recorrido In-Order → jugadores en orden alfabético
    public void InOrder()
    {
        Console.WriteLine("\n--- Jugadores en orden (ABB) ---");
        InOrderRec(root);
        Console.WriteLine();
    }

    private void InOrderRec(Node node)
    {
        if (node != null)
        {
            InOrderRec(node.Left);
            Console.WriteLine(node.Value);
            InOrderRec(node.Right);
        }
    }
}

public class TorneoFutbol
{
    private static Dictionary<string, HashSet<string>> equipos = new();
    private static BinarySearchTree arbolJugadores = new();

    public static void Main(string[] args)
    {
        int opcion;
        do
        {
            Console.WriteLine("\n===== LIGA JOSE I. IZURIETA =====");
            Console.WriteLine("\n===== MENÚ TORNEO DE FÚTBOL =====");
            Console.WriteLine("1. Registrar equipo y jugadores");
            Console.WriteLine("2. Consultar equipos y jugadores");
            Console.WriteLine("3. Consultar estadísticas");
            Console.WriteLine("4. Listar jugadores en orden ");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion)) opcion = -1;

            switch (opcion)
            {
                case 1:
                    RegistrarEquipo();
                    break;
                case 2:
                    ConsultarEquipos();
                    break;
                case 3:
                    ConsultarEstadisticas();
                    break;
                case 4:
                    arbolJugadores.InOrder();
                    break;
                case 0:
                    Console.WriteLine("Saliendo del sistema...");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

        } while (opcion != 0);
    }

    private static void RegistrarEquipo()
    {
        Console.Write("Ingrese el nombre del equipo: ");
        string equipo = Console.ReadLine() ?? "";

        if (!equipos.ContainsKey(equipo))
            equipos[equipo] = new HashSet<string>();

        Console.Write("¿Cuántos jugadores desea registrar? ");
        if (int.TryParse(Console.ReadLine(), out int cantidad))
        {
            for (int i = 0; i < cantidad; i++)
            {
                Console.Write($"Ingrese el nombre del jugador {i + 1}: ");
                string jugador = Console.ReadLine() ?? "";

                if (equipos[equipo].Add(jugador))
                {
                    arbolJugadores.Insert(jugador); // Jugador también se guarda en el ABB
                    Console.WriteLine($"Jugador {jugador} registrado con éxito.");
                }
                else
                {
                    Console.WriteLine($"El jugador {jugador} ya está registrado en el equipo.");
                }
            }
        }
    }

    private static void ConsultarEquipos()
    {
        Console.WriteLine("\n--- Equipos y jugadores ---");
        foreach (var equipo in equipos)
        {
            Console.WriteLine($"Equipo: {equipo.Key}");
            foreach (var jugador in equipo.Value)
            {
                Console.WriteLine($"  - {jugador}");
            }
        }
    }

    private static void ConsultarEstadisticas()
    {
        int totalEquipos = equipos.Count;
        int totalJugadores = 0;
        HashSet<string> jugadoresUnicos = new();

        foreach (var equipo in equipos.Values)
        {
            totalJugadores += equipo.Count;
            jugadoresUnicos.UnionWith(equipo);
        }

        Console.WriteLine("\n--- Estadísticas ---");
        Console.WriteLine($"Total de equipos: {totalEquipos}");
        Console.WriteLine($"Total de jugadores registrados: {totalJugadores}");
        Console.WriteLine($"Jugadores únicos: {jugadoresUnicos.Count}");
    }
}
