using System;
using System.Collections.Generic;

class Program {
    static void Main() {
        List<string> asignaturas = new List<string> { "Matemáticas", "Física", "Química", "Historia", "Lengua" };
        Console.WriteLine("Asignaturas del curso:");
        foreach (string materia in asignaturas) {
            Console.WriteLine(materia);
        }
    }
}