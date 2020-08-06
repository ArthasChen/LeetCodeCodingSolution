using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25_ReverseNodesInK_Group
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
        }
    }

    /// <summary>
    /// 解法一
    /// 时间复杂度：O(n)
    /// 空间复杂度：O(n)
    /// </summary>
    public class Solution
    {
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            // verification
            if (head == null || k < 0)
            {
                return null;
            }

            if (k == 1)
            {
                return head;
            }

            // logic
            ListNode nextGroupHead = head;
            int groupNumbers = k;

            while (k > 0 && nextGroupHead != null)
            {
                nextGroupHead = nextGroupHead.next;
                k--;
            }

            if (k == 0)
            {
                ListNode result = ReverseKGroup(nextGroupHead, groupNumbers);

                ListNode preNode = result;
                ListNode curNode = head;
                ListNode nextNode = null;

                while (groupNumbers > 0)
                {
                    nextNode = curNode.next;
                    curNode.next = preNode;
                    preNode = curNode;
                    curNode = nextNode;

                    groupNumbers--;
                }


                return preNode;

            }
            else
            {
                // 接下来的节点数量不足K个，返回接下来的头节点。
                return head;
            }
        }
    }
}
