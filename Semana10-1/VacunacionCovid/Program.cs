public class Vacunas
{
    // Punto de entrada
    public static void Main(string[] args)
    {
        run();
    }

    public static void run()
    {
        // Generador aleatorio
        Random random = new System.Random();

        // Conjunto total: 500 ciudadanos
        System.Collections.Generic.HashSet<string> todos = new System.Collections.Generic.HashSet<string>();
        for (int i = 1; i <= 500; i++)
        {
            todos.Add("Persona " + i);
        }

        // Pfizer: 75 únicos
        System.Collections.Generic.HashSet<string> pfizer = new System.Collections.Generic.HashSet<string>();
        while (pfizer.Count < 75)
        {
            pfizer.Add("Persona " + random.Next(1, 501));
        }

        // AstraZeneca: 75 únicos
        System.Collections.Generic.HashSet<string> astrazeneca = new System.Collections.Generic.HashSet<string>();
        while (astrazeneca.Count < 75)
        {
            astrazeneca.Add("Persona " + random.Next(1, 501));
        }

        // Ambas dosis = intersección
        System.Collections.Generic.HashSet<string> ambasDosis =
            new System.Collections.Generic.HashSet<string>(pfizer);
        ambasDosis.IntersectWith(astrazeneca);

        // Solo Pfizer = diferencia
        System.Collections.Generic.HashSet<string> soloPfizer =
            new System.Collections.Generic.HashSet<string>(pfizer);
        soloPfizer.ExceptWith(astrazeneca);

        // Solo AstraZeneca = diferencia
        System.Collections.Generic.HashSet<string> soloAstra =
            new System.Collections.Generic.HashSet<string>(astrazeneca);
        soloAstra.ExceptWith(pfizer);

        // No vacunados = todos - (Pfizer ∪ AstraZeneca)
        System.Collections.Generic.HashSet<string> vacunados =
            new System.Collections.Generic.HashSet<string>(pfizer);
        vacunados.UnionWith(astrazeneca);

        System.Collections.Generic.HashSet<string> noVacunados =
            new System.Collections.Generic.HashSet<string>(todos);
        noVacunados.ExceptWith(vacunados);

        // ----- Salida -----
        Console.WriteLine("==== RESULTADOS DE LA CAMPAÑA DE VACUNACIÓN ====\n");
        Console.WriteLine("Total de ciudadanos: " + todos.Count);
        Console.WriteLine("Total vacunados Pfizer: " + pfizer.Count);
        Console.WriteLine("Total vacunados AstraZeneca: " + astrazeneca.Count);
        Console.WriteLine("Total vacunados (Pfizer ∪ AstraZeneca): " + vacunados.Count);
        Console.WriteLine();
        Console.WriteLine("Ciudadanos con ambas dosis (Pfizer ∩ AstraZeneca): " + ambasDosis.Count);
        Console.WriteLine("Ciudadanos con solo Pfizer: " + soloPfizer.Count);
        Console.WriteLine("Ciudadanos con solo AstraZeneca: " + soloAstra.Count);
        Console.WriteLine("Ciudadanos no vacunados: " + noVacunados.Count);

        // Muestras (primeros 10)
        Console.WriteLine("\n=== EJEMPLOS DE LISTADOS (primeros 10) ===");

        Console.WriteLine("\n- No vacunados:");
        int contador = 10;
        foreach (var p in noVacunados)
        {
            Console.WriteLine(p);
            if (--contador == 0) break;
        }

        Console.WriteLine("\n- Ambas dosis:");
        contador = 10;
        foreach (var p in ambasDosis)
        {
            Console.WriteLine(p);
            if (--contador == 0) break;
        }

        Console.WriteLine("\n- Solo Pfizer:");
        contador = 10;
        foreach (var p in soloPfizer)
        {
            Console.WriteLine(p);
            if (--contador == 0) break;
        }

        Console.WriteLine("\n- Solo AstraZeneca:");
        contador = 10;
        foreach (var p in soloAstra)
        {
            Console.WriteLine(p);
            if (--contador == 0) break;
        }
    }
}
