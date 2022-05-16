using System;

namespace Remove_All_Occurrences_of_a_Substring_._1910_
{
    class Program
    {
        static void Main(string[] args)
        {
            // https://leetcode.com/problems/remove-all-occurrences-of-a-substring/
            //1910. Remove All Occurrences of a Substring

            //Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

            //>Find the leftmost occurrence of the substring part and remove it from s.

            //Return s after removing all occurrences of part.

            //A substring is a contiguous sequence of characters in a string.

            //Input for example 2:
            //string s = "axxxxyyyyb";
            //string part = "xy";


            //Example 1

            string s = "daabcbaabcbc";
            string part = "abc";
            string result = RemoveOccurrences(s, part);
            Console.WriteLine(result);
        }
        public static string RemoveOccurrences(string s, string part)
        {
            string sWithoutPart = string.Empty;
            while (s.Contains(part))
            {
                int indexCounter = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    int equalCharCounter = 0;
                    for (int j = 0; j < part.Length; j++)
                    {
                        if (i + j >= s.Length - 1 && equalCharCounter < 2 && s[i + j] != part[j])
                        {
                            int startIndex = i - indexCounter;
                            for (int k = 0; k < j + 1 + indexCounter; k++)
                            {
                                sWithoutPart = sWithoutPart + (s[startIndex + k]);
                            }
                            i = s.Length;
                            j = part.Length;
                        }
                        else if (s[i + j] == part[j])
                        {
                            equalCharCounter++;
                        }
                    }
                    if (equalCharCounter == part.Length)
                    {
                        if (indexCounter > 0)
                        {
                            int startIndex = i - indexCounter;
                            for (int j = 0; j < indexCounter; j++)
                            {
                                sWithoutPart = sWithoutPart + (s[startIndex + j]);
                            }
                        }
                        i = i + part.Length - 1;
                        indexCounter = 0;
                        continue;
                    }
                    else if (indexCounter == part.Length - 1 && i < s.Length)
                    {
                        int startIndex = i - indexCounter;
                        for (int j = 0; j < part.Length; j++)
                        {
                            sWithoutPart = sWithoutPart + (s[startIndex + j]);
                        }
                        indexCounter = 0;
                        continue;
                    }
                    indexCounter++;
                }
                s = sWithoutPart.ToString();
                sWithoutPart = string.Empty;
            }
            return s;
        }
    }
}
