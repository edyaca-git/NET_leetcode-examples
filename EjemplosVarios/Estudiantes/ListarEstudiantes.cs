using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemplosVarios.Estudiantes
{
    public class ListarEstudiantes
    {
        public void ListarEstudiantesMethod(List<Estudiante> estudiantes)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("== Lista de estudiantes ==");
            Console.WriteLine("");
            if (estudiantes.Count() == 0)
            {
                Console.WriteLine($"no hay estudiantes por evaluar");
                Console.Write($"Oprima cualquier tecla para continuar..");
                Console.ReadLine();
                return;
            }
            foreach (var alumno in estudiantes)
            {
                Console.WriteLine($"Estudiante = {alumno.nombre},  Edad = {alumno.edad},  Calificacion = {alumno.calificacion} ");
            }

            Console.Write($"Oprima cualquier tecla para continuar..");
            Console.ReadLine();
        }
    }
}
