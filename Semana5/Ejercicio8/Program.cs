using System;

class Program {
    static void Main() {
        Console.Write("Ingrese una palabra: ");
        string palabra = Console.ReadLine().ToLower();
        char[] invertido = palabra.ToCharArray();
        Array.Reverse(invertido);
        string palabraInvertida = new string(invertido);

        if (palabra == palabraInvertida) {
            Console.WriteLine("La palabra es un palíndromo.");
        } else {
            Console.WriteLine("La palabra no es un palíndromo.");
        }
    }
}