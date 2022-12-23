using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using AvaloniaClient.Views;
using Bll.Rest;
using Dal;
using Dal.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace AvaloniaClient.ViewModels;

public class AddPersonalViewModel: ReactiveObject
{
    [Reactive]
    public string Name
    {
        get; set;
    }
    [Reactive]
    public string Surname
    {
        get; set;
    }
    [Reactive]
    public double Salary
    {
        get; set;
    }
    [Reactive]
    public bool IsProcent
    {
        get; set;
    }
    [Reactive] public int Procent { get; set; } = 7;

    [Reactive] public int SelectedId { get; set; } = 0;

    public ReactiveCommand<Unit, Personal> Create
    {
        get;
    }
    public ReactiveCommand<Unit, Unit> Cancel
    {
        get;
    }

    public AddPersonalViewModel(MementoMori mementoMori, IdPickableView pickableView)
    {
        LoadOffices(mementoMori.UnitOfWork.Offices, pickableView);

        Create = ReactiveCommand.Create(() =>
        {
            return new Personal()
            {
                Name = Name,
                Surname = Surname,
                SalaryAmount = Salary,
                SalaryType = IsProcent ? 1 : 0,
                SalaryPercent = Procent,
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

