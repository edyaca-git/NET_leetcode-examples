// See https://aka.ms/new-console-template for more information
//  Console.WriteLine("Hello, World!");


using EjemplosVarios.Ejemplos_Varios;
using EjemplosVarios.Estudiantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using static EjemplosVarios.Ejemplos_Varios.c3_CloneGraph;
using static System.Net.Mime.MediaTypeNames;


// 1.a1_ Two Sum 
//a1_TwoSum twoSum = new a1_TwoSum();
//int[] result = twoSum.Solution(new int[] { 2, 15, 11, 7 }, 26);
//if (result.Length != 0)
//    Console.WriteLine($"[{result[0]},{result[1]}]");
//else
//    Console.WriteLine("No se encontraron índices que sumen el objetivo.");

//Console.WriteLine("Input: 29 -> Output: " + twoSum.Solution(29)); // 11


// a1_ ContainerAddExists
//a1_ContainerAddExists sol = new a1_ContainerAddExists();
//string[][] queries = new string[][]
//{
//    new string[] { "ADD", "1" },
//    new string[] { "ADD", "2" },
//    new string[] { "ADD", "2" },
//    new string[] { "ADD", "3" },
//    new string[] { "EXISTS", "1" },
//    new string[] { "EXISTS", "2" },
//    new string[] { "EXISTS", "3" },
//    new string[] { "REMOVE", "2" },
//    new string[] { "REMOVE", "1" },
//    new string[] { "EXISTS", "2" },
//    new string[] { "EXISTS", "1" }
//};
//string[][] queries = {
//    new[] { "ADD", "1" },
//    new[] { "ADD", "2" },
//    new[] { "ADD", "2" },
//    new[] { "ADD", "4" },
//    new[] { "GET_NEXT", "1" },
//    new[] { "GET_NEXT", "2" },
//    new[] { "GET_NEXT", "3" },
//    new[] { "GET_NEXT", "4" },
//    new[] { "REMOVE", "2" },
//    new[] { "GET_NEXT", "1" },
//    new[] { "GET_NEXT", "2" },
//    new[] { "GET_NEXT", "3" },
//    new[] { "GET_NEXT", "4" }
//};
//string[][] queries = {
//    new[] {"ADD","0"}, new[] {"ADD","1"}, new[] {"ADD","1"}, new[] {"ADD","11"},
//    new[] {"ADD","22"}, new[] {"ADD","3"}, new[] {"ADD","5"},
//    new[] {"GET_NEXT","0"},   // → "1"
//    new[] {"GET_NEXT","1"},   // → "3"
//    new[] {"REMOVE","1"},     // → "true"
//    new[] {"GET_NEXT","1"},   // → "3"
//    new[] {"ADD","0"}, new[] {"ADD","1"}, new[] {"ADD","2"}, new[] {"ADD","1"},
//    new[] {"GET_NEXT","1"},   // → "2"
//    new[] {"GET_NEXT","2"},   // → "3"
//    new[] {"GET_NEXT","3"},   // → "5"
//    new[] {"GET_NEXT","5"}    // → ""
//};

//string[] results = sol.Solution(queries);
//Console.WriteLine("Resultados de las consultas:");
//foreach (var query in queries)
//{
//    Console.WriteLine($"Comando: {query[0]}, Valor: {query[1]}");
//}
//Console.WriteLine("[" + string.Join(", ", results) + "]");

/// 49. Group Anagrams - Ejemplo de solución para el problema Group Anagrams en C#
//      GroupAnagrams groupAnagrams = new GroupAnagrams();
//      string[] strs = ["a"]; //strs = { "eat", "tea", "tan", "ate", "nat", "bat" };
//      Input: strs = [""]; //
//      Input: strs = ["a"]; //
//      Console.WriteLine(string.Join(",", strs));
//      var result = groupAnagrams.Solution(strs);

//    foreach (var group in result)
//    {
//        Console.Write("[");
//        Console.Write(string.Join(",", group));
//        Console.Write("] ");
//    }
//    Console.WriteLine("");


