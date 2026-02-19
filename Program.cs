using System;
using System.Collections.Generic;

namespace RegistroPersonas
{
    class Program
    {
        static void Main(string[] args)
        {
            int cantidadPersonas = 0;

            while (true)
            {
                Console.Write("Ingrese el número de personas a registrar: ");
                if (int.TryParse(Console.ReadLine() ?? "", out cantidadPersonas) && cantidadPersonas >= 1)
                    break;

                Console.WriteLine("Error: Cantidad inválida, por favor intente nuevamente.");
            }

            List<(string Nombre, int Edad)> listaPersonas = new List<(string Nombre, int Edad)>();

            for (int i = 0; i < cantidadPersonas; i++)
            {
                Console.WriteLine($"\nPersona {i + 1}");

                string nombre;
                while (true)
                {
                    Console.Write("Nombre: ");
                    nombre = Console.ReadLine() ?? "";
                    if (!string.IsNullOrWhiteSpace(nombre))
                        break;

                    Console.WriteLine("Error: El nombre no puede estar vacío, por favor intente nuevamente.");
                }

                int edad;
                while (true)
                {
                    Console.Write("Edad: ");
                    if (int.TryParse(Console.ReadLine() ?? "", out edad) && edad >= 0)
                        break;

                    Console.WriteLine("Error: Edad inválida, por favor intente nuevamente.");
                }

                listaPersonas.Add((nombre, edad));
            }

            if (cantidadPersonas == 1)
            {
                var persona = listaPersonas[0];
                Console.WriteLine("\nResultado:");
                string condicion = persona.Edad >= 18 ? "mayor" : "menor";
                Console.WriteLine($"{persona.Nombre} tiene {persona.Edad} años y es {condicion} de edad.");
            }
            else
            {
                Console.WriteLine("\nLista general:");
                foreach (var persona in listaPersonas)
                    Console.WriteLine($"{persona.Nombre} - {persona.Edad} años");

                List<(string Nombre, int Edad)> mayoresDeEdad = new List<(string Nombre, int Edad)>();
                List<(string Nombre, int Edad)> menoresDeEdad = new List<(string Nombre, int Edad)>();

                foreach (var persona in listaPersonas)
                {
                    if (persona.Edad >= 18)
                        mayoresDeEdad.Add(persona);
                    else
                        menoresDeEdad.Add(persona);
                }

                if (mayoresDeEdad.Count > 0)
                {
                    Console.WriteLine("\nMayores de edad:");
                    foreach (var persona in mayoresDeEdad)
                        Console.WriteLine($"{persona.Nombre} - {persona.Edad} años");
                }

                if (menoresDeEdad.Count > 0)
                {
                    Console.WriteLine("\nMenores de edad:");
                    foreach (var persona in menoresDeEdad)
                        Console.WriteLine($"{persona.Nombre} - {persona.Edad} años");
                }
            }

            Console.ReadKey();
        }
    }
}