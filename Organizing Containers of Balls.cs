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

    // Complete the organizingContainers function below.
    static string organizingContainers(int[][] container)
    {
        int n = container.Length;
        int[] a = new int[n];
        int[] b = new int[n];
        for(int i=0; i<n; i++)
        {
            for(int j=0; j<n; j++)
            {
                int x = container[i][j];
                a[i] += x;
                b[j] += x;
            }
        }
        string result = "Possible";
        for(int i=0;i<n;i++)
        {
            int j=0;
            for(j=i;j<n;j++)
            {
                if(a[i] == b[j])
                {
                    int temp = b[j];
                    b[j] = b[i];
                    b[i] = temp;
                    break;
                }
            }
            if(j==n)
            {
                result = "Impossible";
                break;
            }
        }       
        return result;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++) {
            int n = Convert.ToInt32(Console.ReadLine());

            int[][] container = new int[n][];

            for (int i = 0; i < n; i++) {
                container[i] = Array.ConvertAll(Console.ReadLine().Split(' '), containerTemp => Convert.ToInt32(containerTemp));
            }

            string result = organizingContainers(container);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
