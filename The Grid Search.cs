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

    // Complete the gridSearch function below.
    static string gridSearch(string[] G, string[] P)
    {
        for (int i = 0; i < G.Length; i++)
        {
            bool moreMatches = true;
            int indexOf = -1;
            while (moreMatches)
            {
                indexOf = G[i].IndexOf(P[0], indexOf + 1);
                moreMatches = indexOf != -1;
                bool isContains = indexOf != -1;
                int iter = 1;
                while (isContains && iter < P.Length)
                {
                    if (G[i + iter].IndexOf(P[iter], indexOf) != indexOf)
                    {
                        isContains = false;
                    }
                    iter++;
                }
                if (isContains)
                {
                    return "YES";
                }
            }
        }
        return "NO";
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        int t = Convert.ToInt32(Console.ReadLine());
        for (int tItr = 0; tItr < t; tItr++) {
            string[] RC = Console.ReadLine().Split(' ');
            int R = Convert.ToInt32(RC[0]);
            int C = Convert.ToInt32(RC[1]);
            string[] G = new string [R];
            for (int i = 0; i < R; i++) {
                string GItem = Console.ReadLine();
                G[i] = GItem;
            }
            string[] rc = Console.ReadLine().Split(' ');
            int r = Convert.ToInt32(rc[0]);
            int c = Convert.ToInt32(rc[1]);
            string[] P = new string [r];
            for (int i = 0; i < r; i++) {
                string PItem = Console.ReadLine();
                P[i] = PItem;
            }
            string result = gridSearch(G, P);
            textWriter.WriteLine(result);
        }
        textWriter.Flush();
        textWriter.Close();
    }
}
