using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _429_N_aryTreeLevelOrderTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    /*
   // Definition for a Node.*/
    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }

    public class Solution
    {
        public IList<IList<int>> LevelOrder(Node root)
        {
            if (root == null)
            {
                return new List<IList<int>>();
            }

            IList<IList<int>> result = new List<IList<int>>();
            IList<int> currentLeveList = new List<int>();
            Queue<Node> queue = new Queue<Node>();
            int needCall = 0;
            int nextNeedCall = 0;
            Node currentNode = root;

            queue.Enqueue(currentNode);
            needCall = 1;

            while (queue.Count != 0)
            {
                currentNode = queue.Dequeue();
                currentLeveList.Add(currentNode.val);
                needCall--;

                if (currentNode.children.Count != 0)
                {
                    for (int i = 0; i < currentNode.children.Count; i++)
                    {
                        queue.Enqueue(currentNode.children[i]);
                        nextNeedCall++;
                    }
                }

                if (needCall == 0)
                {
                    needCall = nextNeedCall;
                    nextNeedCall = 0;
                    result.Add(currentLeveList);
                    currentLeveList = new List<int>();
                }
            }

            return result;
        }
    }
}
