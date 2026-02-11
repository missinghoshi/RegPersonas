using System;
using System.Collections.Generic;

namespace RegistroPersonas
{
    class Program
    {
        static void Main(string[] args)
        {
            int numpersonas = 0;

            while (true)
            {
                Console.Write("Ingrese el numero de personas a registrar: ");
                if (int.TryParse(Console.ReadLine(), out numpersonas) && numpersonas >= 1)
                    break;

                Console.WriteLine("Error: Cantidad inválida porfavor intente nuevamente.");
            }

            List<(string Nombre, int Edad)> personas = new List<(string, int)>();

            for (int i = 0; i < numpersonas; i++)
            {
                Console.WriteLine($"\nPersona {i + 1}");

                Console.Write("Nombre: ");
                string nombre = Console.ReadLine();

                int edad;
                while (true)
                {
                    Console.Write("Edad: ");
                    if (int.TryParse(Console.ReadLine(), out edad) && edad >= 0)
                        break;

                    Console.WriteLine("Error: Edad inválida porfavor intente nuevamente.");
                }

                personas.Add((nombre, edad));
            }

            if (numpersonas == 1)
            {
                var persona = personas[0];
                Console.WriteLine("\nResultado:");
                if (persona.Edad >= 18)
                    Console.WriteLine($"{persona.Nombre} tiene {persona.Edad} años y es mayor de edad.");
                else
                    Console.WriteLine($"{persona.Nombre} tiene {persona.Edad} años y es menor de edad.");
            }
            else
            {
                Console.WriteLine("\nLista general:");
                foreach (var persona in personas)
                    Console.WriteLine($"{persona.Nombre} - {persona.Edad} años");

                List<(string, int)> mayores = new List<(string, int)>();
                List<(string, int)> menores = new List<(string, int)>();

                foreach (var persona in personas)
                {
                    if (persona.Edad >= 18)
                        mayores.Add(persona);
                    else
                        menores.Add(persona);
                }

                if (mayores.Count > 0)
                {
                    Console.WriteLine("\nMayores de edad:");
                    foreach (var persona in mayores)
                        Console.WriteLine($"{persona.Item1} - {persona.Item2} años");
                }

                if (menores.Count > 0)
                {
                    Console.WriteLine("\nMenores de edad:");
                    foreach (var persona in menores)
                        Console.WriteLine($"{persona.Item1} - {persona.Item2} años");
                }
            }
            Console.ReadKey();
        }
    }
}