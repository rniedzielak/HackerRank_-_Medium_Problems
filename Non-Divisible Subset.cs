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

    // Complete the nonDivisibleSubset function below.
    static int nonDivisibleSubset(int k, int[] S)
    {
        int[] Array_of_remainders = new int[k];        
        foreach (int item in S)
        {
            Array_of_remainders[item % k]++;
        }
        int zero_remainder = Array_of_remainders[0];
        int maxNumberOfDivisibleSet = zero_remainder > 0 ? 1 : 0;
        for (int i = 1; i <= (k / 2); i++)
        {
            if (i != k - i)
                maxNumberOfDivisibleSet += Math.Max(Array_of_remainders[i],                                                                         Array_of_remainders[k - i]);
            else
                maxNumberOfDivisibleSet ++;
        }
        return maxNumberOfDivisibleSet;
    }

    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        string[] nk = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(nk[0]);
        int k = Convert.ToInt32(nk[1]);
        int[] S = Array.ConvertAll(Console.ReadLine().Split(' '), STemp => Convert.ToInt32(STemp));
        int result = nonDivisibleSubset(k, S);
        textWriter.WriteLine(result);
        textWriter.Flush();
        textWriter.Close();
    }
}
