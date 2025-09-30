//Nueva consola Estructura de datos nuevo 2025

    Console.WriteLine("===== Universidad Estatal Amazónica =====");
    Console.WriteLine("===== ESTRUCTURA DE DATOS (A) =====");
    Console.WriteLine("===== Tercer Semestre =====");
    Console.WriteLine("===== Luis Alfonso Maigua Sisalema =====\n");  // Salto de línea para mejor formato

bool continuar = true;
while (continuar)
{
    //Console.Clear(); // Limpia la pantalla en cada iteración (mejora visual)
    Console.WriteLine("=== MENÚ PRINCIPAL ===");
    Console.WriteLine("1. VacunasCovid");
    Console.WriteLine("2. TraductorEspanolIngles");
    Console.WriteLine("3. TorneoFutbol");
    Console.WriteLine("4. CatalogoRevistass");
    Console.WriteLine("5. CentralidadGrafos");
    Console.WriteLine("6. Salir");
    Console.Write("\nSelecciona una opción: "); 
    string opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            VacunasCovid.run();
            break;
        case "2":
            TraductorEspanolIngles.run(); 
            break;
        case "3":
            TorneoFutbol.run(); 
            break;
        case "4":
            CatalogoRevistass.run();
            break;
        case "5":
            CentralidadGrafos.run();
            break;
        case "6":
            Console.WriteLine("Saliendo... ¡Hasta pronto!");
            continuar = false; // Termina el bucle
            break;
        default:
            Console.WriteLine("Opción inválida. selecciona una opción del 1 al 6.");
            break;
    }

        // Pausa antes de volver al menú (solo si no se está saliendo)
    if (continuar)
    {
        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
        //Console.ReadKey(); // Espera una tecla (mejora usabilidad)
    }
}


