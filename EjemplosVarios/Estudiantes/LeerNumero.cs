using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemplosVarios.Estudiantes
{
    public class LeerNumero
    {
        public static T Validar<T>(string mensaje, Func<string, T> parser) where T : IComparable
        {
            while (true)
            {
                Console.Write(mensaje);
                string input = Console.ReadLine();

                try
                {
                    T valor = parser(input);
                    return valor;
                }
                catch (Exception)
                {
                    Console.WriteLine("Error: Valor numérico inválido. Intenta nuevamente.");
                }
            }

        }
    }
}
