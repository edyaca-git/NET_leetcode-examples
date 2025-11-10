using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// 216.Combination Sum III
//Find all valid combinations of k numbers that sum up to n
//such that the following conditions are true:
//Only numbers 1 through 9 are used.
//Each number is used at most once.
//Return a list of all possible valid combinations. The list must not contain
//the same combination twice, and the combinations may be returned in any order.
//k: número de elementos
//n: suma objetivo
//Devolver todas las combinaciones de k números distintos del 1 al 9 que sumen n.
//Example 1:

//Input: k = 3, n = 7
//Output: [[1, 2, 4]]
//Explanation:
//1 + 2 + 4 = 7
//There are no other valid combinations.
//start = 1
//→ [1] → sum=1 → sigue
//  → [1,2] → sum=3 → sigue
//    → [1,2,4] → sum=7, count=3 → AGREGAR
//    → [1,2,5] → sum=8 > 7 → podar
//  → [1,3] → sum=4 → sigue
//    → [1,3,4] → sum=8 > 7 → podar
//→ [2] → sum=2 → sigue
//  → [2,3] → sum=5 → sigue
//    → [2,3,4] → sum=9 > 7 → podarstart = 1
//→ [1] → sum=1 → sigue
//  → [1,2] → sum=3 → sigue
//    → [1,2,4] → sum=7, count=3 → AGREGAR
//    → [1,2,5] → sum=8 > 7 → podar
//  → [1,3] → sum=4 → sigue
//    → [1,3,4] → sum=8 > 7 → podar
//→ [2] → sum=2 → sigue
//  → [2,3] → sum=5 → sigue
//    → [2,3,4] → sum=9 > 7 → podar

namespace EjemplosVarios.Ejemplos_Varios
{
    public class CombinationSum
    {
        /// <summary>
        /// Devuelve todas las combinaciones de k números distintos en [1..9] cuya suma sea n.
        /// Estrategia: backtracking / búsqueda en árbol de decisiones.
        /// </summary>
        /// <remarks>
        /// Comentarios añadidos (español):
        /// - Se usan números 1..9 y cada número se usa como máximo una vez → avanzamos con i+1.
        /// - currentSum mantiene la suma acumulada para poder podar ramas (si currentSum >= n no hace falta seguir).
        /// - current.Count controla la cantidad de elementos elegidos; si llega a k y la suma es n se añade resultado.
        /// - Se añade una copia de current a result para "congelar" el estado actual antes de hacer backtrack.
        /// - La poda (current.Count >= k || currentSum >= n) evita explorar combinaciones imposibles.
        /// </remarks>
        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            IList<IList<int>> result = new List<IList<int>>();  // ← Usa IList desde el inicio
            Backtrack(k, n, 1, 0, new List<int>(), result);
            return result;
        }

        /// <summary>
        /// Backtracking recursivo.
        /// </summary>
        /// <param name="k">Número de elementos que debe tener la combinación.</param>
        /// <param name="n">Suma objetivo.</param>
        /// <param name="start">Valor mínimo disponible para elegir en esta llamada (evita reutilizar números).</param>
        /// <param name="currentSum">Suma acumulada de los elementos en 'current'.</param>
        /// <param name="current">Subconjunto actualmente construido (se modifica y deshace durante la recursión).</param>
        /// <param name="result">Acumulador de combinaciones válidas.</param>
        private void Backtrack(int k, int n, int start, int currentSum, List<int> current, IList<IList<int>> result)
        {
            // Si tenemos exactamente k elementos y la suma es la objetivo -> añadir copia a resultados
            if (current.Count == k && currentSum == n)
            {
                // Añadir copia para que futuras modificaciones de 'current' no afecten el resultado guardado.
                result.Add(new List<int>(current));  // ← new List<int>
                return;
            }

            // Poda:
            // - Si ya elegimos k elementos y la suma no es n, no tiene sentido seguir.
            // - Si la suma actual ya alcanzó/excedió n, tampoco podemos mejorar (los números son positivos).
            if (current.Count >= k || currentSum >= n) return;

            // Elegimos cada número disponible desde 'start' hasta 9 (inclusive).
            // Importante: usamos i+1 en la recursión para no reutilizar el mismo número.
            for (int i = start; i <= 9; i++)
            {
                // Añadir la elección actual
                current.Add(i);

                // Llamada recursiva: el siguiente número debe ser mayor (i+1),
                // actualizamos la suma acumulada (currentSum + i).
                Backtrack(k, n, i + 1, currentSum + i, current, result);

                // Backtrack: deshacer la elección para probar la siguiente opción en el bucle
                current.RemoveAt(current.Count - 1);
            }
        }
    }
}
