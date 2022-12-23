using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using Bll.Rest;
using Dal.Models;
using System.Reactive.Linq;
using Dal;
using ReactiveUI.Fody.Helpers;
using ReactiveUI;
using Bll.Dao;

namespace Bll;
public class InventoriesBaseVm : ReactiveObject
{
    [Reactive]
    public ObservableCollection<Inventory> Inventories
    {
        get; set;
    }
    [Reactive]
    public Inventory? SelectedInventory
    {
        get; set;
    }
    public ReactiveCommand<Unit, Unit> Buy
    {
        get;
    }
    public ReactiveCommand<Unit, Unit> Change
    {
        get;
    }

    private readonly IUnitOfWork _unitOfWork;
    private readonly IOfficeController _officeController;

    public InventoriesBaseVm(MementoMori mementoMori, Func<Task<InventoryDao?>> inputInventory, Func<Task<int>> amount)
    {
        _unitOfWork = mementoMori.UnitOfWork;
        _officeController = mementoMori.OfficeController;

        Task.Run(async () => await LoadInventories());

        Buy = ReactiveCommand.CreateFromTask(async () =>
        {
            var result = await inputInventory();

            if (result == null)
            {
                return;
            }

            await _unitOfWork.Invenotries.AddAsync(result);
            await _officeController.ChangeBudget(result.BranchOfficeId, -result.Amount * result.Price, $"Bought {result.Name} {result.Amount}");

            await LoadInventories();
        });

        Buy.ThrownExceptions.Subscribe(exc =>
        {

        });

        Change = ReactiveCommand.CreateFromTask(async () =>
        {
            await mementoMori.InventoryController.DecreaseAsync(SelectedInventory!, await amount());
            await LoadInventories();
        }, this.WhenAnyValue(vm => vm.SelectedInventory).Select(v => v != null));


    }

    public async Task UpdateInventory(Inventory inventory)
    {
        await _unitOfWork.Invenotries.UpdateAsync(inventory);
    }

    private async Task LoadInventories()
    {
        var inventories = await _unitOfWork.Invenotries.GetAllAsync();
        Inventories = null;
        Inventories = new(inventories);
    }
}
