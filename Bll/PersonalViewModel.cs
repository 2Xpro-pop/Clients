using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using Bll.Dao;
using Bll.Rest;
using Dal.Models;
using Dal;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Bll;
public class PersonalViewModel: ReactiveObject
{
    [Reactive]
    public ObservableCollection<Personal> Personals
    {
        get; set;
    }
    [Reactive]
    public Personal? SelectedPersonal
    {
        get; set;
    }
    public ReactiveCommand<Unit, Unit> Add
    {
        get;
    }
    public ReactiveCommand<Unit, Unit> PaySalary
    {
        get;
    }

    private readonly IUnitOfWork _unitOfWork;
    private readonly IOfficeController _officeController;

    public PersonalViewModel(MementoMori mementoMori, Func<Task<Personal?>> inputPersonal)
    {
        _unitOfWork = mementoMori.UnitOfWork;
        _officeController = mementoMori.OfficeController;

        Task.Run(async () => await LoadPersonals());

        Add = ReactiveCommand.CreateFromTask(async () =>
        {
            var result = await inputPersonal();

            if (result == null)
            {
                return;
            }

            await _unitOfWork.Personals.AddAsync(result);
            await LoadPersonals();
        });

        Add.ThrownExceptions.Subscribe(exc =>
        {

        });

        PaySalary = ReactiveCommand.CreateFromTask(async () =>
        {
            await _officeController.ChangeBudget(SelectedPersonal!.BranchOfficeId, SelectedPersonal.SalaryAmount, $"{SelectedPersonal.Name} {SelectedPersonal.Surname} salary");
            await LoadPersonals();
        }, this.WhenAnyValue(vm => vm.SelectedPersonal).Select(v => v != null && v.SalaryType == 0));


    }

    public async Task UpdatePersonal(Personal personal)
    {
        await _unitOfWork.Personals.UpdateAsync(personal);
    }

    private async Task LoadPersonals()
    {
        var personals = await _unitOfWork.Personals.GetAllAsync();
        Personals = null;
        Personals = new(personals);
    }
}
