

using System.Diagnostics;
public class CentralidadGrafos
{
    public static void run()
    {
        Console.WriteLine("==== PRACTICO 4: MÉTRICAS DE CENTRALIDAD ====");
        var timer = new Stopwatch();
        timer.Start();

        var grafo = new CentralidadGrafos(5);  // construye un grafo de 5 nodos y se agregan aristas.
        grafo.AgregarArista(0, 1);
        grafo.AgregarArista(0, 2);
        grafo.AgregarArista(1, 3);
        grafo.AgregarArista(2, 3);
        grafo.AgregarArista(3, 4);

        // calculan las métricas de centralidad
        grafo.CentralidadGrado();
        grafo.CentralidadCercania();
        grafo.CentralidadIntermediacion();

        timer.Stop();
        Console.WriteLine($"\nTiempo de ejecución: {timer.ElapsedMilliseconds} ms");
    }
    // Atributos, el grafo se representa con un Diccionario
    private Dictionary<int, List<int>> grafo;

    // Constructor, Inicializa el grafo con la cantidad de vértices especificada
    public CentralidadGrafos(int vertices)
    {
        grafo = new Dictionary<int, List<int>>();
        for (int i = 0; i < vertices; i++)
        {
            grafo[i] = new List<int>();
        }
    }

    // Métodos de lógica, Agregar arista entre dos nodos (no dirigido)
    public void AgregarArista(int origen, int destino)
    {
        grafo[origen].Add(destino);
        grafo[destino].Add(origen); // grafo no dirigido
    }

    // Cuenta cuántos vecinos tiene cada nodo.
    public void CentralidadGrado()
    {
        Console.WriteLine("\nCentralidad de Grado:");
        foreach (var nodo in grafo)
        {
            Console.WriteLine($"Nodo {nodo.Key}: {nodo.Value.Count}");
        }
    }

    // Mide la proximidad de un nodo a todos los demás usando distancias mínimas (BFS)
    public void CentralidadCercania()
    {
        Console.WriteLine("\nCentralidad de Cercanía:");
        foreach (var nodo in grafo.Keys)
        {
            int sumaDistancias = 0;
            foreach (var destino in grafo.Keys)
            {
                if (nodo != destino)
                    sumaDistancias += DistanciaMinima(nodo, destino);
            }
            double cercania = (double)(grafo.Count - 1) / sumaDistancias;
            Console.WriteLine($"Nodo {nodo}: {cercania:F2}");
        }
    }

    // Mide cuántos caminos más cortos pasan por un nodo
    public void CentralidadIntermediacion()
    {
        Console.WriteLine("\nCentralidad de Intermediación:");
        foreach (var nodo in grafo.Keys)
        {
            int contador = 0;
            foreach (var origen in grafo.Keys)
            {
                foreach (var destino in grafo.Keys)
                {
                    if (origen != destino && origen != nodo && destino != nodo)
                    {
                        var camino = CaminoMasCorto(origen, destino);
                        if (camino.Contains(nodo))
                            contador++;
                    }
                }
            }
            Console.WriteLine($"Nodo {nodo}: {contador}");
        }
    }

    // Algoritmo de búsqueda en anchura (BFS) que calcula
    // la distancia más corta entre dos nodos.
    private int DistanciaMinima(int inicio, int fin)
    {
        var cola = new Queue<int>();
        var distancias = new Dictionary<int, int>();

        foreach (var nodo in grafo.Keys)
            distancias[nodo] = int.MaxValue;

        distancias[inicio] = 0;
        cola.Enqueue(inicio);

        while (cola.Count > 0)
        {
            int actual = cola.Dequeue();
            foreach (var vecino in grafo[actual])
            {
                if (distancias[vecino] == int.MaxValue)
                {
                    distancias[vecino] = distancias[actual] + 1;
                    cola.Enqueue(vecino);
                }
            }
        }

        return distancias[fin];
    }

    // Reconstruye el camino más corto entre dos nodos
    // utilizando la información generada por BFS.
    private List<int> CaminoMasCorto(int inicio, int fin)
    {
        var cola = new Queue<int>();
        var anterior = new Dictionary<int, int?>();
        foreach (var nodo in grafo.Keys)
            anterior[nodo] = null;

        cola.Enqueue(inicio);

        while (cola.Count > 0)
        {
            int actual = cola.Dequeue();
            if (actual == fin) break;

            foreach (var vecino in grafo[actual])
            {
                if (anterior[vecino] == null && vecino != inicio)
                {
                    anterior[vecino] = actual;
                    cola.Enqueue(vecino);
                }
            }
        }

        var camino = new List<int>();
        int? nodoActual = fin;
        while (nodoActual != null)
        {
            camino.Insert(0, nodoActual.Value);
            nodoActual = anterior[nodoActual.Value];
        }

        return camino;
    }
}