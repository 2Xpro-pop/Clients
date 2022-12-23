using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaloniaClient.ViewModels;
using AvaloniaClient.Views;

namespace AvaloniaClient;
public partial class App : Application
{
    public static App Current
    {
        get; private set;
    }

    public static async Task<T> OpenDialog<T>(Window window)
    {
        return await window.ShowDialog<T>(Current.MainWindow);
    }

    public Window MainWindow
    {
        get; set;
    }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        Current = this;
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new LoginWindow();
            MainWindow = desktop.MainWindow;
        }
        base.OnFrameworkInitializationCompleted();
    }
}