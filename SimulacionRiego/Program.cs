using Entity;
using System;
using BLL_;
using System.Collections.Generic;

namespace SimulacionRiego
{
    class Program
    {

        static Ambiente ambiente;
        static Riego riego = new Riego();
        static RiegoService riegoService = new RiegoService();
        static List<Ambiente> ListaEstadisticas = new List<Ambiente>();
        
        static void Main(string[] args)
        {

            Menu();

        }


        public static void Menu()
        {
            
            int opciones;
            do
            {
                Console.Clear();
                
                Console.WriteLine("\t\t\t\t\t\t..................");
                Console.WriteLine("\t\t\t\t\t\t-Menu-");
                Console.WriteLine("\t\t\t\t\t\t..................\n");
                Console.WriteLine("\t\t\t\t1-Sistema de riego");
                Console.WriteLine("\t\t\t\t2-Estadisticas");
                Console.WriteLine("\t\t\t\t3-Salir");
                opciones = int.Parse(Console.ReadLine());
                switch (opciones)
                {
                    case 1: SistemaDeRiego(); break;
                    case 2: Estadisticas(); break;
                    case 3: break;
                    default:
                        Console.WriteLine("Por favor ingresar una opcion correcta");
                        Console.ReadKey();break;
                }
            } while (opciones != 3);
        }


        public static void Estadisticas()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t..................");
            Console.WriteLine("\t\t\t\t\t\t-Estadisticas-");
            Console.WriteLine("\t\t\t\t\t\t..................\n");
            decimal promedioHumedad;
            decimal promedioTemperatura;
            decimal sumaHumedad = 0;
            decimal sumaTemperatura = 0;
            foreach (var ambiente in ListaEstadisticas)
            {
                sumaHumedad += ambiente.Humedad;
                sumaTemperatura += ambiente.Temperatura;
            }

            promedioHumedad = sumaHumedad / ListaEstadisticas.Count;
            promedioTemperatura = sumaTemperatura / ListaEstadisticas.Count;

            Console.WriteLine("\t\t\t\t\t..................");
            Console.WriteLine($"\t\t\t\t\tPromedio temperatura: {promedioTemperatura}");
            Console.WriteLine("\t\t\t\t\t..................\n");
            Console.WriteLine("\t\t\t\t\t..................");
            Console.WriteLine($"\t\t\t\t\tPromedio humedad: {promedioHumedad}");
            Console.WriteLine("\t\t\t\t\t..................\n");

            Console.WriteLine("\t\t\t\t\t\tPrecione una tecla para continuar");
            Console.ReadKey();
            Menu();
        }

        public static void SistemaDeRiego()
        {
            Console.Clear();
            string salir = "n";

            do
            {
                Console.WriteLine("\t\t\t\t\t\t..................");
                Console.WriteLine("\t\t\t\t\t\t-Sistema de riego-");
                Console.WriteLine("\t\t\t\t\t\t..................\n");
                ambiente = new Ambiente();

                ambiente.Humedad = Convert.ToDecimal(riegoService.GenerarRandom(0, 100));
                Console.WriteLine($"\t\t\t\t\tHumedad del suelo: {ambiente.Humedad}");
                Console.WriteLine("\t\t\t\t\t---------------------");

                ambiente.Temperatura = Convert.ToDecimal(riegoService.GenerarRandom(15, 60));
                Console.WriteLine($"\t\t\t\t\tTemperatura: {ambiente.Temperatura}\n");
                Console.WriteLine("\t\t\t\t...............................................");
                Console.WriteLine("\t\t\t\t-" + riego.Activar(ambiente)+"-");
                Console.WriteLine("\t\t\t\t...............................................");
                ListaEstadisticas.Add(ambiente);
                
                Console.WriteLine("\t\t\t\t\tPrecione S para continuar o N para salir");
                salir = Console.ReadLine();
                Console.Clear();

            } while (salir.ToLower() != "n");
            Menu();

        }



    }
}
