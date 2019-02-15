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
        static int[][] method_for_obstacles(int n, int r_q, int c_q)
        {// This method initialize first blockers so at beginning it just end of grid.
            int[][] obstacles = new int[8][];
            for (int i = 0; i < obstacles.Length; i++)
            {
                obstacles[i] = new int[2];
            }
            //0 will be left direction
            obstacles[0][0] = r_q;
            obstacles[0][1] = 0;
            //1-Left + UP
            int min = Math.Min(n - r_q, c_q - 1);
            obstacles[1][0] = r_q + min + 1;
            obstacles[1][1] = c_q - min - 1;
            //2-Up
            obstacles[2][0] = n + 1;
            obstacles[2][1] = c_q;
            //3-RIGHT+UP
            min = Math.Min(n - r_q, n - c_q);
            obstacles[3][0] = r_q + min + 1;
            obstacles[3][1] = c_q + min + 1;
            //4-RIGHT
            obstacles[4][0] = r_q;
            obstacles[4][1] = n + 1;
            //5 - RIGHT+DOWN
            min = Math.Min(r_q - 1, n - c_q);
            obstacles[5][0] = r_q - min - 1;
            obstacles[5][1] = c_q + min + 1;
            //6 - DOWN
            obstacles[6][0] = 0;
            obstacles[6][1] = c_q;
            //7 - LEFT + DOWN
            min = Math.Min(r_q - 1, c_q - 1);
            obstacles[7][0] = r_q - min - 1;
            obstacles[7][1] = c_q - min - 1;

            return obstacles;
        }
        static int count_all_possible_mouves(int[][] obstacles_for_queen)
        {
            int counter=0;
            // add horizontal options
            counter += obstacles_for_queen[4][1] - obstacles_for_queen[0][1] - 2; // 2 due to fact that one position take queen and one border
            // add vertical options
            counter += obstacles_for_queen[2][0] - obstacles_for_queen[6][0] - 2;
            // add l_b to r_t options
            counter += obstacles_for_queen[3][0] - obstacles_for_queen[7][0] - 2;
            // add l_t to r_b options
            counter += obstacles_for_queen[1][0] - obstacles_for_queen[5][0] - 2;

            return counter;
        }
        static int queensAttack(int n, int k, int r_q, int c_q, int[][] obstacles)
        {       
            int[][] obstacles_for_queen = method_for_obstacles(n, r_q, c_q);
            for (int i = 0; i < obstacles.Length; i++)
            {
                int rows_from_obst = obstacles[i][0];//now we get present obstacle
                int colu_from_obst = obstacles[i][1];
                if (rows_from_obst==r_q) // so present obstacle is on way of our queen horizontally
                {
                    if (colu_from_obst < c_q) // problem on way from left
                    {
                        if (obstacles_for_queen[0][0] == 0 || colu_from_obst>obstacles_for_queen[0][1])
                        {
                            obstacles_for_queen[0][0] = rows_from_obst;
                            obstacles_for_queen[0][1] = colu_from_obst; // now we chacke is there something earlier on way our queen from left
                        }                       
                    }
                    else // problem on way from right
                    {
                        if (obstacles_for_queen[4][0] == 0 || colu_from_obst < obstacles_for_queen[4][1])
                        {
                            obstacles_for_queen[4][0] = rows_from_obst;
                            obstacles_for_queen[4][1] = colu_from_obst;// now we chacke is there something earlier on way our queen from right
                        }
                    }
                }
                else if (colu_from_obst==c_q) // problem verically?
                {
                    if (rows_from_obst < r_q) // DOWN
                    {
                        if (obstacles_for_queen[6][0] == 0 || rows_from_obst > obstacles_for_queen[6][0])
                        {
                            obstacles_for_queen[6][0] = rows_from_obst;
                            obstacles_for_queen[6][1] = colu_from_obst;
                        }
                    }
                    else // UP
                    {
                        if (obstacles_for_queen[2][0] == 0|| rows_from_obst < obstacles_for_queen[2][0])
                        {
                            obstacles_for_queen[2][0] = rows_from_obst;
                            obstacles_for_queen[2][1] = colu_from_obst;
                        }
                    }
                }
                else if (rows_from_obst - r_q == colu_from_obst - c_q) // chacke Left+DOWN
                {
                    if (rows_from_obst > r_q)
                    {
                        if (obstacles_for_queen[3][0] == 0 || rows_from_obst<obstacles_for_queen[3][0])
                        {
                            obstacles_for_queen[3][0] = rows_from_obst;
                            obstacles_for_queen[3][1] = colu_from_obst;
                        }
                    }
                    else
                    {
                        if (obstacles_for_queen[7][0] == 0 || rows_from_obst> obstacles_for_queen[7][0])
                        {
                            obstacles_for_queen[7][0] = rows_from_obst;
                            obstacles_for_queen[7][1] = colu_from_obst;
                        }
                    }
                }
                else if (Math.Abs(rows_from_obst-r_q) == Math.Abs(colu_from_obst-c_q)) // LEFT+UP DIAGONAL
                {
                    if (rows_from_obst > r_q)
                    {
                        if (obstacles_for_queen[1][0] == 0 || rows_from_obst < obstacles_for_queen[1][0])
                        {
                            obstacles_for_queen[1][0] = rows_from_obst;
                            obstacles_for_queen[1][1] = colu_from_obst;
                        }
                    }
                    else
                    {
                        if (obstacles_for_queen[5][0] == 0 || obstacles_for_queen[5][0] < rows_from_obst)
                        {
                            obstacles_for_queen[5][0] = rows_from_obst;
                            obstacles_for_queen[5][1] = colu_from_obst;
                        }
                    }
                }
            }
            return count_all_possible_mouves(obstacles_for_queen);            
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
