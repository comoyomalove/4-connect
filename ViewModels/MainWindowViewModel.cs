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

    // Optional: Command to reset the game
    public void ResetGame()
    {
        GameState.Reset();
    }
}
