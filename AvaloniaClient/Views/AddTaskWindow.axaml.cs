using System;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using AvaloniaClient.ViewModels;

namespace AvaloniaClient.Views;
public partial class AddTaskWindow : ReactiveWindow<AddTaskViewModel>
{
    public AddTaskWindow()
    {
        InitializeComponent();
        ViewModel = new AddTaskViewModel();
    }
}
