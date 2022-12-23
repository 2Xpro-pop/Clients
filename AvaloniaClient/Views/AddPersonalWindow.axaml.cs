using System;
using System.Reactive.Linq;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using AvaloniaClient.ViewModels;
using ReactiveUI;

namespace AvaloniaClient.Views;
public partial class AddPersonalWindow : ReactiveWindow<AddPersonalViewModel>
{
    public AddPersonalWindow()
    {
        InitializeComponent();
        ViewModel = new AddPersonalViewModel(Program.MementoMori, pickOffice);

        ViewModel.Create.Subscribe(Close);
        ViewModel.Cancel.Subscribe(v => Close(null));
    }


}
