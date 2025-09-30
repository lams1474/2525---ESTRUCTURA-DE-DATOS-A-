public class VacunasCovid
{
    public static void run()
    {
        Console.WriteLine("=== Campaña de Vacunación COVID-19 ===");

        Random random = new Random();

        // Generar conjunto de personas vacunadas con Pfizer (hasta 75 personas únicas)
        HashSet<string> pfizer = new HashSet<string>();
        while (pfizer.Count < 75)
        {
            pfizer.Add("Persona " + random.Next(1, 501));
        }

        // Generar conjunto de personas vacunadas con AstraZeneca (hasta 75 personas únicas)
        HashSet<string> astrazeneca = new HashSet<string>();
        while (astrazeneca.Count < 75)
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

        // No vacunados
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