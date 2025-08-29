using System; // Se utiliza para manejar la consola y generar aleatoriedad en el programa.
using System.Collections.Generic; // se utiliza para trabajar con conjuntos (HashSet) que permiten modelar y resolver el problema de la vacunación mediante operaciones de teoría de conjuntos.

public class Vacunas // se utiliza para organizar el código en una estructura POO, que contiene los métodos principales del programa.
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
