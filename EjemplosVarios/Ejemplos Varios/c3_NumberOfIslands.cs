using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 200. Number of Islands
//Given an m x n 2D binary grid grid which represents a map of '1's (land)
//and '0's (water), return the number of islands.
//An island is surrounded by water and is formed by connecting adjacent lands
//horizontally or vertically. You may assume all four edges of the grid are
//all surrounded by water.
//Example 1:
//  Input: grid = [
//   ["1","1","1","1","0"],
//   ["1","1","0","1","0"],
//   ["1","1","0","0","0"],
//   ["0","0","0","0","0"]
//  ]
//  Output: 1
//Example 2:
//  Input: grid = [
//      ["1","1","0","0","0"],
//      ["1","1","0","0","0"],
//      ["0","0","1","0","0"],
//      ["0","0","0","1","1"]
//  ]
//  Output: 3

namespace EjemplosVarios.Ejemplos_Varios
{
    /// <summary>
    /// Clase que resuelve el problema "Number of Islands".
    /// 
    /// Descripción paso a paso:
    /// 1) Recorre cada celda de la grilla buscando un '1' (tierra) no visitado.
    /// 2) Al encontrar una tierra, incrementa el contador de islas.
    /// 3) Usa DFS para "inundar" (marcar como visitada) toda la isla cambiando '1' a '0'.
    /// 4) Continúa el recorrido hasta procesar todas las celdas.
    /// 
    /// Resultado: el número total de islas (componentes conectadas de '1's).
    /// </summary>
    public class c3_NumberOfIslands
    {
        /// <summary>
        /// Cuenta el número de islas en la grilla dada.
        /// 
        /// Paso a paso dentro del método:
        /// - Validar entrada (null o longitud 0) y retornar 0 en ese caso.
        /// - Obtener dimensiones de la grilla (filas y columnas).
        /// - Inicializar contador de islas en 0.
        /// - Recorrer cada celda; si es '1', es el inicio de una nueva isla:
        ///     * Incrementar contador.
        ///     * Llamar a Dfs Depth-First Search (búsqueda en profundidad) 
        ///       para marcar toda la isla como visitada.
        /// - Al final retornar el contador de islas.
        /// </summary>
        /// <param name="grid">Matriz de caracteres donde '1' = tierra y '0' = agua.</param>
        /// <returns>Entero con el número de islas encontradas.</returns>
        public int NumIslands(char[][] grid)
        {
            // Validación inicial: si la grilla es null o está vacía no hay islas.
            if (grid == null || grid.Length == 0) return 0;

            int rows = grid.Length;      // número de filas
            int cols = grid[0].Length;   // número de columnas (asumimos rectangular)
            int islandCount = 0;         // contador de islas encontrado

            // Recorrer toda la grilla por filas y columnas
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    // Si encontramos una celda con '1' significa una isla no visitada
                    if (grid[r][c] == '1')
                    {
                        islandCount++;           // ¡Nueva isla encontrada!
                        Dfs(grid, r, c);         // Marcar toda la isla utilizando DFS (inundación)
                    }
                }
            }

            // Devolver el número total de islas encontradas
            return islandCount;
        }

        /// <summary>
        /// DFS recursivo que marca todas las celdas conectadas (arriba, abajo, izquierda, derecha)
        /// pertenecientes a la misma isla. Este método modifica la grilla in-place reemplazando '1' por '0'.
        /// 
        /// Paso a paso dentro del método:
        /// - Obtener dimensiones (rows, cols).
        /// - Validar límites y comprobar que la celda actual sea '1'.
        /// - Marcar la celda actual como visitada asignando '0'.
        /// - Llamar recursivamente a Dfs en las cuatro direcciones para propagar la marca.
        /// - Si la celda está fuera de límites o no es '1', retornar inmediatamente.
        /// </summary>
        /// <param name="grid">La grilla a modificar para marcar visitados.</param>
        /// <param name="r">Índice de fila de la celda actual.</param>
        /// <param name="c">Índice de columna de la celda actual.</param>
        private void Dfs(char[][] grid, int r, int c)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            // Validar límites y que sea tierra; si no, terminar la recursión.
            if (r < 0 || r >= rows || c < 0 || c >= cols || grid[r][c] != '1')
            {
                return;
            }

            // Marcar como visitado (evita ciclos y recontar la misma isla)
            grid[r][c] = '0';

            // Explorar 4 direcciones (vecinos ortogonales)
            Dfs(grid, r - 1, c);  // arriba
            Dfs(grid, r + 1, c);  // abajo
            Dfs(grid, r, c - 1);  // izquierda
            Dfs(grid, r, c + 1);  // derecha    
        
        }
    }
}
