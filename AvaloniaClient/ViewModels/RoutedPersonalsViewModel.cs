using System;
using System.Collections.Generic;
using System.Text;
using AvaloniaClient.Views;
using Bll;
using Dal.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace AvaloniaClient.ViewModels;

public class RoutedPersonalsViewModel: PersonalViewModel, IRoutableViewModel
{
    public string? UrlPathSegment => Guid.NewGuid().ToString().Substring(0, 5);

    public IScreen HostScreen
    {
        get;
    }
    public RoutedPersonalsViewModel(IScreen screen) : base(
        Program.MementoMori,
        () => App.OpenDialog<Personal?>(new AddPersonalWindow())
    )
    {
        HostScreen = screen;
    }
}
