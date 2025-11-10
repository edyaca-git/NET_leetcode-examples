using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


//// 733. Flood Fill
/// Objetivo
// Dado:

// Una grilla image de m x n
// Un punto de inicio (sr, sc)
// Un nuevo color color

// Cambiar todos los píxeles conectados (4 direcciones) que tengan el mismo color
// que image[sr][sc] al nuevo color.


namespace EjemplosVarios.Ejemplos_Varios
{
    public class FloodFill
    {
        public int[][] floodFill(int[][] image, int sr, int sc, int color)
        {
            int originalColor = image[sr][sc];

            // Si ya es el color nuevo, no hacer nada
            if (originalColor == color) return image;

            Dfs(image, sr, sc, originalColor, color);
            return image;
        }

        private void Dfs(int[][] image, int r, int c, int original, int newColor)
        {
            int m = image.Length;
            int n = image[0].Length;

            // Validaciones
            if (r < 0 || r >= m || c < 0 || c >= n) return;
            if (image[r][c] != original) return;

            // Cambiar color
            image[r][c] = newColor;

            // 4 direcciones
            Dfs(image, r - 1, c, original, newColor); // arriba
            Dfs(image, r + 1, c, original, newColor); // abajo
            Dfs(image, r, c - 1, original, newColor); // izquierda
            Dfs(image, r, c + 1, original, newColor); // derecha
        }
    }
}
