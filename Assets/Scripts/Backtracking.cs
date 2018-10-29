using UnityEngine;
using UnityEngine.UI;
namespace Backtracking
{
    
    public class Backtracking
    {
        public string console = "";
        int N = 8;

        /* A utility function to print solution matrix 
           sol[N][N] */
        void printSolution(int[,] sol)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Debug.Log(" " + sol[i, j] +
                                     " ");
            }
        }

        /* A utility function to check if x,y is valid 
            index for N*N maze */
        bool isSafe(int[,] maze, int x, int y)
        {

            if (x < 0 || x >= N || y < 0 ||
                    y >= N)
            {
                console += "Out of bounds area\n";
            }
            else if (maze[x, y] == 1)
            {
                console += "Obstacle found, choosing new direction or backtracking...\n";
            }
            // if (x,y outside maze) return false 
            return (x >= 0 && x < N && y >= 0 &&
                    y < N && maze[x, y] == 0);
        }

        /* This function solves the Maze problem using 
           Backtracking. It mainly uses solveMazeUtil() 
           to solve the problem. It returns false if no 
           path is possible, otherwise return true and 
           prints the path in the form of 1s. Please note 
           that there may be more than one solutions, this 
           function prints one of the feasible solutions.*/
        public int[,] solveMaze(int[,] maze)
        {
            int[,] sol = {
            { 0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0},
        };

            if (solveMazeUtil(maze, 0, 0, sol) == false)
            {
                Debug.Log("Solution doesn't exist");
                console += "Solution doesn't exist\n";
                return null;
            }

            printSolution(sol);
            return sol;
        }

        /* A recursive utility function to solve Maze 
       problem */
        bool solveMazeUtil(int[,] maze, int x, int y,
                          int[,] sol)
        {
            // if (x,y is goal) return true 
            if (x == N - 1 && y == N - 1)
            {
                sol[x, y] = 1;
                return true;
            }

            // Check if maze[x][y] is valid 
            if (isSafe(maze, x, y) == true)
            {
                // mark x,y as part of solution path 
                sol[x, y] = 1;

                /* Move forward in x direction */
                console += "Moving forward in X direction\n";
                if (solveMazeUtil(maze, x + 1, y, sol))
                    return true;

                /* If moving in x direction doesn't give 
                   solution then  Move down in y direction */
                console += "X path is blocked, now moving forward in direction\n";
                if (solveMazeUtil(maze, x, y + 1, sol))
                    return true;

                /* If none of the above movements works then 
                   BACKTRACK: unmark x,y as part of solution 
                   path */
                sol[x, y] = 0;
                console += "Y path is also blocked. Now backtracking\n";
                return false;
            }

            return false;
        }
    }
}

