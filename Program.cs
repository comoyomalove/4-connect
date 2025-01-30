using Avalonia;
using Avalonia.Controls;
using Avalonia.Threading;
using System;
using Avalonia.Input;
using Avalonia.Media; // Added to access Brushes
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using Avalonia.Layout; // Added to access VerticalAlignment and HorizontalAlignment
using System.Linq; // Added to access LINQ extension methods
using Avalonia.Markup.Xaml; // Added to access XAML
using Avalonia.Controls.ApplicationLifetimes; // Added to access IClassicDesktopStyleApplicationLifetime
//using Avalonia.ReactiveUI; // Added to access ReactiveUI

namespace _4_connect;

sealed class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}
