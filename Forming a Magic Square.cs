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

class Solution 
{
    // Complete the formingMagicSquare function below.
    static int formingMagicSquare(int[][] s)
    {
        int result = 0;
        List<int> sums = new List<int>();
        int[][][] all_magic_squares = //All posibilities
        {
            new int[3][]                 //1. First one
            {
                new int[] { 8, 1, 6 },
                new int[] { 3, 5, 7 },
                new int[] { 4, 9, 2 }
            },
            new int[3][]                 //2.  Second one
            {
                new int[] { 6, 1, 8 },
                new int[] { 7, 5, 3 },
                new int[] { 2, 9, 4 }
            },
            new int[3][]                 //3.  Third one
            {
                new int[] { 4, 9, 2 },
                new int[] { 3, 5, 7 },
                new int[] { 8, 1, 6 }
            },
            new int[3][]                 //4.  Fourth one
            {
                new int[] { 2, 9, 4 },
                new int[] { 7, 5, 3 },
                new int[] { 6, 1, 8 }
            },
            new int[3][]                 //5. 
            {
                new int[] { 8, 3, 4 },
                new int[] { 1, 5, 9 },
                new int[] { 6, 7, 2 }
            },
            new int[3][]                 //6.
            {
                new int[] { 4, 3, 8 },
                new int[] { 9, 5, 1 },
                new int[] { 2, 7, 6 }
            },
            new int[3][]                 //7.
            {
                new int[] { 6, 7, 2 },
                new int[] { 1, 5, 9 },
                new int[] { 8, 3, 4 }
            },
            new int[3][]                 //8.
            {
                new int[] { 2, 7, 6 },
                new int[] { 9, 5, 1 },
                new int[] { 4, 3, 8 }
            }
        };          
        bool question = false;
        foreach (var item in all_magic_squares)
        {
            if (item == s)
            {
                question = true;
            }
            else
            {
                question = false;
            }
        }
        if (question == true)
        {
            return result;
        }
        else if (question == false)
        {
            for (int k = 0; k < 8; k++)
            {
                int sum = 0;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        sum += Math.Abs(all_magic_squares[k][i][j] - s[i][j]);
                        if (i==2 && j==2)
                        {
                            sums.Add(sum);
                        }
                    }
                }
            }
            return sums.Min();                
        }
        else
        {
            Console.WriteLine("Not proper square.");
            return -1;
        }
    }
    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int[][] s = new int[3][];

        for (int i = 0; i < 3; i++) {
            s[i] = Array.ConvertAll(Console.ReadLine().Split(' '), sTemp => Convert.ToInt32(sTemp));
        }

        int result = formingMagicSquare(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
