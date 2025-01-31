using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Markup.Xaml; // Added to access AvaloniaXamlLoader
using Avalonia.Interactivity; // Added to access RoutedEventArgs
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _4_connect.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent(); // Ensure InitializeComponent is recognized

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

    private void Button_Click(object sender, RoutedEventArgs e) // Corrected signature
    {
        // Handle button click event
        if (sender is Button button && button.Tag is int column)
        {
            // Example action: Change button color to red when clicked
            button.Background = Brushes.Red;
            // Add your game logic here
        }
    }
}