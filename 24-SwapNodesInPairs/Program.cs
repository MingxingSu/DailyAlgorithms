using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24_SwapNodesInPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<string> testData0 =
            //    new List<string>() {"MCDLXXVI", "IV", "V", "VII", "XXIX", "LV", "XCIX"};

            List<int> testData =
                new List<int>() {1,2,3,4};
            
            var solution = new Solution();

            var listNodes = solution.GenerateList(testData);
            var listNodeResult = solution.SwapPairs(listNodes);

            Console.WriteLine("Input List:{0}, After Swap Pairs: {1}",
                solution.DisplayListNodes(listNodes),
                solution.DisplayListNodes(listNodeResult));
            Console.Read();
        }


        public class Solution
        {
            //Given a linked list, swap every two adjacent nodes and return its head.

            //For example,
            //Given 1->2->3->4, you should return the list as 2->1->4->3.

            //Your algorithm should use only constant space. You may not modify the values in the list, only nodes itself can be changed.
            public ListNode SwapPairs(ListNode head)
            {
                //list为空，或者只有一个节点，直接返回该链表
                if (head == null || head.next ==null)
                    return head;

                //保存递归点到临时节点
                ListNode tempNode = head.next.next;

                //Swap
                ListNode newListNode = head.next;//保存2nd节点
                newListNode.next = head;//swap:1st节点放到2nd节点后， 
                head.next = null;//截断原链，否则会无限循环，内存溢出

                //联接递归结果
                newListNode.next.next = SwapPairs(tempNode);


               return newListNode;
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
