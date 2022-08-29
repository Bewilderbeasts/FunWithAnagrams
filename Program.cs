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



class Result
{

    /*
     * Complete the 'funWithAnagrams' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts STRING_ARRAY text as parameter.
     */
   
    public static List<string> funWithAnagrams(List<string> text)
    {
        if (text.Count > 1000 && text.Count < 0)
        {
            throw new Exception("Wrong input");
        }

        bool result;

        for (int x = 0; x < text.Count; x++)
        {
            for (int y = 1; y < text.Count; y++)
            {
                if (x != y)
                {                
                    result = checkIfAnagram(text, x, y);

                    if (result)
                    {
                        removeAnagram(text, y);
                    }
                }
            }      

        }
        text.Sort();
        return text;


    }

    public static void removeAnagram(List<string> text, int index)
    {
        string word = text[index];
        text.Remove(word);
    }

    public static bool checkIfAnagram(List<string> text, int x, int y)
    {
        if (text[x].Length == text[y].Length)
            {
                if (sortString(text[x]) == sortString(text[y]))
                {
                    return true;
                }
                return false;
            } 
        else 
        {
            return false;
        }
  
        
    }

    public static string sortString(string input)
    {
        char[] characts = input.ToCharArray();
        Array.Sort(characts);
        string newString = new string(characts);
        return newString;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        List<string> textnew = new List<string> { "andrzsa", "code", "anagram",  "doce","train", "trani", "lol", "aangram" };
        List<string> result = Result.funWithAnagrams(textnew);

        Console.WriteLine(String.Join("\n", result));
    }
}
