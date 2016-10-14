using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _48_RotateImage
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            Random ran = new Random();
            int[,] matrix = new int[5,5];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = ran.Next(100);
                }
            }
            solution.DisplayMatrix(matrix);
            var now = DateTime.Now;
            solution.Rotate(matrix);
            Console.WriteLine("After Rotate 90 degree (clockwise):");
            solution.DisplayMatrix(matrix);
            Console.WriteLine("Execution time :{0}ms",(DateTime.Now - now).TotalMilliseconds);
            Console.Read();

            

        }
    }

    //You are given an n x n 2D matrix representing an image.
    //Rotate the image by 90 degrees (clockwise).
    //Could you do this in-place?

    //1 2 3 4
    //5 6 7 8
    //9 10 11 12
    //13 14 15 16


    //rowCount=4
    //0,0->0,3  0,1->1,3	0,2->2,3    0,3->3,3
    //1,0->0,2	1,1->1,2	1,2->2,2;	1,3->3,2		
    //2,0->0,1	2,1->1,1	2,2->2,1;	2,3->3,1
    //3,0->0,0	3,1->1,0	3,2->2,0;	3,3->3,0

    public class Solution
    {
        //Beat 60%
        public void Rotate(int[,] matrix)
        {
            int rowCount = matrix.GetLength(0);
            int colCount = rowCount;
            for (int i = 0; i < rowCount-1; i++)
            {
                for (int j = i; j < colCount - 1; j++)
                {
                    RotateElementTo(ref matrix, matrix[i, j], i, j, i,j, matrix.GetLength(0));
                }
                colCount--;
            }
        }

        private void RotateElementTo(ref int[,] matrix, int soureElement, int i, int j, int baseX, int baseY, int rowLen)
        {
            int newX = j;
            int newY = rowLen - 1 - i;
            int destiElement = matrix[newX, newY];
            matrix[newX, newY] = soureElement;
            if (baseY == newY && newX == baseX) return;//回到起始点
            RotateElementTo(ref matrix, destiElement, newX, newY, baseX,baseY, rowLen);
        }

        public void DisplayMatrix(int[,] matrix)
        {

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j].ToString().PadRight(4, ' '));
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
