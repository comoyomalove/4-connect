using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Markup.Xaml; // Added to access AvaloniaXamlLoader
using Avalonia.Controls.Primitives; // Added to access UniformGrid
using Avalonia.Interactivity; // Added to access RoutedEventArgs
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _4_connect.ViewModels;

namespace _4_connect.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent(); // Re-enabled InitializeComponent()

        // Create and add 42 buttons to the UniformGrid
        for (int row = 0; row < 6; row++)
        {
            for (int col = 0; col < 7; col++)
            {
                var button = new Button
                {
                    Background = Brushes.White,
                    CornerRadius = new CornerRadius(20),
                    Tag = col
                };
                button.Click += Button_Click; // Correct event handler signature
                GameGrid.Children.Add(button); // Ensure GameGrid is recognized
            }
        }
    }

    private void Button_Click(object? sender, RoutedEventArgs e) // Made sender nullable
    {
        if (DataContext is MainWindowViewModel viewModel && !viewModel.IsGameOver)
        {
            if (sender is Button button && button.Tag is int column)
            {
                int row = FindLowestEmptyRow(viewModel.GameState.Board, column);
                if (row != -1)
                {
                    viewModel.GameState.Board[row, column] = viewModel.GameState.CurrentPlayer;
                    UpdateButtonColor(row, column, viewModel.GameState.CurrentPlayer);
                    viewModel.CheckForWin(row, column);

                    if (viewModel.IsGameOver)
                    {
                        ShowWinMessage(viewModel.WinMessage);
                        LockBoard();
                    }
                    else
                    {
                        viewModel.GameState.CurrentPlayer =
                            viewModel.GameState.CurrentPlayer == Player.Player1 ? Player.Player2 : Player.Player1;
                    }
                }
            }
        }
    }

    private int FindLowestEmptyRow(Player[,] board, int column)
    {
        for (int row = board.GetLength(0) - 1; row >= 0; row--)
        {
            if (board[row, column] == Player.None)
            {
                return row;
            }
        }
        return -1; // Column is full
    }

    private void UpdateButtonColor(int row, int column, Player player)
    {
        int buttonIndex = row * 7 + column;
        if (buttonIndex >= 0 && buttonIndex < GameGrid.Children.Count)
        {
            var button = GameGrid.Children[buttonIndex] as Button;
            if (button != null)
            {
                button.Background = player == Player.Player1 ? Brushes.Red : Brushes.Yellow;
            }
        }
    }

    private async void ShowWinMessage(string message)
    {
        var dialog = new Window
        {
            Title = "Game Over",
            Width = 300,
            Height = 150,
            Content = new TextBlock
            {
                Text = message,
                HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center,
                FontSize = 16
            }
        };

        await dialog.ShowDialog(this);
    }

    private void LockBoard()
    {
        foreach (var child in GameGrid.Children)
        {
            if (child is Button button)
            {
                button.IsEnabled = false;
            }
        }
    }
}