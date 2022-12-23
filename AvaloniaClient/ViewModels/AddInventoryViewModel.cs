using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;
using AvaloniaClient.Views;
using Bll.Rest;
using Dal.Models;
using Dal;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Bll.Dao;
using System.Reactive.Linq;
using System.Linq;

namespace AvaloniaClient.ViewModels;

public class AddInventoryViewModel: ReactiveObject
{
    [Reactive]
    public string Name
    {
        get; set;
    }
    [Reactive]
    public int Amount
    {
        get; set;
    }
    [Reactive] public int Price { get; set; } 

    public ReactiveCommand<Unit, InventoryDao> Create
    {
        get;
    }
    public ReactiveCommand<Unit, Unit> Cancel
    {
        get;
    }

    public AddInventoryViewModel(MementoMori mementoMori, IdPickableView pickableView)
    {
        LoadOffices(mementoMori.UnitOfWork.Offices, pickableView);

        Create = ReactiveCommand.Create(() =>
        {
            return new InventoryDao()
            {
                Name = Name,
                Amount =  Amount,
                Price = Price,
                BranchOfficeId = pickableView.Id,
            };
        }, pickableView.WhenAnyValue(vm => vm.IdPickables).Select(v => v != null));

        Cancel = ReactiveCommand.Create(() =>
        {

        });
    }

    private async void LoadOffices(IRepository<Office> offices, IdPickableView pickableView)
    {
        var ids = await offices.GetAllAsync();
        pickableView.Id = ids.First().Id;
        pickableView.IdPickables = ids;
    }
}

