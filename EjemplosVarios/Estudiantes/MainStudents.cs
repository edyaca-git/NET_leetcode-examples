using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjemplosVarios.Estudiantes;

namespace EjemplosVarios.Estudiantes
{
	public class MainStudents
	{
		static List<Estudiante> estudiantes = new List<Estudiante>();
		public void EjecutarEstudiantes()
		{
			bool continuar = true;
			MostrarMenuStudent Menu = new MostrarMenuStudent();
			AgregarEstudiante agregarEstudiante = new AgregarEstudiante();
			ListarEstudiantes listarEstudiantes = new ListarEstudiantes();
			CalcularPromedio calcularPromedio = new CalcularPromedio();
            BuscarEstudiantesPorCalificacion buscarEstudiantesPorCalificacion = new BuscarEstudiantesPorCalificacion();


            while (continuar)
			{
				Menu.MostrarMenuStudentMethod();
				string opcion = Console.ReadLine() ?? ""; // Si es null, usa string vacío

				switch (opcion)
				{
					case "1":
						agregarEstudiante.AgregarEstudianteMethod(estudiantes);
						break;
					case "2":
						listarEstudiantes.ListarEstudiantesMethod(estudiantes);
						break;
					case "3":
                        calcularPromedio.CalcularPromedioMethod(estudiantes);
                        break;
					case "4":
                        buscarEstudiantesPorCalificacion.BuscarEstudiantesPorCalificacionMethod(estudiantes);
                        break;
					case "5":
						continuar = false;
						Console.WriteLine("¡Hasta pronto!");
						break;
					default:
						Console.WriteLine("Opción no válida. Presiona Enter para continuar...");
						Console.ReadLine();
						break;
				}
			}
		}
	}
}

