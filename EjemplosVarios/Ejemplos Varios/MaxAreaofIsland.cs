using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// 695.Max Area of Island
// You are given an m x n binary matrix grid. An island is a group of 1's (representing land)
// connected 4-directionally (horizontal or vertical.) You may assume all four edges of
// the grid are surrounded by water.
//The area of an island is the number of cells with a value 1 in the island.
//Return the maximum area of an island in grid. If there is no island, return 0
// Una grilla grid de m x n con 0 (agua) y 1 (tierra)
//Devolver el área máxima de una isla (grupo de 1s conectados por 4 direcciones).
//Si no hay isla → 0.
//Ejemplo 1: Isla de área 6
        //csharpgrid = [
        //  [0,0,1,0,0,0,0,1,0,0,0,0,0],
        //  [0,0,0,0,0,0,0,1,1,1,0,0,0],
        //  [0,1,1,0,1,0,0,0,0,0,0,0,0],
        //  [0,1,0,0,1,1,0,0,1,0,1,0,0],
        //  [0,1,0,0,1,1,0,0,1,1,1,0,0],  ESTA ES LA QUE TIENE 6
        //  [0,0,0,0,0,0,0,0,0,0,1,0,0],
        //  [0,0,0,0,0,0,0,1,1,1,0,0,0],
        //  [0,0,0,0,0,0,0,1,1,0,0,0,0]
        //]

        //Hay varias islas.
        //La más grande tiene 6 celdas (la del centro-derecha).
        //DFS la recorre, cuenta 1 + 1 + 1 + 1 + 1 + 1 = 6.

        //Output: 6

namespace EjemplosVarios.Ejemplos_Varios
{
    public class MaxAreaofIsland
    {
        public int MaxAreaOfIsland(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            int maxArea = 0;

            // - Recorremos cada celda; cuando encontramos un 1 (tierra) iniciamos una búsqueda DFS
            //   Depth-First Search = Búsqueda en Profundidad Primero.
            //   para calcular el área de la isla conectada a esa celda.
            // - Después de la DFS, comparamos el área obtenida con maxArea y guardamos la mayor.
            // - Al marcar las celdas visitadas (grid[r][c] = 0) evitamos volver a contarlas.
            for (int r = 0; r < m; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    if (grid[r][c] == 1)
                    {
                        int area = Dfs(grid, r, c);
                        maxArea = Math.Max(maxArea, area);
                    }
                }
            }

            return maxArea;
        }

        private int Dfs(int[][] grid, int r, int c)
        {
            int m = grid.Length;
            int n = grid[0].Length;

            // Validar límites y que sea tierra
            // Comentario añadido:
            // - Caso base de la recursión: si estamos fuera de límites o la celda no es 1,
            //   no contribuimos al área (devolvemos 0).
            if (r < 0 || r >= m || c < 0 || c >= n || grid[r][c] != 1)
            {
                return 0;
            }

            // Marcar como visitado (evita ciclos)
            // Comentario añadido:
            // - Marcamos la celda como 0 en el mismo grid para no necesitar una estructura
            //   adicional de visitados. Esto modifica la entrada, pero es eficiente en memoria.
            grid[r][c] = 0;

            // Contar esta celda + áreas de vecinos
            // Comentario añadido:
            // - Sumamos 1 por la celda actual y hacemos llamadas recursivas a las cuatro
            //   direcciones (arriba, abajo, izquierda, derecha).
            // - Debido a que las celdas se marcan como 0 al visitarlas, cada celda se procesa
            //   como máximo una vez, por lo que la complejidad es O(m*n) en total.
            return 1 +
                   Dfs(grid, r - 1, c) +  // arriba
                   Dfs(grid, r + 1, c) +  // abajo
                   Dfs(grid, r, c - 1) +  // izquierda
                   Dfs(grid, r, c + 1);   // derecha
        }
    }
}
