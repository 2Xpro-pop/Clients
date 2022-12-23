using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bll;
using Bll.Rest;
using Bll.Dao;
using Dal.Models;
using RestSharp;
using System.Reactive.Linq;

namespace MementoMoriUnitTests;
public class BllRestTest
{
    MementoMori mementoMori;
    [SetUp]
    public void Setup()
    {
        mementoMori = MementoMoriBuilder.Create(api =>
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
        });
    }

    [Test]
    public async Task AuthTest()
    {
        var uGuid = Guid.NewGuid();
        var password = "abcdefg12345";

        await mementoMori.AuthClient.CreateUserAsync($"user{uGuid}", password, "Admin", 1);

        var response = await mementoMori.AuthClient.LoginAsync($"user{uGuid}", password);

        Assert.That(response, Is.Not.Null);
    }
    [Test]
    public async Task OfficesTest()
    {
        var uGuid = Guid.NewGuid();
        var vm = new OfficesViewModel(
            mementoMori,
            async () => new Office()
            {
                Name = $"{uGuid}name",
                Address = $"{uGuid}addr",
                Budget = 1000
            },
            async () => new ChangeBudgetDao()
            {
                Amount = 2010,
                Description = $"test{uGuid}"
            });

        await vm.Add.Execute();

        vm.SelectedOffice = vm.Offices.Last();

        await vm.AddBudget.Execute();
    }
}
