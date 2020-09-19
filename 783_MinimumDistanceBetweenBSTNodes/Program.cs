using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _783_MinimumDistanceBetweenBSTNodes
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution so=new Solution();
            TreeNode t1=new TreeNode(4);
            TreeNode t2=new TreeNode(2);
            TreeNode t3=new TreeNode(6);
            t1.left = t2;
            t1.right = t3;

            so.MinDiffInBST(t1);
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
        public int MinDiffInBST(TreeNode root)
        {
            // verification
            if (root == null)
            {
                return 0;
            }

            // logic
            // 因为是二叉搜索树。因此中序遍历的结果是递增的，然后依次计算相邻的差，记录最小，返回
            int min = int.MaxValue;
            List<int> list = new List<int>();
            MidOrederSearch(root, list);

            for (int i = 0; i < list.Count - 1; i++)
            {
                min = Math.Min(min, list[i + 1] - list[i]);
            }

            return min;
        }

        private void MidOrederSearch(TreeNode root, List<int> list)
        {
            if (root == null)
            {
                return;
            }

            MidOrederSearch(root.left, list);
            list.Add(root.val);
            MidOrederSearch(root.right, list);
        }
    }
}
