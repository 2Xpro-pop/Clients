using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace AvaloniaClient.ViewModels;
public class AmountViewModel : ViewModelBase
{
    [Reactive] public string Label { get; set; } = "Amount";
    [Reactive] public int Amount { get; set; }

    public ReactiveCommand<Unit, int?> Apply { get; }
    public ReactiveCommand<Unit, Unit> Cancel { get; }

    public AmountViewModel()
    {
        Apply = ReactiveCommand.Create(() =>
        {
            int? amount = Amount;
            return amount;
        });

        Cancel = ReactiveCommand.Create(() =>
        {

        });
    }
}
