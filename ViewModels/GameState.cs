
using CommunityToolkit.Mvvm.ComponentModel;

namespace _4_connect.ViewModels;

public enum Player
{
    None,
    Player1,
    Player2
}

public class GameState : ObservableObject
{
    private Player[,] _board = new Player[6, 7];
    public Player[,] Board
    {
        get => _board;
        set => SetProperty(ref _board, value);
    }

    private Player _currentPlayer = Player.Player1;
    public Player CurrentPlayer
    {
        get => _currentPlayer;
        set => SetProperty(ref _currentPlayer, value);
    }

    // Optional: Method to reset the game
    public void Reset()
    {
        _board = new Player[6, 7];
        CurrentPlayer = Player.Player1;
        OnPropertyChanged(nameof(Board));
        OnPropertyChanged(nameof(CurrentPlayer));
    }
}