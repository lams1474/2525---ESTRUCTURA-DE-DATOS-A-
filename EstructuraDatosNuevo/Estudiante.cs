public class Estudiante
{
    // Campos privados
    private string id;
    private string nombres;
    private string apellidos;
    private string direccion;
    private string[] telefonos; // Array para 3 teléfonos

    // Constructor
    public Estudiante(string id, string nombres, string apellidos, string direccion, string[] telefonos)
    {
        this.id = id;
        this.nombres = nombres;
        this.apellidos = apellidos;
        this.direccion = direccion;
        
        // Validar que se proporcionen exactamente 3 teléfonos
        if (telefonos.Length == 3)
        {
            this.telefonos = telefonos;
        }
        else
        {
            throw new System.ArgumentException("Debe proporcionar exactamente 3 números de teléfono");
        }
    }

    // Métodos para acceder a los datos (getters)
    public string GetId() => id;
    public string GetNombres() => nombres;
    public string GetApellidos() => apellidos;
    public string GetDireccion() => direccion;
    public string[] GetTelefonos() => telefonos;

    // Método para mostrar la información del estudiante
    public void MostrarInformacion()
    {
        System.Console.WriteLine($"ID: {id}");
        System.Console.WriteLine($"Nombre completo: {nombres} {apellidos}");
        System.Console.WriteLine($"Dirección: {direccion}");
        System.Console.WriteLine("Teléfonos:");
        for (int i = 0; i < telefonos.Length; i++)
        {
            System.Console.WriteLine($"  Teléfono {i+1}: {telefonos[i]}");
        }
    }
}