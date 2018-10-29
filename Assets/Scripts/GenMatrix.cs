using System;
using UnityEngine;
namespace GenMatrix
{
    public class GenMatrix
    {

        static public int[,] Matrix(int level)
        {
            int obstacles = level * 2;
            int[,] matrix = new int[8, 8];

            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    Debug.Log("r="+r+",c="+c);
                    matrix[r, c] = 0;
                }
            }

            System.Random random = new System.Random();
            while (obstacles > 0)
            {
                int x = random.Next(7);
                int y = random.Next(7);

                if (x == 0 && y == 0 || x == 7 && y == 7 || x == 1 && y == 0 && matrix[1, 0] == 1 || x == 0 && y == 1 && matrix[0, 1] == 1 || x == 7 && y == 6 && matrix[7, 6] == 1 || x == 6 && y == 7 && matrix[6, 7] == 1) { }
                else if (matrix[y, x] == 0)
                {
                    matrix[y, x] = 1; 
                    obstacles--;
                }
            }

            return matrix;
        }
    }
}

