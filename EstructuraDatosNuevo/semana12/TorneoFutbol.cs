public class TorneoFutbol
{
    public static void run()
    {
        var app = new TorneoApp();
        app.Run();
    }
}

class TorneoApp
{
    private readonly Dictionary<string, HashSet<string>> _equipos =
        new Dictionary<string, HashSet<string>>(StringComparer.OrdinalIgnoreCase);

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("===== MENÚ TORNEO DE FÚTBOL (HashSet + Dictionary) =====");
            Console.WriteLine("1. Registrar equipo y jugadores");
            Console.WriteLine("2. Consultar equipos y jugadores");
            Console.WriteLine("3. Consultar estadísticas");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            var op = Console.ReadLine();
            Console.WriteLine();

            if (op == "0") break;
            if (op == "1") RegistrarEquipoYJugadores();
            else if (op == "2") ConsultarEquipos();
            else if (op == "3") MostrarEstadisticas();
            else Console.WriteLine("Opción no válida.\n");
        }
    }

    private void RegistrarEquipoYJugadores()
    {
        Console.Write("Nombre del equipo: ");
        var equipo = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(equipo))
        {
            Console.WriteLine("El nombre del equipo no puede estar vacío.\n");
            return;
        }

        if (!_equipos.ContainsKey(equipo))
        {
            _equipos[equipo] = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            Console.WriteLine($"Equipo '{equipo}' creado.");
        }
        else
        {
            Console.WriteLine($"Equipo '{equipo}' ya existe. Se agregarán jugadores al existente.");
        }

        Console.WriteLine("Ingrese jugadores separados por comas (ej.: Ana, Luis, María): ");
        var linea = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(linea))
        {
            Console.WriteLine("No se ingresaron jugadores.\n");
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

        Console.WriteLine($"Agregados: {agregados}. Duplicados ignorados: {repetidos}.\n");
    }

    private void ConsultarEquipos()
    {
        if (_equipos.Count == 0)
        {
            Console.WriteLine("No hay equipos registrados.\n");
            return;
        }

        foreach (var par in _equipos)
        {
            Console.WriteLine($"Equipo: {par.Key}");
            if (par.Value.Count == 0)
            {
                Console.WriteLine("  (Sin jugadores)");
            }
            else
            {
                foreach (var jugador in par.Value)
                {
                    Console.WriteLine($"  - {jugador}");
                }
            }
            Console.WriteLine();
        }
    }

    private void MostrarEstadisticas()
    {
        int totalEquipos = _equipos.Count;
        int totalJugadores = 0;
        var todos = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        foreach (var par in _equipos)
        {
            totalJugadores += par.Value.Count;
            todos.UnionWith(par.Value);
        }

        Console.WriteLine("===== ESTADÍSTICAS =====");
        Console.WriteLine($"Total de equipos: {totalEquipos}");
        Console.WriteLine($"Total de jugadores (sumando por equipo): {totalJugadores}");
        Console.WriteLine($"Jugadores únicos en el torneo (sin duplicados): {todos.Count}");

        if (_equipos.Count >= 2)
        {
            var enumerator = _equipos.GetEnumerator();
            enumerator.MoveNext();
            var e1 = enumerator.Current;

            if (enumerator.MoveNext())
            {
                var e2 = enumerator.Current;

                var interseccion = new HashSet<string>(e1.Value, StringComparer.OrdinalIgnoreCase);
                interseccion.IntersectWith(e2.Value);

                var diferencia = new HashSet<string>(e1.Value, StringComparer.OrdinalIgnoreCase);
                diferencia.ExceptWith(e2.Value);

                Console.WriteLine($"\nComparando '{e1.Key}' y '{e2.Key}':");
                Console.WriteLine($"  Intersección (jugadores en ambos): {interseccion.Count}");
                Console.WriteLine($"  Diferencia ({e1.Key} - {e2.Key}): {diferencia.Count}");
            }
        }

        Console.WriteLine();
    }
}