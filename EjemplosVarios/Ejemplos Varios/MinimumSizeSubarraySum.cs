using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 209. Minimum Size Subarray Sum
// Given an array of positive integers nums and a positive integer target, return the minimal length
// of a subarray whose sum is greater than or equal to target. If there is no such subarray, return 0 instead.
//Example 1:
    //Input: target = 7, nums = [2, 3, 1, 2, 4, 3]
    //Output: 2
    //Explanation: The subarray[4, 3] has the minimal length under the problem constraint.
//Example 2:
    //Input: target = 4, nums = [1, 4, 4]
    //Output: 1
//Example 3:
    //Input: target = 11, nums = [1, 1, 1, 1, 1, 1, 1, 1]
    //Output: 0
namespace EjemplosVarios.Ejemplos_Varios
{
    public class MinimumSizeSubarraySum
    {
        public int MinSubArrayLen(int target, int[] nums)
        {
            // n: longitud del arreglo de entrada
            int n = nums.Length;

            // minLength: almacena la longitud mínima encontrada.
            // Se inicializa con int.MaxValue para poder identificar si nunca se actualizó.
            int minLength = int.MaxValue;

            // left: índice izquierdo de la ventana deslizante (inicio del subarray actual)
            int left = 0;

            // currentSum: suma de los elementos en la ventana actual [left..right]
            int currentSum = 0;

            // Recorremos el arreglo expandiendo la ventana por la derecha.
            // Por cada 'right' añadimos nums[right] a currentSum.
            // Mientras currentSum >= target, intentamos encoger la ventana desde la izquierda
            // para encontrar la subcadena más corta que todavía cumpla con la condición.
            for (int right = 0; right < n; right++)
            {
                // Agregar el nuevo elemento al sumatorio de la ventana actual
                currentSum += nums[right];

                // Mientras la suma sea >= target, encoger desde la izquierda
                while (currentSum >= target)
                {
                    minLength = Math.Min(minLength, right - left + 1);
                    currentSum -= nums[left];
                    left++;
                }
            }

            // Si minLength no cambió, no existe subarray con suma >= target => devolver 0
            return minLength == int.MaxValue ? 0 : minLength;
        }
    }
}