///220.a1_ Contains Duplicate III - Ejemplo de solución para el problema Contains Duplicate III en C#
//a1_ContainsDuplicate containsDuplicate = new a1_ContainsDuplicate();

//Console.WriteLine("[1, 2, 3, 1], 3, 0"); // true
//Console.WriteLine(containsDuplicate.ContainsCloseNums([1, 2, 3, 1], 3, 0)); // true

//Console.WriteLine("[1, 5, 9, 1, 5, 9], 2, 3"); // false
//Console.WriteLine(containsDuplicate.ContainsCloseNums([1, 5, 9, 1, 5, 9], 2, 3)); // false

//Console.WriteLine("[8, 7, 15], 2, 5"); // true
//Console.WriteLine(containsDuplicate.ContainsCloseNums([8, 7, 15], 2, 5)); // true

//36. a1_ Valid Sudoku
//a1_ValidSudoku sol = new a1_ValidSudoku();

//char[][] board1 = {
//        new char[] {'5','3','.','.','7','.','.','.','.'},
//        new char[] {'6','.','.','1','9','5','.','.','.'},
//        new char[] {'.','9','8','.','.','.','.','6','.'},
//        new char[] {'8','.','.','.','6','.','.','.','3'},
//        new char[] {'4','.','.','8','.','3','.','.','1'},
//        new char[] {'7','.','.','.','2','.','.','.','6'},
//        new char[] {'.','6','.','.','.','.','2','8','.'},
//        new char[] {'.','.','.','4','1','9','.','.','5'},
//        new char[] {'.','.','.','.','8','.','.','7','9'}
//    };
//Console.WriteLine(sol.IsValidSudoku(board1)); // true

//char[][] board2 = {
//        new char[] {'8','3','.','.','7','.','.','.','.'},
//        new char[] {'6','.','.','1','9','5','.','.','.'},
//        new char[] {'.','9','8','.','.','.','.','6','.'},
//        new char[] {'8','.','.','.','6','.','.','.','3'},
//        new char[] {'4','.','.','8','.','3','.','.','1'},
//        new char[] {'7','.','.','.','2','.','.','.','6'},
//        new char[] {'.','6','.','.','.','.','2','8','.'},
//        new char[] {'.','.','.','4','1','9','.','.','5'},
//        new char[] {'.','.','.','.','8','.','.','7','9'}
//    };
//Console.WriteLine(sol.IsValidSudoku(board2)); // false


//3. b2_ Longest Substring Without Repeating Characters
//b2_LongestSubstringWithoutRepeatingCharacters sol = new b2_LongestSubstringWithoutRepeatingCharacters();
//Console.WriteLine("abcabcbb"); // 3
//Console.WriteLine(sol.LengthOfLongestSubstring("abcabcbb")); // 3
//Console.WriteLine("bbbbb");    // 1
//Console.WriteLine(sol.LengthOfLongestSubstring("bbbbb"));    // 1
//Console.WriteLine("pwwkew");   // 3
//Console.WriteLine(sol.LengthOfLongestSubstring("pwwkew"));   // 3
//Console.WriteLine("");         // 0
//Console.WriteLine(sol.LengthOfLongestSubstring(""));         // 0
//Console.WriteLine("dvdf");     // 3
//Console.WriteLine(sol.LengthOfLongestSubstring("dvdf"));     // 3


// 438. b2_ Find All Anagrams in a String
//b2_FindAnagrams sol = new b2_FindAnagrams();
//Console.WriteLine("cbaebabacd, abc"); // [0,6]
//Console.WriteLine("[" + string.Join(",", sol.findAnagrams("cbaebabacd", "abc")) + "]"); // [0,6]
//Console.WriteLine("abab, ab");         // [0,1,2]
//Console.WriteLine("[" + string.Join(",", sol.findAnagrams("abab", "ab")) + "]");         // [0,1,2]

