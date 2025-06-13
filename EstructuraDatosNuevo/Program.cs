System.Console.WriteLine("Universidad Estatal Amazónica");
System.Console.WriteLine("==========================");

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