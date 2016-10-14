using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class BinaryTreeHelper
    {
        /*"{1,2,3,#,#,4,#,#,5}".
         *     1
              / \
             2   3
                /
               4
                \
                 5
         */

        public TreeNode GenerateTree(int[] list)
        {
            if (list == null || list.Length == 0)
                return null;


            TreeNode root = new TreeNode(0);
            TreeNode tempNode = root;
            for (int i = 1; i < list.Length; i += 2)
            {
                tempNode.left =  list[i] != '#' ? new TreeNode(list[i]) : null;
                tempNode.right = list[i+1] != '#' ? new TreeNode(list[i+1]): null;

                tempNode = tempNode.left;
            }

            return root;
        }
    }
}
