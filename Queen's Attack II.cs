using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution {

    // Complete the queensAttack function below.
    static int queensAttack(int n, int k, int r_q, int c_q, int[][] obstacles)
    {
            int result = 0;           
            int[][] grid = new int[n][];
            for (int i = 0; i <grid.Length; i++)
            {
                grid[i] = new int[n];
            }
            grid[r_q-1][c_q-1] = 0;
            if (k != 0)
            {
                for (int i = 0; i < obstacles.Length; i++)
                    grid[obstacles[i][0] - 1][obstacles[i][1] - 1] = -1;
                for (int i = r_q; i < n; i++)
                { // UP
                    if (grid[i][c_q - 1] != -1)
                        grid[i][c_q - 1] = 1;
                    else
                        break;
                }
                for (int i = r_q - 2; i > -1; i--)//down
                {
                    if (grid[i][c_q - 1] != -1)
                        grid[i][c_q - 1] = 1;
                    else
                        break;
                }
                for (int i = c_q; i < n; i++)//right
                {
                    if (grid[r_q - 1][i] != -1)
                        grid[r_q - 1][i] = 1;
                    else
                        break;
                }
                for (int i = c_q - 2; i > -1; i--)//left
                {
                    if (grid[r_q - 1][i] != -1)
                        grid[r_q - 1][i] = 1;
                    else
                        break;
                }
                for (int i = r_q, j = c_q; i < n && j < n; i++, j++) // up+right
                {
                    if (grid[i][j] != -1)
                        grid[i][j] = 1;
                    else
                        break;
                }
                for (int i = r_q, j = c_q - 2; i < n && j > -1; i++, j--) // up+left
                {
                    if (grid[i][j] != -1)
                        grid[i][j] = 1;
                    else
                        break;
                }
                for (int i = r_q - 2, j = c_q; i > -1 && j < n; i--, j++) // down+right
                {
                    if (grid[i][j] != -1)
                        grid[i][j] = 1;
                    else
                        break;
                }
                for (int i = r_q - 2, j = c_q - 2; i > -1 && j > -1; i--, j--) // down+left
                {
                    if (grid[i][j] != -1)
                        grid[i][j] = 1;
                    else
                        break;
                }
                for (int i = 0; i < grid.Length; i++)
                {
                    result += grid[i].Count(v => v == 1);
                }
                return result;
            }
            else
            {
                return n - r_q + (r_q - 1) + (n - c_q) + (c_q - 1) + Math.Min(n - c_q, n - r_q) +
                    +Math.Min(n - c_q, r_q - 1) + Math.Min(c_q - 1, n - r_q) + Math.Min(c_q - 1, r_q - 1);
            } 
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nk = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nk[0]);

        int k = Convert.ToInt32(nk[1]);

        string[] r_qC_q = Console.ReadLine().Split(' ');

        int r_q = Convert.ToInt32(r_qC_q[0]);

        int c_q = Convert.ToInt32(r_qC_q[1]);

        int[][] obstacles = new int[k][];

        for (int i = 0; i < k; i++) {
            obstacles[i] = Array.ConvertAll(Console.ReadLine().Split(' '), obstaclesTemp => Convert.ToInt32(obstaclesTemp));
        }

        int result = queensAttack(n, k, r_q, c_q, obstacles);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
