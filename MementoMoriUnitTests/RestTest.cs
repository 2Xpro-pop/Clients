using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dal.Models;
using Dal.Rest;
using RestSharp;

namespace MementoMoriUnitTests;
public class RestTest
{
    private IUnitOfWork _unitOfWork;
    [SetUp]
    public void Setup()
    {
        _unitOfWork = new RestUnitOfWork(new RestClient("http://localhost:80"), api =>
        {
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
        });
    }

    [Test]
    public async Task BudgetRestTest()
    {
        var uGuid = Guid.NewGuid();

        await _unitOfWork.BudgetHistories.AddAsync(new BudgetHistory()
        {
            Action = 123,
            Description = $"Unit test{uGuid}",
            BranchOfficeId = 1
        });

        var histories = await _unitOfWork.BudgetHistories.GetAllAsync();

        Assert.That(histories.Any(h => h.Description == $"Unit test{uGuid}"), Is.True);
    }
}
