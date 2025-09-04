using System;
using System.Collections.Generic;

public class NodoABB
{
    public string Valor;
    public NodoABB Izquierdo;
    public NodoABB Derecho;

    public NodoABB(string valor)
    {
        Valor = valor;
        Izquierdo = null;
        Derecho = null;
    }
}

public class ArbolBinarioBusqueda
{
    private NodoABB raiz;

    public void Insertar(string valor)
    {
        raiz = InsertarRecursivo(raiz, valor);
    }

    private NodoABB InsertarRecursivo(NodoABB nodo, string valor)
    {
        if (nodo == null)
            return new NodoABB(valor);

        if (string.Compare(valor, nodo.Valor, StringComparison.OrdinalIgnoreCase) < 0)
            nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, valor);
        else if (string.Compare(valor, nodo.Valor, StringComparison.OrdinalIgnoreCase) > 0)
            nodo.Derecho = InsertarRecursivo(nodo.Derecho, valor);

        return nodo;
    }

    public void InOrden()
    {
        Console.WriteLine("\n--- Jugadores en orden (ABB) ---");
        InOrdenRecursivo(raiz);
        Console.WriteLine();
    }

    private void InOrdenRecursivo(NodoABB nodo)
    {
        if (nodo != null)
        {
            InOrdenRecursivo(nodo.Izquierdo);
            Console.WriteLine(nodo.Valor);
            InOrdenRecursivo(nodo.Derecho);
        }
    }
}

public class TorneoFutbol
{
    private static Dictionary<string, HashSet<string>> equipos = new();
    private static ArbolBinarioBusqueda arbolJugadores = new();

    public static void Main(string[] args)
    {
        int opcion;
        do
        {
            Console.WriteLine("\n===== MENÚ TORNEO DE FÚTBOL =====");
            Console.WriteLine("1. Registrar equipo y jugadores");
            Console.WriteLine("2. Consultar equipos y jugadores");
            Console.WriteLine("3. Consultar estadísticas");
            Console.WriteLine("4. Listar jugadores en orden (ABB)");
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
                    arbolJugadores.InOrden();
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
                    arbolJugadores.Insertar(jugador); // También lo insertamos en el ABB
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
