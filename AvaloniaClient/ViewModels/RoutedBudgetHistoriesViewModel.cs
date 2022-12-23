using System;
using System.Collections.Generic;
using System.Text;
using Bll;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace AvaloniaClient.ViewModels;

public class RoutedBudgetHistoriesViewModel: BudgetHistoriesViewModel, IRoutableViewModel
{
    public string? UrlPathSegment => Guid.NewGuid().ToString().Substring(0, 5);

    public IScreen HostScreen
    {
        get;
    }
    public RoutedBudgetHistoriesViewModel(IScreen screen) : base(
        Program.MementoMori
    )
    {
        HostScreen = screen;
    }
}

