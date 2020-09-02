using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _127_WordLadder
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            // verification
            if (wordList == null || wordList.Count == 0 || !wordList.Contains(endWord))
            {
                return 0;
            }

            // logic
            HashSet<string> wordHashSet = new HashSet<string>(wordList);
            if (wordHashSet.Contains(beginWord))
            {
                wordHashSet.Remove(beginWord);
            }
            HashSet<string> visited = new HashSet<string>();
            Queue<string> queue = new Queue<string>();
            int steps = 0;

            queue.Enqueue(beginWord);
            visited.Add(beginWord);
            steps++;

            while (queue.Count != 0)
            {
                int currentQueueCounts = queue.Count;
                for (int i = 0; i < currentQueueCounts; i++)
                {
                    string currentWord = queue.Dequeue();
                    int wordLength = currentWord.Length;

                    for (int j = 0; j < wordLength; j++)
                    {
                        char originChar = currentWord[j];
                        char[] wordArray = currentWord.ToCharArray();

                        for (char k = 'a'; k <= 'z'; k++)
                        {
                            wordArray[j] = k;

                            string newWord = new string(wordArray);

                            if (wordHashSet.Contains(newWord) && !visited.Contains(newWord))
                            {
                                if (endWord.Equals(newWord))
                                {
                                    return steps + 1;
                                }

                                queue.Enqueue(newWord);
                                visited.Add(newWord);
                            }
                        }

                        wordArray[j] = originChar;
                    }
                }
                steps++;
            }

            return 0;
        }
    }
}