// 209. d4_ Minimum Size Subarray Sum
//d4_MinimumSizeSubarraySum sol = new d4_MinimumSizeSubarraySum();
//Console.WriteLine("Target 7, Array { 2, 3, 1, 2, 4, 3 }"); // 2
//Console.WriteLine(sol.MinSubArrayLen(7, new int[] { 2, 3, 1, 2, 4, 3 })); // 2
//Console.WriteLine("Target 4, Array { 1, 4, 4 }");       // 1
//Console.WriteLine(sol.MinSubArrayLen(4, new int[] { 1, 4, 4 }));       // 1
//Console.WriteLine("Target 11, Array { 1, 1, 1, 1, 1, 1, 1, 1 }"); // 0
//Console.WriteLine(sol.MinSubArrayLen(11, new int[] { 1, 1, 1, 1, 1, 1, 1, 1 })); // 0
//Console.WriteLine("Target 3, Array { 1, 2, 1, 2, 1 }"); // 2
//Console.WriteLine(sol.MinSubArrayLen(3, new int[] { 1, 2, 1, 2, 1 })); // 2

// 239. d4_ Sliding Window Maximum
//d4_SlidingWindowMaximum slidingWindowMaximum = new d4_SlidingWindowMaximum();
//Console.WriteLine("Input: nums = [1,3,-1,-3,5,3,6,7], k = 3");
//Console.WriteLine("[" + string.Join(",",
//slidingWindowMaximum.MaxSlidingWindow(new int[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3)) + "]");
//// [3,3,5,5,6,7]
//Console.WriteLine("Input: nums = [1], k = 1");
//Console.WriteLine("[" + string.Join(",",
//slidingWindowMaximum.MaxSlidingWindow(new int[] { 1 }, 1)) + "]");
// [1]

// 733. Flood Fill
//      var floodFill = new FloodFill();

//  int[][] image1 = {
//        new int[] {1,1,1},
//        new int[] {1,1,0},
//        new int[] {1,0,1}
//    };

//    Console.WriteLine("image = [" + string.Join(",", image1.Select(row => "[" + string.Join(",", row) + "]")) + "], sr = 1, sc = 1, color = 2");
//    Console.WriteLine();

//foreach (var row in floodFill.floodFill(image1, 1, 1, 2) )
//    Console.WriteLine("[" + string.Join(",", row) + "]");
//    Console.WriteLine();

//// [[2,2,2],[2,2,0],[2,0,1]]

//int[][] image2 = {
//        new int[] {0,0,0},
//        new int[] {0,0,0}
//    };
//  Console.WriteLine("image = [" + string.Join(",", image2.Select(row => "[" + string.Join(",", row) + "]")) + "], sr = 0, sc = 0, color = 0");
//  Console.WriteLine();
//  Print(floodFill.floodFill(image2, 0, 0, 0));
//    // [[0,0,0],[0,0,0]]


//static void Print(int[][] grid)
//{
//    foreach (var row in grid)
//    {
//        Console.WriteLine("[" + string.Join(",", row) + "]");
//        //Console.Write("[");
//        //for (int i = 0; i < row.Length; i++)
//        //{
//        //    Console.Write(row[i]);
//        //    if (i < row.Length - 1) Console.Write(",");
//        //}
//        //Console.WriteLine("]");
//    }
//    Console.WriteLine();
//}

// 695.Max Area of Island
//MaxAreaofIsland maxAreaofIsland = new MaxAreaofIsland();

//int[][] grid1 = {
//        new int[] {0,0,1,0,0,0,0,1,0,0,0,0,0},
//        new int[] {0,0,0,0,0,0,0,1,1,1,0,0,0},
//        new int[] {0,1,1,0,1,0,0,0,0,0,0,0,0},
//        new int[] {0,1,0,0,1,1,0,0,1,0,1,0,0},
//        new int[] {0,1,0,0,1,1,0,0,1,1,1,0,0},
//        new int[] {0,0,0,0,0,0,0,0,0,0,1,0,0},
//        new int[] {0,0,0,0,0,0,0,1,1,1,0,0,0},
//        new int[] {0,0,0,0,0,0,0,1,1,0,0,0,0}
//    };

