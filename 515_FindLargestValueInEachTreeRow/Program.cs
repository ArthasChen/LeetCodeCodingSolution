using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _515_FindLargestValueInEachTreeRow
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    /**
    Definition for a binary tree node.*/
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    /// <summary>
    /// 层序遍历 记录每层最大值
    /// 时间复杂度：O(n) 每个节点都会访问一次
    /// 空间复杂度：O(n) 队列存储两层的内容，最多不超过n
    /// </summary>
    public class Solution
    {
        public IList<int> LargestValues(TreeNode root)
        {
            // verification
            if (root == null)
            {
                return new List<int>();
            }

            // level traverse , find max in level, restore
            Queue<TreeNode> queue = new Queue<TreeNode>();
            TreeNode currenTreeNode = root;
            queue.Enqueue(currenTreeNode);

            IList<int> result = new List<int>();

            int needCall = 1;
            int nextNeedCall = 0;
            int currentLevelMax = int.MinValue;

            while (queue.Count != 0)
            {
                currenTreeNode = queue.Dequeue();
                currentLevelMax = Math.Max(currentLevelMax, currenTreeNode.val);
                needCall--;

                if (currenTreeNode.left != null)
                {
                    queue.Enqueue(currenTreeNode.left);
                    nextNeedCall++;
                }

                if (currenTreeNode.right != null)
                {
                    queue.Enqueue(currenTreeNode.right);
                    nextNeedCall++;
                }

                if (needCall == 0)
                {
                    needCall = nextNeedCall;
                    nextNeedCall = 0;
                    result.Add(currentLevelMax);
                    currentLevelMax = int.MinValue;
                }
            }

            return result;
        }
    }

}
