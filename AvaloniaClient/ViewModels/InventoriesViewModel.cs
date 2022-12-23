using System;
using System.Collections.Generic;
using System.Text;
using AvaloniaClient.Views;
using Bll;
using Bll.Dao;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace AvaloniaClient.ViewModels;

public class InventoriesViewModel: InventoriesBaseVm, IRoutableViewModel
{
    public string? UrlPathSegment => Guid.NewGuid().ToString().Substring(0, 5);

    public IScreen HostScreen
    {
        get;
    }

    public InventoriesViewModel(IScreen screen) : base(
        Program.MementoMori,
        () => App.OpenDialog<InventoryDao?>(new AddInventoryWindow()),
        () => App.OpenDialog<int>(new AmountWindow())
    )
    {
        HostScreen = screen;
    }
}
