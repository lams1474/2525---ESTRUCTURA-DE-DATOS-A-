public class Traductor
{
    public static void Main(string[] args)
    {
        run();
    }

    public static void run()
    {
        // Diccionario español → inglés
        System.Collections.Generic.Dictionary<string, string> diccionario =
            new System.Collections.Generic.Dictionary<string, string>();

        // Palabras iniciales 
        diccionario.Add("tiempo", "time");
        diccionario.Add("persona", "person");
        diccionario.Add("año", "year");
        diccionario.Add("camino", "way");
        diccionario.Add("día", "day");
        diccionario.Add("cosa", "thing");
        diccionario.Add("hombre", "man");
        diccionario.Add("mundo", "world");
        diccionario.Add("vida", "life");
        diccionario.Add("mano", "hand");
        diccionario.Add("parte", "part");
        diccionario.Add("niño", "child");
        diccionario.Add("ojo", "eye");
        diccionario.Add("mujer", "woman");
        diccionario.Add("lugar", "place");
        diccionario.Add("trabajo", "work");
        diccionario.Add("semana", "week");
        diccionario.Add("caso", "case");
        diccionario.Add("punto", "point");
        diccionario.Add("gobierno", "government");
        diccionario.Add("empresa", "company");
        diccionario.Add("hola", "hello");
        

        int opcion = -1;

        // Menú interactivo
        do
        {
            System.Console.WriteLine("\n==================== MENÚ ====================");
            System.Console.WriteLine("1. Traducir una frase");
            System.Console.WriteLine("2. Agregar palabra al diccionario");
            System.Console.WriteLine("0. Salir");
            System.Console.Write("Seleccione una opción: ");

            try
            {
                opcion = int.Parse(System.Console.ReadLine());
            }
            catch
            {
                opcion = -1;
            }

            if (opcion == 1)
            {
                // Traducir frase
                System.Console.Write("\nIngrese una frase en español: ");
                string frase = System.Console.ReadLine().ToLower();

                string[] palabras = frase.Split(' ');
                string resultado = "";

                foreach (string palabra in palabras)
                {
                    if (diccionario.ContainsKey(palabra))
                    {
                        resultado += diccionario[palabra] + " ";
                    }
                    else
                    {
                        resultado += palabra + " ";
                    }
                }

                System.Console.WriteLine("\nTraducción: " + resultado);
            }
            else if (opcion == 2)
            {
                // Agregar palabra nueva
                System.Console.Write("\nIngrese palabra en español: ");
                string espanol = System.Console.ReadLine().ToLower();

                System.Console.Write("Ingrese su traducción al inglés: ");
                string ingles = System.Console.ReadLine().ToLower();

                if (!diccionario.ContainsKey(espanol))
                {
                    diccionario.Add(espanol, ingles);
                    System.Console.WriteLine("Palabra agregada correctamente.");
                }
                else
                {
                    System.Console.WriteLine("La palabra ya existe en el diccionario.");
                }
            }

        } while (opcion != 0);

        System.Console.WriteLine("\nGracias por usar el traductor.");
    }
}
