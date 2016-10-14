using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace _328_OddEvenLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNodeHelper nodeHelper = new ListNodeHelper();
            Solution solution = new Solution();
            var list = new List<int>() {1, 2, 3, 4, 5};
            var node= nodeHelper.GenerateList(list);
            var sortedList = solution.OddEvenList(node);
            Console.WriteLine("Input list:{0}, OddEvenList:{1}",node,sortedList);

        }
    }
    /**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
    public class Solution
    {
        public ListNode OddEvenList(ListNode head)
        {
            ListNode sortedNode = null, left=null, right=null;

            return sortedNode;
        }
    }
}
