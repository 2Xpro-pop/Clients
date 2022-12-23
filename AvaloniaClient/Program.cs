using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.ReactiveUI;
using AvaloniaClient.ViewModels;
using AvaloniaClient.Views;
using Bll;
using Bll.Rest;
using ReactiveUI;
using RestSharp;
using Splat;

namespace AvaloniaClient;
internal class Program
{
    public static MementoMori MementoMori { get; }

    static Program()
    {
        MementoMori = MementoMoriBuilder.Create(api =>
        {
            var oprions = new RestClientOptions()
            {
                BaseUrl = new("http://localhost:80"),
                ThrowOnAnyError = true,
            };
            api.RestClient = new RestClient(oprions);

            api.BudgetHistoryAdd = "budget/income";
            api.BudgetHistoryAll = "budget/showAll";
            api.BudgetHistoryDelete = "budget/delete";
            api.BudgetHistorySelect = "budget/show";

            api.OfficeAdd = "office/add";
            api.OfficeAll = "office/showAll";
            api.OfficeDelete = "office/delete";
            api.OfficeSelect = "office/show";
            api.OfficeUpdate = "office/update";

            api.InventoryAdd = "inventory/buy";
            api.InventoryAll = "inventory/showAll";
            api.InventorySelect = "inventory/show";

            api.PatientAdd = "patients/add";
            api.PatientAll = "patients/showAll";
            api.PatientDelete = "patients/delete";
            api.PatientSelect = "patients/show-one";
            api.PatientUpdate = "patients/update";

            api.PersonalAdd = "personal/add";
            api.PersonalAll = "personal/showAll";
            api.PersonalDelete = "personal/delete";
            api.PersonalSelect = "personal/show-one";
            api.PersonalUpdate = "personal/update";

            api.ScheduleAdd = "schedule/add";
            api.ScheduleAll = "schedule/showAll";
            api.ScheduleDelete = "schedule/delete";
            api.ScheduleSelect = "";
            api.ScheduleUpdate = "schedule/change";

            api.Login = "auth/login";
            api.CreateUser = "auth/create-user";
            api.PatientAdd = "auth/token";
            api.ChangeBudget = "office/change-to";
            api.InventoryDecrease = "inventory/decrease";
        });
    }
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
    {
        Locator.CurrentMutable.Register(() => new FillialsView(), typeof(IViewFor<FillialsViewModel>));
        Locator.CurrentMutable.Register(() => new BudgetHistoriesWindow(), typeof(IViewFor<RoutedBudgetHistoriesViewModel>));
        Locator.CurrentMutable.Register(() => new PersonalsView(), typeof(IViewFor<RoutedPersonalsViewModel>));
        Locator.CurrentMutable.Register(() => new PacientsView(), typeof(IViewFor<RoutedPacientsViewModel>));
        Locator.CurrentMutable.Register(() => new InventoriesView(), typeof(IViewFor<InventoriesViewModel>));

        return AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .LogToTrace()
            .UseReactiveUI()
            .With(new Win32PlatformOptions
            {
                UseWindowsUIComposition = true
            });
    }
}
