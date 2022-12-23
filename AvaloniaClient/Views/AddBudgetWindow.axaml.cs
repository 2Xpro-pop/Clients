using System;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using AvaloniaClient.ViewModels;

namespace AvaloniaClient.Views;
public partial class AddBudgetWindow : ReactiveWindow<AddBudgetViewModel>
{
    public AddBudgetWindow()
    {
        InitializeComponent();
        ViewModel = new AddBudgetViewModel();

        ViewModel.Create.Subscribe(result => Close(result));

        ViewModel.Create.ThrownExceptions.Subscribe(exc => Close(null));

        ViewModel.Cancel.Subscribe(_ =>
        {
            Close(null);
        });
    }
}
