using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace AvaloniaClient.ViewModels;

public class AddTaskViewModel: ReactiveObject
{
    [Reactive] public string RxText { get; set; }

    public AddTaskViewModel()
    {
        RxText = "Fody & RxUI ♡!";
    }
}

