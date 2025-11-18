using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// a1_ ContainerAddExists
//   Given a list of queries, return the list of answers for these queries. 
//   Dada una lista de consultas, devuelve la lista de respuestas para estas consultas.
//  Example
//      For
//      queries = [
//          ["ADD", "1"],
//          ["ADD", "2"],
//          ["ADD", "5"],
//          ["ADD", "2"],
//          ["EXISTS", "2"],
//          ["EXISTS", "5"],
//          ["EXISTS", "1"],
//          ["EXISTS", "4"],
//          ["EXISTS", "3"],
//          ["EXISTS", "0"]
//      ]
//      the output should be solution(queries) =
//      ["", "", "", "", "true", "true", "true", "false", "false", "false"].
//  Explanation:
//      Numbers 2, 5, 1 exist in the container
//      Numbers 4, 3, 0 don't exist in the containerExample

// nota se le agrego el comando "REMOVE" y "GET_NEXT"
// REMOVE value: Remove value from the container. Return "true" if value existed in the container before removal,
//        otherwise return "false".
// GET_NEXT value: Return the smallest integer in the container which is strictly greater than value.
namespace EjemplosVarios.Ejemplos_Varios
{
    public class a1_ContainerAddExists
    {
        /// <summary>
        /// Procesa una lista de consultas ("ADD", "REMOVE", "EXISTS" y "GET_NEXT") sobre una colección de elementos.
        /// Añade o remueve elementos del contenedor y verifica la existencia de elementos.
        /// </summary>
        /// <param name="queries">Una matriz de matrices de cadenas, donde cada matriz interna es una consulta [comando, valor].</param>
        /// <returns>Un arreglo de cadenas con los resultados de las consultas ("true"/"false" o el valor siguiente).</returns>
        public string[] Solution(string[][] queries)
        {
            // Paso 1: Inicialización de Contenedores

            // 'container' actúa como el almacén de datos (colección). Se usa List<string> para
            // guardar los elementos añadidos, respetando el orden de inserción y permitiendo duplicados.
            List<string> container = new List<string>();

            // 'sorted' es un conjunto ordenado (SortedSet) de enteros.
            // Se utiliza para manejar la operación "GET_NEXT" de forma eficiente,
            // ya que mantiene los elementos únicos y ordenados automáticamente.
            SortedSet<int> sorted = new SortedSet<int>(); // Para GET_NEXT rápido

            // 'results' almacenará la respuesta generada para cada consulta en el orden de llegada.
            List<string> results = new List<string>();

            // Paso 2: Procesamiento de Consultas

            // Iteramos a través de cada consulta en el arreglo 'queries'.
            foreach (var query in queries)
            {
                // Extraemos el comando (ej. "ADD", "EXISTS") que está en la primera posición [0].
                string command = query[0];

                // Extraemos el valor sobre el que se opera (ej. "1", "2") que está en la segunda posición [1].
                string value = query[1];

                // Convertimos el valor (que es una cadena) a entero una sola vez, ya que varios comandos lo usan.
                int valueInt = int.Parse(value);

                // Paso 3: Manejo del Comando "ADD"

                // Si el comando es "ADD":
                if (command == "ADD")
                {
                    // Se añade el 'value' a la lista 'container' (almacén que permite duplicados).
                    // Nota: Dado que se usa List<string>, los elementos duplicados serán añadidos.
                    container.Add(value);

                    // Se añade una cadena vacía al resultado, ya que las operaciones ADD no tienen una salida específica.
                    results.Add("");

                    // Se añade el valor entero al conjunto ordenado 'sorted'.
                    // SortedSet solo almacena valores únicos; si el valor ya existe, no hace nada.
                    sorted.Add(valueInt);  // Agregar al conjunto ordenado
                }
                // Paso 4: Manejo del Comando "REMOVE"
                else if (command == "REMOVE")
                {
                    // Si el comando es "REMOVE":

                    // 4a: Verificar la existencia del elemento.
                    // Se verifica si el 'value' existe en el 'container' antes de intentar removerlo.
                    // El resultado ("true" o "false") indica si el elemento estaba presente ANTES de la remoción.
                    results.Add(container.Contains(value) ? "true" : "false");

                    // 4b: Remover el elemento de la lista principal.
                    // Se intenta remover la PRIMERA aparición del 'value' de la lista 'container'.
                    // List<T>.Remove(item) solo remueve la primera coincidencia que encuentra.
                    container.Remove(value);

                    // 4c: Reconstrucción (Lógica Ineficiente):
                    // Para mantener el SortedSet 'sorted' sincronizado con los elementos
                    // únicos restantes después de la remoción (ya que List<string> permite duplicados),
                    // el SortedSet se vacía y se reconstruye completamente a partir de 'container'.
                    // ESTA ES UNA OPERACIÓN DE ALTO COSTO (O(N*logN)) y no es la forma ideal de manejarlo,
                    // pero garantiza la precisión si los duplicados son un problema para REMOVE.
                    sorted.Clear();
                    foreach (var s in container)
                    {
                        sorted.Add(int.Parse(s));
                    }
                }
                // Paso 5: Manejo del Comando "EXISTS"

                // Si el comando es "EXISTS":
                else if (command == "EXISTS")
                {
                    // Se verifica si el 'value' existe en la lista 'container' usando el método Contains().
                    // El operador ternario (condición ? valor_si_true : valor_si_false)
                    // retorna "true" si se encuentra el valor y "false" si no.
                    results.Add(container.Contains(value) ? "true" : "false");
                }
                // Paso 6: Manejo del Comando "GET_NEXT"
                else if (command == "GET_NEXT")
                {
                    // Si el comando es "GET_NEXT":

                    // Inicializamos el resultado como una cadena vacía.
                    string next = "";

                    // Se usa LINQ en el SortedSet 'sorted' (que garantiza unicidad y orden).
                    // Buscar el menor entero estrictamente mayor (>) que valueInt.
                    var greater = sorted.Where(x => x > valueInt);

                    // Si hay algún elemento que cumpla la condición:
                    if (greater.Any())
                    {
                        // Encontramos el mínimo de esos elementos (el siguiente más pequeño).
                        // Se convierte a cadena y se asigna a la variable 'next'.
                        next = greater.Min().ToString();
                    }

                    // Se añade el valor encontrado (o cadena vacía) al resultado.
                    results.Add(next);
                }
                // Si se encontraran otros comandos, se ignorarían o se podría añadir lógica de error.
            }

            // Paso 7: Conversión del Resultado

            // La lista de resultados (List<string>) se convierte a un arreglo de cadenas (string[])
            // para cumplir con el tipo de retorno esperado.
            return results.ToArray();
        }
    }
}