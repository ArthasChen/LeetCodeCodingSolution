using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1419_MinimumNumberofFrogsCroaking
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int a = s.MinNumberOfFrogs("crcoakroak");

            Console.ReadKey();
        }
    }

    /// <summary>
    /// 自己写出来的最优解法
    /// </summary>
    public class Solution
    {
        public int MinNumberOfFrogs(string croakOfFrogs)
        {
            int minNumber = 0;
            int currentIndex = 0;
            int[] listNeedArray = new int[5];
            int countC = 0;

            while (currentIndex < croakOfFrogs.Length)
            {
                if (countC == 0)
                { 
                    listNeedArray[0]++;
                }
                  
                int index = 0;
                switch (croakOfFrogs[currentIndex])
                {
                    case 'c':
                        index = 0;
                        break;
                    case 'r':
                        index = 1;
                        break;
                    case 'o':
                        index = 2;
                        break;
                    case 'a':
                        index = 3;
                        break;
                    case 'k':
                        index = 4;
                        break;
                }

                if (listNeedArray[index] != 0 || croakOfFrogs[currentIndex] == 'c')
                {
                    if (croakOfFrogs[currentIndex] == 'c')
                    {
                        countC += 1;
                         
                        if (listNeedArray[index]!=0)
                        {
                            listNeedArray[0]--;
                        }
                         
                        listNeedArray[1]++;

                        minNumber = Math.Max(minNumber, countC);

                        currentIndex++;
                        continue;
                    }

                    if (croakOfFrogs[currentIndex] == 'r')
                    { 
                        listNeedArray[1]--; 
                        listNeedArray[2]++;


                        currentIndex++;
                        continue;
                    }

                    if (croakOfFrogs[currentIndex] == 'o')
                    { 
                        listNeedArray[2]--; 
                        listNeedArray[3]++;

                        currentIndex++;
                        continue;
                    }

                    if (croakOfFrogs[currentIndex] == 'a')
                    { 
                        listNeedArray[3]--; 
                        listNeedArray[4]++;


                        currentIndex++;
                        continue;
                    }

                    if (croakOfFrogs[currentIndex] == 'k')
                    {
                        countC -= 1;
                         
                        listNeedArray[4]--;

                        currentIndex++;
                    }
                }
                else
                {
                    return -1;
                }
            } 

            for (int i = 0; i < listNeedArray.Length; i++)
            {
                if (listNeedArray[i] != 0)
                {
                    return -1;
                }
            }

            return minNumber;
        }
    }

    /// <summary>
    /// 第二个解法，当输入很大的时候，依然超时了。
    /// </summary>
    public class Solution2
    {
        public int MinNumberOfFrogs(string croakOfFrogs)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>()
            {
                {'c',0},{'r',0},{'o',0},{'a',0},{'k',0}
            };

            int minNumber = 0;
            int currentIndex = 0;
            List<char> listNeed = new List<char>();

            while (currentIndex < croakOfFrogs.Length)
            {
                // 判断应该是哪个字符
                //listNeed = Judge(dic, ref minNumber);
                if (dic['c'] == 0)
                {
                    listNeed.Add('c');
                }

                // 当前字符跟上面得出的字符进行比对
                if (listNeed.Contains(croakOfFrogs[currentIndex]) || croakOfFrogs[currentIndex] == 'c')
                {
                    if (croakOfFrogs[currentIndex] == 'c')
                    {
                        dic['c'] += 1;

                        listNeed.Remove('c');
                        listNeed.Add('r');

                        minNumber = Math.Max(minNumber, dic['c']);

                        currentIndex++;
                        continue;
                    }

                    if (croakOfFrogs[currentIndex] == 'r')
                    {
                        dic['r'] += 1;

                        listNeed.Remove('r');
                        listNeed.Add('o');

                        currentIndex++;
                        continue;
                    }

                    if (croakOfFrogs[currentIndex] == 'o')
                    {
                        dic['o'] += 1;

                        listNeed.Remove('o');
                        listNeed.Add('a');

                        currentIndex++;
                        continue;
                    }

                    if (croakOfFrogs[currentIndex] == 'a')
                    {
                        dic['a'] += 1;

                        listNeed.Remove('a');
                        listNeed.Add('k');

                        currentIndex++;
                        continue;
                    }

                    if (croakOfFrogs[currentIndex] == 'k')
                    {
                        dic['c'] -= 1;
                        dic['r'] -= 1;
                        dic['o'] -= 1;
                        dic['a'] -= 1;

                        listNeed.Remove('k');

                        currentIndex++;
                    }
                }
                else
                {
                    return -1;
                }
            }

            for (int i = 0; i < 5; i++)
            {
                if (dic.ElementAt(i).Value != 0)
                {
                    return -1;
                }
            }

            return minNumber;
        }
    }

    /// <summary>
    /// 第一个解法，因为用了哈希表，并且重复计算，超时了。
    /// </summary>
    public class Solution3
    {
        public int MinNumberOfFrogs(string croakOfFrogs)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>()
            {
                {'c',0},{'r',0},{'o',0},{'a',0},{'k',0}
            };

            int minNumber = 0;
            int currentIndex = 0;
            List<char> listNeed = new List<char>();

            while (currentIndex < croakOfFrogs.Length)
            {
                // 判断应该是哪个字符
                listNeed = Judge(dic, ref minNumber);

                // 当前字符跟上面得出的字符进行比对
                if (listNeed.Contains(croakOfFrogs[currentIndex]) || croakOfFrogs[currentIndex] == 'c')
                {
                    if (croakOfFrogs[currentIndex] == 'c')
                    {
                        dic['c'] += 1;
                        currentIndex++;
                        continue;
                    }

                    if (croakOfFrogs[currentIndex] == 'r')
                    {
                        dic['r'] += 1;
                        currentIndex++;
                        continue;
                    }

                    if (croakOfFrogs[currentIndex] == 'o')
                    {
                        dic['o'] += 1;
                        currentIndex++;
                        continue;
                    }

                    if (croakOfFrogs[currentIndex] == 'a')
                    {
                        dic['a'] += 1;
                        currentIndex++;
                        continue;
                    }

                    if (croakOfFrogs[currentIndex] == 'k')
                    {
                        dic['c'] -= 1;
                        dic['r'] -= 1;
                        dic['o'] -= 1;
                        dic['a'] -= 1;
                        currentIndex++;
                    }
                }
                else
                {
                    return -1;
                }
            }

            for (int i = 0; i < 5; i++)
            {
                if (dic.ElementAt(i).Value != 0)
                {
                    return -1;
                }
            }

            return minNumber;
        }

        private List<char> Judge(Dictionary<char, int> dic, ref int minNumber)
        {
            List<char> list = new List<char>();
            minNumber = Math.Max(minNumber, dic['c']);

            int countNeedR = dic['c'] - dic['r'];
            for (int i = 0; i < countNeedR; i++)
            {
                list.Add('r');
            }

            int countNeedO = dic['r'] - dic['o'];
            for (int i = 0; i < countNeedO; i++)
            {
                list.Add('o');
            }

            int countNeedA = dic['o'] - dic['a'];
            for (int i = 0; i < countNeedA; i++)
            {
                list.Add('a');
            }

            int countNeedK = dic['a'] - dic['k'];
            for (int i = 0; i < countNeedK; i++)
            {
                list.Add('k');
            }

            if (list.Count == 0)
            {
                list.Add('c');
            }

            return list;
        }
    }
}
