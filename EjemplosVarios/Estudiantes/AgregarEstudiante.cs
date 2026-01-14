using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemplosVarios.Estudiantes
{
    public class AgregarEstudiante
    {
        public void AgregarEstudianteMethod(List<Estudiante> estudiantes)
        {
            Console.Clear();

            bool addStudent = true;

            string name = "";
            string age = "";
            string qualification = "";

            while (addStudent)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("=== ESCRIBE LOS DATOS DEL ESTUCIANTE ===");
                Console.Write("NOMBRE: ");
                if (String.IsNullOrEmpty(name))
                    name = Console.ReadLine() ?? ""; // Si es null, usa string vacío
                else
                    Console.WriteLine($"{name}");
                Console.Write("EDAD:");
                if (String.IsNullOrEmpty(age))
                {
                    age = Console.ReadLine() ?? ""; // Si es null, usa string vacío
                    try
                    {
                        int ageValid = int.Parse(age);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"La Eddad debe contener numeros {ex.Message}");
                        Console.Write($"Oprima cualquier tecla para continuar..");
                        Console.ReadLine();
                        age = "";
                        continue;
                    }
                }
                else
                    Console.WriteLine($"{age}");

                Console.Write("CALIFICACIÓN: ");
                if (String.IsNullOrEmpty(qualification))
                    qualification = Console.ReadLine() ?? ""; // Si es null, usa string vacío
                else
                    Console.WriteLine($"{qualification}");
                try
                {
                    double qualif = double.Parse(qualification);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"La calificacion debe contener numeros {ex.Message}");
                    Console.Write($"Oprima cualquier tecla para continuar..");
                    Console.ReadLine();
                    qualification = "";
                    continue;
                }

                Estudiante estudiante = new Estudiante();
                estudiante.nombre = name;
                estudiante.edad = age;
                estudiante.calificacion = double.Parse(qualification);
                estudiantes.Add(estudiante);

                estudiantes.AddRange(new List<Estudiante>
                                 {
                                 new Estudiante { nombre = name, edad = age, calificacion = double.Parse(qualification) }
                                 });


                addStudent = false;
            }
        }
    }
}
