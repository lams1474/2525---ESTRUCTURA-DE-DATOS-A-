System.Console.WriteLine("Universidad Estatal Amazónica");
System.Console.WriteLine("==========================");


// ejemplo de uso de la clase figurasGeometricas
Cuadrado cuadrado = new Cuadrado(5);
System.Console.WriteLine("Cuadrado:");
System.Console.WriteLine("Área: " + cuadrado.CalcularArea());
System.Console.WriteLine("Perímetro: " + cuadrado.CalcularPerimetro());

System.Console.WriteLine();

Circulo circulo = new Circulo(3);
System.Console.WriteLine("Circulo:");
System.Console.WriteLine("Área: " + circulo.CalcularArea());
System.Console.WriteLine("Perímetro: " + circulo.CalcularPerimetro());

System.Console.WriteLine("\nPresiona Enter para salir...");
System.Console.ReadLine();


// Ejemplo de uso de la clase Estudiante
System.Console.WriteLine("\n\n--- Registro de Estudiantes ---");

// Crear array con 3 teléfonos (CORREGIDO: sin coma inicial)
string[] telefonosEstudiante = { "0996813865", "0960698503", "0975647382" };

// Crear instancia de Estudiante
Estudiante estudiante1 = new Estudiante(
    "E001",
    "Luis Alfonso", 
    "Maigua Sisalema",
    "Rafael Morales y Calle A, Pujili",
    telefonosEstudiante);

// Mostrar información del estudiante (CORREGIDO: minúscula en 'estudiante1')
estudiante1.MostrarInformacion();


