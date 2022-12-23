using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bll;
using Bll.Rest;
using ReactiveUI;

namespace AvaloniaClient.ViewModels;
public class RoutedPacientsViewModel : PatientsViewModel, IRoutableViewModel
{
    public RoutedPacientsViewModel(IScreen screen) : base(Program.MementoMori)
    {
        HostScreen = screen;
    }

    public string? UrlPathSegment => "SDDS";

    public IScreen HostScreen { get; }
}
