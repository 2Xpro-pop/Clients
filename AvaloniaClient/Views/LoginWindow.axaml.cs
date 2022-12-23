using Avalonia.Controls;
using Avalonia.ReactiveUI;
using System.Reactive;
using System.Reactive.Linq;
using Bll;
using System;
using AvaloniaClient.ViewModels;

namespace AvaloniaClient.Views;
public partial class LoginWindow : ReactiveWindow<LoginViewModel>
{
    public LoginWindow()
    {
        InitializeComponent();
        ViewModel = new LoginViewModel(Program.MementoMori.AuthClient);

        ViewModel.LoginCommand.Subscribe(result =>
        {
            if (result)
            {
                Close();
                App.Current.MainWindow = new MainWindow()
                {
                    DataContext = new MainWindowViewModel()
                };
                App.Current.Run(App.Current.MainWindow);

            }
        });
    }
}
