using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// 49. Group Anagrams - Ejemplo de solución para el problema Group Anagrams en C#
/// Dos palabras son anagramas si contienen exactamente las mismas 
/// letras con la misma frecuencia, sin importar el orden

namespace EjemplosVarios.Ejemplos_Varios
{
    public class GroupAnagrams
    {
        public IList<IList<string>> Solution(string[] strs)
        {
            // Diccionario: clave = string ordenado, valor = lista de anagramas
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();

            foreach (string s in strs)
            {
                // Paso 1: Convertir string a array de chars
                char[] chars = s.ToCharArray();

                // Paso 2: Ordenar el array
                Array.Sort(chars);

                // Paso 3: Convertir de vuelta a string → esta es la clave
                string key = new string(chars);

                // Paso 4: Agregar al diccionario
                if (!map.ContainsKey(key))
                {
                    map[key] = new List<string>();
                }
                map[key].Add(s);
            }

            // Convertir los valores del diccionario a IList<IList<string>>
            IList<IList<string>> result = new List<IList<string>>();
            foreach (var list in map.Values)
            {
                result.Add(list);
            }

            return result;
        }
    }
}
