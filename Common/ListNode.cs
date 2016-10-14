using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ListNode
    {
        public int val { get; set; }

        public ListNode(int data)
        {
            this.val = data;
        }

        public ListNode next { get; set; }

    }

    public class ListNodeHelper
    {
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

        public void Display(ListNode listNode)
        {
            var temp = listNode;
            do
            {
                Console.WriteLine("{0}->", temp.val);
                temp = temp.next;
            } while (temp != null);
        }
    }

}
