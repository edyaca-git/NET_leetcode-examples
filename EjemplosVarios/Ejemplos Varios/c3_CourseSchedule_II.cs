using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//210.Course Schedule II
//There are a total of numCourses courses you have to take, labeled from 0
//to numCourses - 1. You are given an array prerequisites
//where prerequisites[i] = [ai, bi] indicates that you must take course
//bi first if you want to take course ai.

//For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.
//  Return the ordering of courses you should take to finish all courses.
//  If there are many valid answers, return any of them.
//  If it is impossible to finish all courses, return an empty array.

//Example 1:
//  Input: numCourses = 2, prerequisites = [[1,0]]
//  Output: [0,1]
//  Explanation: There are a total of 2 courses to take. To take course 1 you should have finished course 0. So the correct course order is [0,1].
//Example 2:
//  Input: numCourses = 4, prerequisites = [[1,0],[2,0],[3,1],[3,2]]
//  Output: [0,2,1,3]
//      Par         Significado
//     [1,0]        Para tomar curso 1, debes haber tomado curso 0 antes
//     [2,0]        Para tomar curso 2, debes haber tomado curso 0 antes
//     [3,1]        Para tomar curso 3, debes haber tomado curso 1 antes
//     [3,2]        Para tomar curso 3, debes haber tomado curso 2 antes
//  Grafo de dependencias:                  Explicación:
//           0                          0 → 1: curso 0 antes de 1
//          / \                         0 → 2: curso 0 antes de 2
//         1   2                        1 → 3: curso 1 antes de 3
//          \ /                         2 → 3: curso 2 antes de 3
//           3
//  Explanation: There are a total of 4 courses to take. To take course 3 you should have
//          finished both courses 1 and 2. Both courses 1 and 2 should be taken after you finished
//          course 0.
//  So one correct course order is [0,1,2,3]. Another correct ordering is [0,2,1,3].
//Example 3:
//  Input: numCourses = 1, prerequisites = []
//  Output: [0]There are a total of numCourses courses you have to take, labeled from 0 to
//          numCourses - 1. You are given an array prerequisites where prerequisites[i] = [ai, bi]
//          indicates that you must take course bi first if you want to take course ai.
//  For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.
//  Return the ordering of courses you should take to finish all courses. If there are many valid
//  answers, return any of them. If it is impossible to finish all courses, return an empty array.

namespace EjemplosVarios.Ejemplos_Varios
{
    public class c3_CourseSchedule_II
    {
        /// <summary>
        /// Calcula el orden topológico de los cursos que se deben tomar basándose en las precondiciones.
        /// Si hay un ciclo (dependencia mutua), es imposible y retorna un arreglo vacío.
        /// Este método implementa la Búsqueda en Profundidad (DFS) para la ordenación topológica.
        /// </summary>
        /// <param name="numCourses">El número total de cursos (de 0 a numCourses - 1).</param>
        /// <param name="prerequisites">Una lista de pares [curso, prerrequisito].</param>
        /// <returns>El orden de los cursos o un arreglo vacío si es imposible completar el plan.</returns>
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            // Paso 1. Construir grafo: curso → lista de cursos que dependen de él
            // Representa el grafo de dependencias usando una lista de adyacencia.
            List<int>[] graph = new List<int>[numCourses];

            // Inicializar la lista de adyacencia para cada curso.
            for (int i = 0; i < numCourses; i++)
            {
                graph[i] = new List<int>();
            }

            // Llenar el grafo con las dependencias: si [a, b] existe, b DEBE ir antes de a.
            // Esto significa que, después de b, podemos tomar a. Por lo tanto, el borde es b -> a.
            foreach (int[] pre in prerequisites)
            {
                int course = pre[0]; // Curso 'a' que requiere un prerrequisito.
                int prerequisite = pre[1]; // Curso 'b' que es el prerrequisito.
                graph[prerequisite].Add(course);  // Añadir la conexión: b (prerrequisito) apunta a a (curso dependiente).
            }

