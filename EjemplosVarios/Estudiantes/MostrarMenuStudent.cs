using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemplosVarios.Estudiantes
{
    public class MostrarMenuStudent
    {
        public void MostrarMenuStudentMethod()
        {
            Console.Clear();
            Console.WriteLine("===== Menú de Estudiantes =====");
            Console.WriteLine("1. Agregar Estudiante");
            Console.WriteLine("2. Listar Estudiantes");
            Console.WriteLine("3. Calcular Promedio de Calificaciones");
            Console.WriteLine("4. Buscar Estudiantes por Calificación");
            Console.WriteLine("5. Salir");
            Console.Write("Selecciona una opción: ");
        }
    }
}
