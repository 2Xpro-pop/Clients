using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;
using ReactiveUI;

namespace AvaloniaClient.ViewModels;
public class MainWindowViewModel : ViewModelBase, IScreen
{

    public RoutingState Router { get; } = new();

    public ReactiveCommand<Unit, IRoutableViewModel> GoBack
    {
        get;
    }

    public ReactiveCommand<Unit, IRoutableViewModel> GoToFillials
    {
        get;
    }
    public ReactiveCommand<Unit, IRoutableViewModel> GoToHistory
    {
        get;
    }
    public ReactiveCommand<Unit, IRoutableViewModel> GoToPersonals
    {
        get;
    }
    public ReactiveCommand<Unit, IRoutableViewModel> GoToInventaries
    {
        get;
    }
    public ReactiveCommand<Unit, IRoutableViewModel> GoToPatients
    {
        get;
    }

    public MainWindowViewModel()
    {
        GoToFillials = ReactiveCommand.CreateFromObservable(
            () => Router.Navigate.Execute(new FillialsViewModel(this))
        );

        GoToHistory = ReactiveCommand.CreateFromObservable(
            () => Router.Navigate.Execute(new RoutedBudgetHistoriesViewModel(this))
        );

        GoToPersonals = ReactiveCommand.CreateFromObservable(
            () => Router.Navigate.Execute(new RoutedPersonalsViewModel(this))
        );

        GoToInventaries = ReactiveCommand.CreateFromObservable(
            () => Router.Navigate.Execute(new InventoriesViewModel(this))
        );

        GoToPatients = ReactiveCommand.CreateFromObservable(
            () => Router.Navigate.Execute(new RoutedPacientsViewModel(this))
        );

        GoBack = ReactiveCommand.CreateFromObservable(() => Router.NavigateBack.Execute());


    }
}
