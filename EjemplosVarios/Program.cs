// See https://aka.ms/new-console-template for more information
//  Console.WriteLine("Hello, World!");


using EjemplosVarios.Ejemplos_Varios;
using System;
using System.Linq;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;


/// 1. Two Sum - Ejemplo de solución para el problema Two Sum en C#
/// Given an array of integers nums and an integer target, 
/// return indices of the two numbers such that they add up to target.
//TwoSum twoSum = new TwoSum();
//int[] result = twoSum.Solution (new int[] { 2, 15, 11, 7}, 9);
//Console.WriteLine($"[{result[0]},{result[1]}]");


/// 49. Group Anagrams - Ejemplo de solución para el problema Group Anagrams en C#
//GroupAnagrams groupAnagrams = new GroupAnagrams();
//    string[] strs = ["a"]; //strs = { "eat", "tea", "tan", "ate", "nat", "bat" };
////Input: strs = [""]; //
////Input: strs = ["a"]; //
//Console.WriteLine(string.Join(",", strs));
//var result = groupAnagrams.Solution(strs);

//    foreach (var group in result)
//    {
//        Console.Write("[");
//        Console.Write(string.Join(",", group));
//        Console.Write("] ");
//    }
//Console.WriteLine("");



///220.Contains Duplicate III - Ejemplo de solución para el problema Contains Duplicate III en C#
//ContainsDuplicate containsDuplicate = new ContainsDuplicate();

//Console.WriteLine("[1, 2, 3, 1], 3, 0"); // true
//Console.WriteLine(containsDuplicate.ContainsCloseNums([1, 2, 3, 1], 3, 0)); // true

//Console.WriteLine("[1, 5, 9, 1, 5, 9], 2, 3"); // true
//Console.WriteLine(containsDuplicate.ContainsCloseNums([1, 5, 9, 1, 5, 9], 2, 3)); // false

// 3. Longest Substring Without Repeating Characters
//LongestSubstringWithoutRepeatingCharacters sol = new LongestSubstringWithoutRepeatingCharacters();
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


// 438. Find All Anagrams in a String
//FindAnagrams sol = new FindAnagrams();
//Console.WriteLine("cbaebabacd, abc"); // [0,6]
//Console.WriteLine("["+string.Join(",", sol.findAnagrams("cbaebabacd", "abc"))+"]"); // [0,6]
//Console.WriteLine("abab, ab");         // [0,1,2]
//Console.WriteLine("["+string.Join(",", sol.findAnagrams("abab", "ab"))+"]");         // [0,1,2]

// 209. Minimum Size Subarray Sum
//var sol = new MinimumSizeSubarraySum();
//Console.WriteLine("Target 7, Array { 2, 3, 1, 2, 4, 3 }"); // 2
//Console.WriteLine(sol.MinSubArrayLen(7, new int[] { 2, 3, 1, 2, 4, 3 })); // 2
//Console.WriteLine("Target 4, Array { 1, 4, 4 }");       // 1
//Console.WriteLine(sol.MinSubArrayLen(4, new int[] { 1, 4, 4 }));       // 1
//Console.WriteLine("Target 11, Array { 1, 1, 1, 1, 1, 1, 1, 1 }"); // 0
//Console.WriteLine(sol.MinSubArrayLen(11, new int[] { 1, 1, 1, 1, 1, 1, 1, 1 })); // 0
//Console.WriteLine("Target 3, Array { 1, 2, 1, 2, 1 }"); // 2
//Console.WriteLine(sol.MinSubArrayLen(3, new int[] { 1, 2, 1,2, 1})); // 2

// 239. Sliding Window Maximum
//SlidingWindowMaximum slidingWindowMaximum = new SlidingWindowMaximum();
//Console.WriteLine("Input: nums = [1,3,-1,-3,5,3,6,7], k = 3");
//Console.WriteLine("[" + string.Join(",", 
//    slidingWindowMaximum.MaxSlidingWindow(new int[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3)) + "]");
//    // [3,3,5,5,6,7]
//Console.WriteLine("Input: nums = [1], k = 1");
//Console.WriteLine("[" + string.Join(",",
//    slidingWindowMaximum.MaxSlidingWindow(new int[] { 1 }, 1)) + "]");
//    // [1]

// 733. Flood Fill
//var floodFill = new FloodFill();

//int[][] image1 = {
//        new int[] {1,1,1},
//        new int[] {1,1,0},
//        new int[] {1,0,1}
//    };

//Console.WriteLine("image = [" + string.Join(",", image1.Select(row => "[" + string.Join(",", row) + "]")) + "], sr = 1, sc = 1, color = 2");
//Console.WriteLine();

//foreach (var row in floodFill.floodFill(image1, 1, 1, 2) )
//    Console.WriteLine("[" + string.Join(",", row) + "]");
//Console.WriteLine();

//// [[2,2,2],[2,2,0],[2,0,1]]

//int[][] image2 = {
//        new int[] {0,0,0},
//        new int[] {0,0,0}
//    };
//Console.WriteLine("image = [" + string.Join(",", image2.Select(row => "[" + string.Join(",", row) + "]")) + "], sr = 0, sc = 0, color = 0");
//Console.WriteLine();
//Print(floodFill.floodFill(image2, 0, 0, 0));
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
CombinationSum combinationSum = new CombinationSum();

// Prueba 1
Print_(combinationSum.CombinationSum3(3, 7));  // [[1,2,4]]

// Prueba 2
Print_(combinationSum.CombinationSum3(3, 9));  // [[1,2,6],[1,3,5],[2,3,4]]

// Prueba 3
Print_(combinationSum.CombinationSum3(4, 1));  // []

// Prueba 4
Print_(combinationSum.CombinationSum3(2, 3));  // [[1,2]]
    

static void Print_(IList<IList<int>> combos)
{
    Console.Write("[");
    for (int i = 0; i < combos.Count; i++)
    {
        Console.Write("[");
        for (int j = 0; j < combos[i].Count; j++)
        {
            Console.Write(combos[i][j]);
            if (j < combos[i].Count - 1) Console.Write(",");
        }
        Console.Write("]");
        if (i < combos.Count - 1) Console.Write(",");
    }
    Console.WriteLine("]");
}

//132.Palindrome Partitioning II