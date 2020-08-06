using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _142_LinkedListCycle2
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
    /// 同141题，用哈希表记录遍历过的节点，当遇到访问某节点后再哈希表中查到了这个节点，则这个节点为入环节点。
    /// 时间复杂度：O(n)
    /// 空间复杂度：O(n)
    /// </summary>

    /// <summary>
    /// 解法二
    /// 快慢指针，如果快指针指向的节点为null，则无环返回null。
    /// 如果快慢指针相遇，则记录相遇的节点。快指针则重新回到头节点并且每次走一步，
    /// 慢指针则继续每次一步，当两个指针再次相遇，相遇点为入环节点。
    /// 时间复杂度：O(n)
    /// 空间复杂度：O(1)
    /// </summary>
    public class Solution
    {
        public ListNode DetectCycle(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            ListNode slowNode = head;
            ListNode fastNode = head;
            ListNode meetNode = null;

            while (fastNode != null && fastNode.next != null)
            {
                fastNode = fastNode.next.next;
                slowNode = slowNode.next;

                if (fastNode == slowNode)
                {
                    meetNode = fastNode;
                    fastNode = head;
                    break;
                }
            }

            while (meetNode != null)
            {
                if (fastNode == slowNode)
                {
                    return fastNode;
                }

                fastNode = fastNode.next;
                slowNode = slowNode.next;
            }

            return null;
        }
    }
}
