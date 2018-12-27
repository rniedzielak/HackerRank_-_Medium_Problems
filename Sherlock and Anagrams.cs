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

    // Complete the sherlockAndAnagrams function below.
    static int sherlockAndAnagrams(string s)
    {
        int counter = 0;
        for (int l = 1; l <= s.Length; l++)
        {
            for (int i = 0; i <= s.Length - l - 1; i++)
            {
                char[] a1 = s.Substring(i, l).ToCharArray();
                Array.Sort(a1);
                for (int j = i + 1; j <= s.Length - l; j++)
                {
                    char[] a2 = s.Substring(j, l).ToCharArray();
                    Array.Sort(a2);
                    bool anagram = true;
                    for (int n = 0; n < a1.Length; n++)
                    {
                        if (a1[n] != a2[n])
                        {
                            anagram = false;
                            break;
                        }
                    }
                    if (anagram)
                    {
                        counter++;
                    }
                }
            }
        }
        return counter;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++) {
            string s = Console.ReadLine();

            int result = sherlockAndAnagrams(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
