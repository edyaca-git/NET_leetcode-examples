using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 1.a1_ Two Sum https://leetcode.com/problems/two-sum/description/
//Given an array of integers nums and an integer target, return indices
//of the two numbers such that they add up to target.
//You may assume that each input would have exactly one solution,
//and you may not use the same element twice.
//You can return the answer in any order.
//Example 1:
//  Input: nums = [2,7,11,15], target = 9
//  Output: [0,1]
//  Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
//Example 2:
//  Input: nums = [3,2,4], target = 6
//  Output: [1,2]
//  Example 3:
//  Input: nums = [3,3], target = 6
//  Output: [0,1]

namespace EjemplosVarios.Ejemplos_Varios
{
    public class a1_TwoSum
    {
        /// <summary>
        /// Encuentra los índices de dos números en un arreglo que suman un valor objetivo (target).
        /// Utiliza un mapa de hash (Dictionary) para lograr una complejidad de tiempo O(n) al
        /// buscar el complemento requerido.
        /// </summary>
        /// <param name="nums">El arreglo de números enteros.</param>
        /// <param name="target">El valor objetivo que deben sumar los dos números.</param>
        /// <returns>Un arreglo de enteros que contiene los dos índices requeridos.</returns>
        public int[] Solution(int[] nums, int target)
        {
            // Paso 1: Inicialización del Mapa de Hash (Dictionary)

            // Creamos un diccionario donde la clave es el valor del número
            // y el valor es el índice de ese número en el arreglo 'nums'.
            // Esto permite buscar el complemento en tiempo O(1) promedio.
            Dictionary<int, int> map = new Dictionary<int, int>();

            // Paso 2: Recorrido del Arreglo

            // Iteramos sobre el arreglo 'nums' una sola vez.
            for (int i = 0; i < nums.Length; i++)
            {
                // Paso 3: Cálculo del Complemento

                // Calculamos el valor que necesitamos (el 'complemento') para que,
                // sumado al número actual (nums[i]), dé como resultado el 'target'.
                int complement = target - nums[i];

                // Paso 4: Búsqueda del Complemento

                // Verificamos si este 'complemento' ya se encuentra en nuestro diccionario.
                // Si el complemento existe, significa que ya hemos encontrado el primer número
                // necesario para la suma.
                if (map.ContainsKey(complement))
                {
                    // Línea de salida opcional (para depuración, muestra la entrada)
                    Console.WriteLine($"[{string.Join(", ", nums)}], {target}");

                    // Si se encuentra, retornamos un nuevo arreglo con los dos índices:
                    // 1. map[complement]: El índice del primer número (el complemento).
                    // 2. i: El índice del número actual (nums[i]).
                    return new int[] { map[complement], i };
                }

                // Paso 5: Almacenamiento del Número Actual

                // Si el complemento no se encuentra, almacenamos el número actual (nums[i])
                // y su índice (i) en el diccionario, para que pueda ser el complemento
                // de un número futuro en el recorrido.
                map[nums[i]] = i;
            }

            // Paso 6: Retorno por Defecto

            // Dado que el problema garantiza que existe exactamente una solución,
            // esta línea solo se alcanza teóricamente si el arreglo está vacío o si la lógica fallara.
            // Retorna un arreglo vacío.
            // No se necesita throw, ya que se asume que hay solución
            return new int[] { };
        }

        public int Solution(int n)
        {

            string s = n.ToString();
            return (s[0] - '0') + (s[1] - '0');

        }
    }
}