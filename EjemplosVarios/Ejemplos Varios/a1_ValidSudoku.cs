using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//36.Valid Sudoku https://leetcode.com/problems/valid-sudoku/description/
//Determine if a 9 x 9 Sudoku board is valid. Only the filled cells need to be validated
//according to the following rules:
//  Each row must contain the digits 1-9 without repetition.
//  Each column must contain the digits 1-9 without repetition.
//  Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition.
//  Note:
//      A Sudoku board (partially filled) could be valid but is not necessarily solvable.
//      Only the filled cells need to be validated according to the mentioned rules.
//Example 1:
//  Input: board =
//       [["5","3",".",".","7",".",".",".","."]
//       ,["6",".",".","1","9","5",".",".","."]
//       ,[".","9","8",".",".",".",".","6","."]
//       ,["8",".",".",".","6",".",".",".","3"]
//       ,["4",".",".","8",".","3",".",".","1"]
//       ,["7",".",".",".","2",".",".",".","6"]
//       ,[".","6",".",".",".",".",".","2","8","."]
//       ,[".",".",".","4","1","9",".",".","5"]
//       ,[".",".",".",".","8",".",".","7","9"]]
//  Output: true
//Example 2:

//  Input: board =
//      [["8","3",".",".","7",".",".",".","."]
//      ,["6",".",".","1","9","5",".",".","."]
//      ,[".","9","8",".",".",".",".","6","."]
//      ,["8",".",".",".","6",".",".",".","3"]
//      ,["4",".",".","8",".","3",".",".","1"]
//      ,["7",".",".",".","2",".",".",".","6"]
//      ,[".","6",".",".",".",".",".","2","8","."]
//      ,[".",".",".","4","1","9",".",".","5"]
//      ,[".",".",".",".","8",".",".","7","9"]]
//  Output: false
//Explanation: Same as Example 1, except with the 5 in the top left
//corner being modified to 8. Since there are two 8's in the top left 3x3 sub-box, it is invalid.


namespace EjemplosVarios.Ejemplos_Varios
{
    public class a1_ValidSudoku
    {
        /// <summary>
        /// Determina si un tablero de Sudoku 9x9 es válido según las reglas de Sudoku.
        /// Solo se validan las celdas llenas: no debe haber repetición de dígitos (1-9)
        /// en ninguna fila, columna o subcuadro 3x3.
        /// </summary>
        /// <param name="board">Una matriz de caracteres (char[][]) que representa el tablero de Sudoku.</param>
        /// <returns>Retorna true si el tablero es válido hasta el momento, false si hay una repetición.</returns>
        public bool IsValidSudoku(char[][] board)
        {
            // Paso 1: Inicialización de Estructuras de Datos

            // Se utilizan 3 arreglos de HashSet (conjuntos de hash) para rastrear la presencia
            // de un dígito en cada una de las 9 filas, 9 columnas y 9 subcuadros 3x3.
            // La complejidad de tiempo de búsqueda, inserción y eliminación en HashSet es O(1) promedio.

            // Arreglo de 9 HashSet, uno para rastrear los números vistos en cada fila.
            HashSet<char>[] rows = new HashSet<char>[9];
            // Arreglo de 9 HashSet, uno para rastrear los números vistos en cada columna.
            HashSet<char>[] cols = new HashSet<char>[9];
            // Arreglo de 9 HashSet, uno para rastrear los números vistos en cada subcuadro 3x3.
            HashSet<char>[] boxes = new HashSet<char>[9];

            // Inicializar cada elemento del arreglo como un nuevo HashSet.
            for (int i = 0; i < 9; i++)
            {
                rows[i] = new HashSet<char>();
                cols[i] = new HashSet<char>();
                boxes[i] = new HashSet<char>();
            }

            // Paso 2: Recorrido del Tablero

            // Bucle principal para recorrer todas las 81 celdas del tablero (9 filas x 9 columnas).
            for (int i = 0; i < 9; i++) // 'i' representa el índice de la fila (0 a 8)
            {
                for (int j = 0; j < 9; j++) // 'j' representa el índice de la columna (0 a 8)
                {
                    // Obtiene el carácter en la celda actual (fila i, columna j).
                    char c = board[i][j];

                    // Si la celda está vacía (representada por '.'), la ignoramos y pasamos a la siguiente.
                    if (c == '.') continue;  // Ignorar vacíos

                    // Paso 3: Cálculo del Índice del Subcuadro 3x3

                    // Cada subcuadro 3x3 se mapea a un índice único de 0 a 8.
                    // El cálculo se realiza así: (índice de fila / 3) * 3 + (índice de columna / 3).
                    // Esto agrupa los índices de fila (0,1,2) en 0, (3,4,5) en 1, etc.,
                    // y los mapea a una cuadrícula 3x3 plana (0-2 para la primera fila de cuadros,
                    // 3-5 para la segunda, 6-8 para la tercera).
                    int boxIndex = (i / 3) * 3 + j / 3;

                    // Paso 4: Verificación y Registro de la Fila (i)

                    // Verifica si el carácter 'c' ya está presente en el HashSet de la fila 'i'.
                    if (rows[i].Contains(c))
                        return false; // Si ya está, la regla de la fila se rompe: Sudoku inválido.

                    rows[i].Add(c); // Si no está, se añade al conjunto de la fila 'i'.

                    // Paso 5: Verificación y Registro de la Columna (j)

                    // Verifica si el carácter 'c' ya está presente en el HashSet de la columna 'j'.
                    if (cols[j].Contains(c))
                        return false; // Si ya está, la regla de la columna se rompe: Sudoku inválido.

                    cols[j].Add(c); // Si no está, se añade al conjunto de la columna 'j'.

                    // Paso 6: Verificación y Registro del Subcuadro (boxIndex)

                    // Verifica si el carácter 'c' ya está presente en el HashSet del subcuadro calculado.
                    if (boxes[boxIndex].Contains(c))
                        return false; // Si ya está, la regla del subcuadro se rompe: Sudoku inválido.

                    boxes[boxIndex].Add(c); // Si no está, se añade al conjunto del subcuadro.
                }
            }

            // Paso 7: Resultado Final

            // Si el bucle termina sin encontrar ninguna repetición en filas, columnas o subcuadros,
            // el tablero es válido.
            return true;
        }
    }
}