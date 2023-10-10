using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3_tic_tac_toe
{
    internal class TTTgame
    {
        public int[,] board = new int[3, 3];
        public int CheckWinner()
        {
            for (int i = 0;board.GetLength(0) > i; i++)
            {
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2] && board[i, 0] != 0)
                {
                    return board[i, 0];
                }
                else if (board[0, i] == board[1, i] && board[1, i] == board[2, i] && board[0, i] != 0)
                {
                    return board[0, i];
                }
            }
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] != 0)
            {
                return board[0, 0];
            }
            else if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[0, 2] != 0)
            {
                return board[0, 2];
            }
            else
            {
                return 0;
            }
        }
        public bool IsBoardFull()
        {
            for (int i = 0; board.GetLength(0) > i; i++)
            {
                for (int j = 0; board.GetLength(1) > j; j++)
                {
                    if (board[i, j] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool IsCellEmpty(int x, int y)
        {
            if (board[x, y] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void SetCell(int x, int y, int value)
        {
            board[x, y] = value;
        }
        public void ClearBoard()
        {
            for (int i = 0; board.GetLength(0) > i; i++)
            {
                for (int j = 0; board.GetLength(1) > j; j++)
                {
                    board[i, j] = 0;
                }
            }
        }
    }
}
