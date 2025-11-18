using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 438. Find All Anagrams in a String https://leetcode.com/problems/find-all-anagrams-in-a-string/description/
// Given two strings s and p, return an array of all the start indices of p's anagrams in s.
// You may return the answer in any order.
//Example 1:
//Input: s = "cbaebabacd", p = "abc"
//Output: [0, 6]
//Explanation:
//The substring with start index = 0 is "cba", which is an anagram of "abc".
//The substring with start index = 6 is "bac", which is an anagram of "abc".
//Example 2:
//Input: s = "abab", p = "ab"
//Output: [0, 1, 2]
//Explanation:
//The substring with start index = 0 is "ab", which is an anagram of "ab".
//The substring with start index = 1 is "ba", which is an anagram of "ab".
//The substring with start index = 2 is "ab", which is an anagram of "ab".

//Dadas dos cadenas s y p, encontrar todos los índices de inicio en s donde una
//subcadena de longitud p.Length es anagrama de p.

//Anagrama: misma frecuencia de letras, sin importar orden.
namespace EjemplosVarios.Ejemplos_Varios
{
    public class b2_FindAnagrams
    {
        public IList<int> findAnagrams(string s, string p)
        {
            // Resultado: lista de índices de inicio donde aparece un anagrama de p en s
            var result = new List<int>();

            // Si s es más corta que p no puede haber anagramas
            if (s.Length < p.Length) return result;

            // Usamos dos arrays de 26 posiciones para contar ocurrencias de 'a'..'z'.
            // Índice 0 -> 'a', 1 -> 'b', ..., 25 -> 'z'.
            // Esta representación permite comparar frecuencias en O(26) = O(1) tiempo.
            int[] pCount = new int[26];
            int[] sCount = new int[26];

            // Rellenamos pCount con la frecuencia de cada letra en p
            // y rellenamos sCount con la frecuencia de la primera ventana de s
            // (la subcadena s[0 .. p.Length-1]).
            // La expresión p[i] - 'a' convierte el carácter en un índice 0..25.
            // ADVERTENCIA: esto asume letras minúsculas 'a'..'z'.
            for (int i = 0; i < p.Length; i++)
            {
                pCount[p[i] - 'a']++;
                sCount[s[i] - 'a']++;
            }

            // Si la primera ventana tiene las mismas frecuencias que p, añadimos índice 0
            if (AreSame(pCount, sCount)) result.Add(0);

            // Deslizar la ventana una posición cada iteración:
            // - restamos la letra que sale (posición i - p.Length)
            // - sumamos la letra que entra (posición i)
            // Después de actualizar las frecuencias, comparamos con pCount.
            // Si son iguales, la ventana actual es un anagrama de p y guardamos el índice de inicio.
            for (int i = p.Length; i < s.Length; i++)
            {
                // Índice del carácter que sale de la ventana (izquierda)
                // s[i - p.Length] es el carácter que ya no pertenece a la ventana deslizante.
                sCount[s[i - p.Length] - 'a']--;

                // Incrementamos la letra que entra en la ventana (derecha)
                sCount[s[i] - 'a']++;

                // Comparar frecuencias: si coinciden, la ventana es un anagrama
                if (AreSame(pCount, sCount))
                {
                    // El índice de inicio de la ventana actual es (i - p.Length + 1)
                    result.Add(i - p.Length + 1);
                }
            }

            return result;
        }

        // Helper: comparar dos arrays de 26 posiciones (frecuencias de letras)
        // Devuelve true si para cada letra las frecuencias son iguales.
        private bool AreSame(int[] a, int[] b)
        {
            for (int i = 0; i < 26; i++)
            {
                if (a[i] != b[i]) return false;
            }
            return true;
        }
    }
}
