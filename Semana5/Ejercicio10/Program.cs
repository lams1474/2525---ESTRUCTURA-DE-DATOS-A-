using System;
using System.Collections.Generic;

class Program {
    static void Main() {
        List<int> precios = new List<int> { 50, 75, 46, 22, 80, 65, 8 };
        int menor = precios[0];
        int mayor = precios[0];

        foreach (int p in precios) {
            if (p < menor) menor = p;
            if (p > mayor) mayor = p;
        }

        Console.WriteLine($"Precio menor: {menor}");
        Console.WriteLine($"Precio mayor: {mayor}");
    }
}