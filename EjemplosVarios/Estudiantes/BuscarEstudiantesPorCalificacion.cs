using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemplosVarios.Estudiantes
{
    public class BuscarEstudiantesPorCalificacion
    {
        public void BuscarEstudiantesPorCalificacionMethod(List<Estudiante> estudiantes)
        {
            if (estudiantes.Count() == 0)
            {
                Console.WriteLine("No hay Estudiante que mostrar");
                Console.WriteLine("Pulse cualquier tecla para continuar");
                Console.ReadLine();
                return;
            }
            bool continuar = true;
            double calVar = 0.0;

            while (continuar)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("== Muestre estudiantes con calificación mayor a ==");
                Console.Write("Escriba Calificacion de Estudiantes a mostrar:: ");
                var cal = Console.ReadLine();
                try
                {
                    calVar = double.TryParse(cal, out double temp)
                            ? temp
                            : throw new FormatException("El valor no es un número válido: " + cal);

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Debe escribir una calificacion valida  entre 1 y 10 {ex.Message}");
                    Console.WriteLine("Presione una tecla para continuar");
                    Console.ReadLine();
                    continue;
                }

                if ((calVar < 0) || (calVar > 10))
                {
                    Console.WriteLine($"Debe escribir una calificacion valida entre 1 y 10");
                    Console.WriteLine("Presione una tecla para continuar");
                    Console.ReadLine();
                    continue;
                }

                // metodo#1
                var encontrarEstudiante = estudiantes.FindAll(e => e.calificacion >= calVar);
                // estod 2 var hacen lo mismo
                var findstudens = estudiantes
                    .Where(e => e.calificacion >= calVar)
                    .OrderBy(e => e.calificacion)
                    .ToList();

                if ( !encontrarEstudiante.Any() )
                {
                    Console.WriteLine($"No hya estuciantes con Calificaciones iguales o mayores a {calVar}");
                    Console.WriteLine("Oprime cualquier tecla para continuar");
                    Console.ReadLine();
                    continue;
                }

                foreach (var estudiante in encontrarEstudiante)
                {
                    Console.WriteLine($"Nombre : {estudiante.nombre}, Edad: {estudiante.edad}, Calificacion: {estudiante.calificacion}");
                }


                // metodo#2
                if (estudiantes.Exists(e => e.calificacion >= calVar) == false)
                {
                    Console.WriteLine($"No hya estuciantes con Calificaciones iguales o mayores a {calVar}");
                    Console.WriteLine("Oprime cualquier tecla para continuar");
                    Console.ReadLine();
                    continue;
                }

                foreach (var estudiante in estudiantes.FindAll(e => e.calificacion >= calVar))
                {
                    Console.WriteLine($"Nombre : {estudiante.nombre}, Edad: {estudiante.edad}, Calificacion: {estudiante.calificacion}");
                }


                Console.WriteLine("Oprime cualquier tecla para continuar");
                Console.ReadLine();
                continuar = false;

            }
        }
    }
}
