using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemplosVarios.Estudiantes
{
    public class CalcularPromedio
    {
        public void CalcularPromedioMethod(List<Estudiante> estudiantes)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("== Promedio de estudiantes ==");
            Console.WriteLine("");
            if (estudiantes.Count() == 0)
            {
                Console.WriteLine($"no hay estudiantes por evaluar");
                Console.Write($"Oprima cualquier tecla para continuar..");
                Console.ReadLine();
                return;
            }
            double sumaCalificaciones = estudiantes.Sum(a => a.calificacion);
            double promedioCalificaciones = estudiantes.Average(a => a.calificacion);
            Console.WriteLine($"El promedio es: {promedioCalificaciones}");
            Console.Write($"Oprima cualquier tecla para continuar..");
            Console.ReadLine();
        }
    }
}
