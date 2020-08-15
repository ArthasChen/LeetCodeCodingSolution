using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102_BinaryTreeLevelOrderTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    /**
 * Definition for a binary tree node. */
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Solution
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            if (root == null)
            {
                return new List<IList<int>>();
            }

            IList<IList<int>> result = new List<IList<int>>();
            IList<int> level = new List<int>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            TreeNode currentnNode = root;
            queue.Enqueue(currentnNode);
            int needCall = 1;
            int nextNeedCall = 0;

            while (queue.Count != 0)
            {
                currentnNode = queue.Dequeue();
                level.Add(currentnNode.val);
                needCall--;

                if (currentnNode.left != null)
                {
                    queue.Enqueue(currentnNode.left);
                    nextNeedCall++;
                }

                if (currentnNode.right != null)
                {
                    queue.Enqueue(currentnNode.right);
                    nextNeedCall++;
                }

                if (needCall == 0)
                {
                    needCall = nextNeedCall;
                    nextNeedCall = 0;
                    result.Add(level);
                    level = new List<int>();
                }
            }

            return result;
        }
    }
}
