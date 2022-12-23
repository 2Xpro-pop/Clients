using Avalonia.Controls;
using Avalonia.ReactiveUI;
using AvaloniaClient.ViewModels;

namespace AvaloniaClient.Views;

public partial class PacientsView : ReactiveUserControl<RoutedPacientsViewModel>
{
    public PacientsView()
    {
        InitializeComponent();
    }
}
