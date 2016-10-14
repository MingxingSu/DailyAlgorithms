using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_RemoveNthNodeFromEndofList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<string> testData0 =
            //    new List<string>() {"MCDLXXVI", "IV", "V", "VII", "XXIX", "LV", "XCIX"};

            List<int> testData =
                new List<int>() { 50, 90, 1476, 4, 5, 7, 29, 55, 99 };

            testData =
                new List<int>() { 1,2};

            var solution = new Solution();
            int n = 2;
            var listNodes = solution.GenerateList(testData);
            var listNodeResult = solution.RemoveNthFromEnd(listNodes, n);

            Console.WriteLine("Input List:{0}, After Remove the {1}th from the end : {2}",
                solution.DisplayListNodes(listNodes),
                n, 
                solution.DisplayListNodes(listNodeResult));
            Console.Read();
        }

        

         
        public class Solution
        {
            //Given a linked list, remove the nth node from the end of list and return its head.

            //For example,

            //   Given linked list: 1->2->3->4->5, and n = 2.

            //   After removing the second node from the end, the linked list becomes 1->2->3->5.
            //Note:
            //Given n will always be valid.
            //Try to do this in one pass.
            public ListNode RemoveNthFromEnd(ListNode head, int n)
            {
                //添加一个头指针好处多多
                ListNode tempHead = new ListNode(0),fastNode = tempHead,slowNode = tempHead;
                tempHead.next = head;

                for (int i = 0; i < n; i++) fastNode = fastNode.next;

                while (fastNode.next != null)
                {
                    fastNode = fastNode.next;
                    slowNode = slowNode.next;
                }

                //删除节点
                if (slowNode.next != null)slowNode.next = slowNode.next.next;

                return tempHead.next;
            }

            public ListNode GenerateList(List<int> list)
            {
                if (list == null || list.Count == 0)
                    return null;

                ListNode resultList = new ListNode(list[0]);
                ListNode temp = resultList;
                for (int i = 0; i < list.Count; i++)
                {
                    var node = new ListNode(list[i]);

                    temp.next = node;
                    temp = temp.next;
                }

                return resultList.next;
            }

            public string DisplayListNodes(ListNode listNode)
            {
                if (listNode == null)
                    return "";

                string nodesStr = "";
                while (listNode != null)
                {
                    nodesStr += "->" + listNode.val;

                    listNode = listNode.next;
                }

                return nodesStr;
            }
        }

        //Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }



    }
}
