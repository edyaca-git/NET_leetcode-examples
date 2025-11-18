using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 3. Longest Substring Without Repeating Characters
//Encontrar la longitud máxima de una subcadena contigua sin caracteres repetidos.
//Given a string s, find the length of the longest substring without duplicate characters.
//Example 1:
    //Input: s = "abcabcbb"
    //Output: 3
    //Explanation: The answer is "abc", with the length of 3. Note that "bca" and "cab"
    //are also correct answers.
//Example 2:
    //Input: s = "bbbbb"
    //Output: 1
    //Explanation: The answer is "b", with the length of 1.
//Example 3:
    //Input: s = "pwwkew"
    //Output: 3
    //Explanation: The answer is "wke", with the length of 3.
    //Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
    //namespace EjemplosVarios.Ejemplos_Varios

    public class b2_LongestSubstringWithoutRepeatingCharacters
    {
        public int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            Dictionary<char, int> lastSeen = new Dictionary<char, int>();
            int left = 0;
            int maxLength = 0;

            for (int right = 0; right < s.Length; right++)
            {
                char currentChar = s[right];

                // Si el carácter ya fue visto y está dentro de la ventana actual
                if (lastSeen.ContainsKey(currentChar) && lastSeen[currentChar] >= left)
                {
                    left = lastSeen[currentChar] + 1;  // Mover left al siguiente del duplicado
                }

                // Actualizar último índice visto
                lastSeen[currentChar] = right;

                // Actualizar longitud máxima
                maxLength = Math.Max(maxLength, right - left + 1);
            }

            return maxLength;
        }
    }

