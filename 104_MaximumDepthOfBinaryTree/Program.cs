using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _104_MaximumDepthOfBinaryTree
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

    /// <summary>
    /// 解法一
    /// 递归
    /// 时间复杂度：O(n) 树的每个子节点都访问了一次，因此是O(n)
    /// 空间复杂度：O(height) 递归函数需要栈空间，而栈空间取决于递归的深度，因此空间复杂度等价于二叉树的高度。
    /// </summary>
    public class Solution
    {
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int leftMaxDepth = MaxDepth(root.left);
            int rightMaxDepth = MaxDepth(root.right);

            return Math.Max(leftMaxDepth, rightMaxDepth) + 1;
        }
    }

    /// <summary>
    /// 解法二
    /// 广度优先遍历，层序遍历，记录有几层
    /// 时间复杂度：O(n) 树的每个子节点都访问了一次，因此是O(n)
    /// 空间复杂度：O(n) 此方法空间的消耗取决于队列存储的元素数量，其在最坏情况下会达到O(n)。
    /// </summary>
    public class Solution2
    {
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            Queue<TreeNode> queue = new Queue<TreeNode>();
            int needCall = 0;
            int nextNeedCall = 0;
            int maxDepth = 0;
            TreeNode currentNode = root;

            queue.Enqueue(currentNode);
            needCall++;

            while (queue.Count != 0)
            {
                currentNode = queue.Dequeue();
                needCall--;

                if (currentNode.left != null)
                {
                    queue.Enqueue(currentNode.left);
                    nextNeedCall++;
                }

                if (currentNode.right != null)
                {
                    queue.Enqueue(currentNode.right);
                    nextNeedCall++;
                }

                if (needCall == 0)
                {
                    needCall = nextNeedCall;
                    nextNeedCall = 0;
                    maxDepth++;
                }
            }

            return maxDepth;
        }
    }
}
