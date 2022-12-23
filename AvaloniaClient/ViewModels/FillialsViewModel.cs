using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using RestSharp;
using DynamicData;
using AvaloniaClient.Views;
using Bll;
using Dal.Models;
using Bll.Dao;

namespace AvaloniaClient.ViewModels;

public class FillialsViewModel : OfficesViewModel, IRoutableViewModel
{
    public string? UrlPathSegment => Guid.NewGuid().ToString().Substring(0, 5);

    public IScreen HostScreen
    {
        get;
    }
    public FillialsViewModel(IScreen screen): base(
        Program.MementoMori, 
        () => App.OpenDialog<Office?>(new AddFillialWindow()), 
        () => App.OpenDialog<ChangeBudgetDao?>(new AddBudgetWindow())
    )
    {
        HostScreen = screen;
    }
}