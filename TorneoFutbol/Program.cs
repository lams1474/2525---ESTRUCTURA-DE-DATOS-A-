using System;
using System.Collections.Generic;

public class TorneoFutbol
{
    // Diccionario que guarda equipos y sus jugadores
    private static Dictionary<string, HashSet<string>> equipos = new Dictionary<string, HashSet<string>>();

    public static void Main(string[] args)
    {
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("\n===== LIGA JOSE I. IZURIETA =====");
            Console.WriteLine("\n===== MENÚ TORNEO DE FÚTBOL =====");
            Console.WriteLine("1. Registrar equipo y jugadores");
            Console.WriteLine("2. Consultar equipos y jugadores");
            Console.WriteLine("3. Consultar estadísticas");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine()!; // operador ! asegura que no es null

            switch (opcion)
            {
                case "1":
                    RegistrarEquipo();
                    break;
                case "2":
                    MostrarEquipos();
                    break;
                case "3":
                    MostrarEstadisticas();
                    break;
                case "0":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

    // Registrar un equipo y sus jugadores
    private static void RegistrarEquipo()
    {
        Console.Write("Ingrese el nombre del equipo: ");
        string nombreEquipo = Console.ReadLine()!; // corregido con !

        if (!equipos.ContainsKey(nombreEquipo))
        {
            equipos[nombreEquipo] = new HashSet<string>();
            Console.WriteLine($"Equipo '{nombreEquipo}' creado.");
        }
        else
        {
            Console.WriteLine($"El equipo '{nombreEquipo}' ya existe. Se agregarán jugadores al equipo.");
        }

        bool agregarMas = true;
        while (agregarMas)
        {
            Console.Write("Ingrese el nombre de un jugador: ");
            string jugador = Console.ReadLine()!; // corregido con !

            if (equipos[nombreEquipo].Add(jugador))
            {
                Console.WriteLine($"Jugador '{jugador}' agregado al equipo '{nombreEquipo}'.");
            }
            else
            {
                Console.WriteLine($"El jugador '{jugador}' ya estaba registrado en el equipo.");
            }

            Console.Write("¿Desea agregar otro jugador a este equipo? (s/n): ");
            agregarMas = Console.ReadLine()!.ToLower() == "s"; // corregido con !
        }
    }

    // Mostrar equipos y sus jugadores
    private static void MostrarEquipos()
    {
        if (equipos.Count == 0)
        {
            Console.WriteLine("No hay equipos registrados.");
            return;
        }

        Console.WriteLine("\n===== LISTA DE EQUIPOS Y JUGADORES =====");
        foreach (var equipo in equipos)
        {
            Console.WriteLine($"Equipo: {equipo.Key}");
            foreach (var jugador in equipo.Value)
            {
                Console.WriteLine($"  - {jugador}");
            }
        }
    }

    // Mostrar estadísticas del torneo
    private static void MostrarEstadisticas()
    {
        int totalEquipos = equipos.Count;
        int totalJugadores = 0;

        HashSet<string> jugadoresUnicos = new HashSet<string>();
        foreach (var equipo in equipos.Values)
        {
            totalJugadores += equipo.Count;
            jugadoresUnicos.UnionWith(equipo);
        }

        Console.WriteLine("\n===== ESTADÍSTICAS =====");
        Console.WriteLine($"Total de equipos: {totalEquipos}");
        Console.WriteLine($"Total de jugadores (con posibles repetidos): {totalJugadores}");
        Console.WriteLine($"Total de jugadores únicos: {jugadoresUnicos.Count}");
    }
}
