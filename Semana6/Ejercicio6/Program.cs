using System;

public class Estudiante
{
    public string Cedula;
    public string Nombre;
    public string Apellido;
    public string Correo;
    public double Nota;
    public Estudiante? Siguiente;

    public Estudiante(string cedula, string nombre, string apellido, string correo, double nota)
    {
        Cedula = cedula;
        Nombre = nombre;
        Apellido = apellido;
        Correo = correo;
        Nota = nota;
        Siguiente = null;
    }
}

public class ListaEstudiantes
{
    private Estudiante? head;

    public void AgregarEstudiante(Estudiante estudiante)
    {
        if (estudiante.Nota >= 7)
        {
            estudiante.Siguiente = head;
            head = estudiante;
        }
        else
        {
            if (head == null)
            {
                head = estudiante;
            }
            else
            {
                Estudiante actual = head;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = estudiante;
            }
        }
    }

    public Estudiante? BuscarPorCedula(string cedula)
    {
        Estudiante? actual = head;
        while (actual != null)
        {
            if (actual.Cedula == cedula)
                return actual;
            actual = actual.Siguiente;
        }
        return null;
    }

    public void EliminarPorCedula(string cedula)
    {
        if (head == null) return;

        if (head.Cedula == cedula)
        {
            head = head.Siguiente;
            return;
        }

        Estudiante? actual = head;
        while (actual.Siguiente != null && actual.Siguiente.Cedula != cedula)
        {
            actual = actual.Siguiente;
        }

        if (actual.Siguiente != null)
        {
            actual.Siguiente = actual.Siguiente.Siguiente;
        }
    }

    public int TotalAprobados()
    {
        int count = 0;
        Estudiante? actual = head;
        while (actual != null)
        {
            if (actual.Nota >= 7)
                count++;
            actual = actual.Siguiente;
        }
        return count;
    }

    public int TotalReprobados()
    {
        int count = 0;
        Estudiante? actual = head;
        while (actual != null)
        {
            if (actual.Nota < 7)
                count++;
            actual = actual.Siguiente;
        }
        return count;
    }

    public void MostrarEstudiantes()
    {
        Estudiante? actual = head;
        while (actual != null)
        {
            Console.WriteLine($"{actual.Cedula} - {actual.Nombre} {actual.Apellido} - {actual.Correo} - Nota: {actual.Nota}");
            actual = actual.Siguiente;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ListaEstudiantes registro = new ListaEstudiantes();

        registro.AgregarEstudiante(new Estudiante("0101", "Luis", "Maigua", "luis@correo.com", 8.5));
        registro.AgregarEstudiante(new Estudiante("0102", "Ana", "Pérez", "ana@correo.com", 6.4));
        registro.AgregarEstudiante(new Estudiante("0103", "Carlos", "Vera", "carlos@correo.com", 9.2));

        Console.WriteLine("Estudiantes registrados:");
        registro.MostrarEstudiantes();

        Console.WriteLine($"\nTotal aprobados: {registro.TotalAprobados()}");
        Console.WriteLine($"Total reprobados: {registro.TotalReprobados()}");

        Console.WriteLine("\nBuscar por cédula (0102):");
        var estudiante = registro.BuscarPorCedula("0102");
        if (estudiante != null)
            Console.WriteLine($"{estudiante.Nombre} {estudiante.Apellido} - Nota: {estudiante.Nota}");
        else
            Console.WriteLine("Estudiante no encontrado.");

        Console.WriteLine("\nEliminando estudiante con cédula 0102...");
        registro.EliminarPorCedula("0102");

        Console.WriteLine("\nEstudiantes actualizados:");
        registro.MostrarEstudiantes();
    }
}
