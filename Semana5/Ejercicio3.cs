using System;
using System.Collections.Generic;

class Ejercicio3 {
    static void Main() {
        List<string> asignaturas = new List<string> { "Matemáticas", "Física", "Química", "Historia", "Lengua" };
        Dictionary<string, double> notas = new Dictionary<string, double>();

        foreach (string materia in asignaturas) {
            Console.Write($"¿Qué nota sacaste en {materia}? ");
            double nota = double.Parse(Console.ReadLine());
            notas[materia] = nota;
        }

        Console.WriteLine("\nResumen de notas:");
        foreach (var par in notas) {
            Console.WriteLine($"En {par.Key} has sacado {par.Value}");
        }
    }
}