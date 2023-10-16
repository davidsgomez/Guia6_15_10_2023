using Guia6_EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

class Program
{
    static void Main()
    {

        while (true)
        {
            using (var context = new Context())
            {
                Console.WriteLine("\nLista de Estudiantes:");

                using (var contextdb = new Context())
                {
                    contextdb.Database.EnsureCreated();

                    var estudiante = new EstudianteUNAB() { Nombre = "Pepito", Apellido = "Pérez" };
                    contextdb.Add(estudiante);
                    contextdb.SaveChanges();

                    foreach (var s in context.Estudiante.ToList())
                    {
                        Console.WriteLine($"ID: {s.Id}, Nombre: {s.Nombre} {s.Apellido}, Edad: {s.Edad}, Sexo: {s.Sexo}");
                    }
                }

                Console.WriteLine("\nIngrese los datos de los nuevos estudiantes:");

                Console.Write("Nombre: ");
                var nombre = Console.ReadLine();

                Console.Write("Apellido: ");
                var apellido = Console.ReadLine();

                Console.Write("Sexo: ");
                var sexo = Console.ReadLine();

                Console.Write("Edad: ");
                if (int.TryParse(Console.ReadLine(), out int edad))
                {
                    var nuevoEstudiante = new EstudianteUNAB
                    {
                        Nombre = nombre,
                        Apellido = apellido,
                        Sexo = sexo,
                        Edad = edad
                    };

                    try
                    {
                        context.Estudiante.Add(nuevoEstudiante);
                        context.SaveChanges();
                        Console.WriteLine("Estudiante agregado correctamente.");
                    }
                    catch (DbUpdateException ex)
                    {
                        Console.WriteLine("Error al agregar estudiante. Asegúrate de que los datos sean válidos.");
                    }
                }
                else
                {
                    Console.WriteLine("Edad no válida. Intente nuevamente.");
                }

                Console.Write("¿Si desea agregar más estudiantes, presione (S) y si ya no desea ingresar, presione (N): ");
                var respuesta = Console.ReadLine();
                if (respuesta?.Trim().ToLower() != "s")
                {
                    break;
                }
            }
        }
    }
}
