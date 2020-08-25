using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_LetterCombinationsOfAPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        Dictionary<char, string> dic = new Dictionary<char, string>()
        {
            ['2'] = "abc",
            ['3'] = "def",
            ['4'] = "ghi",
            ['5'] = "jkl",
            ['6'] = "mno",
            ['7'] = "pqrs",
            ['8'] = "tuv",
            ['9'] = "wxyz",
        };

        IList<string> result = new List<string>();


        public IList<string> LetterCombinations(string digits)
        {
            // verification
            if (string.IsNullOrEmpty(digits) || digits.Contains('1'))
            {
                return result;
            }

            // logic
            DFS(0, digits, new StringBuilder());

            return result;
        }

        public void DFS(int currentIndex, string digits, StringBuilder currentStr)
        {
            // end condition
            if (currentIndex >= digits.Length)
            {
                result.Add(currentStr.ToString());
                return;
            }

            // current level logic
            char currentChar = digits[currentIndex];

            for (int i = 0; i < dic[currentChar].Length; i++)
            {
                currentStr.Append(dic[currentChar][i]);

                // drill down
                DFS(currentIndex + 1, digits, currentStr);

                // reverse
                currentStr.Remove(currentIndex, 1);
            }
        }
    }
}
