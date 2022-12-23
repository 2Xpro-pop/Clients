using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Bll.Dao;
using Bll.Rest;
using Dal;
using Dal.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Bll;
public class OfficesViewModel: ReactiveObject
{
    [Reactive]
    public ObservableCollection<Office> Offices
    {
        get; set;
    }
    [Reactive]
    public Office? SelectedOffice { get; set; }
    public ReactiveCommand<Unit, Unit> Add
    {
        get;
    }
    public ReactiveCommand<Unit, Unit> AddBudget
    {
        get;
    }

    private readonly IUnitOfWork _unitOfWork;
    private readonly IOfficeController _officeController;

    public OfficesViewModel(MementoMori mementoMori, Func<Task<Office?>> inputOffice, Func<Task<ChangeBudgetDao?>> inputAmount)
    {
        _unitOfWork = mementoMori.UnitOfWork;
        _officeController = mementoMori.OfficeController;

        Task.Run(async () => await LoadOffices());

        Add = ReactiveCommand.CreateFromTask(async () =>
        {
            var result = await inputOffice();

            if (result == null)
            {
                return;
            }

            await _unitOfWork.Offices.AddAsync(result);
            await LoadOffices();
        });

        Add.ThrownExceptions.Subscribe(exc =>
        {

        });

        AddBudget = ReactiveCommand.CreateFromTask(async () =>
        {
            var result = await inputAmount();

            if (result == null)
            {
                return;
            }

            await _officeController.ChangeBudget(SelectedOffice!.Id, result.Amount, result.Description);
            await LoadOffices();
        }, this.WhenAnyValue(vm => vm.SelectedOffice).Select(v => v != null));


    }

    public async Task UpdateOffice(Office office)
    {
        await _unitOfWork.Offices.UpdateAsync(office);
    }

    private async Task LoadOffices()
    {
        Offices = null;
        Offices = new(await _unitOfWork.Offices.GetAllAsync());
    }
}
