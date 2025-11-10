using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// 90. Subsets II
//Given an integer array nums that may contain duplicates, return all possible
//subsets (the power set).
//Dado un array nums que puede tener duplicados, devolver todos los
//subconjuntos posibles (power set) sin duplicados.
//The solution set must not contain duplicate subsets. Return the solution in any order.
//Example 1:
//      Input: nums = [1, 2, 2]
//      Output: [[],[1],[1, 2],[1, 2, 2],[2],[2, 2]]
//      [] 
//      ├── [1] 
//      │   ├── [1,2] 
//      │   │   └── [1,2,2]
//      │   └── [1,2] (segundo 2 → saltado por duplicado)
//      ├── [2] 
//      │   └── [2,2]
//      └── [2] (segundo 2 → saltado)[] 
//Example 2:
//Input: nums = [0]
//Output: [[],[0]]

namespace EjemplosVarios.Ejemplos_Varios
{
    public class Subsets
    {
        /// <summary>
        /// Devuelve todos los subconjuntos únicos del array `nums` que puede contener duplicados.
        /// Estrategia: backtracking (generación de subconjuntos) + ordenación para detectar duplicados.
        /// </summary>
        /// <remarks>
        /// Por qué ordenar: al ordenar `nums` todos los iguales quedan contiguos. Eso permite
        /// detectar y saltar elecciones duplicadas en el mismo nivel de recursión usando:
        /// `if (i > start && nums[i] == nums[i - 1]) continue;`
        /// 
        /// Complejidad:
        /// - Tiempo: O(2^n * n) en el peor caso (tamaño del resultado * coste de copiar cada subconjunto).
        /// - Espacio: O(n) recursión + espacio para almacenar el resultado.
        /// </remarks>
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();

            // Ordenar es crucial: agrupa duplicados para poder saltarlos.
            Array.Sort(nums);  // Crucial para saltar duplicados

            // Iniciar backtracking: empezamos en posición 0 con subconjunto vacío.
            Backtrack(nums, 0, new List<int>(), result);
            return result;
        }

        /// <summary>
        /// Backtracking que construye todos los subconjuntos a partir del índice `start`.
        /// </summary>
        /// <param name="nums">Array ordenado de entrada.</param>
        /// <param name="start">Índice desde el que se permiten elecciones en este nivel.</param>
        /// <param name="current">Lista que representa el subconjunto construido hasta ahora.</param>
        /// <param name="result">Acumulador de todos los subconjuntos únicos.</param>
        private void Backtrack(int[] nums, int start, List<int> current, List<IList<int>> result)
        {
            // Añadir una copia del subconjunto actual.
            // IMPORTANTE: se añade una copia (new List<int>(current)) para congelar el estado actual.
            result.Add(new List<int>(current));

            // Explorar todas las opciones a partir de `start`.
            for (int i = start; i < nums.Length; i++)
            {
                // Saltar duplicados en el mismo nivel de recursión:
                // Si nums[i] == nums[i-1] y estamos en el mismo nivel (i > start),
                // entonces elegir nums[i] produciría el mismo subconjunto que ya se
                // generó cuando se eligió nums[i-1] en este nivel, por eso lo saltamos.
                //
                // Ejemplo rápido con [1,2,2]:
                // - start=0: i=1 elige el primer 2 -> genera subconjuntos que contienen "2"
                // - i=2 (segundo 2) está al mismo nivel que i=1 y nums[2]==nums[1] -> lo saltamos
                //   para evitar duplicar subconjuntos como [2] y [1,2].
                if (i > start && nums[i] == nums[i - 1]) continue;

                // Elegir nums[i]
                current.Add(nums[i]);

                // Recursión: el siguiente nivel solo puede elegir elementos a la derecha (i + 1)
                Backtrack(nums, i + 1, current, result);

                // Deshacer la elección (backtrack) para intentar la siguiente opción en el bucle
                current.RemoveAt(current.Count - 1);  // backtrack
            }
        }
    }
}
