using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///220.Contains Duplicate III - https://leetcode.com/problems/contains-duplicate-iii/
//You are given an integer array nums and two integers indexDiff and valueDiff.
//Find a pair of indices (i, j) such that
//  i ≠ j
//  |i - j| ≤ indexDiff → índices cercanos
//  |nums[i] - nums[j]| ≤ valueDiff → valores casi iguales
//Return true if such pair exists or false otherwise.

//Ejemplo 1
//  nums = [1,2,3,1], indexDiff=3, valueDiff=0
//  i ≠ j      |i - j| ≤ indexDiff     valores  (|nums[i] - nums[j]| ≤ valueDiff)
//  0-1 (true)  |0-1|   1<= 3 (true)    |1-2|        1<=0 falso
//  0-2 (true)  |0-2|   2<= 3 (true)    |1-3|        2<=0 falso
//  0-3 (true)  |0-3|   3<= 3 (true)    |1-1|        0<=0 true 
//    se cumplen las 3 condiciones y el resultado es true
//Respuesta correcta: true
//Ejemplo 2
//  nums = [-3, 3], indexDiff = 2, valueDiff = 4
//  i ≠ j      |i - j| ≤ indexDiff     valores  (|nums[i] - nums[j]| ≤ valueDiff)
//  0-1 (true)  |0-1|   1<= 2 (true)    |-3-3|        6<=0 falso
//    no se cumplen las 3 condiciones y el resultado es false
//Respuesta correcta: false


namespace EjemplosVarios.Ejemplos_Varios
{
    public class a1_ContainsDuplicate
    {
        /// <summary>
        /// Determina si existe un par de índices (i, j) en el arreglo 'nums' tal que
        /// la diferencia absoluta entre los índices es menor o igual a 'indexDiff' 
        /// Y la diferencia absoluta entre los valores es menor o igual a 'valueDiff'.
        /// La solución utiliza una Ventana Deslizante (Sliding Window) y un conjunto ordenado (SortedSet)
        /// para verificar rápidamente la condición de los valores (valueDiff), logrando O(N log K)
        /// donde K = indexDiff.
        /// </summary>
        /// <param name="nums">El arreglo de números enteros.</param>
        /// <param name="indexDiff">La máxima diferencia permitida entre los índices (K).</param>
        /// <param name="valueDiff">La máxima diferencia permitida entre los valores (T).</param>
        /// <returns>True si se encuentra dicho par, False en caso contrario.</returns>
        public bool ContainsCloseNums(int[] nums, int indexDiff, int valueDiff)
        {
            // Código comentado con la solución O(N^2) (fuerza bruta) que no pasa casos grandes.
            //funciona pero no pasa cuando son arreglas muy grandes
            //int n = nums.Length;
            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = i + 1; j < n && (j - i) <= indexDiff; j++)
            //    {
            //        if (Math.Abs(nums[i] - nums[j]) <= valueDiff)
            //        {
            //            return true;
            //        }
            //    }
            //}
            //return false;

            // Paso 1: Manejo de Casos Triviales

            // Si el arreglo es nulo, tiene menos de dos elementos, o la ventana de índice no existe.
            if (nums == null || nums.Length < 2 || indexDiff <= 0) return false;

            // Paso 2: Inicialización de la Ventana Deslizante

            // Se usa SortedSet<long> (conjunto ordenado) para almacenar los valores dentro de la ventana.
            // Usamos 'long' para evitar posibles desbordamientos de enteros (overflow) al calcular 'lower' y 'upper'.
            // SortedSet permite inserciones y búsquedas de rango eficientes (O(log K)).
            SortedSet<long> window = new SortedSet<long>();

            // Paso 3: Iteración sobre el Arreglo

            // Recorrer el arreglo desde el inicio hasta el final, manteniendo la ventana deslizante.
            for (int i = 0; i < nums.Length; i++)
            {
                // Convertir el número actual a long para las operaciones de rango.
                long num = nums[i];

                // 3a: Definir el Rango de Búsqueda

                // La condición es |nums[i] - nums[j]| ≤ valueDiff.
                // Esto es equivalente a buscar un nums[j] tal que:
                // nums[i] - valueDiff ≤ nums[j] ≤ nums[i] + valueDiff
                var lower = num - valueDiff; // Límite inferior
                var upper = num + valueDiff; // Límite superior

                // 3b: Búsqueda del Duplicado Cercano

                // Utilizar GetViewBetween() para obtener un subconjunto de 'window' 
                // que caiga dentro del rango [lower, upper].
                // Esta es la parte crucial que comprueba la condición valueDiff en O(log K).
                var view = window.GetViewBetween(lower, upper);

                // Si el tamaño del subconjunto (view) es mayor que 0, significa que existe al menos
                // un elemento 'j' en la ventana (que cumple la condición indexDiff) que también
                // cumple la condición valueDiff con el elemento actual 'i'.
                if (view.Count > 0)
                {
                    return true; // Éxito: se cumplen ambas condiciones.
                }

                // 3c: Agregar el Elemento Actual a la Ventana

                // Añadir el valor actual al SortedSet para que sea considerado en futuras iteraciones.
                window.Add(num);

                // 3d: Mantener el Tamaño de la Ventana

                // La ventana debe contener como máximo indexDiff + 1 elementos (de i-indexDiff a i).
                // Si el índice actual 'i' es mayor o igual que 'indexDiff', el elemento más antiguo
                // (el que está en la posición i - indexDiff) está saliendo de la ventana.
                if (i >= indexDiff)
                {
                    // Eliminar el elemento más antiguo de la ventana (nums[i - indexDiff]).
                    // Esto asegura que la condición |i - j| ≤ indexDiff se mantenga.
                    window.Remove(nums[i - indexDiff]);
                }
            }

            // Paso 4: Resultado Final

            // Si el bucle termina sin encontrar ningún par que cumpla ambas condiciones.
            return false;
        }
    }
}