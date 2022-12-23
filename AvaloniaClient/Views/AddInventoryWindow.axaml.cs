using System;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using AvaloniaClient.ViewModels;

namespace AvaloniaClient.Views;
public partial class AddInventoryWindow : ReactiveWindow<AddInventoryViewModel>
{
    public AddInventoryWindow()
    {
        InitializeComponent();
        ViewModel = new AddInventoryViewModel(Program.MementoMori, pickOffice);

        ViewModel.Create.Subscribe(Close);
        ViewModel.Cancel.Subscribe(v => Close(null));
    }
}
