using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static EjemplosVarios.Ejemplos_Varios.c3_CloneGraph;
using static System.Net.Mime.MediaTypeNames;

//133.Clone Graph
//Given a reference of a node in a connected undirected graph.
//Return a deep copy (clone) of the graph.
//Dado un nodo de un grafo conexo y sin ciclos dirigidos,
//devolver una copia profunda (clon) del grafo completo.

//Each node in the graph contains a value (int) and a list (List[Node]) of its neighbors.
//class Node
//{
//    public int val;
//    public List<Node> neighbors;
//}
//Test case format:
//  For simplicity, each node's value is the same as the node's index (1-indexed). For example,
//  the first node with val == 1, the second node with val == 2, and so on. The graph is
//  represented in the test case using an adjacency list.
//  An adjacency list is a collection of unordered lists used to represent a finite graph. Each list
//  describes the set of neighbors of a node in the graph.
//  The given node will always be the first node with val = 1. You must return the copy of the given
//  node as a reference to the cloned graph.
//Example 1:
//  Input: adjList = [[2, 4], [1, 3], [2, 4], [1, 3]]
//  Output: [[2, 4],[1, 3],[2, 4],[1, 3]]
//      Explanation: There are 4 nodes in the graph.
//      1st node (val = 1)'s neighbors are 2nd node (val = 2) and 4th node (val = 4).
//      2nd node (val = 2)'s neighbors are 1st node (val = 1) and 3rd node (val = 3).
//      3rd node (val = 3)'s neighbors are 2nd node (val = 2) and 4th node (val = 4).
//      4th node (val = 4)'s neighbors are 1st node (val = 1) and 3rd node (val = 3).
//Example 2:
//  Input: adjList = [[]]
//  Output: [[]]
//      Explanation: Note that the input contains one empty list. The graph consists of only
//      one node with val = 1 and it does not have any neighbors.
//Example 3:
//  Input: adjList = []
//  Output: []
//      Explanation: This an empty graph, it does not have any nodes.



namespace EjemplosVarios.Ejemplos_Varios
{
    /// <summary>
    /// Clase que resuelve el problema "Clone Graph".
    /// 
    /// Descripción general:
    /// - Dado un nodo de un grafo no dirigido y conexo, devuelve una copia profunda del grafo.
    /// - La copia profunda debe crear nuevos nodos y nuevas listas de vecinos, sin compartir referencias
    ///   con el grafo original.
    /// 
    /// Estrategia:
    /// 1) Recorrido DFS (o BFS) para visitar todos los nodos del grafo.
    /// 2) Mantener un diccionario que mapea cada nodo original a su clon para evitar duplicados y romper ciclos.
    /// 3) Para cada nodo, crear su clon (si no existe) y clonar recursivamente sus vecinos.
    /// </summary>
    public class c3_CloneGraph
    {

        // Definition for a Node.
        /// <summary>
        /// Representación de un nodo del grafo (estructura típica usada en LeetCode).
        /// </summary>
        public class Node
        {
            /// <summary>Valor del nodo.</summary>
            public int val;
            /// <summary>Lista de vecinos (adyacentes).</summary>
            public IList<Node> neighbors;

            /// <summary>
            /// Constructor por defecto: valor 0 y lista vacía de vecinos.
            /// </summary>
            public Node()
            {
                val = 0;
                neighbors = new List<Node>();
            }

            /// <summary>
            /// Constructor que inicializa el valor y crea lista vacía de vecinos.
            /// </summary>
            /// <param name="_val">Valor del nodo.</param>
            public Node(int _val)
            {
                val = _val;
                neighbors = new List<Node>();
            }

            /// <summary>
            /// Constructor que inicializa valor y lista de vecinos proporcionada.
            /// </summary>
            /// <param name="_val">Valor del nodo.</param>
            /// <param name="_neighbors">Lista de vecinos (puede ser null).</param>
            public Node(int _val, List<Node> _neighbors)
            {
                val = _val;
                neighbors = _neighbors;
            }
        }

        /// <summary>
        /// Punto de entrada para clonar el grafo.
        /// 
        /// Paso a paso:
        /// - Si el nodo de entrada es null, retornar null (caso trivial).
        /// - Crear un diccionario que mapea cada nodo original a su clon (visited).
        /// - Llamar a Dfs para realizar la clonación recursiva utilizando el diccionario.
        /// </summary>
        /// <param name="node">Nodo de referencia del grafo original (puede ser null).</param>
        /// <returns>Referencia al nodo correspondiente en el grafo clonado (o null).</returns>
        public Node cloneGraph(Node node)
        {
            // Caso base: si la entrada es null no hay nada que clonar
            if (node == null) return null;

            // Diccionario: original -> clon. Evita clonar repetidas veces y rompe ciclos.
            Dictionary<Node, Node> visited = new Dictionary<Node, Node>();

            // Iniciar clonación desde el nodo dado usando DFS.
            return Dfs(node, visited);
        }

        /// <summary>
        /// DFS recursivo que crea/recupera el clon del nodo actual y clona sus vecinos.
        /// 
        /// Detalle paso a paso:
        /// 1) Si el nodo ya está en el diccionario 'visited', devolver su clon (ya fue procesado).
        /// 2) Crear un nuevo nodo clon con el mismo valor que el original.
        /// 3) Registrar en 'visited' el mapeo original->clon antes de procesar vecinos
        ///    (esto evita bucles infinitos en grafos con ciclos).
        /// 4) Recorrer cada vecino del nodo original y añadir al clon el resultado recursivo de Dfs(neighbor).
        /// 5) Devolver el clon construido.
        /// </summary>
        /// <param name="node">Nodo original a clonar.</param>
        /// <param name="visited">Diccionario que mapea nodos originales a sus clones.</param>
        /// <returns>Clon del nodo original.</returns>
        private Node Dfs(Node node, Dictionary<Node, Node> visited)
        {
            // Si el nodo ya fue clonado, devolver el clon existente (evita duplicados y rompe ciclos)
            if (visited.ContainsKey(node))
            {
                return visited[node];
            }

            // Crear nuevo nodo clon con el mismo valor
            Node clone = new Node(node.val);

            // Registrar mapeo original -> clon antes de clonar los vecinos
            // Esto es crucial para manejar grafos con ciclos y referencias recíprocas.
            visited[node] = clone;

            // Clonar recursivamente cada vecino y añadirlo a la lista de vecinos del clon
            foreach (Node neighbor in node.neighbors)
            {
                // Llamada recursiva: si el vecino no fue clonado, se clonará aquí;
                // si ya fue clonado, Dfs devolverá el clon existente.
                clone.neighbors.Add(Dfs(neighbor, visited));
            }

            // Devolver el clon completo (valor y lista de vecinos clonados)
            return clone;
        }
    }
}
