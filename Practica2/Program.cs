// ----------------------------
// Simulación de Asignación de 30 Asientos en orden de llegada
// ----------------------------

using System;
using System.Collections.Generic;

/// <summary>
/// Clase que representa a una persona en la cola.
/// </summary>
class Persona
{
    public string Nombre { get; set; }
    public int NumeroTurno { get; set; }

    public Persona(string nombre, int turno)
    {
        Nombre = nombre;
        NumeroTurno = turno;
    }
}

/// <summary>
/// Clase que gestiona la cola de asientos disponibles.
/// </summary>
class ColaAsientos
{
    private Queue<Persona> cola;
    private int capacidadMaxima;

    public ColaAsientos(int capacidad)
    {
        capacidadMaxima = capacidad;
        cola = new Queue<Persona>();
    }

    public bool EncolarPersona(Persona persona)
    {
        if (cola.Count >= capacidadMaxima)
        {
            Console.WriteLine("\nNo se pueden asignar más asientos. Cupo lleno.");
            return false;
        }

        cola.Enqueue(persona);
        Console.WriteLine($"Turno {persona.NumeroTurno}: {persona.Nombre} ha sido encolado.");
        return true;
    }

    public void MostrarAsientosAsignados()
    {
        Console.WriteLine("\nLista de personas con asiento asignado:");
        foreach (var persona in cola)
        {
            Console.WriteLine($"Turno {persona.NumeroTurno}: {persona.Nombre}");
        }
    }

    public int TotalAsignados()
    {
        return cola.Count;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ColaAsientos cola = new ColaAsientos(30);
        int turno = 1;
        string opcion;

        Console.WriteLine("=== Sistema de Asignación de 30 Asientos ===\n");

        do
        {
            Console.Write("Ingrese el nombre de la persona (o 'fin' para terminar): ");
            string nombre = Console.ReadLine()?.Trim() ?? "";

            if (nombre.ToLower() == "fin")
                break;

            Persona p = new Persona(nombre, turno);
            bool encolado = cola.EncolarPersona(p);
            if (encolado) turno++;

            if (cola.TotalAsignados() == 30)
            {
                Console.WriteLine("\nSe han asignado los 30 asientos disponibles.");
                break;
            }

        } while (true);

        cola.MostrarAsientosAsignados();
        Console.WriteLine("\nTotal de personas atendidas: " + cola.TotalAsignados());
    }
}
