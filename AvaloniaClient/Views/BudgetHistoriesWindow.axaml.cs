using System;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using AvaloniaClient.ViewModels;

namespace AvaloniaClient.Views;
public partial class BudgetHistoriesWindow : ReactiveUserControl<RoutedBudgetHistoriesViewModel>
{
    public BudgetHistoriesWindow()
    {
        InitializeComponent();
    }
}