//Console.WriteLine("Input: grid = ");
//foreach (var row in grid1)
//        Console.WriteLine("[" + string.Join(",", row) + "]");
//Console.WriteLine();
//Console.WriteLine("Output: " + maxAreaofIsland.MaxAreaOfIsland(grid1)); // 6
//Console.WriteLine();

//int[][] grid2 = { new int[] { 0, 0, 0, 0, 0, 0, 0, 0 } };

//Console.WriteLine("Input: grid = ");
//foreach (var row in grid2)
//    Console.WriteLine("[" + string.Join(",", row) + "]");
//Console.WriteLine();
//Console.WriteLine("Output: " + maxAreaofIsland.MaxAreaOfIsland(grid2)); // 0

// 608.Tree Node  SQL ver archivo TreeNode.sql

// 90. Subsets II
//Subsets subsets = new Subsets();

//Console.WriteLine("[ 1, 2, 2 ]");
//Print(subsets.SubsetsWithDup(new int[] { 1, 2, 2 }));
//// [[], [1], [2], [1,2], [2,2], [1,2,2]]

//Console.WriteLine("");

//Console.WriteLine("[ 0 ]");
//Print(subsets.SubsetsWithDup(new int[] { 0 }));
//    // [[], [0]]

//static void Print(IList<IList<int>> subsets)
//{
//    Console.Write("[");
//    for (int i = 0; i < subsets.Count; i++)
//    {
//        Console.Write("[");
//        for (int j = 0; j < subsets[i].Count; j++)
//        {
//            Console.Write(subsets[i][j]);
//            if (j < subsets[i].Count - 1) Console.Write(",");
//        }
//        Console.Write("]");
//        if (i < subsets.Count - 1) Console.Write(",");
//    }
//    Console.WriteLine("]");
//}

// 216.Combination Sum III
//CombinationSum combinationSum = new CombinationSum();

//// Prueba 1
//Print_(combinationSum.CombinationSum3(3, 7));  // [[1,2,4]]

//// Prueba 2
//Print_(combinationSum.CombinationSum3(3, 9));  // [[1,2,6],[1,3,5],[2,3,4]]

//// Prueba 3
//Print_(combinationSum.CombinationSum3(4, 1));  // []

//// Prueba 4
//Print_(combinationSum.CombinationSum3(2, 3));  // [[1,2]]


//static void Print_(IList<IList<int>> combos)
//{
//    Console.Write("[");
//    for (int i = 0; i < combos.Count; i++)
//    {
//        Console.Write("[");
//        for (int j = 0; j < combos[i].Count; j++)
//        {
//            Console.Write(combos[i][j]);
//            if (j < combos[i].Count - 1) Console.Write(",");
//        }
//        Console.Write("]");
//        if (i < combos.Count - 1) Console.Write(",");
//    }
//    Console.WriteLine("]");
//}

//132.Palindrome Partitioning II
//   PalindromePartitioningII palindromePartitioningII = new PalindromePartitioningII();
//   Console.WriteLine("aab " + palindromePartitioningII.MinCut("aab"));  // 1
//   Console.WriteLine("aba " + palindromePartitioningII.MinCut("aba"));  // 1
//   Console.WriteLine("a " + palindromePartitioningII.MinCut("a"));    // 0
//   Console.WriteLine("ab " + palindromePartitioningII.MinCut("ab"));   // 1
//   Console.WriteLine("abc " + palindromePartitioningII.MinCut("abc"));  // 2

// 200. c3_ Number of Islands
//c3_NumberOfIslands numberOfIslands = new c3_NumberOfIslands();

//char[][] grid1 = {
//        new char[] {'1','1','1','1','0'},
//        new char[] {'1','1','0','1','0'},
//        new char[] {'1','1','0','0','0'},
//        new char[] {'0','0','0','0','0'}
//    };

//Console.WriteLine(numberOfIslands.NumIslands(grid1)); // 1

//char[][] grid2 = {
//        new char[] {'1','1','0','0','0'},
//        new char[] {'1','1','0','0','0'},
//        new char[] {'0','0','1','0','0'},
//        new char[] {'0','0','0','1','1'}
//    };
//Console.WriteLine(numberOfIslands.NumIslands(grid2)); // 3

