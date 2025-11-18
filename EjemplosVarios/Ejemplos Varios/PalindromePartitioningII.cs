using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//132.Palindrome Partitioning II
//Given a string s, partition s such that every substring of the partition is a palindrome.
//Dado un string s, devolver el mínimo número de cortes para que cada subcadena sea un palíndromo.
//Return the minimum cuts needed for a palindrome partitioning of s.
//  Example 1:
//      Input: s = "aab"
//      Output: 1
//      Explanation: The palindrome partitioning["aa", "b"] could be produced using 1 cut.
//  Example 2:
//      Input: s = "a"
//      Output: 0
//  Example 3:
//      Input: s = "ab"
//      Output: 1

namespace EjemplosVarios.Ejemplos_Varios
{
    /// <summary>
    /// Clase que resuelve el problema "Palindrome Partitioning II".
    /// Esta clase proporciona un método para calcular el número mínimo de cortes
    /// necesarios para dividir una cadena en subcadenas que sean palíndromos.
    /// Implementación en dos pasos:
    /// 1) Precomputar todas las subcadenas que son palíndromos (expansión desde centros).
    /// 2) Programación dinámica para calcular el mínimo de cortes basado en las subcadenas palíndromas.
    /// </summary>
    public class PalindromePartitioningII
    {
        /// <summary>
        /// Calcula el mínimo número de cortes para que cada subcadena resultante sea un palíndromo.
        /// </summary>
        /// <param name="s">La cadena de entrada.</param>
        /// <returns>El mínimo número de cortes necesarios.</returns>
        public int MinCut(string s)
        {
            // Paso inicial: longitud de la cadena y caso base
            int n = s.Length;
            if (n == 0) return 0; // Si la cadena está vacía, no se necesitan cortes

            // Paso 1: Precomputar todos los palíndromos
            // isPalindrome[i][j] será true si la subcadena s[i..j] es un palíndromo.
            bool[][] isPalindrome = new bool[n][];
            for (int i = 0; i < n; i++)
            {
                isPalindrome[i] = new bool[n];
            }

            // Encontrar todos los palíndromos expandiendo desde cada posible centro.
            // Esto cubre palíndromos de longitud impar (centro único) y par (centro entre caracteres).
            for (int center = 0; center < n; center++)
            {
                // Centro impar (ej: "aba") — inicia expansión con left=center, right=center
                ExpandPalindrome(s, center, center, isPalindrome);
                // Centro par (ej: "aa") — inicia expansión con left=center, right=center+1
                ExpandPalindrome(s, center, center + 1, isPalindrome);
            }

            // Paso 2: DP (programación dinámica) para mínimo cortes
            // dp[i] representa el mínimo número de particiones para la subcadena s[0..i-1].
            // Por convención dp[0] = 0 (cadena vacía).
            int[] dp = new int[n + 1];
            Array.Fill(dp, int.MaxValue);
            dp[0] = 0;

            // Razonamiento:
            // Para cada i (longitud de prefijo), probamos todos los j < i.
            // Si s[j..i-1] es palíndromo, podemos formar una partición añadiendo 1 a dp[j].
            // Elegimos el mínimo entre todas las opciones.
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    // Si la subcadena s[j..i-1] es palíndromo y dp[j] es alcanzable
                    if (isPalindrome[j][i - 1] && dp[j] != int.MaxValue)
                    {
                        // dp[i] es el mínimo número de particiones hasta i (incluye la nueva partición)
                        dp[i] = Math.Min(dp[i], dp[j] + 1);
                    }
                }
            }

            // dp[n] cuenta el número de particiones; el número de cortes es particiones - 1
            return dp[n] - 1;
        }

        /// <summary>
        /// Expande desde los índices proporcionados hacia afuera para marcar todas las
        /// subcadenas palíndromas que tengan ese centro.
        /// </summary>
        /// <param name="s">Cadena de entrada.</param>
        /// <param name="left">Índice izquierdo del centro inicial.</param>
        /// <param name="right">Índice derecho del centro inicial.</param>
        /// <param name="isPalindrome">Matriz para marcar palíndromos (se modifica in-place).</param>
        private void ExpandPalindrome(string s, int left, int right, bool[][] isPalindrome)
        {
            // Mientras los índices estén dentro de los límites y los caracteres coincidan,
            // la subcadena s[left..right] es un palíndromo.
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                // Marcar la subcadena como palíndromo
                isPalindrome[left][right] = true;
                // Expandir la ventana: mover left a la izquierda y right a la derecha
                left--;
                right++;
            }
        }
    }
}
