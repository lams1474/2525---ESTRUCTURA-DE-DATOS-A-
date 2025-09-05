// Archivo: Program.cs
public class Program
{
    public static void Main(string[] args)
    {
        var app = new TorneoApp();
        app.Run();
    }
}

public class TorneoApp
{
    // Diccionario: Equipo -> Conjunto de jugadores (sin duplicados)
    private readonly System.Collections.Generic.Dictionary<string, System.Collections.Generic.HashSet<string>> _equipos =
        new System.Collections.Generic.Dictionary<string, System.Collections.Generic.HashSet<string>>(System.StringComparer.OrdinalIgnoreCase);

    public void Run()
    {
        while (true)
        {
            System.Console.WriteLine("===== MENÚ TORNEO DE FÚTBOL (HashSet + Dictionary) =====");
            System.Console.WriteLine("1. Registrar equipo y jugadores");
            System.Console.WriteLine("2. Consultar equipos y jugadores");
            System.Console.WriteLine("3. Consultar estadísticas");
            System.Console.WriteLine("0. Salir");
            System.Console.Write("Seleccione una opción: ");

            var op = System.Console.ReadLine();
            System.Console.WriteLine();

            if (op == "0") break;
            if (op == "1") RegistrarEquipoYJugadores();
            else if (op == "2") ConsultarEquipos();
            else if (op == "3") MostrarEstadisticas();
            else System.Console.WriteLine("Opción no válida.\n");
        }
    }

    private void RegistrarEquipoYJugadores()
    {
        System.Console.Write("Nombre del equipo: ");
        var equipo = System.Console.ReadLine();
        if (string.IsNullOrWhiteSpace(equipo))
        {
            System.Console.WriteLine("El nombre del equipo no puede estar vacío.\n");
            return;
        }

        if (!_equipos.ContainsKey(equipo))
        {
            _equipos[equipo] = new System.Collections.Generic.HashSet<string>(System.StringComparer.OrdinalIgnoreCase);
            System.Console.WriteLine($"Equipo '{equipo}' creado.");
        }
        else
        {
            System.Console.WriteLine($"Equipo '{equipo}' ya existe. Se agregarán jugadores al existente.");
        }

        System.Console.WriteLine("Ingrese jugadores separados por comas (ej.: Ana, Luis, María): ");
        var linea = System.Console.ReadLine();
        if (string.IsNullOrWhiteSpace(linea))
        {
            System.Console.WriteLine("No se ingresaron jugadores.\n");
            return;
        }

        var jugadores = linea.Split(',');
        int agregados = 0, repetidos = 0;
        foreach (var j in jugadores)
        {
            var nombre = j.Trim();
            if (string.IsNullOrWhiteSpace(nombre)) continue;
            if (_equipos[equipo].Add(nombre)) agregados++;
            else repetidos++;
        }

        System.Console.WriteLine($"Agregados: {agregados}. Duplicados ignorados: {repetidos}.\n");
    }

    private void ConsultarEquipos()
    {
        if (_equipos.Count == 0)
        {
            System.Console.WriteLine("No hay equipos registrados.\n");
            return;
        }

        foreach (var par in _equipos)
        {
            System.Console.WriteLine($"Equipo: {par.Key}");
            if (par.Value.Count == 0)
            {
                System.Console.WriteLine("  (Sin jugadores)");
            }
            else
            {
                foreach (var jugador in par.Value)
                {
                    System.Console.WriteLine($"  - {jugador}");
                }
            }
            System.Console.WriteLine();
        }
    }

    private void MostrarEstadisticas()
    {
        int totalEquipos = _equipos.Count;
        int totalJugadores = 0;

        // Conjunto para contar jugadores únicos en todo el torneo
        var todos = new System.Collections.Generic.HashSet<string>(System.StringComparer.OrdinalIgnoreCase);

        foreach (var par in _equipos)
        {
            totalJugadores += par.Value.Count;
            todos.UnionWith(par.Value); // Unión de conjuntos
        }

        System.Console.WriteLine("===== ESTADÍSTICAS =====");
        System.Console.WriteLine($"Total de equipos: {totalEquipos}");
        System.Console.WriteLine($"Total de jugadores (sumando por equipo): {totalJugadores}");
        System.Console.WriteLine($"Jugadores únicos en el torneo (sin duplicados): {todos.Count}");

        // Ejemplo de operaciones de teoría de conjuntos:
        // Si existen al menos dos equipos, mostramos intersección y diferencia
        if (_equipos.Count >= 2)
        {
            var enumerator = _equipos.GetEnumerator();
            enumerator.MoveNext();
            var e1 = enumerator.Current;

            if (enumerator.MoveNext())
            {
                var e2 = enumerator.Current;

                // Intersección: jugadores que están (por nombre) en ambos equipos
                var interseccion = new System.Collections.Generic.HashSet<string>(e1.Value, System.StringComparer.OrdinalIgnoreCase);
                interseccion.IntersectWith(e2.Value);

                // Diferencia: jugadores en e1 que no están en e2
                var diferencia = new System.Collections.Generic.HashSet<string>(e1.Value, System.StringComparer.OrdinalIgnoreCase);
                diferencia.ExceptWith(e2.Value);

                System.Console.WriteLine($"\nComparando '{e1.Key}' y '{e2.Key}':");
                System.Console.WriteLine($"  Intersección (jugadores en ambos): {interseccion.Count}");
                System.Console.WriteLine($"  Diferencia ({e1.Key} - {e2.Key}): {diferencia.Count}");
            }
        }

        System.Console.WriteLine();
    }
}
