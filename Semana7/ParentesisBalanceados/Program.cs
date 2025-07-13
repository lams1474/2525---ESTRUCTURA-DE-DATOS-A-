using System;
using System.Collections.Generic;

/// <summary>
/// Clase que contiene el método para verificar si una expresión tiene símbolos correctamente balanceados.
/// </summary>
class BalanceoParentesis
{
    public static bool EstaBalanceada(string expresion)
    {
        Stack<char> pila = new Stack<char>();
        foreach (char c in expresion)
        {
            if (c == '(' || c == '[' || c == '{')
                pila.Push(c);
            else if (c == ')' || c == ']' || c == '}')
            {
                if (pila.Count == 0) return false;
                char tope = pila.Pop();
                if (!EsPar(tope, c)) return false;
            }
        }
        return pila.Count == 0;
    }

    private static bool EsPar(char apertura, char cierre)
    {
        return (apertura == '(' && cierre == ')') ||
               (apertura == '[' && cierre == ']') ||
               (apertura == '{' && cierre == '}');
    }

    static void Main()
    {
        Console.Write("Ingrese una expresión matemática: ");
        string entrada = Console.ReadLine() ?? "";

        if (EstaBalanceada(entrada))
            Console.WriteLine("Fórmula balanceada.");
        else
            Console.WriteLine("Fórmula NO balanceada.");
    }
}
