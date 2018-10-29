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
                
                if (matrix[y, x] == 0)
                {
                    matrix[y, x] = 1;
                    obstacles--;
                }
            }

            return matrix;
        }
    }
}

