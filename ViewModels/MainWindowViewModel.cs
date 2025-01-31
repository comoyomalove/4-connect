using CommunityToolkit.Mvvm.ComponentModel;

namespace _4_connect.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to Avalonia!";

    private GameState _gameState = new GameState();
    public GameState GameState
    {
        get => _gameState;
        set => SetProperty(ref _gameState, value);
    }

    private bool _isGameOver = false;
    public bool IsGameOver
    {
        get => _isGameOver;
        set => SetProperty(ref _isGameOver, value);
    }

    private string _winMessage = string.Empty;
    public string WinMessage
    {
        get => _winMessage;
        set => SetProperty(ref _winMessage, value);
    }

    // Optional: Command to reset the game
    public void ResetGame()
    {
        GameState.Reset();
        IsGameOver = false;
        WinMessage = string.Empty;
    }

    public void CheckForWin(int lastRow, int lastCol)
    {
        var winChecker = new WinChecker(GameState.Board);
        var currentPlayer = GameState.CurrentPlayer;

        if (winChecker.IsWin(lastRow, lastCol, currentPlayer))
        {
            IsGameOver = true;
            WinMessage = currentPlayer == Player.Player1 ? "Player 1 Wins!" : "Player 2 Wins!";
        }
    }
}
