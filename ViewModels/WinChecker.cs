
namespace _4_connect.ViewModels;

public class WinChecker
{
    private readonly Player[,] _board;
    private readonly int _rows = 6;
    private readonly int _columns = 7;
    private const int WinCondition = 4;

    public WinChecker(Player[,] board)
    {
        _board = board;
    }

    public bool CheckVerticalWin(int lastRow, int lastCol, Player player)
    {
        int count = 0;
        for (int row = lastRow; row < _rows; row++)
        {
            if (_board[row, lastCol] == player)
                count++;
            else
                break;

            if (count >= WinCondition)
                return true;
        }
        return false;
    }

    public bool CheckHorizontalWin(int lastRow, int lastCol, Player player)
    {
        int count = 1;

        // Check left
        int col = lastCol - 1;
        while (col >= 0 && _board[lastRow, col] == player)
        {
            count++;
            col--;
        }

        // Check right
        col = lastCol + 1;
        while (col < _columns && _board[lastRow, col] == player)
        {
            count++;
            col++;
        }

        return count >= WinCondition;
    }

    public bool CheckDiagonalRightWin(int lastRow, int lastCol, Player player)
    {
        int count = 1;

        // Check bottom-left to top-right
        int row = lastRow - 1;
        int col = lastCol + 1;
        while (row >= 0 && col < _columns && _board[row, col] == player)
        {
            count++;
            row--;
            col++;
        }

        row = lastRow + 1;
        col = lastCol - 1;
        while (row < _rows && col >= 0 && _board[row, col] == player)
        {
            count++;
            row++;
            col--;
        }

        return count >= WinCondition;
    }

    public bool CheckDiagonalLeftWin(int lastRow, int lastCol, Player player)
    {
        int count = 1;

        // Check top-left to bottom-right
        int row = lastRow - 1;
        int col = lastCol - 1;
        while (row >= 0 && col >= 0 && _board[row, col] == player)
        {
            count++;
            row--;
            col--;
        }

        row = lastRow + 1;
        col = lastCol + 1;
        while (row < _rows && col < _columns && _board[row, col] == player)
        {
            count++;
            row++;
            col++;
        }

        return count >= WinCondition;
    }

    public bool IsWin(int lastRow, int lastCol, Player player)
    {
        return CheckVerticalWin(lastRow, lastCol, player) ||
               CheckHorizontalWin(lastRow, lastCol, player) ||
               CheckDiagonalRightWin(lastRow, lastCol, player) ||
               CheckDiagonalLeftWin(lastRow, lastCol, player);
    }
}