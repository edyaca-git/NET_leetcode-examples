using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 239. Sliding Window Maximum
// You are given an array of integers nums, there is a sliding window of size k
// which is moving from the very left of the array to the very right.
// You can only see the k numbers in the window. Each time the sliding window moves right by one position.
// Se te da un arreglo de enteros `nums`, y una ventana deslizante de tamaño `k`
// que se mueve desde el extremo izquierdo del arreglo hasta el extremo derecho.
// Solo puedes ver los `k` números en la ventana. Cada vez, la ventana deslizante se mueve una posición
// a la derecha.
// Return the max sliding window.
// Devuelve el máximo de la ventana deslizante.
//Example 1:
    //Input: nums = [1, 3, -1, -3, 5, 3, 6, 7], k = 3
    //Output: [3, 3, 5, 5, 6, 7]
    //Explanation:
        //Window position                Max
        //-------------- - -----
        //[1  3 - 1] - 3  5  3  6  7       3
        // 1[3 - 1 - 3] 5  3  6  7       3
        // 1  3[-1 - 3  5] 3  6  7       5
        // 1  3 - 1[-3  5  3] 6  7       5
        // 1  3 - 1 - 3[5  3  6] 7       6
        // 1  3 - 1 - 3  5[3  6  7]      7
//Example 2:
    //Input: nums = [1], k = 1
    //Output: [1]
namespace EjemplosVarios.Ejemplos_Varios
{
    public class SlidingWindowMaximum
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0) return new int[0];

            // Lista para almacenar los máximos resultantes (uno por cada ventana completa)
            List<int> result = new List<int>();

            // Deque (doble cola) que almacenará índices del arreglo `nums`.
            // Mantenemos la propiedad: los índices en el deque están en orden decreciente
            // por el valor correspondiente en `nums` (nums[deque.First] es el máximo).
            LinkedList<int> deque = new LinkedList<int>(); // almacena índices

            // Recorremos el arreglo y tratamos cada posición `i` como el extremo derecho
            // de la ventana deslizante actual.
            for (int i = 0; i < nums.Length; i++)
            {
                // 1. Eliminar índices fuera de la ventana actual
                // Si el índice en la cabeza del deque ya no pertenece a la ventana
                // (i - k es la posición anterior a la izquierda de la ventana), lo quitamos.
                if (deque.Count > 0 && deque.First.Value <= i - k)
                {
                    deque.RemoveFirst();
                }

                // 2. Eliminar índices con valores menores que nums[i]
                // Mantener el deque ordenado por valor decreciente: si el nuevo valor es mayor
                // que algunos valores al final, esos índices nunca podrán ser máximos mientras
                // el nuevo índice esté en la ventana, por eso se eliminan.
                while (deque.Count > 0 && nums[deque.Last.Value] < nums[i])
                {
                    deque.RemoveLast();
                }

                // 3. Agregar índice actual
                // Insertamos el índice `i` en la cola por la derecha.
                deque.AddLast(i);

                // 4. Si la ventana está completa, agregar máximo
                // La ventana comienza a estar completa cuando i >= k - 1.
                // El máximo para la ventana actual está en la cabeza del deque.
                if (i >= k - 1)
                {
                    result.Add(nums[deque.First.Value]);
                }
            }

            // Convertir la lista de resultados a arreglo y devolver.
            return result.ToArray();
        }
    }
}