//133.c3_ Clone Graph
//c3_CloneGraph sol = new c3_CloneGraph();


//// Crear nodo 1 con vecinos 2 y 4
//c3_CloneGraph.Node n1 = new c3_CloneGraph.Node(1);
//c3_CloneGraph.Node n2 = new c3_CloneGraph.Node(2);
//c3_CloneGraph.Node n3 = new c3_CloneGraph.Node(3);
//c3_CloneGraph.Node n4 = new c3_CloneGraph.Node(4);

//n1.neighbors = new List<c3_CloneGraph.Node> { n2, n4 };
//n2.neighbors = new List<c3_CloneGraph.Node> { n1, n3 };
//n3.neighbors = new List<c3_CloneGraph.Node> { n2, n4 };
//n4.neighbors = new List<c3_CloneGraph.Node> { n1, n3 };

//c3_CloneGraph.Node clone = sol.cloneGraph(n1);

//// Puedes inspeccionar clone.val, clone.neighbors, etc.

//Console.WriteLine("=== GRAFO ORIGINAL ===");
//PrintGraph(n1, "Original");

//Console.WriteLine("\n=== GRAFO CLONADO ===");
//PrintGraph(clone, "Clon");

//// Verificación de copia profunda
//Console.WriteLine("\n--- VERIFICACIÓN DE COPIA PROFUNDA ---");
//Console.WriteLine($"¿n1 == clone? → {ReferenceEquals(n1, clone)}"); // False
//Console.WriteLine($"¿n1.neighbors[0] == clone.neighbors[0]? → {ReferenceEquals(n1.neighbors[0], clone.neighbors[0])}"); // False

//// Función para imprimir el grafo
//static void PrintGraph(Node start, string label)
//{
//    if (start == null)
//    {
//        Console.WriteLine("Grafo vacío");
//        return;
//    }

//    HashSet<Node> visited = new HashSet<Node>();
//    Queue<Node> queue = new Queue<Node>();
//    queue.Enqueue(start);

//    Console.WriteLine($"Grafo: {label}");

//    while (queue.Count > 0)
//    {
//        Node node = queue.Dequeue();
//        if (visited.Contains(node)) continue;

//        visited.Add(node);

//        // Imprimir nodo y sus vecinos
//        Console.Write($"Nodo {node.val} → [ ");
//        for (int i = 0; i < node.neighbors.Count; i++)
//        {
//            Console.Write(node.neighbors[i].val);
//            if (i < node.neighbors.Count - 1) Console.Write(", ");
//        }
//        Console.WriteLine(" ]");

//        // Agregar vecinos no visitados
//        foreach (Node neighbor in node.neighbors)
//        {
//            if (!visited.Contains(neighbor))
//            {
//                queue.Enqueue(neighbor);
//            }
//        }
//    }
//}

//210. c3_ Course Schedule II
//c3_CourseSchedule_II sol = new c3_CourseSchedule_II();

//Print(sol.FindOrder(2, new int[][] { new int[] { 1, 0 } }));
//// [0,1]

//Print(sol.FindOrder(4, new int[][] {
//        new int[] {1,0}, new int[] {2,0}, new int[] {3,1}, new int[] {3,2}
//    }));
//// [0,1,2,3] o [0,2,1,3]

//Print(sol.FindOrder(1, new int[0][])); 
//    // [0]


//static void Print(int[] arr)
//{
//    Console.Write("[");
//    for (int i = 0; i < arr.Length; i++)
//    {
//        Console.Write(arr[i]);
//        if (i < arr.Length - 1) Console.Write(",");
//    }
//    Console.WriteLine("]");
//}


/// Ejecución del módulo de Estudiantes
MainStudents mainStudents = new MainStudents();
mainStudents.EjecutarEstudiantes();

//Determines if two words are anagrams
//IsAnagram TwoWordsAreAnagrams = new IsAnagram();
//bool res = TwoWordsAreAnagrams.WordsAnagram("Lissten", "ssilent");

//Console.WriteLine($"El resultado es {res} ");