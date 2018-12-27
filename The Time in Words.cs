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

    // Complete the timeInWords function below.
    static string timeInWords(int h, int m) 
    {
        string result ="";
        string[] hours = {"one", "two","three","four","five","six","seven","eight", "nine","ten","eleven","twelve"};
        string[] minutes= {
        "zero", 
        "one",
        "two",
        "three",
        "four",
        "five",
        "six",
        "seven",
        "eight",
        "nine",
        "ten",
        "eleven",
        "twelve",
        "thirteen",
        "fourteen",
        "fifteen",
        "sixteen",
        "seventeen",
        "eighteen",
        "nineteen",
        "twenty",
        "twenty one",
        "twenty two",
        "twenty three",
        "twenty four",
        "twenty five",
        "twenty six",
        "twenty seven",
        "twenty eight",
        "twenty nine"};
        if(m==0)
        {
            result = String.Format("{0} o' clock", hours[h-1]);
            return result;
        }
        else
        {
            if(m<=30)
            {
                if(m==1)
                {
                    result = String.Format("one minute past {0}", hours[h-1]);
                    return result;
                }
                else if(m>1 && m<15)
                {
                    result = String.Format("{0} minutes past {1}",minutes[m], hours[h-1]);
                    return result;
                }
                else if(m==15)
                {
                    result = String.Format("quarter past {0}", hours[h-1]);
                    return result;
                }
                else if (m>15 && m<30)
                {
                    result = String.Format("{0} minutes past {1}",minutes[m], hours[h-1]);
                    return result;
                }
                else if (m==30)
                {
                    result = String.Format("half past {0}", hours[h-1]);
                    return result;
                }

            }
            if(m>30)
            {
                if(m < 45)
                {
                    result = String.Format("{0} minutes to {1}",minutes[60-m], hours[h]);
                    return result;
                }
                else if(m == 45)
                {
                    result = String.Format("quarter to {0}", hours[h]);
                    return result;
                }
                else if(m > 45)
                {
                    result = String.Format("{0} minutes to {1}",minutes[60-m], hours[h]);
                    return result;
                }               
            }
            return "something went wrong";
        }


    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int h = Convert.ToInt32(Console.ReadLine());

        int m = Convert.ToInt32(Console.ReadLine());

        string result = timeInWords(h, m);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
