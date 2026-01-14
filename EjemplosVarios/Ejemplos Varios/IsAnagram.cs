using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemplosVarios.Ejemplos_Varios
{
    public class IsAnagram
    {
        public bool WordsAnagram(string palabra1, string palabra2) 
        {
            if (palabra1 == null || palabra2 == null) return false;
            if (palabra1.Length != palabra2.Length) return false;

            // Contar frecuencias con array
            int[] contador = new int[256]; // Para caracteres ASCII

            foreach (char c in palabra1.ToLower())
                contador[c]++;

            foreach (char c in palabra2.ToLower())
            {
                contador[c]--;
                if (contador[c] < 0) return false;
            }

            return true;

            
        }
    }
}
