using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///220.Contains Duplicate III - Ejemplo de solución para el problema Contains Duplicate III en C#
//You are given an integer array nums and two integers indexDiff and valueDiff.
//Find a pair of indices (i, j) such that

// "Contains Nearby Almost Duplicate"
//(Encontrar casi duplicados cercanos)

//Enunciado (Resumido)
//Dado:

//Un array nums
//Dos enteros: indexDiff y valueDiff

//Devolver true si existe un par (i, j) tal que:

//i ≠ j
//|i - j| ≤ indexDiff → índices cercanos
//|nums[i] - nums[j]| ≤ valueDiff → valores casi iguales

//Sino, devolver false.
//Ejemplo Clave 
//nums = [-3, 3]
//indexDiff = 2
//valueDiff = 4

//| 0 - 1 | = 1 ≤ 2 → índices cercanos
//|-3 - 3| = 6 > 4 → NO cumple la diferencia de valores

//Respuesta correcta: false


namespace EjemplosVarios.Ejemplos_Varios
{
    public class ContainsDuplicate
    {
        public bool ContainsCloseNums(int[] nums, int indexDiff, int valueDiff)
        {
            //funciona pero no pasa cuando son arreglas muy grandes
            //int n = nums.Length;
            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = i + 1; j < n && (j - i) <= indexDiff; j++)
            //    {
            //        if (Math.Abs(nums[i] - nums[j]) <= valueDiff)
            //        {
            //            return true;
            //        }
            //    }
            //}
            //return false;
            if (nums == null || nums.Length < 2 || indexDiff <= 0) return false;

            SortedSet<long> window = new SortedSet<long>();

            for (int i = 0; i < nums.Length; i++)
            {
                long num = nums[i];

                // Buscar (Rango permitido) si hay algún valor en [num - valueDiff, num + valueDiff]
                var lower = num - valueDiff;
                var upper = num + valueDiff;

                //// ¿Hay algún número en la ventana dentro de este rango?
                var view = window.GetViewBetween(lower, upper);
                if (view.Count > 0)
                {
                    return true;
                }

                window.Add(num);

                // Mantener ventana deslizante
                //// Si hay más de indexDiff + 1 elementos, eliminar el más antiguo
                if (window.Count > indexDiff)
                {
                    window.Remove(nums[i - indexDiff]);
                }
            }

            return false;
        }
    }
}
