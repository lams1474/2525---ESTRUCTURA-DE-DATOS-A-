using System;

public class Nodo
{
    public int Dato;
    public Nodo? Siguiente;

    public Nodo(int dato)
    {
        Dato = dato;
        Siguiente = null;
    }
}

public class ListaSimple
{
    private Nodo? head;

    public void InsertarInicio(int dato)
    {
        Nodo nuevo = new Nodo(dato);
        nuevo.Siguiente = head;
        head = nuevo;
    }

    public void Mostrar()
    {
        Nodo? actual = head;
        while (actual != null)
        {
            Console.Write("[" + actual.Dato + "] -> ");
            actual = actual.Siguiente;
        }
        Console.WriteLine("null");
    }

    public void Invertir()
    {
        Nodo? anterior = null;
        Nodo? actual = head;
        Nodo? siguiente;

        while (actual != null)
        {
            siguiente = actual.Siguiente;
            actual.Siguiente = anterior;
            anterior = actual;
            actual = siguiente;
        }

        head = anterior;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ListaSimple lista = new ListaSimple();
        lista.InsertarInicio(10);
        lista.InsertarInicio(20);
        lista.InsertarInicio(30);
        lista.InsertarInicio(40);

        Console.WriteLine("Lista original:");
        lista.Mostrar();

        lista.Invertir();

        Console.WriteLine("Lista invertida:");
        lista.Mostrar();
    }
}
