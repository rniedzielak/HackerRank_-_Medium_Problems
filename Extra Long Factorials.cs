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

    // Complete the extraLongFactorials function below.
    static void extraLongFactorials(int n)
    {
        int[] res = new int[500];
        res[0] = 1;
        int res_size = 1;
        for (int i = 2; i <= n; i++)
        {
            res_size = multiply(i, res, res_size);
        }
        for (int i = res_size - 1; i >= 0; i--)
        {
            Console.Write(res[i]);
        }
    }
    static int multiply(int x, int[] res, int res_size)
    {
        int carry = 0;
        for (int i = 0; i < res_size; i++)
        {
            int prod = res[i] * x + carry;
            res[i] = prod % 10;
            carry = prod / 10;

        }
        while (carry != 0)
        {
            res[res_size] = carry % 10;
            carry = carry / 10;
            res_size++;

        }
        return res_size;
    }

    static void Main(string[] args) {
        int n = Convert.ToInt32(Console.ReadLine());

        extraLongFactorials(n);
    }
}
