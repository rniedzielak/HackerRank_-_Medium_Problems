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

    // Complete the encryption function below.
    static string encryption(string s)
    {
        string a = s.Replace(" ","");
        int columns = (int)Math.Ceiling(Math.Sqrt((double)a.Length));
        int rows = (int)Math.Ceiling((double)a.Length / columns);
        string[,] encrypted_text = new string[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if ((i * columns) + j >= a.Length)
                {
                    encrypted_text[i, j] = "";
                }
                else
                {
                    encrypted_text[i, j] = a[(i * columns) + j].ToString();
                }
                
            }
        }
        string result = "";
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                result += encrypted_text[j, i];
            }
            result += " ";
        }
        return result;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = encryption(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
