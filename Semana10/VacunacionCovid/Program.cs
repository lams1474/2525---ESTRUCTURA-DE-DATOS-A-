using System;
using System.Collections.Generic;
using System.Linq;

namespace VacunacionCOVID19
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== MINISTERIO DE SALUD - CAMPAÑA DE VACUNACIÓN CONTRA EL COVID-19 ===");
            Console.WriteLine("Aplicación de operaciones de teoría de conjuntos en C#\n");

            // Crear conjunto universal de 500 ciudadanos
            var ciudadanos = new HashSet<string>();
            for (int i = 1; i <= 500; i++)
            {
                ciudadanos.Add($"C{i:000}");
            }

            var random = new Random();

            // Seleccionar 20 ciudadanos para ambas dosis (intersección controlada)
            var ciudadanosParaAmbas = SeleccionarAleatorios(ciudadanos, 20, random);
            
            // Restantes después de quitar los 20
            var restantes = new HashSet<string>(ciudadanos.Except(ciudadanosParaAmbas));
            
            // Seleccionar 55 para solo Pfizer (diferencia)
            var soloPfizer = SeleccionarAleatorios(restantes, 55, random);
            restantes.ExceptWith(soloPfizer);
            
            // Seleccionar 55 para solo AstraZeneca (diferencia)
            var soloAstraZeneca = SeleccionarAleatorios(restantes, 55, random);
            restantes.ExceptWith(soloAstraZeneca);
            
            // Construir conjuntos completos
            var pfizer = new HashSet<string>(ciudadanosParaAmbas);
            pfizer.UnionWith(soloPfizer);
            
            var astraZeneca = new HashSet<string>(ciudadanosParaAmbas);
            astraZeneca.UnionWith(soloAstraZeneca);
            
            // Aplicar operaciones de teoría de conjuntos para los listados solicitados
            var noVacunados = new HashSet<string>(ciudadanos);
            noVacunados.ExceptWith(pfizer);
            noVacunados.ExceptWith(astraZeneca);
            
            var ambasDosis = new HashSet<string>(pfizer);
            ambasDosis.IntersectWith(astraZeneca);
            
            var soloPfizerFinal = new HashSet<string>(pfizer);
            soloPfizerFinal.ExceptWith(astraZeneca);
            
            var soloAstraZenecaFinal = new HashSet<string>(astraZeneca);
            soloAstraZenecaFinal.ExceptWith(pfizer);

            // Mostrar resultados
            Console.WriteLine("=== RESULTADOS DE LA CAMPAÑA ===");
            Console.WriteLine($"Total de ciudadanos: {ciudadanos.Count}");
            Console.WriteLine($"Ciudadanos con Pfizer: {pfizer.Count}");
            Console.WriteLine($"Ciudadanos con AstraZeneca: {astraZeneca.Count}");
            Console.WriteLine($"No vacunados: {noVacunados.Count}");
            Console.WriteLine($"Con ambas dosis: {ambasDosis.Count}");
            Console.WriteLine($"Solo Pfizer: {soloPfizerFinal.Count}");
            Console.WriteLine($"Solo AstraZeneca: {soloAstraZenecaFinal.Count}\n");

            // Muestra de datos
            MostrarMuestra("No vacunados", noVacunados, 10);
            MostrarMuestra("Ambas dosis", ambasDosis, 10);
            MostrarMuestra("Solo Pfizer", soloPfizerFinal, 10);
            MostrarMuestra("Solo AstraZeneca", soloAstraZenecaFinal, 10);

            Console.WriteLine("\n✅ Simulación finalizada.");
            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey();
        }

        static HashSet<string> SeleccionarAleatorios(HashSet<string> origen, int cantidad, Random random)
        {
            var lista = origen.ToList();
            var seleccionados = new HashSet<string>();

            while (seleccionados.Count < cantidad && lista.Count > 0)
            {
                int index = random.Next(lista.Count);
                seleccionados.Add(lista[index]);
                lista.RemoveAt(index);
            }

            return seleccionados;
        }

        static void MostrarMuestra(string titulo, HashSet<string> conjunto, int cantidad)
        {
            var muestra = conjunto.Take(cantidad).ToList();
            Console.WriteLine($"{titulo}: {string.Join(", ", muestra)}{(conjunto.Count > cantidad ? "..." : "")}");
        }
    }
}