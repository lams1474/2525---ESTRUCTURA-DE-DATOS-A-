using System;
using System.Collections.Generic;

class Program {
    static void Main() {
        List<int> numeros = new List<int>();
        Console.WriteLine("Ingrese los 6 números ganadores de la lotería:");

        for (int i = 0; i < 6; i++) {
            Console.Write($"Número {i + 1}: ");
            int n = int.Parse(Console.ReadLine());
            numeros.Add(n);
        }

        numeros.Sort();
        Console.WriteLine("\nNúmeros ordenados:");
        foreach (int num in numeros) {
            Console.Write(num + " ");
        }
    }
}