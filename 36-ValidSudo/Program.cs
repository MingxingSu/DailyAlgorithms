using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _36_ValidSudo
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();

            string[] sudo =
            {
                ".87654321", "2........", "3........", "4........", "5........", "6........", "7........","8........", "9........"
            };
            char[,] board =  new char[9,9];
            for(int i=0; i <9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    board[i, j] = sudo[i][j];
                }    
            }

            bool isValidSudo = s.IsValidSudoku_Hash(board);

            Console.WriteLine("Is Valid Sudo:"+ isValidSudo);

            Console.Read();
        }
    }

    public class Solution
    {
        //Method#1: using Array,create by myselft,    Beat 72%'s submissions
        public bool IsValidSudoku(char[,] board)
        {
            if (board == null || (board.GetLength(0) != 9 && board.GetLength(1) != 9))
                return false;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i, j] != '.')
                    {
                        bool validInRow = IsValidInRow(ref board, board[i, j], i, j);
                        bool validInCol = IsValidInColumn(ref board, board[i, j], i, j);
                        bool validInSquare = IsValidInSquare(ref board, board[i, j], i, j);
                        if (!validInRow || !validInCol || !validInSquare)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private bool IsValidInRow(ref char[,] board, char p, int pX, int pY)
        {
            for (int j = 0; j < 9; j++)
            {

                if (board[pX, j] != '.' && board[pX, j] == p)
                {
                    if (j != pY)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool IsValidInColumn(ref char[,] board, char p, int pX, int pY)
        {
            for (int i = 0; i < 9; i++)
            {
                if (board[i, pY] != '.' && board[i, pY] == p)
                {
                    if (pX != i)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool IsValidInSquare(ref char[,] board, char p, int pX, int pY)
        {
            int centerX = 0, centerY = 0;

            if (pX%3 >= 0 && pX%3 <= 2)
                centerX = 1 + 3*(pX/3);
            if (pY%3 >= 0 && pY%3 <= 2)
                centerY = 1 + 3*(pY/3);

            for (int i = centerX - 1; i <= centerX + 1; i++)
            {
                for (int j = centerY - 1; j <= centerY + 1; j++)
                {
                    if (!Compare(board, p, pX, pY, i, j)) return false;
                }
            }
            return true;
        }

        private bool Compare(char[,] board, char p, int pX, int pY, int i, int j)
        {
            if (board[i, j] != '.' && board[i, j] == p)
            {
                if (pY != j && pX != i)
                {
                    return false;
                }
            }
            return true;
        }


        //Method#2:Big operations 
        //就是每一行，从开始到最后，都是一个二进制数，比如第一行第一个是3，那么二进制数idx是1000，如果再出现3，必然生成还是1000，而此时idx的从右往左第四位必然是1，一旦进行与运算，结果就为1，于是return false
        public bool IsValidSudo_Bit(char[,] board)
        {
            int[] vSet = new int[9];
            int[] hSet = new int[9];
            int[] bckt = new int[9];
            int idx = 0;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i, j] != '.')
                    {
                        idx = 1 << (board[i, j] - '0');

                        if ((hSet[i] & idx) > 0 ||
                            (vSet[j] & idx) > 0 ||
                            (bckt[(i/3)*3 + j/3] & idx) > 0) return false;

                        hSet[i] |= idx;
                        vSet[j] |= idx;
                        bckt[(i/3)*3 + j/3] |= idx;
                    }
                }
            }
            return true;
        }

        //Method#3: HasSet:为每一个元素创建一个哈希表，
        public bool IsValidSudoku_Hash(char[,] board)
        {
            HashSet<char>[] setXX= new HashSet<char>[9];
            HashSet<char>[] setYY = new HashSet<char>[9];
            HashSet<char>[] setXY = new HashSet<char>[9];

            for (int i = 0; i < 9; i++)
            {
                setXX[i] = new HashSet<char>();
                setYY[i] = new HashSet<char>();
                setXY[i] = new HashSet<char>();
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i,j] == '.')
                    {
                        continue;
                    }
                    if (!setXX[i].Add(board[i,j]))//check duplication in row
                    {
                        return false;
                    }
                    if (!setYY[j].Add(board[i, j]))//check duplication in column
                    {
                        return false;
                    }
                    if (!setXY[(j / 3) * 3 + i / 3].Add(board[i, j]))//check duplication in square
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}

