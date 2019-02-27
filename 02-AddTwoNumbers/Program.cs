using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_AddTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {

            var l1 = new ListNode(2);
            var temp1 = new ListNode(4);
            var temp2 = new ListNode(3);
            l1.next = temp1;
            temp1.next = temp2;

            var l2 = new ListNode(5);
            var temp3 = new ListNode(6);
            var temp4 = new ListNode(4);
            l2.next = temp3;
            temp3.next = temp4;

            var sumNode = Solution.AddTwoNumbersV2(l1, l2);

            Console.WriteLine("{0}->", sumNode.val);
            Console.WriteLine("{0}->", sumNode.next.val);
            Console.WriteLine("{0}->", sumNode.next.next.val);



            var l3 = new ListNode(5);
            var l4 = new ListNode(5);

            var sumNode2 = Solution.AddTwoNumbers(l3, l4);

            Console.WriteLine("{0}", sumNode2.val);
            Console.WriteLine("{0}", sumNode2.next.val);

            var n1 = new ListNode(9);
            var n2 = new ListNode(9);
            n1.next = n2;

            var n3 = new ListNode(1);

            var sumNode3 = Solution.AddTwoNumbers(n1, n3);

            Console.WriteLine("{0}->", sumNode3.val);
            Console.WriteLine("{0}->", sumNode3.next.val);
            Console.WriteLine("{0}->", sumNode3.next.next.val);

            var t1 = new ListNode(1);
            var t2 = new ListNode(8);
            t1.next = t2;

            var t3 = new ListNode(0);

            var sumNode4 = Solution.AddTwoNumbers(t1, t3);

            Console.WriteLine("{0}->", sumNode4.val);

            Console.Read();
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
    public static class Solution
    {
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            return AddNumbeList(l1, l2, false);
        }

        private static ListNode AddNumbeList(ListNode l1, ListNode l2,bool hasSave)
        {

            if (l1 == null)
            {
                if (l2 == null)//此时为合并后的list的结尾
                {
                    if (hasSave)
                    {
                        return new ListNode(1);
                    }
                    return null;
                }
                //l2比l1长，此时看是否有进位，有进位则递归继续加下去；无进位则返回剩余节点
                if (hasSave)
                {
                    return AddNumbeList(new ListNode(1), l2, l2.val > 9);
                }
                return l2;
            }
            //l1比l2长，此时看是否有进位，有进位则递归继续加下去；无进位则返回剩余节点
            if (l2 == null)
            {
                if (hasSave)
                {
                    return AddNumbeList(l1, new ListNode(1), l1.val > 9);
                }
                return l1;
            }

            ListNode newNode;
            
            //合并节点的值
            int tempSum = hasSave ? l1.val + l2.val + 1 : l1.val + l2.val;
            newNode = new ListNode(tempSum % 10);
            newNode.next = AddNumbeList(l1.next, l2.next, (tempSum / 10) == 1);
            return newNode;
        }


		//V2 参考别人的solution写出来的
		public static ListNode AddTwoNumbersV2(ListNode l1, ListNode l2)
		{
			//始终定义一个头指针，把要返回的链表存在head.next里
			ListNode headNode = new ListNode(0);

			//用头指针来初始化变量指针。
			ListNode varNode = headNode;
			int carry = 0;

			//至少一个链表非空
			while (l1 != null || l2 != null) {

				//给缺失的节点赋值为0，这是一个常用的填坑技巧，从而抽象出一般的计算步骤，从而把循环外的IF判断转化为循环内，效率更高，更简介直观，更符合本地化原则。
				int firstVal = l1 != null ? l1.val : 0;
				int secondVal = l2 != null ? l2.val : 0;

				int sum = firstVal + secondVal + carry;

				if (sum > 9)
				{
					carry = sum / 10;
					sum -= 10;
				}
				else
					carry = 0;

				//把计算结果添加到结果链表里
				varNode.next = new ListNode(sum);
				
				//注意更新指针，否则节点之间的关系就是覆盖，而不再是联结。
				varNode = varNode.next;
				
				//更新遍历源链表的两个指针
				if (l1 != null) l1 = l1.next;
				if (l2 != null) l2 = l2.next;

			}
			//处理最后有无进位
			if (carry > 0) {
				varNode.next = new ListNode(carry);
			}

			return headNode.next;			
		}
	}

    public class ListNode
    {
        public int val { get; set; }

        public ListNode(int data)
        {
            this.val = data;
        }

        public ListNode next { get; set; }

        public void Display()
        {
            var temp = this;
            do
            {
                Console.WriteLine("{0}->", temp.val);
                temp = this.next;
            } while (temp != null);

        }
    }

    public class ListNodeFactory
    {

    }
}
