using System;
using System.Collections.Generic;

public class Vacunas
{
    // Método de entrada obligatorio
    public static void Main(string[] args)
    {
        Run();
    }

    public static void Run()
    {
        Random random = new Random();

        HashSet<string> pfizer = new HashSet<string>();
        for (int i = 0; i < 75; i++)
        {
            pfizer.Add("Persona " + random.Next(1, 501));
        }

        HashSet<string> astrazeneca = new HashSet<string>();
        for (int i = 0; i < 75; i++)
        {
            astrazeneca.Add("Persona " + random.Next(1, 501));
        }

        // Solo Pfizer
        HashSet<string> soloPfizer = new HashSet<string>(pfizer);
        soloPfizer.ExceptWith(astrazeneca);

        Console.WriteLine("Vacunados con solo Pfizer: " + soloPfizer.Count);

        // Solo AstraZeneca
        HashSet<string> soloAstra = new HashSet<string>(astrazeneca);
        soloAstra.ExceptWith(pfizer);

        Console.WriteLine("Vacunados con solo AstraZeneca: " + soloAstra.Count);

        // Ambas dosis
        HashSet<string> ambasDosis = new HashSet<string>(pfizer);
        ambasDosis.IntersectWith(astrazeneca);

        Console.WriteLine("Vacunados con ambas dosis: " + ambasDosis.Count);

        // No vacunados (500 personas - los que están en Pfizer o AstraZeneca)
        HashSet<string> todos = new HashSet<string>();
        for (int i = 1; i <= 500; i++)
        {
            todos.Add("Persona " + i);
        }

        HashSet<string> vacunados = new HashSet<string>(pfizer);
        vacunados.UnionWith(astrazeneca);

        HashSet<string> noVacunados = new HashSet<string>(todos);
        noVacunados.ExceptWith(vacunados);

        Console.WriteLine("No vacunados: " + noVacunados.Count);
    }
}