            // Paso 2. Inicializar estados y resultado

            // Arreglo para rastrear el estado de visita de cada nodo durante el DFS.
            // 0 = No visitado (unseen)
            // 1 = Visitando (visiting / recursion stack) - Usado para detectar ciclos.
            // 2 = Visitado (visited / processed) - Ya se incluyó en el orden.
            int[] visited = new int[numCourses];

            // Lista para almacenar el resultado del orden topológico (se llena en el orden inverso).
            List<int> result = new List<int>();

            // Paso 3. DFS desde cada curso

            // Recorrer todos los cursos para asegurar que cubrimos los grafos desconectados.
            for (int i = 0; i < numCourses; i++)
            {
                // Solo ejecutar el DFS si el curso no ha sido visitado (estado 0).
                if (visited[i] == 0)
                {
                    // Si el DFS retorna 'false', significa que se detectó un ciclo.
                    if (!Dfs(i, graph, visited, result))
                    {
                        return new int[0];  // Ciclo detectado, es imposible terminar todos los cursos.
                    }
                }
            }

            // Paso 4. Invertir resultado (orden topológico)

            // El DFS agrega los cursos a 'result' en el orden en que son procesados (post-orden),
            // lo cual es el orden topológico INVERSO.
            int[] order = new int[result.Count];
            for (int i = 0; i < result.Count; i++)
            {
                // Invertir la lista 'result' para obtener el orden topológico correcto.
                order[i] = result[result.Count - 1 - i];
            }

            // Retornar el orden final de los cursos.
            return order;
        }

        /// <summary>
        /// Implementa la Búsqueda en Profundidad (DFS) para encontrar el orden topológico
        /// y detectar ciclos.
        /// </summary>
        /// <param name="course">El curso actual a visitar.</param>
        /// <param name="graph">El grafo de dependencias.</param>
        /// <param name="visited">Arreglo de estados de visita.</param>
        /// <param name="result">Lista donde se almacena el orden.</param>
        /// <returns>True si no se detectó un ciclo, False si sí se detectó.</returns>
        private bool Dfs(int course, List<int>[] graph, int[] visited, List<int> result)
        {
            // Paso 5a: Detección de Ciclos

            // Si el curso actual está marcado como '1' (Visitando), significa que hemos vuelto
            // a un nodo que ya está en la pila de recursión actual. ¡Hay un ciclo!
            if (visited[course] == 1)
                return false;  // Ciclo detectado (e.g., A -> B -> A).

            // Paso 5b: Nodo Ya Procesado

            // Si el curso está marcado como '2' (Visitado/Procesado), ya se ha determinado
            // que es válido y se ha añadido al resultado. No es necesario visitarlo de nuevo.
            if (visited[course] == 2)
                return true;   // Ya procesado, no hacer nada.

            // Paso 6: Marcado Inicial

            // Marcar el curso actual como '1' (Visitando), entrando en la pila de recursión.
            visited[course] = 1;  // Marcando como visitando

            // Paso 7: Recorrer Nodos Adyacentes

            // Iterar sobre todos los cursos 'next' que dependen del curso actual.
            foreach (int next in graph[course])
            {
                // Llamada recursiva al DFS para el curso dependiente.
                if (!Dfs(next, graph, visited, result))
                {
                    // Si la llamada recursiva detecta un ciclo, propagar el 'false'.
                    return false;
                }
            }

            // Paso 8: Procesamiento Final y Adición al Resultado

            // El curso y todos sus dependientes ya han sido procesados.
            // Marcar el curso como '2' (Visitado/Procesado).
            visited[course] = 2;  // Marcado como visitado

            // Añadir el curso al resultado. En orden topológico con DFS, el nodo se añade
            // cuando sale completamente de la recursión, lo cual resulta en el orden INVERSO.
            result.Add(course);   // ¡Agregar al final!

            // El subgrafo visitado es válido.
            return true;
        }
    }
}
