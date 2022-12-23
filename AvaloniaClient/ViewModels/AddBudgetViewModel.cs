using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;
using Dal.Models;
using System.Xml.Linq;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Tmds.DBus;
using Bll.Dao;

namespace AvaloniaClient.ViewModels;

public class AddBudgetViewModel: ReactiveObject
{
    [Reactive] public double Amount { get; set; }
    [Reactive] public string Description { get; set; }

    public ReactiveCommand<Unit, ChangeBudgetDao> Create
    {
        get;
    }
    public ReactiveCommand<Unit, Unit> Cancel
    {
        get;
    }

    public AddBudgetViewModel()
    {
        Create = ReactiveCommand.CreateFromTask(async () =>
        {
            return new ChangeBudgetDao()
            {
                Amount = Amount,
                Description = Description,
            };
        });

        Cancel = ReactiveCommand.Create(() =>
        {

        });
    }
}

