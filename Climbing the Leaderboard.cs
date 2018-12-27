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

    // Complete the climbingLeaderboard function below.
    static int[] climbingLeaderboard(int[] scores, int[] alice)
    {
        var results = new int[alice.Length];
        var map = new List<int>(scores).Distinct().ToList();
        for (var i = 0; i < alice.Length; i++)
        {
            var aliceScore = alice[i];
            var currentRank = -1;
            var min = 0;
            var max = map.Count - 1;
            while (min <= max)
            {
                if (aliceScore < map[max])
                {
                    currentRank = max + 2;
                    break;
                }
                if (aliceScore > map[min])
                {
                    currentRank = 1;
                    break;
                }
                int mid = (min + max) / 2;
                if (aliceScore == map[mid])
                {
                    currentRank = mid + 1;
                    break;
                }
                else if (aliceScore < map[mid])
                {
                    if (aliceScore > map[mid + 1])
                    {
                        currentRank = mid + 2;
                        break;
                    }
                    min = mid + 1;
                }
                else
                {
                    max = mid - 1;
                }
            }
            results[i] = currentRank;
        }

        return results;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int scoresCount = Convert.ToInt32(Console.ReadLine());

        int[] scores = Array.ConvertAll(Console.ReadLine().Split(' '), scoresTemp => Convert.ToInt32(scoresTemp))
        ;
        int aliceCount = Convert.ToInt32(Console.ReadLine());

        int[] alice = Array.ConvertAll(Console.ReadLine().Split(' '), aliceTemp => Convert.ToInt32(aliceTemp))
        ;
        int[] result = climbingLeaderboard(scores, alice);

        textWriter.WriteLine(string.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
