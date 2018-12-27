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

    // Complete the countTriplets function below.
    static long countTriplets(List<long> arr, long r)
    {
        var dictionary1 = new Dictionary<long, long>();
        var dictionary2 = new Dictionary<long, long>();
        long result = 0;
        foreach (long value in arr)
        {
            if (dictionary2.ContainsKey(value))
            {
                result += dictionary2[value];
            }                
            if (dictionary1.ContainsKey(value))
            {
                if (dictionary2.ContainsKey(value * r))
                {
                    dictionary2[value * r] += dictionary1[value];
                }
                else
                {
                    dictionary2[value * r] = dictionary1[value];
                }
            }                   
            if (dictionary1.ContainsKey(value * r))
            {
                dictionary1[value * r] = dictionary1[value * r] + 1;
            }
            else
            {
                dictionary1[value * r] = 1;
            }                
        }
        return result;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nr = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(nr[0]);

        long r = Convert.ToInt64(nr[1]);

        List<long> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt64(arrTemp)).ToList();

        long ans = countTriplets(arr, r);

        textWriter.WriteLine(ans);

        textWriter.Flush();
        textWriter.Close();
    }
}
