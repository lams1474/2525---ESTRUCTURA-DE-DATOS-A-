using System;
using System.Collections.Generic;

/// <summary>
/// Representa una torre con discos almacenados en una pila.
/// </summary>
class Torre
{
    public Stack<int> Discos { get; private set; }
    public string Nombre { get; private set; }

    public Torre(string nombre)
    {
        Nombre = nombre;
        Discos = new Stack<int>();
    }

    public void MoverDiscoA(Torre destino)
    {
        int disco = Discos.Pop();
        destino.Discos.Push(disco);
        Console.WriteLine($"Mover disco {disco} de {Nombre} a {destino.Nombre}");
    }
}

/// <summary>
/// Clase que contiene el algoritmo recursivo para resolver las Torres de Hanoi.
/// </summary>
class Hanoi
{
    public static void Resolver(int n, Torre origen, Torre destino, Torre auxiliar)
    {
        if (n == 1)
        {
            origen.MoverDiscoA(destino);
        }
        else
        {
            Resolver(n - 1, origen, auxiliar, destino);
            origen.MoverDiscoA(destino);
            Resolver(n - 1, auxiliar, destino, origen);
        }
    }

    static void Main()
    {
        int discos = 3;
        Torre A = new Torre("A");
        Torre B = new Torre("B");
        Torre C = new Torre("C");

        for (int i = discos; i >= 1; i--)
        {
            A.Discos.Push(i);
        }

        Console.WriteLine($"Resolviendo Torres de Hanoi con {discos} discos:\n");
        Resolver(discos, A, C, B);
    }
}
