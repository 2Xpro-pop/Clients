using System;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using AvaloniaClient.ViewModels;

namespace AvaloniaClient.Views;
public partial class AmountWindow : ReactiveWindow<AmountViewModel>
{
    public AmountWindow()
    {
        InitializeComponent();
        ViewModel = new AmountViewModel();

        ViewModel.Apply.Subscribe(result =>
        {
            Close(result);
        });

        ViewModel.Cancel.Subscribe(unit => Close());
    }
}
