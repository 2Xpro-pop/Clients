using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;
using Dal.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using RestSharp;

namespace AvaloniaClient.ViewModels;

public class AddFillialViewModel: ReactiveObject
{
    [Reactive] public string Name { get; set; }
    [Reactive] public string Address { get; set; }

    public ReactiveCommand<Unit, Office> Create 
    {
        get;
    }
    public ReactiveCommand<Unit, Unit> Cancel
    {
        get;
    }

    public AddFillialViewModel()
    {
        Create = ReactiveCommand.CreateFromTask(async () =>
        {
            return new Office()
            {
                Name = Name,
                Address = Address,
                Budget = 0,
            };
        });

        Cancel = ReactiveCommand.Create(() =>
        {

        });
    }
}

